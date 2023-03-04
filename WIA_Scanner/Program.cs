using uom.WIA2;

namespace WS
{
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
				Localization.Strings.Culture = cul;	
				*/
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try
			{
				using WIAManager mgr = new();
				if (!mgr.GetScanners().Any()) throw new Exception(Localization.Strings.E_NO_SCANNER_FOUND);
				using frmMain fm = new(mgr);
				Application.Run(fm);
			}
			catch (Exception ex) { ex.e_LogError(true); }
		}
	}
}