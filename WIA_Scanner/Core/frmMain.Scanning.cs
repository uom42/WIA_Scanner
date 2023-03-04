#nullable enable

using System.Drawing;
using System.Windows.Forms;

using uom.Extensions;
using uom.WIA2;
using uom.WIA2.Scanner;

using WIA;

using WS.Core;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WS
{
	partial class frmMain
	{


		private void On_ScanPreview()
		{
			if (!_canProcessUIEvents || GetSelectedScanner() == null) return;

			ScannerDevice scanner = GetSelectedScanner()!;

			SCANNER_SETTINGS ss = new(this);

			ss.ColorMode |= (int)WIA_IPS_CUR_INTENT.WIA_INTENT_MINIMIZE_SIZE;
			ss.DPI = scanner.MinimumDPI.X;
			ss.FileFormat = (int)WIA_IMAGE_FORMATS.WiaImgFmt_PNG;

			scanner.Preview = WIA_PREVIEW_MODES.WIA_PREVIEW_SCAN;
			scanner.DocumentHandlingSelect = ss.HandlingFlags;
			if (ss.UseAutoFeeder) scanner.FeederPagesToScan = 1;


			void onPageScanCompleted(Image imgScanned)
			{
				if (imgScanned == null) return;
				SizeF imgSizeCm = imgScanned.Size.e_Pixels_To_Inches(ss.DPI_AsPoint).e_InchesToCM();
				RectangleF rcfImageCm = new(0, 0, imgSizeCm.Width, imgSizeCm.Height);

				xPageControl.SetBackImage(imgScanned, rcfImageCm);
			}

			scanner.ScanToMemory(
				ss.DPI_AsPoint,
				ss.ColorMode_WIA,
				ss.FileFormat_WIA,
				onPageScanCompleted,
				cropRectInPixels: null);
		}


		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]//Marking method do not optimized, bc use _ in variable when checkong file existing 
		private void On_ScanFullQuality()
		{
			if (!_canProcessUIEvents || GetSelectedScanner() == null) return;

			SCANNER_SETTINGS ss = SaveScanSettings();

			ScannerDevice scanner = GetSelectedScanner()!;

			ss.ColorMode |= (int)WIA_IPS_CUR_INTENT.WIA_INTENT_MAXIMIZE_QUALITY;
			scanner.Preview = WIA_PREVIEW_MODES.WIA_FINAL_SCAN;
			scanner.DocumentHandlingSelect = ss.HandlingFlags;
			if (ss.UseAutoFeeder)
			{
				//scanner.FeederPagesToScan = WIA_Const.ALL_PAGES;
				//ss.HandlingFlags |= WIA_DPS_DOCUMENT_HANDLING_SELECT.AUTO_ADVANCE;
			}

			//Crop Rect in Pixels
			Rectangle? rcCropPx = (!ss.CropRectCm.HasValue)
				? null
				: ss.CropRectCm.Value.e_CMToInches().e_Inches_To_Pixels(ss.DPI_AsPoint);


			DirectoryInfo diSave = xFileFolder.Directory;
			_ = diSave.LastAccessTime;//Testing dir is exist

			int scannedPagesCount = 0;


			void onPageScanCompleted(FileInfo fiTempCache)
			{
				scannedPagesCount += 1;
				string fileName = DateTime.Now.e_ToFileName().e_ToFlatFileSystemString() + ss.FileFormat_WIA.e_GetOutputInfoForImageFormat().FileExtension;

				FileInfo fiNewPath = new(Path.Combine(diSave.FullName, fileName));
				fiNewPath.e_DeleteIfExist();

				fiTempCache.MoveTo(fiNewPath.FullName);

				Image? img = Image.FromFile(fiNewPath.FullName);
				if (img == null) return;

				SizeF imgSizeCm = img.Size.e_Pixels_To_Inches(ss!.DPI_AsPoint).e_InchesToCM();
				RectangleF rcfImageCm = ss!.CropRectCm.HasValue
					? ss!.CropRectCm.Value
					: new(0, 0, imgSizeCm.Width, imgSizeCm.Height);

				xPageControl.SetFrontImage(img, rcfImageCm);
			}

			int? imageQuality = !ss.FileFormat_WIA.e_HasCompressionQualityParameter()
				? null
				: ss.FileQualityPercent;


			scanner.ScanToFile(
			ss.DPI_AsPoint,
			ss.ColorMode_WIA,
			ss.FileFormat_WIA,
			imageQualityPercent: imageQuality,
			onPageScanCompleted: onPageScanCompleted,
			cropRectInPixels: rcCropPx);

			/*
		void onPageScanRAW(MemoryStream msRaw)
		{
			scannedPagesCount += 1;
			if (msRaw == null) return;

			using MemoryStream msImage = msRaw;
			string fileName = DateTime.Now.e_ToLongDateTimeStamp().e_ToFlatFileSystemString() + ss.FileFormat_WIA.e_GetOutputInfoForImageFormat().FileExtension;
			FileInfo fiNewPath = new(Path.Combine(diSave.FullName, fileName)); fiNewPath.e_DeleteIfExist();

			{
				msImage.Seek(0, SeekOrigin.Begin);
				Image imgScanned = Image.FromStream(msImage);

				SizeF imgSizeCm = imgScanned.Size.e_Pixels_To_Inches(ss.DPI_AsPoint).e_InchesToCM();
				RectangleF rcfImageCm = ss!.CropRectCm.HasValue
					? ss!.CropRectCm.Value
					: new(0, 0, imgSizeCm.Width, imgSizeCm.Height);

				xPageControl.SetFrontImage(imgScanned, rcfImageCm);

				//imgScanned.Save(fiNewPath.FullName);			
			}
		}
		scanner.ScanToRaw(
		ss.DPI_AsPoint,
		ss.ColorMode_WIA,
		ss.FileFormat_WIA,
		onPageScanCompleted: onPageScanRAW,
		cropRectInPixels: rcCropPx);
			*/
		}


		private void On_ScanUsingSysUI()
		{
			if (!_canProcessUIEvents || GetSelectedScanner() == null) return;

			SCANNER_SETTINGS ss = SaveScanSettings();
			ScannerDevice scanner = GetSelectedScanner()!;

			//This don't working in Sys UI mode!
			/*												 
			ss.ColorMode |= (int)WIA_IPS_CUR_INTENT.WIA_INTENT_MAXIMIZE_QUALITY;
			scanner.Preview = WIA_PREVIEW_MODES.WIA_FINAL_SCAN;
			scanner.DocumentHandlingSelect = ss.HandlingFlags;
			if (ss.UseAutoFeeder)
			{
				//scanner.FeederPagesToScan = WIA_Const.ALL_PAGES;
				//ss.HandlingFlags |= WIA_DPS_DOCUMENT_HANDLING_SELECT.AUTO_ADVANCE;
			}

			//Crop Rect in Pixels
			Rectangle? rcCropPx = (!ss.CropRectCm.HasValue)
				? null
				: ss.CropRectCm.Value.e_CMToInches().e_Inches_To_Pixels(ss.DPI_AsPoint);
			 */

			DirectoryInfo diSave = xFileFolder.Directory;
			_ = diSave.LastAccessTime;//Testing dir is exist

			int scannedPagesCount = 0;
			void onPageScanCompleted(SCANNED_IMAGE_INFO wsi)
			{
				scannedPagesCount += 1;
				string fileName = DateTime.Now.e_ToLongDateTimeStamp().e_ToFlatFileSystemString() + ss.FileFormat_WIA.e_GetOutputInfoForImageFormat().FileExtension;

				FileInfo fiNewPath = new(Path.Combine(diSave.FullName, fileName)); fiNewPath.e_DeleteIfExist();
				wsi.File.MoveTo(fiNewPath.FullName);

				Image? img = Image.FromFile(fiNewPath.FullName);
				if (img == null) return;

				RectangleF rcfImageCm = new(
					 new PointF(0, 0),
					 wsi.SizeIn.e_InchesToCM());

				xPageControl.SetFrontImage(img, rcfImageCm);
			}

			int? imageQuality = !ss.FileFormat_WIA.e_HasCompressionQualityParameter()
				? null
				: ss.FileQualityPercent;

			scanner.ScanToFileUsingSysUI(ss.ColorMode_WIA, ss.FileFormat_WIA, onPageScanCompleted: onPageScanCompleted, imageQualityPercent: imageQuality);

		}


		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]//Marking method do not optimized, bc use _ in variable when checkong file existing 
		private void On_DisplayScanDirInExplorer()
		{
			_ = xFileFolder.Directory.CreationTime;
			global::uom.AppTools.StartWinSysTool_Explorer(xFileFolder.Directory.FullName, global::uom.AppTools.WindowsExplorerPathModes.OpenPath);
		}




		/*
		// Private Sub ProcessImage() 'Handles cboRotate.SelectedIndexChanged
		// Call Status("Подготовка результата...")
		// If (_imgScanned Is Nothing) Then Return
		// Me.pbImage.BackgroundImage = _imgScanned


		// 'Me.pbImage.BackgroundImage = _imgModifed
		// '_imgModifed = _imgScanned '_imgScanned.CloneUOM
		// 'Dim iRotate = 0 ' Me.cboRotate.SelectedIndex
		// 'If (iRotate > 0) Then
		// '    Dim eRotation As RotateFlipType = RotateFlipType.Rotate180FlipNone
		// '    Select Case iRotate
		// '        Case 0 'нет
		// '            '
		// '        Case 1 '90
		// '            eRotation = RotateFlipType.Rotate90FlipNone
		// '        Case 2 '180
		// '            eRotation = RotateFlipType.Rotate180FlipNone
		// '        Case 3 '270
		// '            eRotation = RotateFlipType.Rotate270FlipNone
		// '    End Select
		// '    Call _imgModifed.RotateFlip(eRotation)
		// 'End If


		// End Sub

		 */
	}
}