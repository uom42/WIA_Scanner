#nullable enable

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Windows.Forms;

using Svg;

using uom.Extensions;

using static System.Net.Mime.MediaTypeNames;

using Font = System.Drawing.Font;

namespace WS
{

	internal class xPageview : UserControl
	{


		private class DISPLAY_IMAGE(System.Drawing.Image img, RectangleF rectCm)
		{
			public readonly System.Drawing.Image? @Image = img;

			/// <summary>Image rect on paper in Centimeters</summary>
			public readonly RectangleF ImageRectCm = rectCm;

			~DISPLAY_IMAGE()
			{
				@Image?.Dispose();
			}
		}


		public class DrawPageEventArgs(SizeF paperSizeCm, RectangleF paperOnScreenPx, float zoom, Graphics graphics) : EventArgs()
		{
			public readonly SizeF PaperSizeCm = paperSizeCm;
			public readonly RectangleF PaperOnScreenPx = paperOnScreenPx;
			public readonly float Zoom = zoom;
			public readonly Graphics @Graphics = graphics;
		}


		#region Events


		public event EventHandler<DrawPageEventArgs> DrawPage = delegate { };

		public new event EventHandler<PointF?> MouseMove = delegate { };

		/// <summary>When user completed setup crop zone by releasing mouse button in finish crop position</summary>
		public event EventHandler<RectangleF> CropZoneCompleted = delegate { };


		#endregion


		#region Constants


		private const int MIN_VISIBLE_PAGE_SIZE_PX = 20;
		private const int CONTROL_PADDING_MM = 5;

		public static readonly RectangleF CROP_ZERRO = new(0f, 0f, 0f, 0f);

		//private readonly static Brush BRUSH_SHADOW = SystemBrushes.ButtonShadow;
		private readonly static Brush B_PAPER_BACKGROUND = Brushes.White;
		private readonly static Brush B_RULLER_BACKGROUND = Brushes.Khaki;
		private readonly static Brush B_RULLER_TEXT = Brushes.Gray;
		private readonly static Pen P_RULLER_MARKS = Pens.SlateGray;




		#endregion



		private SizeF _paperSizeCm = new(10f, 15f);
		private int _rullerOffsetMM = 4;
		private int _rullerSizeMM = 10;
		private float _paperZoom = 0f;

		/// <summary>Size of the papper sheet on the screen (pixels)</summary>
		private Rectangle _rcPageOnScreenPx = new(0, 0, 0, 0); // Страница на экране

		/// <summary>Size of the crop zone (cm)</summary>
		private RectangleF? _cropZoneCm = null;

		private DISPLAY_IMAGE? _backImage = null;
		private DISPLAY_IMAGE? _frontImage = null;




		private PointF? _ptfMouseCropStartCm = null, _ptfMouseCropEndCm = null;


		/// <summary>
		/// Цруь тщ
		/// </summary>
		private bool CropIsInProcess
			=> _ptfMouseCropStartCm.HasValue && _ptfMouseCropEndCm.HasValue;


		private RectangleF? NormalizedMaouseCropRectCm
			=> !CropIsInProcess
				? null
				: RectangleF.FromLTRB(_ptfMouseCropStartCm!.Value.X, _ptfMouseCropStartCm!.Value.Y, _ptfMouseCropEndCm!.Value.X, _ptfMouseCropEndCm!.Value.Y).eNormalize();


		#region Constructor

		// UserControl overrides dispose to clean up the component list.
		[DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null) components.Dispose();
			}
			finally { base.Dispose(disposing); }
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
			base.MouseMove += (_, e) => _MouseMove(e);
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
		public SizeF PaperSizeCm { get => _paperSizeCm; set { _paperSizeCm = value; OnPropertiesChanged(); } }


		[Description("Толщина линейки")]
		public int RullerSizeMM { get => _rullerSizeMM; set { _rullerSizeMM = value; OnPropertiesChanged(); } }


		[Description("Spacing between paper and ruller on screen")]
		public int RullerOffsetMM { get => _rullerOffsetMM; set { _rullerOffsetMM = value; OnPropertiesChanged(); } }


		[Description("Paper scaling factor between real paper size and onscreen paper size")]
		public float PaperZoom => _paperZoom;


		public RectangleF? CropZoneCm
		{
			get => _cropZoneCm; set
			{
				_cropZoneCm = value.HasValue
					? value.Value.eEnsureInRect(_paperSizeCm.eToRectangleF())
					: null;

				OnPropertiesChanged();
			}
		}

		private SvgDocument? _emptyImagesLogo;
		public SvgDocument? EmptyImagesLogo { get => _emptyImagesLogo; set { _emptyImagesLogo = value; OnPropertiesChanged(); } }


		private string _emptyImagesText = string.Empty;
		public string EmptyImagesText { get => _emptyImagesText; set { _emptyImagesText = value; OnPropertiesChanged(); } }

		private string _cropZoneString = "Crop area";
		public string CropZoneString { get => _cropZoneString; set { _cropZoneString = value; OnPropertiesChanged(); } }

		string _cropZone_UnitsCm = "cm";
		public string CropZoneUnitsCm { get => _cropZone_UnitsCm; set { _cropZone_UnitsCm = value; OnPropertiesChanged(); } }


		#endregion

		public void PaperCropReset()
			=> CropZoneCm = CROP_ZERRO;


		public void ResetImages(bool resetFront, bool resetBack)
		{
			if (resetFront) this._frontImage = null;
			if (resetBack) this._backImage = null;
			OnPropertiesChanged();
		}

		public void SetBackImage(System.Drawing.Image img, RectangleF imageRectCM)
		{
			this._backImage = new(img, imageRectCM);
			ResetImages(true, false);
		}

		public void SetFrontImage(System.Drawing.Image img, RectangleF imageRectCM)
		{
			this._frontImage = new(img, imageRectCM);
			ResetImages(false, true);
		}


		private void OnPropertiesChanged() => Invalidate();



		#region Scale Params Counting...



		/// <summary>Converts paper Coords (Cm) to Screen Coords (Pixels)</summary>
		public Size PaperToScreen(SizeF szfPaper)
			=> szfPaper.eMultiply(_paperZoom).ToSize();


		/// <inheritdoc cref="PaperToScreen(SizeF)"/>
		public Point PaperToScreen(PointF ptfPaper)
		{
			var ptScreen = PaperToScreen(ptfPaper.eToSize()).eToPoint();
			//Offsetting from paper start corner
			{
				ptScreen.X += _rcPageOnScreenPx.Left;
				ptScreen.Y += _rcPageOnScreenPx.Top;
			}
			return ptScreen;
		}

		/// <inheritdoc cref="PaperToScreen(SizeF)"/>
		public Rectangle PaperToScreen(RectangleF rcfPaper)
			=> PaperToScreen(rcfPaper.Size)
			.eToRectangle(PaperToScreen(rcfPaper.Location));


		/// <summary>Converts Screen Pixels Coords to paper Coords (Cm)</summary>
		private PointF? ScreenToPaper(Point screenPos)
		{
			if (!_rcPageOnScreenPx.Contains(screenPos)) return null;
			screenPos.Offset(-(int)_rcPageOnScreenPx.X, -(int)_rcPageOnScreenPx.Y);
			PointF ptfCursorOnPage = new(screenPos.X / _paperZoom, screenPos.Y / _paperZoom);
			return ptfCursorOnPage;
		}



		/// <summary>Расчёт координат листа на экране и коэффициента ZOOM</summary>
		private (Rectangle VRuller, Rectangle HRuller) CalculatePageMetrics(Graphics g)
		{

			_rullerOffsetMM = 2;
			_rullerSizeMM = 6;

			Rectangle rcClient = ClientRectangle;

			var paddingPx = g.eMM_ToPixels(new SizeF(CONTROL_PADDING_MM, CONTROL_PADDING_MM));
			rcClient.Inflate(-paddingPx.Width, -paddingPx.Height);


			var rullerSizePx = g.eMM_ToPixels(new SizeF(_rullerSizeMM, _rullerSizeMM));
			var rullerOffsetPx = g.eMM_ToPixels(new SizeF(_rullerOffsetMM, _rullerOffsetMM));

			int offsetX = rullerSizePx.Width + rullerOffsetPx.Width;
			int offsetY = rullerSizePx.Height + rullerOffsetPx.Height;

			rcClient = rcClient.eMoveLeftTopCorner(new(offsetX, offsetY));

			// Центральная точка страницы
			PointF ptfPageCenter = rcClient.eToRectangleF().eGetCenter();
			(var targetSize, _paperZoom) = _paperSizeCm.eВписатьВ(rcClient.Size);

			_rcPageOnScreenPx = targetSize.eToRectangleF().eCenterTo(ptfPageCenter).eToRectangle();

			//var r1 = _rcPageOnScreenPx;
			//_rcPageOnScreenPx = _rcPageOnScreenPx.eMoveLeftTopCorner(new(offsetX, offsetY));
			Rectangle rcVRuller = new(_rcPageOnScreenPx.Left - offsetX, _rcPageOnScreenPx.Top, rullerSizePx.Width, _rcPageOnScreenPx.Height);
			Rectangle rcHRuller = new(_rcPageOnScreenPx.Left, _rcPageOnScreenPx.Top - offsetY, _rcPageOnScreenPx.Width, rullerSizePx.Height);

			//float xx = (float)_rcPageOnScreenPx.Width / (float)r1.Width;
			//float yy = (float)_rcPageOnScreenPx.Height / (float)r1.Height;

			return (rcVRuller, rcHRuller);
		}







		#endregion


		private void _Paint(Graphics g)
		{

			g.Clear(SystemColors.AppWorkspace);


			var (rcVRuller, rcHRuller) = CalculatePageMetrics(g);


			if (_rcPageOnScreenPx.Width < MIN_VISIBLE_PAGE_SIZE_PX || _rcPageOnScreenPx.Height < MIN_VISIBLE_PAGE_SIZE_PX) return;

			Region rgnFull = g.Clip;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;

			g.PageUnit = GraphicsUnit.Pixel;


			const int SHADOW_SIZE = 40;
			float alphaStep = 5f / (float)SHADOW_SIZE;

			int penWidth = SHADOW_SIZE;
			float alpha = 0;

			for (int iStep = 0; iStep < SHADOW_SIZE; iStep++)
			{
				Color clrShadow = Color.FromArgb((int)alpha, Color.Black);
				using Pen pnShadow = new(clrShadow, penWidth)
				{
					LineJoin = LineJoin.Round
				};

				g.DrawRectangle(pnShadow, _rcPageOnScreenPx);
				penWidth--;
				alpha += alphaStep;
			}

			// ***** Draw White Page
			g.FillRectangle(B_PAPER_BACKGROUND, _rcPageOnScreenPx);

			// ***** Draw Yellow rullers
			Enum
				.GetValues<Orientation>()
				.eForEach(o =>
				{
					Draw_Ruller(g,
						o,
						0f,
						(o == Orientation.Vertical ? PaperSizeCm.Height : PaperSizeCm.Width),
						(o == Orientation.Vertical ? rcVRuller : rcHRuller),
						P_RULLER_MARKS,
						B_RULLER_TEXT,
						B_RULLER_BACKGROUND);
				});


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
						g.DrawImage(di.Image!, PaperToScreen(di.ImageRectCm));
#if DEBUG
						g.DrawRectangles(Pens.Blue, rcImage.eToArrayOf());
#endif
					}

					if (_backImage == null && _frontImage == null)
					{
						//Drawing NoImage Logo & Text

						if (_emptyImagesLogo != null)
						{
							var zoom = _emptyImagesLogo.Width.Value / _emptyImagesLogo.Width.Value;
							Rectangle rcBitmap = _rcPageOnScreenPx;
							rcBitmap.Height = (int)(((float)rcBitmap.Width) + zoom);

							rcBitmap = rcBitmap.Size
								.eВписатьВ(_rcPageOnScreenPx.Size).TargetSize
								.eToRectangle()
								.eScaleToInt(new(0.5f, 0.5f));

							var bm = _emptyImagesLogo.Draw(rcBitmap.Width, rcBitmap.Height);
							bm.MakeTransparent();

							//Rectangle rcBm = bmTmp.Size.eToRectangle();
							var rectBm = rcBitmap.eCenterTo(_rcPageOnScreenPx.eGetCenter().eRoundToInt());

							bm = bm.eMakeTransparent(0.1f);
							g.DrawImageUnscaled(bm, rectBm.Location);



						}
						if (_emptyImagesText.eIsNotNullOrWhiteSpace())
						{
							//Drawing No Image Text
							using Font fnt = new(this.Font.FontFamily, 20);
							g.eDrawTextEx(_emptyImagesText, fnt, Color.Gray, _rcPageOnScreenPx, ContentAlignment.MiddleCenter);
						}
					}
					else
					{
						DrawImageProc(_backImage);
						DrawImageProc(_frontImage);
					}

				}


				// ***** Drawing Crop Region	
				{
					bool bCrop = _cropZoneCm.HasValue || CropIsInProcess;
					if (bCrop)
					{
						RectangleF rcfCropCm = default;

						rcfCropCm = CropIsInProcess
							? NormalizedMaouseCropRectCm!.Value
							: _cropZoneCm!.Value.eNormalize();

						rcfCropCm = rcfCropCm.eEnsureInRect(PaperSizeCm.eToRectangleF());

						Rectangle rcCropPx = PaperToScreen(rcfCropCm);
						rcCropPx = rcCropPx.eEnsureInRect(_rcPageOnScreenPx);

						// Shadowing page except Clip Rect
						{
							using Region rgnPageWitoutCrop = new(_rcPageOnScreenPx);
							rgnPageWitoutCrop.Exclude(rcCropPx);
							g.Clip = rgnPageWitoutCrop;

							const byte CROP_SHADOW_ALPHA = 50;
							var CLR_CROP_SHADOW = Color.FromArgb(CROP_SHADOW_ALPHA, 0, 0, 0);

							using SolidBrush brClipShadow = new(CLR_CROP_SHADOW);
							g.FillRectangle(brClipShadow, _rcPageOnScreenPx);
						}

						g.Clip = rgnFull;
						// ***** Clip Frame
						{
							Color clrCropFrame = Color.DarkGray;


							using Region rgnCrop = new(rcCropPx); // Регион светлой области (вырезаемая часть)
							g.Clip = rgnCrop;

							{
								//Drawing crop zone tips

								//const int MIN_TIP_W = 120, MIN_TIP_H = 60;
								//const string NUMBER_FORMAT = "0.00";

								string cropZoneStart = $"{rcfCropCm.X:0.00}x{rcfCropCm.Y:0.00}{_cropZone_UnitsCm}";
								string cropZoneSize = $"{_cropZoneString}: {rcfCropCm.Width:0.00}x{rcfCropCm.Height:0.00}{_cropZone_UnitsCm}";
								string cropZoneEnd = $"{rcfCropCm.Right:0.00}x{rcfCropCm.Bottom:0.00}{_cropZone_UnitsCm}";

								var szfCropZoneStart = g.MeasureString(cropZoneStart, Font);
								var szfCropZoneSize = g.MeasureString(cropZoneSize, Font);
								var szfCropZoneEnd = g.MeasureString(cropZoneEnd, Font);

								var minTimSize = szfCropZoneStart.Height + szfCropZoneEnd.Height;
								if (CropIsInProcess && rcCropPx.Height > minTimSize)
								{

									void DrawTipText(string txt, Rectangle rc, ContentAlignment align)
									{
										const int FRAME_PADDING = 2;
										Point tipOffset = new(4, 4);

										Rectangle tr = g.MeasureString(txt, Font).eToRectangleF().eToRectangle();
										tr.Inflate(FRAME_PADDING, FRAME_PADDING);

										if (rcCropPx.Width < tr.Width || rcCropPx.Height < tr.Height) return;

										tr = tr.eAlignTo(rc, align, tipOffset);

										//g.FillRectangle(SystemBrushes.Info, tr);
										Color clrTip = Color.FromArgb(150, SystemColors.Info);
										using SolidBrush brTip = new(clrTip);
										g.FillRectangle(brTip, tr);

										g.DrawRectangle(Pens.DarkGray, tr);
										g.eDrawTextEx(txt, Font, Color.DarkGray, tr, ContentAlignment.MiddleCenter);
									}

									DrawTipText(cropZoneStart, rcCropPx, ContentAlignment.TopLeft);
									DrawTipText(cropZoneEnd, rcCropPx, ContentAlignment.BottomRight);
									DrawTipText(cropZoneSize, rcCropPx, ContentAlignment.MiddleCenter);

								}
							}

							using Pen pnClipFrame = new(clrCropFrame, 3)
							{
								DashStyle = System.Drawing.Drawing2D.DashStyle.Dash,
								Alignment = System.Drawing.Drawing2D.PenAlignment.Inset
							};
							g.DrawRectangle(pnClipFrame, rcCropPx);

						}
					}
				}
			}
			finally
			{
				g.Clip = rgnFull;
			}

			DrawPageEventArgs DPEA = new(PaperSizeCm, _rcPageOnScreenPx, _paperZoom, g);
			try { DrawPage?.Invoke(this, DPEA); } catch { }
		}


		#region Рисуем линейку

		private static void Draw_Ruller(
			Graphics g,
			Orientation rullerOrientation,
			float rullerValueMin,
			float rullerValueMax,
			Rectangle rullerBoundsPx,
			Pen pRullerMarks,
			Brush bRullerText,
			Brush bRullerBack)
		{

			bool vertical = (rullerOrientation == Orientation.Vertical);

			//var oldUnits = g.PageUnit;

			var oldClip = g.Clip;
			g.Clip = new(rullerBoundsPx);

			try
			{
				g.FillRectangle(bRullerBack, rullerBoundsPx);

				int rullerLenghtPx = vertical ? rullerBoundsPx.Height : rullerBoundsPx.Width;
				float rullerWidthPx = (vertical ? rullerBoundsPx.Width : rullerBoundsPx.Height);

				float Size_10_mm = rullerWidthPx / 3f * 2f;
				float Size_5_mm = rullerWidthPx / 2f;
				float Size_1_mm = Size_5_mm / 2f;

				float rullerSizeMM = (rullerValueMax - rullerValueMin) * 10;
				var rullerScale = (float)rullerLenghtPx / rullerSizeMM;

				float fTextSize = rullerScale.eCheckRange(1f, 3f);
				using Font fnt = new(FontFamily.GenericSansSerif, fTextSize, GraphicsUnit.Millimeter);

				Debug.WriteLine(rullerScale);

				int mm = 0, mmInPixels = 0;
				while (mmInPixels < rullerLenghtPx)
				{
					mm++;
					mmInPixels = (int)(mm * rullerScale);

					float markSize = Size_1_mm;

					if (mm.eIsКратно(10))
					{
						markSize = Size_10_mm;
					}
					else if (mm.eIsКратно(5))
					{
						markSize = Size_5_mm;
					}
					else
					{

						if (rullerScale < 2f) continue;
					}

					Point ptStart = vertical
						? new(rullerBoundsPx.Right, rullerBoundsPx.Top + mmInPixels)
						: new(rullerBoundsPx.Left + mmInPixels, rullerBoundsPx.Bottom);

					Point ptEnd = ptStart;

					if (vertical)
						ptEnd.Offset(-(int)markSize, 0);
					else
						ptEnd.Offset(0, -(int)markSize);

					g.DrawLine(pRullerMarks, ptStart, ptEnd);


					if (mm.eIsКратно(10))
					{
						string cm = ((rullerValueMin + mm) / 10).ToString();
						g.eDrawTextEx(cm, fnt, bRullerText, ptEnd, ContentAlignment.MiddleCenter);
					}


				}

				return;



			}
			finally
			{
				//	g.PageUnit = oldUnits;
				g.Clip = oldClip;
			}

		}

		#endregion








		private void _MouseDown(MouseEventArgs e)
		{
			_ptfMouseCropStartCm = (e.Button == MouseButtons.Left)
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

			_ptfMouseCropEndCm = (e.Button == MouseButtons.Left) ? ptfCursor : null;

			DrawCropArea();

			MouseMove.Invoke(this, ptfCursor);
		}

		private void _MouseUp(MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left || !NormalizedMaouseCropRectCm.HasValue) return;
			RectangleF rcfCrop = NormalizedMaouseCropRectCm!.Value;
			CropZoneCompleted.Invoke(this, rcfCrop);
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
			_ptfMouseCropStartCm = null;
			_ptfMouseCropEndCm = null;
			if (redraw) DrawCropArea();
		}

		private void _MouseLeave(EventArgs e) => MouseMove.Invoke(this, null);


		private void DrawCropArea() => Invalidate();

	}
}