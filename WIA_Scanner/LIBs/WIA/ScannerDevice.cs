#nullable enable

using System.Drawing;

using WIA;


namespace uom.WIA2.Scanner
{

	internal class ScannerDevice : WIADeviceBase
	{

		internal ScannerDevice(WIAManager mgr, DeviceInfo comDevInfo) : base(mgr, comDevInfo) { }

		private Point minimumDPI = default;

		internal Device? _deviceConnection { get; private set; }
		private ScannerCaps? _caps = null;

		public void Connect()
		{
			if (_deviceConnection == null)
			{
				_deviceConnection = _comDevInfo.Connect();
				RegisterDisposableCOMObject(_deviceConnection);
				CalculateMinimumDPI();
			}
			_caps ??= new(this!);
		}
		/// <summary>!!!GETTING MINIMUM DPI changes all scanner settings via changing ScanIntent!!!
		/// </summary>
		private void CalculateMinimumDPI()
		{
			ScanIntent = WIA_IPS_CUR_INTENT.WIA_INTENT_IMAGE_TYPE_COLOR | WIA_IPS_CUR_INTENT.WIA_INTENT_MINIMIZE_SIZE;
			minimumDPI = ScanDPI;
		}

		public ScannerCaps Caps
		{
			get
			{
				Connect();
				return _caps!;
			}
		}

		internal protected Properties _props
		{
			get
			{
				Connect();
				return _deviceConnection!.Properties;
			}
		}





		/// <summary>Scanner paper source
		/// Setting source valid only on Multisources Scanners. (If set this on SingleSource Scanners Error may hapens</summary>
		public WIA_DPS_DOCUMENT_HANDLING_SELECT? DocumentHandlingSelect
		{
			get => _props
				.e_SearchWiaPropertyByID(WIA_PROP_ID.WIA_DPS_DOCUMENT_HANDLING_SELECT)?
				.e_GetWiaPropertyValue((WIA_DPS_DOCUMENT_HANDLING_SELECT)0);
			set
			{
				if (Caps.DocumentHandlingCaps_MultuSources)
					_props
						.e_SearchWiaPropertyByID(WIA_PROP_ID.WIA_DPS_DOCUMENT_HANDLING_SELECT)?
						.e_SetWiaPropertyValue(value!);
			}
		}

		/// <summary>Source Status</summary>
		public WIA_DPS_DOCUMENT_HANDLING_STATUS? DocumentHandlingStatus
		{
			get => _props
				.e_SearchWiaPropertyByID(WIA_PROP_ID.WIA_DPS_DOCUMENT_HANDLING_STATUS)?
				.e_GetWiaPropertyValue((WIA_DPS_DOCUMENT_HANDLING_STATUS)0);
		}


		/// <summary>
		/// Contains the current number of pages to be acquired from an automatic document feeder. The minidriver creates and maintains this property.
		/// Access: Read/Write; Valid values: WIA_PROP_RANGE(zero through the maximum number of pages that the document feeder can hold)
		/// An application reads this property to determine the document feeder's page capacity. The application also sets this property to the number of pages it is going to scan.
		/// [!Note]
		/// If duplex mode is enabled(WIA_DPS_DOCUMENT_HANDLING_SELECT is set to FEEDER | DUPLEX ), WIA_DPS_PAGES is still equal to the number of pages to scan.
		/// One sheet of paper will automatically contain two pages if DUPLEX is enabled, even if the back side of the page is blank.
		/// Setting WIA_DPS_PAGES to 1 causes a scanner to process one of the sides of the page.It is recommended that if a scanner is unable to scan only one side of a page while in duplex mode, the WIA_DPS_PAGES valid value for the Inc member of the WIA_PROPERTY_INFO structure should be changed to 2. This value signals the application that it must request pages in multiples of two.A value of zero means that all pages that are currently loaded into the document feeder are to be scanned.
		/// 
		/// Note: Normally ShowTransfer() method scan all pages inserted in the scanner. If you want to change this default value, you can use 3096 property as follows:
		/// 0 means fast scan, 
		/// 1 means single page scan, 
		/// 2 means double scan, dublex. 
		/// 
		/// And also set above DocumentHandlingSelect property as FEEDER | DUPLEX
		/// </summary>
		public int FeederPagesToScan
		{
			get => _props.e_GetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_PAGES, 0);
			set => _props.e_SetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_PAGES, value);
		}


		public WIA_PREVIEW_MODES Preview
		{
			get => _props.e_GetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_PREVIEW, WIA_PREVIEW_MODES.WIA_PREVIEW_SCAN);
			set => _props.e_SetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_PREVIEW, value);
		}

		/// <summary>Contains the maximum time to scan a single page with the current property settings, in milliseconds. 
		/// An application reads this property to estimate the time it will take to scan a page. 
		/// This is helpful when determining the conditions of a device that has stopped responding. 
		/// The minidriver creates and maintains this property. This property is required for all scanners.
		/// </summary>
		public TimeSpan MaxScanTime
		{
			get
			{
				//Max Scan Time:LongPropertyType(3095) = "3600000"
				int milisec = _props.e_GetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_MAX_SCAN_TIME, 0);
				return TimeSpan.FromMilliseconds(milisec);
			}
		}


		internal Item ScanCommand
		{
			get
			{
				Connect();
				Items wiaItems = _deviceConnection!.Items;
				Item scanCommand = wiaItems[1]; // set properties 'BIG SNAG!! if you call WiaDev.Items[1] apprently it erases the item from memory so you cant call it again
				return scanCommand;
			}
		}



		/// <summary>Contains the maximum time to scan a single page with the current property settings, in milliseconds. 
		/// An application reads this property to estimate the time it will take to scan a page. 
		/// This is helpful when determining the conditions of a device that has stopped responding. 
		/// The minidriver creates and maintains this property. This property is required for all scanners.
		/// </summary>
		public WIA_IPS_CUR_INTENT ScanIntent
		{
			get => ScanCommand.e_GetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_CUR_INTENT, (WIA_IPS_CUR_INTENT)0);
			set => ScanCommand.e_SetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_CUR_INTENT, value);
		}

		public Point MinimumDPI => minimumDPI;

		public Point ScanDPI
		{
			get
			{
				Item sc = ScanCommand;
				return new(
				sc.e_GetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_XRES, 0),
				sc.e_GetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_YRES, 0)
				);
			}
			set
			{
				Item sc = ScanCommand;
				sc.e_SetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_XRES, value.X);
				sc.e_SetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_YRES, value.Y);
			}
		}

		public Rectangle CropRectPx
		{
			get
			{

				Item cmd = ScanCommand;
				Rectangle rcCrop = new(
					cmd.e_GetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_XPOS, -1),
					cmd.e_GetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_YPOS, -1),
					cmd.e_GetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_XEXTENT, -1),
					cmd.e_GetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_YEXTENT, -1));

				return rcCrop;
			}
			set
			{
				Item cmd = ScanCommand;
				cmd.e_SetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_XPOS, value.Left);
				cmd.e_SetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_YPOS, value.Top);
				cmd.e_SetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_XEXTENT, value.Width);
				cmd.e_SetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_YEXTENT, value.Height);
			}
		}






		#region Scan

		const string IMAGE_FORMAT_UNSPECIFED = "{00000000-0000-0000-0000-000000000000}";

		private void Scan(
				Point dpi,
				WIA_IPS_CUR_INTENT colorMode,
				Action<MemoryStream>? onPageScanToRAW = null,
				Action<System.Drawing.Image>? onPageScanToMemoryCompleted = null,
				Action<FileInfo>? onPageScanToFileCompleted = null,
				WIA_IMAGE_FORMATS? fileFormat = null,
				Rectangle? cropRectInPixels = null,
				int? imageQualityPercentForFile = null
				)
		{

			Connect();

			try // Начинаем сканировать страницу
			{
				ScanIntent = colorMode;
				ScanDPI = dpi;

				SizeF sourceSizeIn = (Caps.DocumentHandlingCaps_CanAutoFeed && DocumentHandlingSelect!.Value.HasFlag(WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER))
					? Caps.Feeder_Caps!.SheetSizeIn
					: Caps.FlatBed_Caps!.SizeIn;

				Rectangle defaultPageRectPix = new(
					new Point(0, 0),
					sourceSizeIn.e_Inches_To_Pixels(dpi));

				CropRectPx = !cropRectInPixels.HasValue
					? defaultPageRectPix
					: cropRectInPixels.Value;

				/*
				scanCommand.e_SetPropertyValue(WIA_PROP_ID.WIA_IPS_BRIGHTNESS, brightnessPercents);
				scanCommand.e_SetPropertyValue(WIA_PROP_ID.WIA_IPS_CONTRAST, contrastPercents);

				//brightness
			Device.Items[1].Properties["Brightness"].set_Value(Scanner.Brightness);

			//contrast
			Device.Items[1].Properties["Contrast"].set_Value(Scanner.Contrast);

				  switch (Scanner.Format)
			{
				case 0://A3
					Device.Items[1].Properties["3097"].set_Value(10);
					//Device.Items[1].Properties["6151"].set_Value(11692);
					//Device.Items[1].Properties["6152"].set_Value(16535);
					break;

				case 1://A4
					Device.Items[1].Properties["3097"].set_Value(0);
					//Device.Items[1].Properties["6156"].set_Value(1);
					//Device.Items[1].Properties["3098"].set_Value(8267);
					//Device.Items[1].Properties["3099"].set_Value(11692);
					////Device.Items[1].Properties["6151"].set_Value(1165 * 2);
					////Device.Items[1].Properties["6152"].set_Value(1653 * 2);
					////Device.Items[1].Properties["3097"].set_Value("0");
					break;

				case 2://A5
					Device.Items[1].Properties["3097"].set_Value(11);
					//Device.Items[1].Properties["6151"].set_Value(1165);
					//Device.Items[1].Properties["6152"].set_Value(1653);
					break;
			}

				 */

				Item cmd = ScanCommand;
				bool hasMorePages = false;
				do
				{
					ImageFile? wiaImage = (ImageFile)(_manager._wcd.ShowTransfer(cmd, IMAGE_FORMAT_UNSPECIFED, false));
					if (wiaImage == null) return; // Сканирование отменено (нажата отмена)


					if (onPageScanToRAW != null)
					{
						MemoryStream msRAW = wiaImage.WIAImageToRawBytes();
						Marshal.ReleaseComObject(wiaImage);
						wiaImage = null;
						onPageScanToRAW.Invoke(msRAW);
					}
					else if (onPageScanToMemoryCompleted != null)
					{
						Image? imgMem = wiaImage.WIAImageToNETImageMem();
						Marshal.ReleaseComObject(wiaImage);
						wiaImage = null;
						if (imgMem != null) onPageScanToMemoryCompleted.Invoke(imgMem);
					}
					else if (onPageScanToFileCompleted != null)
					{
						WIA_IMAGE_FORMATS wf = fileFormat!.Value;
						var wiaFormat = wf.e_GetOutputInfoForImageFormat();

						FileInfo fiTempCache = wiaImage.WIAImageToNETImageFile(wf, imageQualityPercent: imageQualityPercentForFile);
						Marshal.ReleaseComObject(wiaImage);
						wiaImage = null;
						if (fiTempCache != null) onPageScanToFileCompleted.Invoke(fiTempCache);
					}

					//determine if there are any more pages waiting				 
					WIA_DPS_DOCUMENT_HANDLING_SELECT? dhSel = DocumentHandlingSelect;
					WIA_DPS_DOCUMENT_HANDLING_STATUS? dhStat = DocumentHandlingStatus;

					hasMorePages = dhSel.HasValue
						&& dhSel.Value.HasFlag(WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER)
						&& dhStat.HasValue
						&& dhStat.Value.HasFlag(WIA_DPS_DOCUMENT_HANDLING_STATUS.FEED_READY);


				} while (hasMorePages);


			}

			catch (COMException exCOM)
			{
				// Convert the error code to UINT
				uint errorCode = (uint)exCOM.ErrorCode;
				// See the error codes
				if (errorCode == 0x80210006)
				{
					Console.WriteLine("The scanner is busy or isn't ready");
				}
				else if (errorCode == 0x80210064)
				{
					Console.WriteLine("The scanning process has been cancelled.");
				}
				else if (errorCode == 0x8021000C)
				{
					Console.WriteLine("There is an incorrect setting on the WIA device.");
				}
				else if (errorCode == 0x80210005)
				{
					Console.WriteLine("The device is offline. Make sure the device is powered on and connected to the PC.");
				}
				else if (errorCode == 0x80210001)
				{
					Console.WriteLine("An unknown error has occurred with the WIA device.");
				}


				// paper empty
				WIA_ERRORS EX = (WIA_ERRORS)exCOM.ErrorCode;
				switch (EX)
				{
					case WIA_ERRORS.WIA_ERROR_PAPER_EMPTY:
						// Нет листа! Ничего не делаем!
						break;

					default: throw;
				}
			}
			finally { }
		}


		public void ScanToFile(
			Point dpi,
			WIA_IPS_CUR_INTENT colorMode,
			WIA_IMAGE_FORMATS format,
			Action<FileInfo> onPageScanCompleted,
			int? imageQualityPercent = null,
			Rectangle? cropRectInPixels = null
			)
		{
			Scan(dpi, colorMode, onPageScanToFileCompleted: onPageScanCompleted, fileFormat: format, cropRectInPixels: cropRectInPixels, imageQualityPercentForFile: imageQualityPercent);
		}


		public void
			ScanToFileUsingSysUI(
			WIA_IPS_CUR_INTENT colorMode,
			WIA_IMAGE_FORMATS format,
			Action<SCANNED_IMAGE_INFO> onPageScanCompleted,
			int? imageQualityPercent = null
			)
		{

			throw new NotImplementedException();
			//Disabling this block bc. we hass troubles to set/get scanning paramenets when using SystemUI

			/*	


			ScanIntent = colorMode;
			ScanDPI = new Point(300, 300);

			SizeF sourceSizeIn = (Caps.DocumentHandlingCaps_CanAutoFeed && DocumentHandlingSelect!.Value.HasFlag(WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER))
				? Caps.Feeder_Caps!.SheetSizeIn
				: Caps.FlatBed_Caps!.SizeIn;

			CropRectPx = new Rectangle(100, 100, 200, 300);

			//This don't working in Sys UI mode!
			 

			bool hasMorePages = false;
			do
			{
				ImageFile? wiaImage = (ImageFile)(_manager._wcd.ShowAcquireImage(
					  WiaDeviceType.ScannerDeviceType,
					  (WiaImageIntent)((int)colorMode),
					  WiaImageBias.MaximizeQuality,
					  IMAGE_FORMAT_UNSPECIFED,
					  false,
					  false,
					  false));

				if (wiaImage == null) return; // Сканирование отменено (нажата отмена)

				if (onPageScanCompleted != null)
				{
					Point dpi = new(
						(int)wiaImage.HorizontalResolution.e_Round(0),
						(int)wiaImage.VerticalResolution.e_Round(0));

					Size imageSizePx = new(wiaImage.Width, wiaImage.Height);
					SizeF imageSizeIn = imageSizePx.e_Pixels_To_Inches(dpi);

					FileInfo fiTempCache = wiaImage.WIAImageToNETImageFile(format, imageQualityPercent: imageQualityPercent);
					Marshal.ReleaseComObject(wiaImage);
					wiaImage = null;

					if (fiTempCache != null)
					{
						colorMode = ScanIntent;
						var rrr = CropRectPx;

						WIA_SCANNED_IMAGE wsi = new(fiTempCache, dpi, imageSizeIn);
						onPageScanCompleted.Invoke(wsi);
					}
				}

				return;

				//determine if there are any more pages waiting				 
				WIA_DPS_DOCUMENT_HANDLING_SELECT? dhSel = DocumentHandlingSelect;
				WIA_DPS_DOCUMENT_HANDLING_STATUS? dhStat = DocumentHandlingStatus;

				hasMorePages = dhSel.HasValue
					&& dhSel.Value.HasFlag(WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER)
					&& dhStat.HasValue
					&& dhStat.Value.HasFlag(WIA_DPS_DOCUMENT_HANDLING_STATUS.FEED_READY);


			} while (hasMorePages);
			*/
		}


		public void ScanToMemory(
			Point dpi,
			WIA_IPS_CUR_INTENT colorMode,
			WIA_IMAGE_FORMATS format,
			Action<System.Drawing.Image> onPageScanCompleted,
			Rectangle? cropRectInPixels = null
			)
		{
			Scan(dpi, colorMode, onPageScanToMemoryCompleted: onPageScanCompleted, cropRectInPixels: cropRectInPixels);
		}

		public void ScanToRaw(
			Point dpi,
			WIA_IPS_CUR_INTENT colorMode,
			WIA_IMAGE_FORMATS format,
			Action<MemoryStream> onPageScanCompleted,
			Rectangle? cropRectInPixels = null
			)
		{
			Scan(dpi, colorMode, onPageScanToRAW: onPageScanCompleted, cropRectInPixels: cropRectInPixels);
		}





		#endregion




	}
}


