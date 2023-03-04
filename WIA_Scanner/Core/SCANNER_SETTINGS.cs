#nullable enable

using System.Drawing;

using uom.Extensions;
using uom.WIA2;
using uom.WIA2.Scanner;

namespace WS
{


	[Serializable]
	public class SCANNER_SETTINGS
	{

		#region Public Serializable Props

		public string ScannerID = string.Empty;

		public bool UseAutoFeeder = false;
		public bool UseAutoFeederDuplex = false;

		public int ColorMode = 0;
		public int DPI = 300;

		//public bool Crop = false;
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


		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]//Marking method do not optimized, bc use _ in variable when checkong file existing 
		internal SCANNER_SETTINGS(frmMain fm) : this()
		{
			ScannerID = fm.GetSelectedScanner()!.ID;

			(UseAutoFeeder, UseAutoFeederDuplex, HandlingFlags) = fm.GetSelectedPaperSource();
			ColorMode = (int)fm.cboColorMode.e_SelectedItemAs_ObjectContainerValue<WIA_IPS_CUR_INTENT>();
			DPI = fm.cboDPI.e_SelectedItemAs_ObjectContainerValue<int>();

			CropRectCm = !fm.chkCropZone_Set.Checked
				? null
				: new RectangleF(
					   (float)fm.xudCrop_Left.Value,
					   (float)fm.xudCrop_Top.Value,
					   (float)fm.xudCrop_Width.Value,
					   (float)fm.xudCrop_Height.Value);

			if (CropRectCm.HasValue)
				CropRectCm = CropRectCm.Value.e_EnsureInRect(fm.ScannerPaperSourceSizeCm!.Value.e_ToRectangleF());


			var ff = fm.GetSelectedFileFormat();
			FileFormat = (int)ff.format!.Value!;
			if (FileFormat_WIA.e_HasCompressionQualityParameter()) FileQualityPercent = fm.sldFile_Quality.Value;

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


		private const string FILE_NAME = "ScannerSettings.xml";
		private static FileInfo file = FILE_NAME.e_GetFileIn_AppData_Roaming().e_ToFileInfo()!;

		public void Save()
		{
			string XML = this.e_SerializeAsXML();
			SCANNER_SETTINGS? Test2 = XML.e_DeSerializeXML<SCANNER_SETTINGS>();//Testing deserialization
			file.e_WriteAllText(XML);
		}

		public static SCANNER_SETTINGS Load()
		{
			try
			{
				if (file.Exists)
				{
					string xml = file.e_ReadAsText()!;
					SCANNER_SETTINGS? ss = xml.e_DeSerializeXML<SCANNER_SETTINGS>();
					if (ss != null) return ss!;

				}
				//else returning default settings
			}
			catch { }//If any errors occur - ignore it and returning default settings

			//Returning default settings
			return new SCANNER_SETTINGS();
		}
	}

}