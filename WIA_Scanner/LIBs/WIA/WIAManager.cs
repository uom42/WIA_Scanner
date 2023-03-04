#nullable enable

using uom.WIA2.Scanner;

using WIA;


namespace uom.WIA2
{


	internal class WIAManager : uom.AutoDisposableCOM
	{
		protected internal DeviceManager _wiaDevMgr;
		protected internal WIA.CommonDialog _wcd = new();

		public WIAManager()
		{
			_wiaDevMgr = new(); // Create DeviceManager
			RegisterDisposableCOMObject(_wiaDevMgr);

			_wiaDevMgr.OnEvent += DeviceManager1_OnEvent;

		}


		private IEnumerable<DeviceInfo> GetDevices(WiaDeviceType devType)
			=> _wiaDevMgr
				.DeviceInfos
				.Cast<DeviceInfo>()
				.Where(dev => dev.Type == devType);

		private bool alreadyAttachedToEvents = false;

		public ScannerDevice[] GetScanners()
		{

			ScannerDevice[] devList = GetDevices(WiaDeviceType.ScannerDeviceType)
					.Select(comDev => new ScannerDevice(this, comDev))
					.ToArray();

			if (!alreadyAttachedToEvents)
			{
				alreadyAttachedToEvents = true;

				/*
				  Scanner events *****************************
					Name: Device disconnected, ID:{143E4E83-6497-11D2-A231-00C04FA31809}, Description:Device disconnected Event
					Name: Device connected, ID:{A28BBADE-64B6-11D2-A231-00C04FA31809}, Description:Device connected Event
					Name: WIA item tree updated, ID:{C9859B91-4AB2-4CD6-A1FC-582EEC55E585}, Description:This event is sent when the WIA item tree is updated by other clients


					Name: Scan/File Button, ID:{FC4767C1-C8B3-48A2-9CFA-2E90CB3D3590}, Description:Scan To File - Button Press
					Name: Scan/E-mail Button, ID:{C686DCEE-54F2-419E-9A27-2FC7F2E98F9E}, Description:Scan To E-mail - Button Press
					Name: Scan/OCR Button, ID:{9D095B89-37D6-4877-AFED-62A297DC6DBE}, Description:Scan To OCR - Button Press
					Name: Scan/Image Button, ID:{A6C5A715-8C6E-11D2-977A-0000F87A926F}, Description:Scan To Image - Button Press				
				 */



				devList.ToList().ForEach(dev =>
				{
					dev.Connect();

					Debug.WriteLine("\n Scanner: " + dev.ToString());

					IEnumerable<DeviceEvent> deviceEvents = dev._deviceConnection!.Events.Cast<DeviceEvent>();
					Debug.WriteLine("\n Scanner events *****************************");

					foreach (DeviceEvent evt in deviceEvents)
					{
						string s = $"Name: {evt.Name}, ID:{evt.EventID}, Description:{evt.Description}";
						Debug.WriteLine(s);

						if (evt.Name.StartsWith("Scan"))
						{
							this._wiaDevMgr.RegisterEvent(evt.EventID, "*");
						}
					}
				});
			}



			return devList;
		}

		private void DeviceManager1_OnEvent(string eventID, String deviceID, String itemID)
		{
			Debug.WriteLine("\n\n\n*********************");

			Debug.WriteLine($"Scanner Event! ID:{eventID}, DeviceID:{deviceID}, ItemID:{itemID}");

			Debug.WriteLine("\n\n\n*********************");

			/*
			Dim dev As Device

		Dim itm As Item

		Dim img As ImageFile

		Dim v As Vector


		Set dev = DeviceManager1.DeviceInfos(DeviceID).Connect

		Set itm = dev.GetItem(ItemID)

		Set img = CommonDialog1.ShowTransfer(itm)

		Set v = img.FileData

		Set Picture1.Picture = v.Picture
				 */
		}




	}



}


