global using WIA;
global using uom.WIA2;
global using static WS.Localization.LStrings;

namespace WS;


internal static class Program
{
	/// <summary>The main entry point for the application.</summary>
	[STAThread]
	static void Main()
	{
		{
			//Localization Test
			/*
			
			//var cul = new CultureInfo("en-US");
			var cul = new CultureInfo("uk-UA");
			Thread.CurrentThread.CurrentCulture = cul;
			 Culture = cul;	
			*/
		}

		ApplicationConfiguration.Initialize();

		try
		{
			using WIAManager mgr = new();
			if (!mgr.GetScanners().Any()) throw new Exception(E_NO_SCANNER_FOUND);
			using frmMain fm = new(mgr);
			Application.Run(fm);
		}
		catch (Exception ex) { ex.eLogError(true); }
	}
}