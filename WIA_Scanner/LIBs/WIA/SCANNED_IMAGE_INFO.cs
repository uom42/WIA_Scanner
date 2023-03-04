#nullable enable

using System.Drawing;

namespace uom.WIA2.Scanner
{
	public struct SCANNED_IMAGE_INFO
	{
		public readonly FileInfo @File;
		public readonly Point DPI;
		public readonly SizeF SizeIn;

		public SCANNED_IMAGE_INFO(FileInfo fi, Point dpi, SizeF sizeIn)
		{
			@File = fi;
			DPI = dpi;
			SizeIn = sizeIn;
		}
	}

}
