#nullable enable

using System.Drawing;

using uom;
using uom.WIA2;
using uom.WIA2.Scanner;

namespace WS
{
	partial class frmMain
	{
		#region Color Modes
		private const WIA_IPS_CUR_INTENT wiaIntent_Color = WIA_IPS_CUR_INTENT.WIA_INTENT_IMAGE_TYPE_COLOR;
		private const WIA_IPS_CUR_INTENT wiaIntent_GrayScale = WIA_IPS_CUR_INTENT.WIA_INTENT_IMAGE_TYPE_GRAYSCALE;
		private const WIA_IPS_CUR_INTENT wiaIntent_BWText = WIA_IPS_CUR_INTENT.WIA_INTENT_IMAGE_TYPE_TEXT;
		private static readonly ComboboxItemContainer<WIA_IPS_CUR_INTENT> ColorMode_Color = new(wiaIntent_Color, Localization.Strings.L_SCAN_PARAMS_MODE_COLOR_IMAGE);
		private static readonly ComboboxItemContainer<WIA_IPS_CUR_INTENT> ColorMode_GrayScale = new(wiaIntent_GrayScale, Localization.Strings.L_SCAN_PARAMS_MODE_GRAYSCALE);
		private static readonly ComboboxItemContainer<WIA_IPS_CUR_INTENT> ColorMode_BWText = new(wiaIntent_BWText, Localization.Strings.L_SCAN_PARAMS_MODE_BW_TEXT);
		private static readonly ComboboxItemContainer<WIA_IPS_CUR_INTENT>[] colorModes = { ColorMode_Color, ColorMode_GrayScale, ColorMode_BWText };
		#endregion

		#region File Formats
		private const WIA_IMAGE_FORMATS wiaFileFormat_JPG = WIA_IMAGE_FORMATS.WiaImgFmt_JPEG;
		private const WIA_IMAGE_FORMATS wiaFileFormat_PNG = WIA_IMAGE_FORMATS.WiaImgFmt_PNG;
		private static readonly ComboboxItemContainer<WIA_IMAGE_FORMATS> FileFormat_JPG = new(wiaFileFormat_JPG, "JPG");
		private static readonly ComboboxItemContainer<WIA_IMAGE_FORMATS> FileFormat_PNG = new(wiaFileFormat_PNG, "PNG");
		private static readonly ComboboxItemContainer<WIA_IMAGE_FORMATS>[] fileFormats = { FileFormat_JPG, FileFormat_PNG };
		#endregion

		private bool _canProcessUIEvents = false;

		private static readonly int[] dpiList = { 75, 100, 150, 200, 300, 600, 1200, 2400, 4800 };
		private bool oldUuseFeeder = false;
		private bool canProcessCropXuds = true;


		#region Local Properties

		internal ScannerDevice? GetSelectedScanner()
			=> cboScannerSelect.e_SelectedItemAs_ObjectContainerValue<ScannerDevice>();


		internal (bool UseAutoFeed, bool UseDuplex, WIA_DPS_DOCUMENT_HANDLING_SELECT handlingFlags) GetSelectedPaperSource()
		{
			ScannerDevice scanner = GetSelectedScanner()!;
			bool useAutoFeed = scanner.Caps.DocumentHandlingCaps_CanAutoFeed && chkUseAutoFeeder.Checked;
			bool useDuplex = useAutoFeed && scanner.Caps.DocumentHandlingCaps_CanDuplex && chkUseAutoFeederDuplex.Checked;

			WIA_DPS_DOCUMENT_HANDLING_SELECT paperSource = useAutoFeed
				? WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER
				: WIA_DPS_DOCUMENT_HANDLING_SELECT.FLATBED;

			if (useDuplex) paperSource |= WIA_DPS_DOCUMENT_HANDLING_SELECT.DUPLEX;

			return (useAutoFeed, useDuplex, paperSource);
		}

		internal SizeF? ScannerPaperSourceSizeCm => GetSelectedPaperSource().UseAutoFeed
			? GetSelectedScanner()?.Caps.Feeder_Caps?.SheetSizeIn.e_InchesToCM()
			: GetSelectedScanner()?.Caps.FlatBed_Caps?.SizeIn.e_InchesToCM();


		internal (WIA_IMAGE_FORMATS? format, int QualityPercent) GetSelectedFileFormat()
		{
			WIA_IMAGE_FORMATS? format = cboFileFormat.e_SelectedItemAs_ObjectContainerValue<WIA_IMAGE_FORMATS>();
			return (format, 0);
		}


		#endregion


		private SCANNER_SETTINGS LoadScanSettings() => SCANNER_SETTINGS.Load();


		private SCANNER_SETTINGS SaveScanSettings()
		{
			SCANNER_SETTINGS ss = new(this);
			ss.Save();
			return ss;
		}


		private void On_SelectedScannerChanged()
		{
			if (!_canProcessUIEvents || GetSelectedScanner() == null) return;

			try
			{
				ScannerDevice scanner = GetSelectedScanner()!;
				scanner.Connect();

				{
					//Fill Scanner DPI list with PRESERVING previous selected DPI

					int minDPI = (new int[] { scanner.MinimumDPI.X, scanner.MinimumDPI.Y }).Max();
					int maxDPI = (new int[] { scanner.Caps.OpticalDPI.X, scanner.Caps.OpticalDPI.Y }).Min();

					var selectedDPI = (cboDPI.SelectedItem == null)
						? minDPI
						: cboDPI.e_SelectedItemAs_ObjectContainerValue<int>();

					int[] validDPIList = dpiList
						.Where(dpi => dpi >= minDPI && dpi <= maxDPI)
						.ToArray();

					cboDPI.e_FillWithContainersOf<int>(validDPIList, selectedDPI);
				}


				bool canAutoFeed = scanner.Caps.DocumentHandlingCaps_CanAutoFeed;
				chkUseAutoFeeder.Visible = canAutoFeed;
				chkUseAutoFeeder.Enabled = canAutoFeed;
			}
			catch (Exception ex) { ex.e_LogError(true); }
			finally
			{
				On_PaperSourceChanged();
			}

			cmdScan_PreView.Enabled = cboDPI.SelectedItem != null;
			cmdScan_FullQuality.Enabled = cboDPI.SelectedItem != null;





		}


		private void On_PaperSourceChanged()
		{
			if (!_canProcessUIEvents || GetSelectedScanner() == null) return;

			ScannerDevice scanner = GetSelectedScanner()!;

			bool canDuplex = scanner.Caps.DocumentHandlingCaps_CanDuplex && chkUseAutoFeeder.Checked;
			chkUseAutoFeederDuplex.Visible = canDuplex;
			chkUseAutoFeederDuplex.Enabled = canDuplex;

			chkScan_НесколькоСтраницВручную.Enabled = !chkUseAutoFeeder.Checked;

			bool useFeeder = GetSelectedPaperSource().UseAutoFeed;
			if (useFeeder != oldUuseFeeder)
			{
				xPageControl.ResetImages(true, true);
			}
			oldUuseFeeder = useFeeder;

			SizeF? pageSizeCm = ScannerPaperSourceSizeCm;
			lblPageSize.Text = !pageSizeCm.HasValue
				? null
				: Localization.Strings.L_SCAN_PARAMS_SCANNER_PAGE_SIZE.e_Format(pageSizeCm.Value.ToString_WxH(1));

			/*
					var DPI = Selected_DPI;
					var rcPagePixels = rcPageInches.e_Inches_To_Pixels(DPI);
					sPageSize = string.Format("{0}см. ({1}пикс.)", szPage.ToString_WxH(1), rcPagePixels.Size.ToString_WxH());
			*/
			On_PaperSizeChanged();
		}


		private void On_PaperSizeChanged()
		{
			if (!_canProcessUIEvents || GetSelectedScanner() == null) return;

			ScannerDevice scanner = GetSelectedScanner()!;
			xPageControl.PaperSizeCm = ScannerPaperSourceSizeCm!.Value;



			RecalculateCropLimits();
			On_CropChanged();

		}

		private void On_ColorModeChanged()
		{
			if (!_canProcessUIEvents || GetSelectedScanner() == null) return;
			xPageControl.ResetImages(true, true);
		}

		private void On_DPIChanged()
		{
			if (!_canProcessUIEvents || GetSelectedScanner() == null) return;



			//this.UpdateCurrentScanProfileSettingsFromUI();
			// Call OnCropSize_Changed()
		}

		void SetCropAreaCm(RectangleF rcfCrop)
		{
			canProcessCropXuds = false;
			try
			{
				xudCrop_Left.Value = (decimal)rcfCrop.Left.e_Round(2);
				xudCrop_Top.Value = (decimal)rcfCrop.Top.e_Round(2);

				decimal cw = (decimal)(rcfCrop.Width.e_Round(2));
				decimal ch = (decimal)(rcfCrop.Height.e_Round(2));

				if (cw > xudCrop_Width.Maximum) xudCrop_Width.Maximum = cw;
				if (ch > xudCrop_Height.Maximum) xudCrop_Height.Maximum = ch;
				xudCrop_Width.Value = cw;
				xudCrop_Height.Value = ch;

				chkCropZone_Set.Checked = true;
			}
			finally { canProcessCropXuds = true; }
			On_CropChanged();
		}

		private void On_CropChanged()
		{
			if (!_canProcessUIEvents || GetSelectedScanner() == null || !canProcessCropXuds) return;
			tlpPageCrop.Visible = chkCropZone_Set.Checked;

			RectangleF? rcfCrop = null;

			if (chkCropZone_Set.Checked)
			{
				RecalculateCropLimits();

				rcfCrop = new RectangleF((float)xudCrop_Left.Value, (float)xudCrop_Top.Value, (float)xudCrop_Width.Value, (float)xudCrop_Height.Value);
			}
			xPageControl.PaperCropCm = rcfCrop;
		}

		private void RecalculateCropLimits()
		{
			canProcessCropXuds = false;
			try
			{
				SizeF? szfnPaper = ScannerPaperSourceSizeCm;
				if (szfnPaper == null) return;

				SizeF szfPaper = szfnPaper.Value;
				decimal pageW = (decimal)szfPaper.Width, pageH = (decimal)szfPaper.Height;
				decimal maxW = pageW, maxH = pageH;

				xudCrop_Left.Maximum = maxW;
				xudCrop_Top.Maximum = maxH;

				if (xudCrop_Left.Value > 0) maxW = (pageW - xudCrop_Left.Value);
				if (xudCrop_Top.Value > 0) maxH = (pageH - xudCrop_Top.Value);

				xudCrop_Width.Maximum = maxW;
				xudCrop_Height.Maximum = maxH;

				if (xudCrop_Width.Value == 0) xudCrop_Width.Value = maxW;
				if (xudCrop_Height.Value == 0) xudCrop_Height.Value = maxH;
			}
			finally { canProcessCropXuds = true; }

		}

		private void On_FileFormatChanged()
		{
			if (!_canProcessUIEvents || GetSelectedScanner() == null) return;

			(WIA_IMAGE_FORMATS? format, _) = GetSelectedFileFormat();
			bool formatHasQuality = format.HasValue && format.Value.e_HasCompressionQualityParameter();

			sldFile_Quality.Visible = formatHasQuality;
			lblFile_Quality.Visible = formatHasQuality;

			On_FileQualityChanged();
		}

		private void On_FileQualityChanged()
		{
			if (!_canProcessUIEvents || GetSelectedScanner() == null) return;

			//this.UpdateCurrentScanProfileSettingsFromUI();
			//lblFile_Quality.Text = WIA_Scanner.e_ExecExtensions_Strings.e_Format("Качество:|{0}%", (object)this._CurrentScanProfile.ImageQuality.ToString().Trim()).e_WrapVB();
		}






	}
}