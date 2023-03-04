#nullable enable

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Windows.Forms;

using uom.Extensions;

using static System.Net.Mime.MediaTypeNames;

namespace WS
{

	internal class xPageview : UserControl
	{
		private class DISPLAY_IMAGE
		{
			public System.Drawing.Image? @Image { get; private set; }
			/// <summary>Image rect on paper in Centimeters</summary>
			public RectangleF ImageRectCm = new(0f, 0f, 0f, 0f);
			public DISPLAY_IMAGE(System.Drawing.Image img, RectangleF rectCm)
			{
				@Image = img;
				ImageRectCm = rectCm;
			}

			~DISPLAY_IMAGE()
			{
				@Image?.Dispose();
				@Image = null;
			}
		}


		private const int C_MIN_VISIBLE_PAGE_SIZE = 20;
		private int BORDER_SIZE = 30;
		//private float SHADOW_SIZE_PERCENT = 2f;

		private Brush BRUSH_SHADOW = SystemBrushes.ButtonShadow;
		private Brush BRUSH_PAGE = Brushes.White;
		private Brush RULLER_COLOR_BACK = Brushes.Khaki;
		private Pen RULLER_COLOR = Pens.SlateGray;


		public static readonly RectangleF PAPER_CROP_ZERRO = new(0f, 0f, 0f, 0f);

		private SizeF _paperSize = new(10f, 15f);
		private int _rullerOffset = 4;
		private int _rullerSize = 10;
		private float _zoom = 0f;

		private Rectangle _rcPageOnScreenPx = new(0, 0, 0, 0); // Страница на экране
		private RectangleF? _paperCropCm = null;

		private DISPLAY_IMAGE? backImage = null;
		private DISPLAY_IMAGE? frontImage = null;


		public class DrawPageEventArgs : EventArgs
		{
			public SizeF PaperSizeCm;
			public RectangleF PaperOnScreenPx;
			public float Zoom;
			public Graphics @Graphics;
			public DrawPageEventArgs(SizeF paperSize, RectangleF screenRect, float zoom, Graphics graphics) : base()
			{
				PaperSizeCm = paperSize;
				PaperOnScreenPx = screenRect;
				Zoom = zoom;
				@Graphics = graphics;
			}
		}
		public event EventHandler<DrawPageEventArgs> OnDrawPage = delegate { };


		public event EventHandler<PointF?> MouseMoveOnPaper = delegate { };
		public event EventHandler<RectangleF> OnMouseCropSetup = delegate { };

		private PointF? ptfMouseCropStartCm = null, ptfMouseCropEndCm = null;

		private bool IsInMouseCropMode => ptfMouseCropStartCm.HasValue && ptfMouseCropEndCm.HasValue;

		private RectangleF? NormalizedMaouseCropRectCm => !IsInMouseCropMode
			? null
			: RectangleF.FromLTRB(ptfMouseCropStartCm!.Value.X, ptfMouseCropStartCm!.Value.Y, ptfMouseCropEndCm!.Value.X, ptfMouseCropEndCm!.Value.Y)
			.e_Normalize();


		#region Constructor

		// UserControl overrides dispose to clean up the component list.
		[DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Required by the Windows Form Designer
		private System.ComponentModel.IContainer? components = null;

		public xPageview() : base()
		{

			SetStyle(ControlStyles.AllPaintingInWmPaint |
				ControlStyles.OptimizedDoubleBuffer |
				ControlStyles.ResizeRedraw |
				ControlStyles.UserPaint, true);

			UpdateStyles();

			this.Paint += (_, e) => _Paint(e.Graphics);

			this.MouseDown += (_, e) => _MouseDown(e);
			this.MouseMove += (_, e) => _MouseMove(e);
			this.MouseUp += (_, e) => _MouseUp(e);
			this.KeyDown += (_, e) => _KeyPress(e);
			this.MouseLeave += (_, e) => _MouseLeave(e);

			this.Cursor = Cursors.Default;
		}

		#endregion


		#region Properties

		/// <summary>
		/// Displayed PaperSize in Centimeters
		/// </summary>
		[Description("Размер настоящей отображаемой бумаги (например 10х15 см)")]
		public SizeF PaperSizeCm { get => _paperSize; set { _paperSize = value; OnPropertiesChanged(); } }


		[Description("Толщина линейки")]
		public int RullerSize { get => _rullerSize; set { _rullerSize = value; OnPropertiesChanged(); } }


		[Description("Щель между бумагой и линейкой")]
		public int RullerOffset { get => _rullerOffset; set { _rullerOffset = value; OnPropertiesChanged(); } }


		[Description("Коэффициент масштабирования между реальным размером бумаги и отображением на экране")]
		public float Zoom => _zoom;


		public RectangleF? PaperCropCm
		{
			get => _paperCropCm; set
			{
				_paperCropCm = value;
				if (_paperCropCm.HasValue) _paperCropCm = _paperCropCm.Value.e_EnsureInRect(PaperSizeCm.e_ToRectangleF());

				OnPropertiesChanged();
			}
		}


		private string _emptyImagesText = string.Empty;
		public string EmptyImagesText { get => _emptyImagesText; set { _emptyImagesText = value; OnPropertiesChanged(); } }

		private string _cropZoneString = "Crop area";
		public string CropZoneString { get => _cropZoneString; set { _cropZoneString = value; OnPropertiesChanged(); } }

		string _cropZone_UnitsCm = "cm";
		public string CropZoneUnitsCm { get => _cropZone_UnitsCm; set { _cropZone_UnitsCm = value; OnPropertiesChanged(); } }


		#endregion

		public void PaperCropReset() => PaperCropCm = PAPER_CROP_ZERRO;


		public void ResetImages(bool resetFront, bool resetBack)
		{
			if (resetFront) this.frontImage = null;
			if (resetBack) this.backImage = null;
			OnPropertiesChanged();
		}

		public void SetBackImage(System.Drawing.Image img, RectangleF imageRectCM)
		{
			this.backImage = new(img, imageRectCM);
			ResetImages(true, false);
		}

		public void SetFrontImage(System.Drawing.Image img, RectangleF imageRectCM)
		{
			this.frontImage = new(img, imageRectCM);
			ResetImages(false, true);
		}


		private void OnPropertiesChanged() => Invalidate();


		#region Scale Params Counting...

		/// <summary>Расчёт координат листа на экране и коэффициента ZOOM</summary>
		private void CalculateScreenPage()
		{
			Rectangle rcClient = ClientRectangle;
			rcClient.Inflate(-BORDER_SIZE, -BORDER_SIZE);

			// Центральная точка страницы
			PointF ptfCenter = rcClient.e_ToRectangleF().e_GetCenter();

			var pageOnScreenPx = PaperSizeCm.e_ВписатьВ(rcClient.Size);
			_zoom = pageOnScreenPx.Zoom;
			_rcPageOnScreenPx = pageOnScreenPx.TargetSize.e_ToRectangleF().e_CenterTo(ptfCenter).e_ToRectangle();
		}



		/// <summary>Converts paper Coords (Cm) to Screen Coords (Pixels)</summary>
		public Size PaperToScreen(SizeF szfPaper) => szfPaper.e_Multiply(_zoom).ToSize();


		/// <inheritdoc cref="PaperToScreen"/>
		public Point PaperToScreen(PointF ptfPaper)
		{
			var ptScreen = PaperToScreen(ptfPaper.e_ToSize()).e_ToPoint();
			//Offsetting from paper start corner
			{
				ptScreen.X += _rcPageOnScreenPx.Left;
				ptScreen.Y += _rcPageOnScreenPx.Top;
			}
			return ptScreen;
		}

		/// <inheritdoc cref="PaperToScreen"/>
		public Rectangle PaperToScreen(RectangleF rcfPaper)
		{
			var ptScreen = PaperToScreen(rcfPaper.Location);
			var szScreen = PaperToScreen(rcfPaper.Size);
			Rectangle rcfScreenRect = new RectangleF(ptScreen, szScreen).e_ToRectangle();
			return rcfScreenRect;
		}


		/// <summary>Converts Screen Pixels Coords to paper Coords (Cm)</summary>
		private PointF? ScreenToPaper(Point screenPos)
		{
			if (!_rcPageOnScreenPx.Contains(screenPos)) return null;
			screenPos.Offset(-(int)_rcPageOnScreenPx.X, -(int)_rcPageOnScreenPx.Y);
			PointF ptfCursorOnPage = new(screenPos.X / _zoom, screenPos.Y / _zoom);
			return ptfCursorOnPage;
		}


		#endregion


		private void _Paint(Graphics g)
		{
			CalculateScreenPage();
			g.Clear(SystemColors.AppWorkspace);
			if (_rcPageOnScreenPx.Width < C_MIN_VISIBLE_PAGE_SIZE || _rcPageOnScreenPx.Height < C_MIN_VISIBLE_PAGE_SIZE) return;

			Region rgnFull = g.Clip;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
			g.PageUnit = GraphicsUnit.Pixel;
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;

			const int SHADOW_SIZE = 40;

			float alphaStep = 5f / (float)SHADOW_SIZE;

			int penWidth = SHADOW_SIZE;
			float alpha = 0;

			for (int iStep = 0; iStep < SHADOW_SIZE; iStep++)
			{
				Color clrShadow = Color.FromArgb((int)alpha, Color.Black);
				using Pen pnShadow = new Pen(clrShadow, penWidth);

				pnShadow.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

				g.DrawRectangle(pnShadow, _rcPageOnScreenPx);
				penWidth--;
				alpha += alphaStep;
			}

			// ***** Draw White Page
			g.FillRectangle(BRUSH_PAGE, _rcPageOnScreenPx);
			//g.DrawRectangle(BRUSH_PAGE, _rcPageOnScreenPx);

			// ***** Draw Yellow rullers
			Draw_Ruller(g, 0f, PaperSizeCm.Width, _zoom, _rcPageOnScreenPx, false, _rullerOffset, _rullerSize, RULLER_COLOR, RULLER_COLOR_BACK);
			Draw_Ruller(g, 0f, PaperSizeCm.Height, _zoom, _rcPageOnScreenPx, true, _rullerOffset, _rullerSize, RULLER_COLOR, RULLER_COLOR_BACK);


			// Allow drawing only on page
			using Region rgnPage = new(_rcPageOnScreenPx);
			g.Clip = rgnPage;
			try
			{
				{
					void DrawImageProc(DISPLAY_IMAGE? di)
					{
						if (di == null) return;

						var rcImage = PaperToScreen(di.ImageRectCm);
						g.DrawImage(di.Image, PaperToScreen(di.ImageRectCm));
#if DEBUG
						g.DrawRectangles(Pens.Blue, rcImage.e_ToArrayOf());
#endif
					}

					if (backImage == null && frontImage == null)
					{
						if (!string.IsNullOrWhiteSpace(_emptyImagesText))
						{
							//Drawing No Image Text
							using Font fnt = new(this.Font.FontFamily, 20);
							g.e_DrawTextEx(_emptyImagesText, fnt, Color.Gray, _rcPageOnScreenPx, ContentAlignment.MiddleCenter);
						}
					}
					else
					{
						DrawImageProc(backImage);
						DrawImageProc(frontImage);
					}

				}

				// ***** Drawing Crop Region	
				{
					bool bCrop = _paperCropCm.HasValue || IsInMouseCropMode;
					if (bCrop)
					{
						RectangleF rcfCropCm = default;

						rcfCropCm = IsInMouseCropMode
							? NormalizedMaouseCropRectCm!.Value
							: _paperCropCm!.Value.e_Normalize();

						rcfCropCm = rcfCropCm.e_EnsureInRect(PaperSizeCm.e_ToRectangleF());


						Rectangle rcCropPx = PaperToScreen(rcfCropCm);
						rcCropPx = rcCropPx.e_EnsureInRect(_rcPageOnScreenPx);

						// Shadowing White page except Clip Rect
						using Region rgnPageWitoutCrop = new(_rcPageOnScreenPx);
						rgnPageWitoutCrop.Exclude(rcCropPx);
						//using Region rgnCrop = new(rcCropPx);
						g.Clip = rgnPageWitoutCrop;



						const byte CROP_SHADOW_ALPHA = 50;
						var CLR_CROP_SHADOW = Color.FromArgb(CROP_SHADOW_ALPHA, 0, 0, 0);

						using SolidBrush brClipShadow = new(CLR_CROP_SHADOW);
						g.FillRectangle(brClipShadow, _rcPageOnScreenPx);

						g.Clip = rgnFull;
						// ***** Clip Frame
						{
							Color clrCropFrame = Color.DarkGray;


							using Region rgnCrop = new(rcCropPx); // Регион светлой области (вырезаемая часть)
							g.Clip = rgnCrop;

							{
								//Drawing Crop Tip Labels

								const int MIN_TIP_W = 120;
								const int MIN_TIP_H = 60;

								if (IsInMouseCropMode && rcCropPx.Width > MIN_TIP_W && rcCropPx.Height > MIN_TIP_H)
								{

									void DrawTipText(string txt, Rectangle rc, ContentAlignment align)
									{
										const int TIP_FRAME_SIZE = 2;
										Point tipOffset = new(4, 4);

										Rectangle tr = g.MeasureString(txt, Font).e_ToRectangleF().e_ToRectangle();
										tr.Inflate(TIP_FRAME_SIZE, TIP_FRAME_SIZE);

										tr = tr.e_AlignTo(rc, align, tipOffset);
										g.FillRectangle(SystemBrushes.Info, tr);
										g.DrawRectangle(Pens.DarkGray, tr);
										g.e_DrawTextEx(txt, Font, Color.DarkGray, tr, ContentAlignment.MiddleCenter);
									}


									//using Font fnt = new(this.Font.FontFamily, 20);

									string posStart = $"{rcfCropCm.X:0.00}x{rcfCropCm.Y:0.00}" + _cropZone_UnitsCm;
									DrawTipText(posStart, rcCropPx, ContentAlignment.TopLeft);

									string cropSize = $"{_cropZoneString}: {rcfCropCm.Width:0.00}x{rcfCropCm.Height:0.00}" + _cropZone_UnitsCm;
									DrawTipText(cropSize, rcCropPx, ContentAlignment.MiddleCenter);

									string endStart = $"{rcfCropCm.Right:0.00}x{rcfCropCm.Bottom:0.00}" + _cropZone_UnitsCm;
									DrawTipText(endStart, rcCropPx, ContentAlignment.BottomRight);

								}
							}

							using Pen pnClipFrame = new(clrCropFrame, 3);
							pnClipFrame.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
							pnClipFrame.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
							g.DrawRectangle(pnClipFrame, rcCropPx);


						}
					}
				}
			}
			finally
			{
				g.Clip = rgnFull;
			}

			DrawPageEventArgs DPEA = new(PaperSizeCm, _rcPageOnScreenPx, _zoom, g);
			try { OnDrawPage?.Invoke(this, DPEA); } catch { }
		}


		#region Рисуем линейку

		private static void Draw_Ruller(
			Graphics g,
			float Value_Min,
			float Value_Max,
			float ScreenZoom,
			RectangleF rcPaper,
			bool bVertical,
			float RullerOffset,
			float RullerSize,
			Pen RullerColor,
			Brush RullerBackColor)
		{


			// Рисуем жёлтый фон линейки
			RectangleF rcRullerBack = bVertical
				? new(rcPaper.Left - RullerOffset - RullerSize, rcPaper.Top, RullerSize, rcPaper.Height)
				: new(rcPaper.Left, rcPaper.Top - RullerOffset - RullerSize, rcPaper.Width, RullerSize);

			g.FillRectangle(RullerBackColor, rcRullerBack);

			void Draw_Деления(RectangleF rc, float _From, float _To, float _Step)
			{
				PointF pt1, pt2;

				float sngValue = _From;
				while (sngValue < _To)
				{
					float ValueOnScreen = sngValue * ScreenZoom; // зНАЧЕНИЕ В ЭКРАННОЙ КООРДИНАТЕ

					if (bVertical)
					{
						ValueOnScreen += rcPaper.Top; // Сдвигаем относительно начала на экране
						pt1 = new PointF(rc.Left, ValueOnScreen);
						pt2 = new PointF(rc.Right, ValueOnScreen);
					}
					else
					{
						ValueOnScreen += rcPaper.Left; // Сдвигаем относительно начала на экране
						pt1 = new PointF(ValueOnScreen, rc.Top);
						pt2 = new PointF(ValueOnScreen, rc.Bottom);
					}

					g.DrawLine(RullerColor, pt1, pt2);

					sngValue += _Step;
				}
			};


			// Уменьшаем толщину линейки для основных делений
			float Size_1 = RullerSize / 2f;
			float Size_05 = Size_1 / 2f;
			float Size_01 = Size_05 / 2f;

			(float ВысотаРиски, float ШагДелений)[] aШкалы = {
				new (Size_1, 1.0f),
				new (Size_05, 0.5f),
				new (Size_01, 0.1f)
			};

			foreach (var Шкала in aШкалы)
			{
				var RC = rcRullerBack;

				if (bVertical)
				{
					RC.Offset(RC.Width, 0f);
					RC.Width = Шкала.ВысотаРиски;
					RC.Offset(-RC.Width, 0f);
				}
				else
				{
					RC.Offset(0f, RC.Height);
					RC.Height = Шкала.ВысотаРиски;
					RC.Offset(0f, -RC.Height);
				}

				Draw_Деления(RC, Value_Min, Value_Max, Шкала.ШагДелений);
			}

		}

		#endregion








		private void _MouseDown(MouseEventArgs e)
		{
			ptfMouseCropStartCm = (e.Button == MouseButtons.Left)
				? ScreenToPaper(e.Location)
				: null;

			DrawCropArea();
		}
		private void _MouseMove(MouseEventArgs e)
		{
			PointF? ptfCursor = ScreenToPaper(e.Location);

			this.Cursor = ptfCursor.HasValue
				? Cursors.Cross
				: Cursors.Default;

			//UseWaitCursor = false;

			ptfMouseCropEndCm = (e.Button == MouseButtons.Left) ? ptfCursor : null;

			DrawCropArea();

			MouseMoveOnPaper.Invoke(this, ptfCursor);
		}

		private void _MouseUp(MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left || !NormalizedMaouseCropRectCm.HasValue) return;
			RectangleF rcfMouseCrop = NormalizedMaouseCropRectCm!.Value;
			OnMouseCropSetup.Invoke(this, rcfMouseCrop);
			ClearMouseCrop(false);
		}

		private void _KeyPress(KeyEventArgs e)
		{
			//If press ESC when cliping = this reset cliping
			if (e.KeyCode != Keys.Escape) return;
			ClearMouseCrop();
		}

		private void ClearMouseCrop(bool redraw = true)
		{
			ptfMouseCropStartCm = null;
			ptfMouseCropEndCm = null;
			if (redraw) DrawCropArea();
		}

		private void _MouseLeave(EventArgs e) => MouseMoveOnPaper.Invoke(this, null);


		private void DrawCropArea() => Invalidate();

	}
}