#nullable enable


using uom.WIA2.Scanner;


namespace WS;


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
		Text = Application.ProductName + " " + Assembly.GetExecutingAssembly().GetName().Version!.ToString();

		this.eStartAutoupdateOnShown("https://raw.githubusercontent.com/uom42/WIA_Scanner/master/UpdaterXML.xml");

		try
		{

			Status(L_INITIALIZING);

			LocalizeUI();

			SCANNER_SETTINGS ss = LoadScanSettings();

			//Fill scanners list
			{
				ScannerDevice[] scannersList = _scanManager.GetScanners();
				ScannerDevice? lastUsedScanner = scannersList.Where(dev => dev.ID == ss.ScannerID).FirstOrDefault();
				cboScannerSelect.eFillWithContainersOf(scannersList, lastUsedScanner);
			}

			//Color mode and DPI
			{
				cboColorMode.eFill(colorModes, selectedItem: ss.ColorMode_WIA);

				//Just populate DPI Combobox with FAKE last saved DPI from scanner settings
				//When user selects scanner - dpi list will be updated ()
				cboDPI.eFillWithContainersOf<int>(ss.DPI.eToArrayOf(), ss.DPI);
			}

			//File format and storage
			{
				cboFileFormat.eFill(fileFormats, selectedItem: ss.FileFormat_WIA);

				sldFile_Quality.Value = 100;

				if (ss.FileFormat_WIA.eHasCompressionQualityParameter())
				{
					sldFile_Quality.Value = ss.FileQualityPercent;
				}

				xFileFolder.FullPath = ss.SaveDir;
			}

			cmdScan_PreView.Enabled = false;
			cmdScan_FullQuality.Enabled = false;

			#region Attaching UI Events

			cboScannerSelect.SelectedIndexChanged += delegate { On_SelectedScannerChanged(); };

			chkUseAutoFeeder.CheckedChanged += delegate { On_PaperSourceChanged(); };
			chkUseAutoFeederDuplex.CheckedChanged += delegate { On_PaperSizeChanged(); };

			cboColorMode.SelectedIndexChanged += delegate { On_ColorModeChanged(); };
			cboDPI.SelectedIndexChanged += delegate { On_DPIChanged(); };


			cboFileFormat.SelectedIndexChanged += delegate { On_FileFormatChanged(); };
			sldFile_Quality.ValueChanged += delegate { On_FileQualityChanged(); };


			cmdScan_PreView.Click += delegate { ((Action)On_ScanPreview).erunTryCatch(); };

			chkScan_НесколькоСтраницВручную.Visible = false;
			cmdScan_FullQuality.Click += delegate { ((Action)On_ScanFullQuality).erunTryCatch(); };

			llScanFolder.LinkClicked += delegate { ((Action)On_DisplayScanDirInExplorer).erunTryCatch(); };

			//Just disabling bc have a probles with parameters send/get to System UI
			llScanUsingSysUI.Visible = false;
			//llScanUsingSysUI.LinkClicked += delegate { ((Action)On_ScanUsingSysUI).erunTryCatch(); };


			chkCropZone_Set.CheckedChanged += delegate { On_CropChanged(); };
			xudCrop_Width.ValueChanged += delegate { On_CropChanged(); };
			xudCrop_Left.ValueChanged += delegate { On_CropChanged(); };
			xudCrop_Height.ValueChanged += delegate { On_CropChanged(); };
			xudCrop_Top.ValueChanged += delegate { On_CropChanged(); };


			xPageControl.MouseMove += (_, ptfCursorOnPage) =>
			{
				//string units = L_CROP_ZONE_MOUSE_UNITS_CM;
				lblMousePos.Text = !ptfCursorOnPage.HasValue
					? string.Empty
					: $"Cursor: {ptfCursorOnPage.Value.X:N2},{ptfCursorOnPage.Value.Y:N2}";
			};
			xPageControl.CropZoneCompleted += (_, rcfCrop) => SetCropAreaCm(rcfCrop);

			#endregion


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
			ex.eLogError(true);
			Close();
		}
	}


	private void LocalizeUI()
	{

		//Localizing UI
		sbMain.Text = L_READY;
		lblStatus.Text = L_READY;
		lblMousePos.Text = "";


		xPageControl.EmptyImagesText = L_NO_PREVIEW_IMAGE.eWrap();
		xPageControl.CropZoneString = L_CROP_ZONE_MOUSE_LABEL;
		xPageControl.CropZoneUnitsCm = L_CROP_ZONE_MOUSE_UNITS_CM;


		grpSettings.Text = L_SCAN_PARAMS;
		lblScanner.Text = L_SCAN_PARAMS_SCANNER;
		lblPageSize.Text = L_SCAN_PARAMS_SCANNER_PAGE_SIZE.eFormat(0);
		chkUseAutoFeeder.Text = L_SCAN_PARAMS_AUTOFEEDER_USE;
		chkUseAutoFeederDuplex.Text = L_SCAN_PARAMS_AUTOFEEDER_DOUBLE_SIDE;

		lblColorMode.Text = L_SCAN_PARAMS_MODE;
		lblDPI.Text = L_SCAN_PARAMS_DPI;

		cmdScan_PreView.Text = L_SCAN_PREVIEW;

		chkCropZone_Set.Text = L_CROP_ZONE_SET;
		lblCropZone_X.Text = L_CROP_ZONE_X;
		lblCropZone_Y.Text = L_CROP_ZONE_Y;
		lblCropZone_W.Text = L_CROP_ZONE_W;
		lblCropZone_H.Text = L_CROP_ZONE_H;


		lblFileFormat.Text = L_SCAN_PARAMS_FILE_FORMAT;
		lblFile_Quality.Text = L_SCAN_PARAMS_FILE_QUALITY;
		llScanFolder.Text = L_SCAN_PARAMS_FILE_DIR;
		xFileFolder.SelectButtonToolTip = L_SCAN_PARAMS_FILE_SELECT;


		grpScanButtons.Text = L_SCAN_FULL_QUALITY_GRP;
		llScanUsingSysUI.Text = L_SCAN_FULL_QUALITY_USING_OS_UI;
		chkScan_НесколькоСтраницВручную.Text = L_SCAN_FULL_QUALITY_MANUAL;
		cmdScan_FullQuality.Text = L_SCAN_FULL_QUALITY;


		var svgScaner = uom.AppInfo.Assembly.eLoadSVGFromResourceFile("scanner-svgrepo-com.svg");
		xPageControl.EmptyImagesLogo = svgScaner;

		this.Icon = svgScaner.eToIcon();

		/*
FileInfo fi = new(@"C:\Users\uom\Desktop\1.ico");
using FileStream fs = fi.Create();
svg.eWriteIconSet(fs);
 */



		cmdScan_FullQuality.Image = svgScaner.eToBitmap(false);
		cmdScan_FullQuality.TextImageRelation = TextImageRelation.ImageBeforeText;

		//cmdScan_PreView.Image = uom.AppInfo.Assembly.eLoadSVGFromResourceFile("preview-svgrepo-com.svg").eToBitmap(false);
		//cmdScan_PreView.TextImageRelation = TextImageRelation.ImageBeforeText;



		//lblMousePos.Text = "xy";

		/*
		this.lblPageSize.Text = "Page Size:";
		this.lblDPI.Text = "разрешение:";
		this.lblColorMode.Text = "Режим:";
		this.chkUseAutoFeeder.Text = "Через автоподатчик";
		this.chkUseAutoFeederDuplex.Text = "С обеих строн листа";
		this.lblFileFormat.Text = "Формат:";
		this.lblCropZone_X.Text = "Слева:";
		this.lblCropZone_Y.Text = "Сверху:";
		this.lblCropZone_W.Text = "Ширина:";
		this.lblCropZone_H.Text = "Высота:";
		this.fileOpenSelector1.SelectButtonToolTip = "Select...";
		 */

	}


	private void Status(string status = "")
	{
		status = status.eCheckNullOrWhiteSpace(L_READY);

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




