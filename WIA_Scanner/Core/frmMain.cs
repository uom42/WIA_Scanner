#nullable enable

using uom;
using uom.Extensions;
using uom.WIA2;
using uom.WIA2.Scanner;

namespace WS
{
	internal partial class frmMain
	{

		private WIAManager _scanManager;


		/// <summary>Just for Designer! do not use in code direct!</summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		private frmMain() : base() => InitializeComponent();
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		public frmMain(WIAManager manager) : this()
		{
			_scanManager = manager;
			InitUI();
		}


		private void InitUI()
		{
			Text = Application.ProductName + " " + Application.ProductVersion.ToString();

			this.e_StartAutoupdateOnShown("https://raw.githubusercontent.com/uom42/1C_Pasta/master/UpdaterXML.xml");

			try
			{
				Status(Localization.Strings.L_INITIALIZING);

				LocalizeUI();

				SCANNER_SETTINGS ss = LoadScanSettings();

				//Fill scanners list
				{
					ScannerDevice[] scannersList = _scanManager.GetScanners();
					ScannerDevice? lastUsedScanner = scannersList.Where(dev => dev.ID == ss.ScannerID).FirstOrDefault();
					cboScannerSelect.e_FillWithContainersOf(scannersList, lastUsedScanner);
				}

				//Color mode and DPI
				{
					cboColorMode.e_Fill(colorModes, selectedItem: ss.ColorMode_WIA);
					//Just populate DPI Combobox with FAKE last saved DPI from scanner settings
					//When user selects scanner - dpi list will be updated ()
					cboDPI.e_FillWithContainersOf<int>(ss.DPI.e_ToArrayOf(), ss.DPI);
				}

				//File format and storage
				{
					cboFileFormat.e_Fill(fileFormats, selectedItem: ss.FileFormat_WIA);
					xFileFolder.FullPath = ss.SaveDir;
				}

				cmdScan_PreView.Enabled = false;
				cmdScan_FullQuality.Enabled = false;

				//******************************************
				{
					#region Attaching UI Events

					cboScannerSelect.SelectedIndexChanged += delegate { On_SelectedScannerChanged(); };

					chkUseAutoFeeder.CheckedChanged += delegate { On_PaperSourceChanged(); };
					chkUseAutoFeederDuplex.CheckedChanged += delegate { On_PaperSizeChanged(); };

					cboColorMode.SelectedIndexChanged += delegate { On_ColorModeChanged(); };
					cboDPI.SelectedIndexChanged += delegate { On_DPIChanged(); };


					cboFileFormat.SelectedIndexChanged += delegate { On_FileFormatChanged(); };
					sldFile_Quality.ValueChanged += delegate { On_FileQualityChanged(); };


					cmdScan_PreView.Click += delegate { ((Action)On_ScanPreview).e_runTryCatch(); };

					chkScan_НесколькоСтраницВручную.Visible = false;
					cmdScan_FullQuality.Click += delegate { ((Action)On_ScanFullQuality).e_runTryCatch(); };

					llScanFolder.LinkClicked += delegate { ((Action)On_DisplayScanDirInExplorer).e_runTryCatch(); };

					//Just disabling bc have a probles with parameters send/get to System UI
					llScanUsingSysUI.Visible = false;                   //llScanUsingSysUI.LinkClicked += delegate { ((Action)On_ScanUsingSysUI).e_runTryCatch(); };



					//this.xPagePreView.OnDrawPage += new System.EventHandler<WIA_Scanner.xPageview.DrawPageEventArgs>(this._OnDrawPage);
					xPageControl.MouseMoveOnPaper += (_, ptfCursorOnPage) =>
					{
						string s = string.Empty;
						string units = Localization.Strings.L_CROP_ZONE_MOUSE_UNITS_CM;
						if (ptfCursorOnPage.HasValue) s = $"x:{ptfCursorOnPage.Value.X.e_Round(2).ToString(" 0.00")}, y:{ptfCursorOnPage.Value.Y.e_Round(2).ToString(" 0.00")}{units}";
						lblMousePos.Text = s;
					};
					chkCropZone_Set.CheckedChanged += delegate { On_CropChanged(); };
					xudCrop_Width.ValueChanged += delegate { On_CropChanged(); };
					xudCrop_Left.ValueChanged += delegate { On_CropChanged(); };
					xudCrop_Height.ValueChanged += delegate { On_CropChanged(); };
					xudCrop_Top.ValueChanged += delegate { On_CropChanged(); };
					xPageControl.OnMouseCropSetup += (_, rcfCrop) => SetCropAreaCm(rcfCrop);

					#endregion
				}



				#region Processing UI settings to update controls statuses

				_canProcessUIEvents = true;

				On_SelectedScannerChanged();

				On_CropChanged();

				On_FileFormatChanged();

				#endregion

				RegisterScanApp();

				Status();
			}



			catch (Exception ex)
			{
				Status(ex.Message);
				ex.e_LogError(true);
				Close();
			}
		}

		private void LocalizeUI()
		{

			//Localizing UI
			sbMain.Text = Localization.Strings.L_READY;
			lblStatus.Text = Localization.Strings.L_READY;
			lblMousePos.Text = "";


			xPageControl.EmptyImagesText = Localization.Strings.L_NO_PREVIEW_IMAGE.e_Wrap();
			xPageControl.CropZoneString = Localization.Strings.L_CROP_ZONE_MOUSE_LABEL;
			xPageControl.CropZoneUnitsCm = Localization.Strings.L_CROP_ZONE_MOUSE_UNITS_CM;


			grpSettings.Text = Localization.Strings.L_SCAN_PARAMS;
			lblScanner.Text = Localization.Strings.L_SCAN_PARAMS_SCANNER;
			lblPageSize.Text = Localization.Strings.L_SCAN_PARAMS_SCANNER_PAGE_SIZE.e_Format(0);
			chkUseAutoFeeder.Text = Localization.Strings.L_SCAN_PARAMS_AUTOFEEDER_USE;
			chkUseAutoFeederDuplex.Text = Localization.Strings.L_SCAN_PARAMS_AUTOFEEDER_DOUBLE_SIDE;

			lblColorMode.Text = Localization.Strings.L_SCAN_PARAMS_MODE;
			lblDPI.Text = Localization.Strings.L_SCAN_PARAMS_DPI;

			cmdScan_PreView.Text = Localization.Strings.L_SCAN_PREVIEW;

			chkCropZone_Set.Text = Localization.Strings.L_CROP_ZONE_SET;
			lblCropZone_X.Text = Localization.Strings.L_CROP_ZONE_X;
			lblCropZone_Y.Text = Localization.Strings.L_CROP_ZONE_Y;
			lblCropZone_W.Text = Localization.Strings.L_CROP_ZONE_W;
			lblCropZone_H.Text = Localization.Strings.L_CROP_ZONE_H;


			lblFileFormat.Text = Localization.Strings.L_SCAN_PARAMS_FILE_FORMAT;
			lblFile_Quality.Text = Localization.Strings.L_SCAN_PARAMS_FILE_QUALITY;
			llScanFolder.Text = Localization.Strings.L_SCAN_PARAMS_FILE_DIR;
			xFileFolder.SelectButtonToolTip = Localization.Strings.L_SCAN_PARAMS_FILE_SELECT;


			grpScanButtons.Text = Localization.Strings.L_SCAN_FULL_QUALITY_GRP;
			llScanUsingSysUI.Text = Localization.Strings.L_SCAN_FULL_QUALITY_USING_OS_UI;
			chkScan_НесколькоСтраницВручную.Text = Localization.Strings.L_SCAN_FULL_QUALITY_MANUAL;
			cmdScan_FullQuality.Text = Localization.Strings.L_SCAN_FULL_QUALITY;




			//this.ttПодсказка.SetToolTip(this.chkScan_НесколькоСтраницВручную, "Сканировать несколько страниц, с переворотом вручную.");

		}


		private void Status(string status = "")
		{
			status = status.e_CheckNullOrWhiteSpace(Localization.Strings.L_READY);

			lblStatus.Text = status;
			Update();
		}


		private void RegisterScanApp()
		{

			/*
			if (WIA_Scanner.uomvb.OS.UserAccounts.mUserAccounts.IsRunAsAdmin())
			{

			return;
			try
			{
				string sEvent = EventID.wiaEventDeviceConnected;
				_WIA_ScanManager.RegisterWIACommand(true, "Сканировать UOM", WiaEvent: sEvent);
			}
			catch
			{
			}

			try
			{
				string sEvent = EventID.wiaEventScanImage;
				_WIA_ScanManager.RegisterWIACommand(true, "Сканировать UOM", WiaEvent: sEvent);
			}
			catch
			{
			}

		}
					 */

		}


		private void _OnDrawPage(object sender, WS.xPageview.DrawPageEventArgs e)
		{
			// With e
			// Dim sText = .ZoomKF.ToString
			// Dim ptCenter = .GraphicsPageRect.Center
			// Dim ptZoom = .Graphics.MeasureStringLocation(sText, Me.Font, ptCenter, ContentAlignment.MiddleCenter)
			// Call .Graphics.DrawString(sText, Me.Font, Brushes.Red, ptZoom)
			// End With
		}



		/*
				private void OnScanParams_DPIChanged(object sender, EventArgs e) => OnScanParams_DPIChanged();
				private void OnScanParams_FileFormatChanged(object sender, EventArgs e) => OnScanParams_FileFormatChanged();
				private void cboFile_Formats_DropDownClosed(object sender, EventArgs e) => cboFile_Formats_DropDownClosed();
				private void OnScanParams_QualityScroll(object sender, EventArgs e) => OnScanParams_QualityScroll();
				private void OnAutoFeederChecked(object sender, EventArgs e) => OnAutoFeederChecked();
				private void OnCrop(object sender, EventArgs e) => OnCrop();
				private void OnCropSize_Changed(object sender, EventArgs e) => OnCropSize_Changed();
				private void OnOpenScanDir(object sender, LinkLabelLinkClickedEventArgs e) => OnOpenScanDir();
				private void _Scan_ShowQuickPreView(object sender, EventArgs e) => _Scan_ShowQuickPreView();
				private void _ScanAndSave(object sender, EventArgs e) => _ScanAndSave();
				private void _Scan_BeginScanUsingSysUI(object sender, LinkLabelLinkClickedEventArgs e) => _Scan_BeginScanUsingSysUI();
		 */





	}
}




