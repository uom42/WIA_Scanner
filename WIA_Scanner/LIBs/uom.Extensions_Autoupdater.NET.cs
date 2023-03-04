#nullable enable

using AutoUpdaterDotNET;


namespace uom.Extensions;


/// <summary>
/// https://github.com/ravibpatel/AutoUpdater.NET
/// </summary>
internal static class Extensions_AutoUpdaterDotNET
{

	/*
	Thread BackgroundThread = new(CheckForUpdates) { IsBackground = true };
	BackgroundThread.SetApartmentState(System.Threading.ApartmentState.STA);
	BackgroundThread.Start();
	 */

	public static void eStartAutoupdateOnShown(this Form f, string updaterXML, bool sync = true, bool runUpdateAsAdmin = false)
	{
		AutoUpdater.Synchronous = sync;
		AutoUpdater.RunUpdateAsAdmin = false;
		AutoUpdater.ShowSkipButton = false;

#if NET
		AutoUpdater.InstalledVersion = uom.AppInfo.AssemblyVersion!;
#endif


		//AutoUpdater.SetOwner(this);
		f.Shown += async (_, _) => await CheckForAppUpdates(updaterXML);
	}

	private async static Task CheckForAppUpdates(string updaterXML)
		=> await Task.Run(delegate { AutoUpdater.Start(updaterXML); });
}