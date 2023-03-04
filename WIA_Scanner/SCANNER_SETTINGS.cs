#nullable enable


namespace WS;



[Serializable]
public class SCANNER_SETTINGS
{

	private const string FILE_NAME = "ScannerSettings.xml";

	private static readonly Lazy<FileInfo> _fiSettings = new(() => uom.AppTools.GetFileIn_AppData(FILE_NAME, true).eToFileInfo()!);



	#region Public Serializable Props

	public string ScannerID = string.Empty;

	public bool UseAutoFeeder = false;
	public bool UseAutoFeederDuplex = false;

	public int ColorMode = 0;
	public int DPI = 300;

	public RectangleF? CropRectCm = null;

	public string SaveDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
	public int FileFormat = 0;
	public int FileQualityPercent = 100;

	#endregion


	#region Internal Props

	internal WIA_DPS_DOCUMENT_HANDLING_SELECT HandlingFlags;
	internal WIA_IPS_CUR_INTENT ColorMode_WIA => (WIA_IPS_CUR_INTENT)ColorMode;
	internal WIA_IMAGE_FORMATS FileFormat_WIA => (WIA_IMAGE_FORMATS)FileFormat;
	internal Point DPI_AsPoint => new(DPI, DPI);

	#endregion


	public SCANNER_SETTINGS() { }


	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]//Marking method do not optimized, bc use _ in variable when checking file existing 
	internal SCANNER_SETTINGS(frmMain fm) : this()
	{
		ScannerID = fm.GetSelectedScanner()!.ID;

		(UseAutoFeeder, UseAutoFeederDuplex, HandlingFlags) = fm.GetSelectedPaperSource();
		ColorMode = (int)fm.cboColorMode.eSelectedItemAs_ObjectContainerValue<WIA_IPS_CUR_INTENT>();
		DPI = fm.cboDPI.eSelectedItemAs_ObjectContainerValue<int>();

		CropRectCm = !fm.chkCropZone_Set.Checked
			? null
			: new RectangleF(
				   (float)fm.xudCrop_Left.Value,
				   (float)fm.xudCrop_Top.Value,
				   (float)fm.xudCrop_Width.Value,
				   (float)fm.xudCrop_Height.Value);

		if (CropRectCm.HasValue)
			CropRectCm = CropRectCm.Value.eEnsureInRect(fm.ScannerPaperSourceSizeCm!.Value.eToRectangleF());


		var ff = fm.GetSelectedFileFormat();
		FileFormat = (int)ff.format!.Value!;
		if (FileFormat_WIA.eHasCompressionQualityParameter()) FileQualityPercent = fm.sldFile_Quality.Value;

		try
		{
			DirectoryInfo diSave = fm.xFileFolder.Directory;
			_ = diSave.LastAccessTime;//Testing dir is exist
			SaveDir = diSave.FullName;
		}
		catch
		{
			string defaultSaveDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			SaveDir = defaultSaveDir;
		}
	}



	public void Save()
	{
		string XML = this.eSerializeAsXML();
		SCANNER_SETTINGS? Test2 = XML.eDeSerializeXML<SCANNER_SETTINGS>();//Testing deserialization
		_fiSettings.Value.eWriteAllText(XML);
	}

	public static SCANNER_SETTINGS Load()
	{
		try
		{
			if (_fiSettings.Value.Exists)
			{
				string xml = _fiSettings.Value.eReadAsText()!;
				SCANNER_SETTINGS? ss = xml.eDeSerializeXML<SCANNER_SETTINGS>();
				if (ss != null) return ss!;

			}
			//else returning default settings
		}
		catch { }//If any errors occur - ignore it and returning default settings

		//Returning default settings
		return new SCANNER_SETTINGS();
	}
}