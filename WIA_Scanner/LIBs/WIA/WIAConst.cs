#nullable enable


namespace uom.WIA2;


#region WIA CONSTANTS


[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
internal class WiaFormatFileExtensionAttribute : System.Attribute
{
	public readonly string FileExtension = string.Empty;
	public WiaFormatFileExtensionAttribute(string dottedExt) : base() { FileExtension = dottedExt; }
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
internal class WiaFormatAttribute : System.Attribute
{
	public readonly WIA_IMAGE_FORMATS @Format;
	public WiaFormatAttribute(WIA_IMAGE_FORMATS f) : base() { this.Format = f; }
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
internal class WiaFormatQualityAttribute : System.Attribute
{
	public readonly bool HasQualityParam;
	public WiaFormatQualityAttribute(bool hqp = true) : base() { this.HasQualityParam = hqp; }
}

//WIA_Const.WiaImgFmt_BMP
internal enum WIA_IMAGE_FORMATS : int
{
	[WiaFormatFileExtension(".bmp")] WiaImgFmt_BMP,
	[WiaFormatFileExtension(".emf")] WiaImgFmt_EMF,
	[WiaFormatFileExtension(".wmf")] WiaImgFmt_WMF,
	[WiaFormatFileExtension(".jpg"), WiaFormatQuality] WiaImgFmt_JPEG,
	[WiaFormatFileExtension(".png"), WiaFormatQuality] WiaImgFmt_PNG,
	[WiaFormatFileExtension(".gif"), WiaFormatQuality] WiaImgFmt_GIF,
	[WiaFormatFileExtension(".tif"), WiaFormatQuality] WiaImgFmt_TIFF,
	[WiaFormatFileExtension(".ico")] WiaImgFmt_ICO
}


internal static class WIAConst
{
	/// <summary>WIA_DPS_PAGES constants</summary>
	internal const int ALL_PAGES = 0;

	#region WIA image format constants (!!! Do not move this into diferent namespace or class! this will broke eToFormatGuid(this WIA_IMAGE_FORMATS f) via reflection !!!)

	[WiaFormat(WIA_IMAGE_FORMATS.WiaImgFmt_BMP)] internal static readonly Guid WiaImgFmt_BMP = new(0xb96b3cab, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	[WiaFormat(WIA_IMAGE_FORMATS.WiaImgFmt_EMF)] internal static readonly Guid WiaImgFmt_EMF = new(0xb96b3cac, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	[WiaFormat(WIA_IMAGE_FORMATS.WiaImgFmt_WMF)] internal static readonly Guid WiaImgFmt_WMF = new(0xb96b3cad, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	[WiaFormat(WIA_IMAGE_FORMATS.WiaImgFmt_JPEG)] internal static readonly Guid WiaImgFmt_JPEG = new(0xb96b3cae, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	[WiaFormat(WIA_IMAGE_FORMATS.WiaImgFmt_PNG)] internal static readonly Guid WiaImgFmt_PNG = new(0xb96b3caf, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	[WiaFormat(WIA_IMAGE_FORMATS.WiaImgFmt_GIF)] internal static readonly Guid WiaImgFmt_GIF = new(0xb96b3cb0, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	[WiaFormat(WIA_IMAGE_FORMATS.WiaImgFmt_TIFF)] internal static readonly Guid WiaImgFmt_TIFF = new(0xb96b3cb1, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	[WiaFormat(WIA_IMAGE_FORMATS.WiaImgFmt_ICO)] internal static readonly Guid WiaImgFmt_ICO = new(0xb96b3cb5, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	internal static readonly Guid WiaImgFmt_UNDEFINED = new(0xb96b3ca9, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	internal static readonly Guid WiaImgFmt_RAWRGB = new(0xbca48b55, 0xf272, 0x4371, 0xb0, 0xf1, 0x4a, 0x15, 0x0d, 0x05, 0x7b, 0xb4);
	internal static readonly Guid WiaImgFmt_MEMORYBMP = new(0xb96b3caa, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	internal static readonly Guid WiaImgFmt_EXIF = new(0xb96b3cb2, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	internal static readonly Guid WiaImgFmt_PHOTOCD = new(0xb96b3cb3, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	internal static readonly Guid WiaImgFmt_FLASHPIX = new(0xb96b3cb4, 0x0728, 0x11d3, 0x9d, 0x7b, 0x00, 0x00, 0xf8, 0x1e, 0xf3, 0x2e);
	internal static readonly Guid WiaImgFmt_CIFF = new(0x9821a8ab, 0x3a7e, 0x4215, 0x94, 0xe0, 0xd2, 0x7a, 0x46, 0x0c, 0x03, 0xb2);
	internal static readonly Guid WiaImgFmt_PICT = new(0xa6bc85d8, 0x6b3e, 0x40ee, 0xa9, 0x5c, 0x25, 0xd4, 0x82, 0xe4, 0x1a, 0xdc);
	internal static readonly Guid WiaImgFmt_JPEG2K = new(0x344ee2b2, 0x39db, 0x4dde, 0x81, 0x73, 0xc4, 0xb7, 0x5f, 0x8f, 0x1e, 0x49);
	internal static readonly Guid WiaImgFmt_JPEG2KX = new(0x43e14614, 0xc80a, 0x4850, 0xba, 0xf3, 0x4b, 0x15, 0x2d, 0xc8, 0xda, 0x27);

	#region (_WIN32_WINNT >=  0x0600)
	internal static readonly Guid WiaImgFmt_RAW = new(0x6f120719, 0xf1a8, 0x4e07, 0x9a, 0xde, 0x9b, 0x64, 0xc6, 0x3a, 0x3d, 0xcc);
	internal static readonly Guid WiaImgFmt_JBIG = new(0x41e8dd92, 0x2f0a, 0x43d4, 0x86, 0x36, 0xf1, 0x61, 0x4b, 0xa1, 0x1e, 0x46);
	#endregion

	/*
 internal static readonly Guid[] WiaImageFormatGuids =
	 {
	 WiaImgFmt_BMP           ,
	 WiaImgFmt_EMF         ,
	 WiaImgFmt_WMF         ,
	 WiaImgFmt_JPEG        ,
	 WiaImgFmt_PNG         ,
	 WiaImgFmt_GIF         ,
	 WiaImgFmt_TIFF        ,
	 WiaImgFmt_ICO         ,
	 WiaImgFmt_UNDEFINED   ,
	 WiaImgFmt_RAWRGB      ,
	 WiaImgFmt_MEMORYBMP   ,
	 WiaImgFmt_EXIF        ,
	 WiaImgFmt_PHOTOCD     ,
	 WiaImgFmt_FLASHPIX    ,
	 WiaImgFmt_CIFF        ,
	 WiaImgFmt_PICT        ,
	 WiaImgFmt_JPEG2K      ,
	 WiaImgFmt_JPEG2KX
 };
  */

	#endregion

	#region WIA document format constants

	internal static readonly Guid WiaImgFmt_RTF = new(0x573dd6a3, 0x4834, 0x432d, 0xa9, 0xb5, 0xe1, 0x98, 0xdd, 0x9e, 0x89, 0x0d);
	internal static readonly Guid WiaImgFmt_XML = new(0xb9171457, 0xdac8, 0x4884, 0xb3, 0x93, 0x15, 0xb4, 0x71, 0xd5, 0xf0, 0x7e);
	internal static readonly Guid WiaImgFmt_HTML = new(0xc99a4e62, 0x99de, 0x4a94, 0xac, 0xca, 0x71, 0x95, 0x6a, 0xc2, 0x97, 0x7d);
	internal static readonly Guid WiaImgFmt_TXT = new(0xfafd4d82, 0x723f, 0x421f, 0x93, 0x18, 0x30, 0x50, 0x1a, 0xc4, 0x4b, 0x59);
	#region if (_WIN32_WINNT >= 0x0600)
	internal static readonly Guid WiaImgFmt_PDFA = new(0x9980bd5b, 0x3463, 0x43c7, 0xbd, 0xca, 0x3c, 0xaa, 0x14, 0x6f, 0x22, 0x9f);
	internal static readonly Guid WiaImgFmt_XPS = new(0x700b4a0f, 0x2011, 0x411c, 0xb4, 0x30, 0xd1, 0xe0, 0xb2, 0xe1, 0x0b, 0x28);
	#endregion
	#endregion

	#region WIA video format constants
	//internal static readonly Guid WiaImgFmt_MPG,       = new( 0xecd757e4 , 0xd2ec , 0x4f57 , 0x95 , 0x5d , 0xbc , 0xf8 , 0xa9 , 0x7c , 0x4e , 0x52);
	//internal static readonly Guid WiaImgFmt_AVI,       = new( 0x32f8ca14 , 0x087c , 0x4908 , 0xb7 , 0xc4 , 0x67 , 0x57 , 0xfe , 0x7e , 0x90 , 0xab);
	#endregion

	#region WIA audio format constants

	//internal static readonly Guid WiaAudFmt_WAV,       = new( 0xf818e146 , 0x07af , 0x40ff , 0xae , 0x55 , 0xbe , 0x8f , 0x2c , 0x06 , 0x5d , 0xbe);
	//internal static readonly Guid WiaAudFmt_MP3,       = new( 0x0fbc71fb , 0x43bf , 0x49f2 , 0x91 , 0x90 , 0xe6 , 0xfe , 0xcf , 0xf3 , 0x7e , 0x54);
	//internal static readonly Guid WiaAudFmt_AIFF,      = new( 0x66e2bf4f , 0xb6fc , 0x443f , 0x94 , 0xc8 , 0x2f , 0x33 , 0xc8 , 0xa6 , 0x5a , 0xaf);
	//internal static readonly Guid WiaAudFmt_WMA,       = new( 0xd61d6413 , 0x8bc2 , 0x438f , 0x93 , 0xad , 0x21 , 0xbd , 0x48 , 0x4d , 0xb6 , 0xa1);
	#endregion

	#region WIA misc format constants
	//internal static readonly Guid WiaImgFmt_ASF,       = new( 0x8d948ee9 , 0xd0aa , 0x4a12 , 0x9d , 0x9a , 0x9c , 0xc5 , 0xde , 0x36 , 0x19 , 0x9b);
	//internal static readonly Guid WiaImgFmt_SCRIPT,    = new( 0xfe7d6c53 , 0x2dac , 0x446a , 0xb0 , 0xbd , 0xd7 , 0x3e , 0x21 , 0xe9 , 0x24 , 0xc9);
	//internal static readonly Guid WiaImgFmt_e_Exec,      = new( 0x485da097 , 0x141e , 0x4aa5 , 0xbb , 0x3b , 0xa5 , 0x61 , 0x8d , 0x95 , 0xd0 , 0x2b);
	//internal static readonly Guid WiaImgFmt_UNICODE16 , 0x1b7639b6 , 0x6357 , 0x47d1 , 0x9a , 0x07 , 0x12 , 0x45 , 0x2d , 0xc0 , 0x73 , 0xe9);
	//internal static readonly Guid WiaImgFmt_DPOF,      = new( 0x369eeeab , 0xa0e8 , 0x45ca , 0x86 , 0xa6 , 0xa8 , 0x3c , 0xe5 , 0x69 , 0x7e , 0x28);
	#endregion

	#region WIA event constants
	internal static readonly Guid WIA_EVENT_DEVICE_DISCONNECTED = new(0x143e4e83, 0x6497, 0x11d2, 0xa2, 0x31, 0x00, 0xc0, 0x4f, 0xa3, 0x18, 0x09);
	internal static readonly Guid WIA_EVENT_DEVICE_CONNECTED = new(0xa28bbade, 0x64b6, 0x11d2, 0xa2, 0x31, 0x00, 0xc0, 0x4f, 0xa3, 0x18, 0x09);
	internal static readonly Guid WIA_EVENT_ITEM_DELETED = new(0x1d22a559, 0xe14f, 0x11d2, 0xb3, 0x26, 0x00, 0xc0, 0x4f, 0x68, 0xce, 0x61);
	internal static readonly Guid WIA_EVENT_ITEM_CREATED = new(0x4c8f4ef5, 0xe14f, 0x11d2, 0xb3, 0x26, 0x00, 0xc0, 0x4f, 0x68, 0xce, 0x61);
	internal static readonly Guid WIA_EVENT_TREE_UPDATED = new(0xc9859b91, 0x4ab2, 0x4cd6, 0xa1, 0xfc, 0x58, 0x2e, 0xec, 0x55, 0xe5, 0x85);
	internal static readonly Guid WIA_EVENT_VOLUME_INSERT = new(0x9638bbfd, 0xd1bd, 0x11d2, 0xb3, 0x1f, 0x00, 0xc0, 0x4f, 0x68, 0xce, 0x61);
	internal static readonly Guid WIA_EVENT_SCAN_IMAGE = new(0xa6c5a715, 0x8c6e, 0x11d2, 0x97, 0x7a, 0x00, 0x00, 0xf8, 0x7a, 0x92, 0x6f);
	internal static readonly Guid WIA_EVENT_SCAN_PRINT_IMAGE = new(0xb441f425, 0x8c6e, 0x11d2, 0x97, 0x7a, 0x00, 0x00, 0xf8, 0x7a, 0x92, 0x6f);
	internal static readonly Guid WIA_EVENT_SCAN_FAX_IMAGE = new(0xc00eb793, 0x8c6e, 0x11d2, 0x97, 0x7a, 0x00, 0x00, 0xf8, 0x7a, 0x92, 0x6f);
	internal static readonly Guid WIA_EVENT_SCAN_OCR_IMAGE = new(0x9d095b89, 0x37d6, 0x4877, 0xaf, 0xed, 0x62, 0xa2, 0x97, 0xdc, 0x6d, 0xbe);
	internal static readonly Guid WIA_EVENT_SCAN_EMAIL_IMAGE = new(0xc686dcee, 0x54f2, 0x419e, 0x9a, 0x27, 0x2f, 0xc7, 0xf2, 0xe9, 0x8f, 0x9e);
	internal static readonly Guid WIA_EVENT_SCAN_FILM_IMAGE = new(0x9b2b662c, 0x6185, 0x438c, 0xb6, 0x8b, 0xe3, 0x9e, 0xe2, 0x5e, 0x71, 0xcb);
	internal static readonly Guid WIA_EVENT_SCAN_IMAGE2 = new(0xfc4767c1, 0xc8b3, 0x48a2, 0x9c, 0xfa, 0x2e, 0x90, 0xcb, 0x3d, 0x35, 0x90);
	internal static readonly Guid WIA_EVENT_SCAN_IMAGE3 = new(0x154e27be, 0xb617, 0x4653, 0xac, 0xc5, 0x0f, 0xd7, 0xbd, 0x4c, 0x65, 0xce);
	internal static readonly Guid WIA_EVENT_SCAN_IMAGE4 = new(0xa65b704a, 0x7f3c, 0x4447, 0xa7, 0x5d, 0x8a, 0x26, 0xdf, 0xca, 0x1f, 0xdf);
	internal static readonly Guid WIA_EVENT_STORAGE_CREATED = new(0x353308b2, 0xfe73, 0x46c8, 0x89, 0x5e, 0xfa, 0x45, 0x51, 0xcc, 0xc8, 0x5a);
	internal static readonly Guid WIA_EVENT_STORAGE_DELETED = new(0x5e41e75e, 0x9390, 0x44c5, 0x9a, 0x51, 0xe4, 0x70, 0x19, 0xe3, 0x90, 0xcf);
	internal static readonly Guid WIA_EVENT_STI_PROXY = new(0xd711f81f, 0x1f0d, 0x422d, 0x86, 0x41, 0x92, 0x7d, 0x1b, 0x93, 0xe5, 0xe5);
	internal static readonly Guid WIA_EVENT_CANCEL_IO = new(0xc860f7b8, 0x9ccd, 0x41ea, 0xbb, 0xbf, 0x4d, 0xd0, 0x9c, 0x5b, 0x17, 0x95);
	#endregion

}



[Flags]
internal enum WIA_DPS_DOCUMENT_HANDLING_SELECT : int
{
	/// <summary>Scan using the document feeder.</summary>
	FEEDER = 0x1,
	/// <summary>Scan using the flatbed.</summary>
	FLATBED = 0x2,
	/// <summary>Scan using duplexer operations.</summary>
	DUPLEX = 0x4,
	/// <summary>Scan the front of the document first. This value is valid when DUPLEX is set.</summary>
	FRONT_FIRST = 0x8,
	/// <summary>Scan the back of the document first. This value is valid when DUPLEX is set.</summary>
	BACK_FIRST = 0x10,
	/// <summary>Scan the front only. This value is valid when DUPLEX is set.</summary>
	FRONT_ONLY = 0x20,
	/// <summary>Scan the back only. This value is valid when DUPLEX is set.</summary>
	BACK_ONLY = 0x40,
	/// <summary>Scan the next page of the document.</summary>
	NEXT_PAGE = 0x80,
	/// <summary>Enable pre-feed mode. Pre-position next document while scanning.</summary>
	PREFEED = 0x100,
	/// <summary>Enables automatic feeding of the next document after a scan.</summary>
	AUTO_ADVANCE = 0x200,
	#region (_WIN32_WINNT >=  = &h0600)
	/// <summary></summary>
	ADVANCED_DUPLEX = 0x400
	#endregion
}


[Flags]
internal enum WIA_DPS_DOCUMENT_HANDLING_STATUS : int
{
	/// <summary>The flatbed is ready for use.</summary>
	FEED_READY = 0x1,
	/// <summary>The scanner has a document on the flatbed platen.</summary>
	FLAT_READY = 0x2,
	/// <summary>The duplexer is enabled and ready to be used.</summary>
	DUP_READY = 0x4,
	/// <summary>The flat bed cover is up.</summary>
	FLAT_COVER_UP = 0x8,
	/// <summary>The paper path is covered up and is preventing proper operation.</summary>
	PATH_COVER_UP = 0x10,
	/// <summary>A document is jammed in the document feeder.</summary>
	PAPER_JAM = 0x20,
	#region (_WIN32_WINNT >=  = &h0600)
	/// <summary>The transparency adapter is installed and ready for use.</summary>
	FILM_TPA_READY = 0x40,
	/// <summary>The internal storage device is ready.</summary>
	STORAGE_READY = 0x80,
	/// <summary>The storage is full, no upload operations possible.</summary>
	STORAGE_FULL = 0x100,
	/// <summary>A multiple feed condition occurred (usually with a PAPER_JAM).</summary>
	MULTIPLE_FEED = 0x200,
	/// <summary>There is an error that requires user intervention on the device.</summary>
	DEVICE_ATTENTION = 0x400,
	/// <summary>The scanner is not ready due to a lamp problem.</summary>
	LAMP_ERR = 0x800
	#endregion
}


[Flags]
internal enum WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES : int
{
	/// <summary>The scanner has a document feeder installed.</summary>
	FEED = 0x1,
	/// <summary>The scanner has a flatbed platen.</summary>
	FLAT = 0x2,
	/// <summary>The scanner has a duplexer.</summary>
	DUP = 0x4,

	/// <summary>The scanner can detect a document on the flatbed platen.</summary>
	DETECT_FLAT = 0x8,







	/// <summary>The scanner can detect a document in the feeder only by scanning.</summary>
	DETECT_SCAN = 0x10,

	/// <summary>The scanner can detect a document in the feeder.</summary>
	DETECT_FEED = 0x20,

	/// <summary>The scanner can detect a duplex scan request from a user.</summary>
	[Obsolete("obsolete and should not be used (https://learn.microsoft.com/en-us/windows-hardware/drivers/image/wia-dps-document-handling-capabilities).", true)]
	DETECT_DUP = 0x40,
	/// <summary>The scanner can detect when a document feeder is installed.</summary>
	[Obsolete("obsolete and should not be used (https://learn.microsoft.com/en-us/windows-hardware/drivers/image/wia-dps-document-handling-capabilities).", true)]
	DETECT_FEED_AVAIL = 0x80,
	/// <summary>The scanner can detect when a duplexer is installed.</summary>
	[Obsolete("obsolete and should not be used (https://learn.microsoft.com/en-us/windows-hardware/drivers/image/wia-dps-document-handling-capabilities).", true)]
	DETECT_DUP_AVAIL = 0x100,

	#region (_WIN32_WINNT >=  = &h0600)
	/// <summary>The scanner has a transparency or film scanning adapter.</summary>
	FILM_TPA = 0x200,

	/// <summary>The scanner can detect when the transparency or film scanning adapter is ready to scan.</summary>
	DETECT_FILM_TPA = 0x400,

	/// <summary>The scanner is equipped with an internal storage device.</summary>
	STOR = 0x800,

	/// <summary>The scanner can detect when there is a document in the internal storage.</summary>
	DETECT_STOR = 0x1000,

	/// <summary>The device supports advanced duplex scan configuration, independently on each document size.</summary>
	ADVANCED_DUP = 0x2000,

	/// <summary>The device supports auto-configured scanning.
	/// https://learn.microsoft.com/en-us/windows-hardware/drivers/image/auto-configured-scanning
	/// </summary>
	AUTO_SOURCE = 0x8000
	#endregion
}


/// <summary>WIA_IPS_PREVIEW</summary>
internal enum WIA_PREVIEW_MODES : int
{
	/// <summary>The application will perform a final scan.</summary>
	WIA_FINAL_SCAN = 0,
	/// <summary>The application will perform a preview scan.</summary>
	WIA_PREVIEW_SCAN = 1
}

/// <summary>WIA_IPS_AUTO_DESKEW constants</summary>
internal enum WIA_IPS_AUTO_DESKEW_MODES : int
{
	WIA_AUTO_DESKEW_ON = 0,
	WIA_AUTO_DESKEW_OFF = 1
}


/// <summary>WIA_DPS_SHEET_FEEDER_REGISTRATION and WIA_DPS_HORIZONTAL_BED_REGISTRATION constants</summary>
internal enum WIA_HORIZONTAL_REGISTRATIONS : int
{
	LEFT_JUSTIFIED = 0,
	CENTERED = 1,
	RIGHT_JUSTIFIED = 2
}

/// <summary>WIA_DPS_VERTICAL_BED_REGISTRATION constants</summary>
internal enum WIA_VERTICAL_BED_REGISTRATIONS : int
{
	TOP_JUSTIFIED = 0,
	CENTERED = 1,
	BOTTOM_JUSTIFIED = 2
}




// '
// ' WIA_IPA_ITEM_CATEGORY constants
// '
// DEFINE_GUID(WIA_CATEGORY_FINISHED_FILE, = &hff2b77ca,  = &hcf84,  = &h432b,  = &ha7,  = &h35,  = &h3a,  = &h13,  = &h0d,  = &hde,  = &h2a,  = &h88);
// DEFINE_GUID(WIA_CATEGORY_FLATBED,       = &hfb607b1f,  = &h43f3,  = &h488b,  = &h85,  = &h5b,  = &hfb,  = &h70,  = &h3e,  = &hc3,  = &h42,  = &ha6);
// DEFINE_GUID(WIA_CATEGORY_FEEDER,        = &hfe131934,  = &hf84c,  = &h42ad,  = &h8d,  = &ha4,  = &h61,  = &h29,  = &hcd,  = &hdd,  = &h72,  = &h88);
// DEFINE_GUID(WIA_CATEGORY_FILM,          = &hfcf65be7,  = &h3ce3,  = &h4473,  = &haf,  = &h85,  = &hf5,  = &hd3,  = &h7d,  = &h21,  = &hb6,  = &h8a);
// DEFINE_GUID(WIA_CATEGORY_ROOT,          = &hf193526f,  = &h59b8,  = &h4a26,  = &h98,  = &h88,  = &he1,  = &h6e,  = &h4f,  = &h97,  = &hce,  = &h10);
// DEFINE_GUID(WIA_CATEGORY_FOLDER,        = &hc692a446,  = &h6f5a,  = &h481d,  = &h85,  = &hbb,  = &h92,  = &he2,  = &he8,  = &h6f,  = &hd3,  = &ha);
// DEFINE_GUID(WIA_CATEGORY_FEEDER_FRONT,  = &h4823175c,  = &h3b28,  = &h487b,  = &ha7,  = &he6,  = &hee,  = &hbc,  = &h17,  = &h61,  = &h4f,  = &hd1);
// DEFINE_GUID(WIA_CATEGORY_FEEDER_BACK,   = &h61ca74d4,  = &h39db,  = &h42aa,  = &h89,  = &hb1,  = &h8c,  = &h19,  = &hc9,  = &hcd,  = &h4c,  = &h23);
// DEFINE_GUID(WIA_CATEGORY_AUTO,          = &hdefe5fd8,  = &h6c97,  = &h4dde,  = &hb1,  = &h1e,  = &hcb,  = &h50,  = &h9b,  = &h27,  = &h0e,  = &h11);

// '
// ' GUID for Default Segmentation Filter
// '
// DEFINE_GUID(CLSID_WiaDefaultSegFilter,  = &hD4F4D30B,  = &h0B29,  = &h4508,  = &h89,  = &h22,  = &h0C,  = &h57,  = &h97,  = &hD4,  = &h27,  = &h65);

// '
// ' WIA_IPS_TRANSFER_CAPABILITIES flags:
// '
// WIA_TRANSFER_CHILDREN_SINGLE_SCAN  = &h00000001

// '
// ' WIA_IPS_SEGMENTATION_FILTER constants
// '
// WIA_USE_SEGMENTATION_FILTER       0
// WIA_DONT_USE_SEGMENTATION_FILTER  1

// '
// ' WIA_IPS_FILM_SCAN_MODE constants
// '
// WIA_FILM_COLOR_SLIDE              0
// WIA_FILM_COLOR_NEGATIVE           1
// WIA_FILM_BW_NEGATIVE              2




// '

// '
// ' WIA Raw Format header:
// '
// typedef struct _WIA_RAW_HEADER
// {
// DWORD Tag;
// DWORD Version;
// DWORD HeaderSize;
// DWORD XRes;
// DWORD YRes;
// DWORD XExtent;
// DWORD YExtent;
// DWORD BytesPerLine;
// DWORD BitsPerPixel;
// DWORD ChannelsPerPixel;
// DWORD DataType;
// BYTE  BitsPerChannel[8];
// DWORD Compression;
// DWORD PhotometricInterp;
// DWORD LineOrder;
// DWORD RawDataOffset;
// DWORD RawDataSize;
// DWORD PaletteOffset;
// DWORD PaletteSize;
// } WIA_RAW_HEADER;

// typedef struct _WIA_RAW_HEADER *PWIA_RAW_HEADER;

// #endif '#if (_WIN32_WINNT >=  = &h0600)

// '
// ' Use the WIA property offsets to define private WIA properties.
// '
// ' Example: (Creating a private WIA property)
// '
// '   WIA_THE_PROP         (WIA_PRIVATE_DEVPROP + 1000)
// '   WIA_THE_PROP_STR     L"The Property")
// '

// '
// ' Private property offset constants
// '

// WIA_PRIVATE_DEVPROP  38914 ' offset for private device (root) item properties
// WIA_PRIVATE_ITEMPROP 71682 ' offset for private item properties

















// '
// ' Power management event GUIDs, sent by the WIA service to drivers
// '

// DEFINE_GUID(WIA_EVENT_POWER_SUSPEND,       = &ha0922ff9, = &hc3b4, = &h411c, = &h9e, = &h29, = &h03, = &ha6, = &h69, = &h93, = &hd2, = &hbe);
// DEFINE_GUID(WIA_EVENT_POWER_RESUME,        = &h618f153e, = &hf686, = &h4350, = &h96, = &h34, = &h41, = &h15, = &ha3, = &h04, = &h83, = &h0c);

// '
// ' No action handler and prompt handler
// '

// DEFINE_GUID(WIA_EVENT_HANDLER_NO_ACTION,   = &he0372b7d, = &he115, = &h4525, = &hbc, = &h55, = &hb6, = &h29, = &he6, = &h8c, = &h74, = &h5a);
// DEFINE_GUID(WIA_EVENT_HANDLER_PROMPT,      = &h5f4baad0, = &h4d59, = &h4fcd, = &hb2, = &h13, = &h78, = &h3c, = &he7, = &ha9, = &h2f, = &h22);

// '
// ' WIA command constants
// '

// DEFINE_GUID(WIA_CMD_SYNCHRONIZE,           = &h9b26b7b2, = &hacad, = &h11d2, = &ha0, = &h93, = &h00, = &hc0, = &h4f, = &h72, = &hdc, = &h3c);
// DEFINE_GUID(WIA_CMD_TAKE_PICTURE,          = &haf933cac, = &hacad, = &h11d2, = &ha0, = &h93, = &h00, = &hc0, = &h4f, = &h72, = &hdc, = &h3c);
// DEFINE_GUID(WIA_CMD_DELETE_ALL_ITEMS,      = &he208c170, = &hacad, = &h11d2, = &ha0, = &h93, = &h00, = &hc0, = &h4f, = &h72, = &hdc, = &h3c);
// DEFINE_GUID(WIA_CMD_CHANGE_DOCUMENT,       = &h04e725b0, = &hacae, = &h11d2, = &ha0, = &h93, = &h00, = &hc0, = &h4f, = &h72, = &hdc, = &h3c);
// DEFINE_GUID(WIA_CMD_UNLOAD_DOCUMENT,       = &h1f3b3d8e, = &hacae, = &h11d2, = &ha0, = &h93, = &h00, = &hc0, = &h4f, = &h72, = &hdc, = &h3c);
// DEFINE_GUID(WIA_CMD_DIAGNOSTIC,            = &h10ff52f5, = &hde04, = &h4cf0, = &ha5, = &had, = &h69, = &h1f, = &h8d, = &hce, = &h01, = &h41);
// DEFINE_GUID(WIA_CMD_FORMAT,                = &hc3a693aa, = &hf788, = &h4d34, = &ha5, = &hb0, = &hbe, = &h71, = &h90, = &h75, = &h9a, = &h24);

// '
// ' WIA command constants used for debugging only
// '

// DEFINE_GUID(WIA_CMD_DELETE_DEVICE_TREE,    = &h73815942, = &hdbea, = &h11d2, = &h84, = &h16, = &h00, = &hc0, = &h4f, = &ha3, = &h61, = &h45);
// DEFINE_GUID(WIA_CMD_BUILD_DEVICE_TREE,     = &h9cba5ce0, = &hdbea, = &h11d2, = &h84, = &h16, = &h00, = &hc0, = &h4f, = &ha3, = &h61, = &h45);

// FACILITY_WIA         33
// BASE_VAL_WIA_ERROR    = &h00000000
// BASE_VAL_WIA_SUCCESS  = &h00000000

// WIA_ERROR_GENERAL_ERROR              MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 1)
// WIA_ERROR_PAPER_JAM                  MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 2)
// WIA_ERROR_PAPER_EMPTY                MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 3)
// WIA_ERROR_PAPER_PROBLEM              MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 4)
// WIA_ERROR_OFFLINE                    MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 5)
// WIA_ERROR_BUSY                       MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 6)
// WIA_ERROR_WARMING_UP                 MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 7)
// WIA_ERROR_USER_INTERVENTION          MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 8)
// WIA_ERROR_ITEM_DELETED               MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 9)
// WIA_ERROR_DEVICE_COMMUNICATION       MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 10)
// WIA_ERROR_INVALID_COMMAND            MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 11)
// WIA_ERROR_INCORRECT_HARDWARE_SETTING MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 12)
// WIA_ERROR_DEVICE_LOCKED              MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 13)
// WIA_ERROR_EXCEPTION_IN_DRIVER        MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 14)
// WIA_ERROR_INVALID_DRIVER_RESPONSE    MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 15)
// WIA_ERROR_COVER_OPEN                 MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 16)
// WIA_ERROR_LAMP_OFF                   MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 17)
// WIA_ERROR_DESTINATION                MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 18)
// WIA_ERROR_NETWORK_RESERVATION_FAILED MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 19)
// WIA_STATUS_END_OF_MEDIA              MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 1)

// '
// ' Definitions for errors and status codes passed to IWiaDataTransfer::BandedDataCallback as the lReason parameter.
// ' These codes are in addition to the errors defined above; in some cases the SEVERITY_SUCCESS version of
// ' an error is meant to replace the SEVERITY_ERROR version listed above.
// '

// WIA_STATUS_WARMING_UP                MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 2)
// WIA_STATUS_CALIBRATING               MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 3)
// WIA_STATUS_RESERVING_NETWORK_DEVICE  MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 6)
// WIA_STATUS_NETWORK_DEVICE_RESERVED   MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 7)
// WIA_STATUS_CLEAR                     MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 8)
// WIA_STATUS_SKIP_ITEM                 MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 9)
// WIA_STATUS_NOT_HANDLED               MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 10)

// '
// ' The value is returned by Scansetting.dll when the user chooses to change the scanner in scandialog
// '

// WIA_S_CHANGE_DEVICE                  MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 11)

// '
// ' SelectDeviceDlg and SelectDeviceDlgID status code when there are no devices available
// '

// WIA_S_NO_DEVICE_AVAILABLE            MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 21)

// '
// ' SelectDeviceDlg and GetImageDlg flag constants
// '

// WIA_SELECT_DEVICE_NODEFAULT           = &h00000001

// '
// ' DeviceDlg and GetImageDlg flags constants
// '

// WIA_DEVICE_DIALOG_SINGLE_IMAGE        = &h00000002  ' Only allow one image to be selected
// WIA_DEVICE_DIALOG_USE_COMMON_UI       = &h00000004  ' Give preference to the system-provided UI, if available

// '
// ' RegisterEventCallbackInterface and RegisterEventCallbackCLSID flag constants
// '

// WIA_REGISTER_EVENT_CALLBACK          = &h00000001
// WIA_UNREGISTER_EVENT_CALLBACK        = &h00000002
// WIA_SET_DEFAULT_HANDLER              = &h00000004

// '
// ' WIA event type constants
// '

// WIA_NOTIFICATION_EVENT               = &h00000001
// WIA_ACTION_EVENT                     = &h00000002

// '
// ' Additional WIA raw format constants
// '

// WIA_LINE_ORDER_TOP_TO_BOTTOM         = &h00000001
// WIA_LINE_ORDER_BOTTOM_TO_TOP         = &h00000002

// '
// ' WIA event persistent handler flag constants
// '

// WIA_IS_DEFAULT_HANDLER               = &h00000001

// '
// ' WIA connected and disconnected event description strings
// '

// WIA_EVENT_DEVICE_DISCONNECTED_STR L"Device Disconnected"
// WIA_EVENT_DEVICE_CONNECTED_STR    L"Device Connected"

// '
// ' WIA event and command icon resource identifier constants
// '
// ' Events   : -1000 to -1499 (Standard), -1500 to -1999 (Custom)
// ' Commands : -2000 to -2499 (Standard), -2500 to -2999 (Custom)
// '

// WIA_ICON_DEVICE_DISCONNECTED (L"sti.dll,-1001")
// WIA_ICON_DEVICE_CONNECTED    (L"sti.dll,-1001")
// WIA_ICON_ITEM_DELETED        (L"sti.dll,-1001")
// WIA_ICON_ITEM_CREATED        (L"sti.dll,-1001")
// WIA_ICON_TREE_UPDATED        (L"sti.dll,-1001")
// WIA_ICON_VOLUME_INSERT       (L"sti.dll,-1001")
// WIA_ICON_SCAN_BUTTON_PRESS   (L"sti.dll,-1001")
// WIA_ICON_SYNCHRONIZE         (L"sti.dll,-2000")
// WIA_ICON_TAKE_PICTURE        (L"sti.dll,-2001")
// WIA_ICON_DELETE_ALL_ITEMS    (L"sti.dll,-2002")
// WIA_ICON_CHANGE_DOCUMENT     (L"sti.dll,-2003")
// WIA_ICON_UNLOAD_DOCUMENT     (L"sti.dll,-2004")
// WIA_ICON_DELETE_DEVICE_TREE  (L"sti.dll,-2005")
// WIA_ICON_BUILD_DEVICE_TREE   (L"sti.dll,-2006")

// '
// ' WIA TYMED constants
// '

// TYMED_CALLBACK                     128
// TYMED_MULTIPAGE_FILE               256
// TYMED_MULTIPAGE_CALLBACK           512

// '
// ' IWiaDataCallback and IWiaMiniDrvCallBack message ID constants
// '

// IT_MSG_DATA_HEADER               = &h0001
// IT_MSG_DATA                      = &h0002
// IT_MSG_STATUS                    = &h0003
// IT_MSG_TERMINATION               = &h0004
// IT_MSG_NEW_PAGE                  = &h0005
// IT_MSG_FILE_PREVIEW_DATA         = &h0006
// IT_MSG_FILE_PREVIEW_DATA_HEADER  = &h0007

// '
// ' IWiaDataCallback and IWiaMiniDrvCallBack status flag constants
// '

// IT_STATUS_TRANSFER_FROM_DEVICE     = &h0001
// IT_STATUS_PROCESSING_DATA          = &h0002
// IT_STATUS_TRANSFER_TO_CLIENT       = &h0004
// IT_STATUS_MASK                     = &h0007 ' any status value that doesn't
// ' fit the mask is an HRESULT
// '
// ' IWiaTransfer flags
// '

// WIA_TRANSFER_ACQUIRE_CHILDREN      = &h0001

// '
// ' IWiaTransferCallback Message types
// '

// WIA_TRANSFER_MSG_STATUS            = &h00001
// WIA_TRANSFER_MSG_END_OF_STREAM     = &h00002
// WIA_TRANSFER_MSG_END_OF_TRANSFER   = &h00003
// WIA_TRANSFER_MSG_DEVICE_STATUS     = &h00005
// WIA_TRANSFER_MSG_NEW_PAGE          = &h00006

// '
// ' IWiaEventCallback code constants
// '

// WIA_MAJOR_EVENT_DEVICE_CONNECT     = &h01
// WIA_MAJOR_EVENT_DEVICE_DISCONNECT  = &h02
// WIA_MAJOR_EVENT_PICTURE_TAKEN      = &h03
// WIA_MAJOR_EVENT_PICTURE_DELETED    = &h04

// '
// ' WIA device connection status constants
// '

// WIA_DEVICE_NOT_CONNECTED         0
// WIA_DEVICE_CONNECTED             1

// '
// ' EnumDeviceCapabilities and drvGetCapabilities flags
// '

// WIA_DEVICE_COMMANDS               1
// WIA_DEVICE_EVENTS                 2

// '
// ' EnumDeviceInfo Flags
// '

// WIA_DEVINFO_ENUM_ALL               = &h0000000F
// WIA_DEVINFO_ENUM_LOCAL             = &h00000010


// '
// ' WIA item type constants
// '

// WiaItemTypeFree                    = &h00000000
// WiaItemTypeImage                   = &h00000001
// WiaItemTypeFile                    = &h00000002
// WiaItemTypeFolder                  = &h00000004
// WiaItemTypeRoot                    = &h00000008
// WiaItemTypeAnalyze                 = &h00000010
// WiaItemTypeAudio                   = &h00000020
// WiaItemTypeDevice                  = &h00000040
// WiaItemTypeDeleted                 = &h00000080
// WiaItemTypeDisconnected            = &h00000100
// WiaItemTypeHPanorama               = &h00000200
// WiaItemTypeVPanorama               = &h00000400
// WiaItemTypeBurst                   = &h00000800
// WiaItemTypeStorage                 = &h00001000
// WiaItemTypeTransfer                = &h00002000
// WiaItemTypeGenerated               = &h00004000
// WiaItemTypeHasAttachments          = &h00008000
// WiaItemTypeVideo                   = &h00010000
// WiaItemTypeRemoved                 = &h80000000
// '
// '  = &h00020000 has been reserved for the TWAIN compatiblity layer
// ' pass-through feature.
// '
// #if (_WIN32_WINNT >=  = &h0600)
// WiaItemTypeDocument                = &h00040000
// WiaItemTypeProgrammableDataSource  = &h00080000
// WiaItemTypeMask                    = &h800FFFFF
// #Else
// WiaItemTypeMask                    = &h8003FFFF
// #End If

// '
// ' Big max device specific item context
// '

// WIA_MAX_CTX_SIZE                   = &h01000000

// '
// ' WIA property access flag constants
// '

// WIA_PROP_READ             = &h01
// WIA_PROP_WRITE            = &h02
// WIA_PROP_RW              (WIA_PROP_READ | WIA_PROP_WRITE)
// WIA_PROP_SYNC_REQUIRED    = &h04

// WIA_PROP_NONE             = &h08
// WIA_PROP_RANGE            = &h10
// WIA_PROP_LIST             = &h20
// WIA_PROP_FLAG             = &h40

// WIA_PROP_CACHEABLE        = &h10000

// '
// ' IWiaItem2 CreateChildItem flag constants
// '

// COPY_PARENT_PROPERTY_VALUES        = &h40000000

// '
// ' WIA item access flag constants
// '

// WIA_ITEM_CAN_BE_DELETED   = &h80
// WIA_ITEM_READ            WIA_PROP_READ
// WIA_ITEM_WRITE           WIA_PROP_WRITE
// WIA_ITEM_RD              (WIA_ITEM_READ | WIA_ITEM_CAN_BE_DELETED)
// WIA_ITEM_RWD             (WIA_ITEM_READ | WIA_ITEM_WRITE | WIA_ITEM_CAN_BE_DELETED)

// '
// ' WIA property container constants
// '

// WIA_RANGE_MIN                          0
// WIA_RANGE_NOM                          1
// WIA_RANGE_MAX                          2
// WIA_RANGE_STEP                         3
// WIA_RANGE_NUM_ELEMS                    4

// WIA_LIST_COUNT                         0
// WIA_LIST_NOM                           1
// WIA_LIST_VALUES                        2
// WIA_LIST_NUM_ELEMS                     2

// WIA_FLAG_NOM                           0
// WIA_FLAG_VALUES                        1
// WIA_FLAG_NUM_ELEMS                     2



// '
// ' Microsoft defined WIA property offset constants
// '

// WIA_DIP_FIRST                        2
// WIA_IPA_FIRST                     4098
// WIA_DPF_FIRST                     3330
// WIA_IPS_FIRST                     6146
// WIA_DPS_FIRST                     3074
// WIA_IPC_FIRST                     5122
// WIA_NUM_IPC                          9
// WIA_RESERVED_FOR_NEW_PROPS        1024

// '
// ' WIA_DPC_WHITE_BALANCE constants
// '

// WHITEBALANCE_MANUAL            1
// WHITEBALANCE_AUTO              2
// WHITEBALANCE_ONEPUSH_AUTO      3
// WHITEBALANCE_DAYLIGHT          4
// WHITEBALANCE_FLORESCENT        5
// WHITEBALANCE_TUNGSTEN          6
// WHITEBALANCE_FLASH             7

// '
// ' WIA_DPC_FOCUS_MODE constants
// '

// FOCUSMODE_MANUAL               1
// FOCUSMODE_AUTO                 2
// FOCUSMODE_MACROAUTO            3

// '
// ' WIA_DPC_EXPOSURE_METERING_MODE constants
// '

// EXPOSUREMETERING_AVERAGE       1
// EXPOSUREMETERING_CENTERWEIGHT  2
// EXPOSUREMETERING_MULTISPOT     3
// EXPOSUREMETERING_CENTERSPOT    4

// '
// ' WIA_DPC_FLASH_MODE constants
// '

// FLASHMODE_AUTO                 1
// FLASHMODE_OFF                  2
// FLASHMODE_FILL                 3
// FLASHMODE_REDEYE_AUTO          4
// FLASHMODE_REDEYE_FILL          5
// FLASHMODE_EXTERNALSYNC         6

// '
// ' WIA_DPC_EXPOSURE_MODE constants
// '

// EXPOSUREMODE_MANUAL            1
// EXPOSUREMODE_AUTO              2
// EXPOSUREMODE_APERTURE_PRIORITY 3
// EXPOSUREMODE_SHUTTER_PRIORITY  4
// EXPOSUREMODE_PROGRAM_CREATIVE  5
// EXPOSUREMODE_PROGRAM_ACTION    6
// EXPOSUREMODE_PORTRAIT          7

// '
// ' WIA_DPC_CAPTURE_MODE constants
// '

// CAPTUREMODE_NORMAL             1
// CAPTUREMODE_BURST              2
// CAPTUREMODE_TIMELAPSE          3

// '
// ' WIA_DPC_EFFECT_MODE constants
// '

// EFFECTMODE_STANDARD            1
// EFFECTMODE_BW                  2
// EFFECTMODE_SEPIA               3

// '
// ' WIA_DPC_FOCUS_METERING_MODE constants
// '

// FOCUSMETERING_CENTERSPOT       1
// FOCUSMETERING_MULTISPOT        2

// '
// ' WIA_DPC_POWER_MODE constants
// '

// POWERMODE_LINE                 1
// POWERMODE_BATTERY              2


// '
// ' WIA_IPS_MIRROR flags
// '

// MIRRORED                       = &h01




// '
// ' WIA_DPS_TRANSPARENCY / WIA_DPS_TRANSPARENCY_STATUS flags
// '

// LIGHT_SOURCE_PRESENT_DETECT    = &h01
// LIGHT_SOURCE_PRESENT           = &h02
// LIGHT_SOURCE_DETECT_READY      = &h04
// LIGHT_SOURCE_READY             = &h08

// '
// ' WIA_DPS_TRANSPARENCY_CAPABILITIES
// '

// TRANSPARENCY_DYNAMIC_FRAME_SUPPORT  = &h01
// TRANSPARENCY_STATIC_FRAME_SUPPORT   = &h02

// '
// ' WIA_DPS_TRANSPARENCY_SELECT flags
// '

// LIGHT_SOURCE_SELECT            = &h001 ' currently not used
// LIGHT_SOURCE_POSITIVE          = &h002
// LIGHT_SOURCE_NEGATIVE          = &h004

// '
// ' WIA_DPS_SCAN_AHEAD_PAGES constants
// '

// WIA_SCAN_AHEAD_ALL            0


// '
// ' Predefined strings for WIA_DPS_ENDORSER_STRING
// '

// WIA_ENDORSER_TOK_DATE          L"$DATE$"
// WIA_ENDORSER_TOK_TIME          L"$TIME$"
// WIA_ENDORSER_TOK_PAGE_COUNT    L"$PAGE_COUNT$"
// WIA_ENDORSER_TOK_DAY           L"$DAY$"
// WIA_ENDORSER_TOK_MONTH         L"$MONTH$"
// WIA_ENDORSER_TOK_YEAR          L"$YEAR$"



// '
// ' WIA_IPA_COMPRESSION constants
// '

// WIA_COMPRESSION_NONE           0
// WIA_COMPRESSION_BI_RLE4        1
// WIA_COMPRESSION_BI_RLE8        2
// WIA_COMPRESSION_G3             3
// WIA_COMPRESSION_G4             4
// WIA_COMPRESSION_JPEG           5
// #if (_WIN32_WINNT >=  = &h0600)
// WIA_COMPRESSION_JBIG           6
// WIA_COMPRESSION_JPEG2K         7
// WIA_COMPRESSION_PNG            8
// #endif '#if (_WIN32_WINNT >=  = &h0600)

// '
// ' WIA_IPA_PLANAR constants
// '

// WIA_PACKED_PIXEL               0
// WIA_PLANAR                     1

// '
// ' WIA_IPA_DATATYPE constants
// '

// WIA_DATA_THRESHOLD             0
// WIA_DATA_DITHER                1
// WIA_DATA_GRAYSCALE             2
// WIA_DATA_COLOR                 3
// WIA_DATA_COLOR_THRESHOLD       4
// WIA_DATA_COLOR_DITHER          5
// #if (_WIN32_WINNT >=  = &h0600)
// WIA_DATA_RAW_RGB               6
// WIA_DATA_RAW_BGR               7
// WIA_DATA_RAW_YUV               8
// WIA_DATA_RAW_YUVK              9
// WIA_DATA_RAW_CMY              10
// WIA_DATA_RAW_CMYK             11
// #endif '#if (_WIN32_WINNT >=  = &h0600)


// '
// ' WIA_IPS_PHOTOMETRIC_INTERP constants
// '

// WIA_PHOTO_WHITE_1              0 ' white is 1, black is 0
// WIA_PHOTO_WHITE_0              1 ' white is 0, black is 1

// '
// ' WIA_IPA_SUPPRESS_PROPERTY_PAGE flags
// '

// WIA_PROPPAGE_SCANNER_ITEM_GENERAL  = &h00000001
// WIA_PROPPAGE_CAMERA_ITEM_GENERAL   = &h00000002
// WIA_PROPPAGE_DEVICE_GENERAL        = &h00000004




// ****************************************************************************
// *
// *  (C) Copyright 1998-2003, Microsoft Corp.
// *
// *  File:    wiadef.h
// *
// *  Version: 3.0
// *
// *  Description: WIA constant definitions
// *
// *****************************************************************************/

[Flags]
internal enum WIA_IPS_CUR_INTENT : int
{
	WIA_INTENT_NONE = 0x0,
	WIA_INTENT_IMAGE_TYPE_COLOR = 0x1, // Цветной
	WIA_INTENT_IMAGE_TYPE_GRAYSCALE = 0x2, // Оттенки серого
	WIA_INTENT_IMAGE_TYPE_TEXT = 0x4, // Чёрно/белый 1 бит
	WIA_INTENT_IMAGE_TYPE_MASK = 0xF,
	WIA_INTENT_MINIMIZE_SIZE = 0x10000,
	WIA_INTENT_MAXIMIZE_QUALITY = 0x20000,
	WIA_INTENT_BEST_PREVIEW = 0x40000,
	WIA_INTENT_SIZE_MASK = 0xF0000
}

enum WIA_ORIENTATION : int // WIA_IPS_ORIENTATION and WIA_IPS_ROTATION constants
{
	PORTRAIT = 0,
	LANSCAPE = 1,
	// #if (_WIN32_WINNT >=  = &h0600)
	LANDSCAPE = LANSCAPE,
	// #End If
	ROT180 = 2,
	ROT270 = 3
}


/// <summary>Dimensions are defined as (WIDTH x HEIGHT) in 1/1000ths of an inch</summary>
internal enum WIA_PAGE_SIZE : int  // WIA_DPS_PAGE_SIZE/WIA_IPS_PAGE_SIZE constants
{


	WIA_PAGE_A4 = 0, // 8267 x 11692
	WIA_PAGE_LETTER = 1, // 8500 x 11000
	WIA_PAGE_CUSTOM = 2, // (current extent settings)

	WIA_PAGE_USLEGAL = 3, // 8500 x 14000
	WIA_PAGE_USLETTER = WIA_PAGE_LETTER,
	WIA_PAGE_USLEDGER = 4, // 11000 x 17000
	WIA_PAGE_USSTATEMENT = 5, // 5500 x  8500
	WIA_PAGE_BUSINESSCARD = 6, // 3543 x  2165

	// ISO A page size constants
	WIA_PAGE_ISO_A0 = 7, // 33110 x 46811
	WIA_PAGE_ISO_A1 = 8, // 23385 x 33110
	WIA_PAGE_ISO_A2 = 9, // 16535 x 23385
	WIA_PAGE_ISO_A3 = 10, // 11692 x 16535
	WIA_PAGE_ISO_A4 = WIA_PAGE_A4,
	WIA_PAGE_ISO_A5 = 11, // 5826 x  8267
	WIA_PAGE_ISO_A6 = 12, // 4133 x  5826
	WIA_PAGE_ISO_A7 = 13, // 2913 x  4133
	WIA_PAGE_ISO_A8 = 14, // 2047 x  2913
	WIA_PAGE_ISO_A9 = 15, // 1456 x  2047
	WIA_PAGE_ISO_A10 = 16, // 1023 x  1456

	// ISO B page size constants
	WIA_PAGE_ISO_B0 = 17, // 39370 x 55669
	WIA_PAGE_ISO_B1 = 18, // 27834 x 39370
	WIA_PAGE_ISO_B2 = 19, // 19685 x 27834
	WIA_PAGE_ISO_B3 = 20, // 13897 x 19685
	WIA_PAGE_ISO_B4 = 21, // 9842 x 13897
	WIA_PAGE_ISO_B5 = 22, // 6929 x  9842
	WIA_PAGE_ISO_B6 = 23, // 4921 x  6929
	WIA_PAGE_ISO_B7 = 24, // 3464 x  4921
	WIA_PAGE_ISO_B8 = 25, // 2440 x  3464
	WIA_PAGE_ISO_B9 = 26, // 1732 x  2440
	WIA_PAGE_ISO_B10 = 27, // 1220 x  1732

	// ISO C page size constants
	WIA_PAGE_ISO_C0 = 28, // 36102 x 51062
	WIA_PAGE_ISO_C1 = 29, // 25511 x 36102
	WIA_PAGE_ISO_C2 = 30, // 18031 x 25511
	WIA_PAGE_ISO_C3 = 31, // 12755 x 18031
	WIA_PAGE_ISO_C4 = 32, // 9015 x 12755 (unfolded)
	WIA_PAGE_ISO_C5 = 33, // 6377 x  9015 (folded once)
	WIA_PAGE_ISO_C6 = 34, // 4488 x  6377 (folded twice)
	WIA_PAGE_ISO_C7 = 35, // 3188 x  4488
	WIA_PAGE_ISO_C8 = 36, // 2244 x  3188
	WIA_PAGE_ISO_C9 = 37, // 1574 x  2244
	WIA_PAGE_ISO_C10 = 38, // 1102 x  1574

	// JIS B page size constants
	WIA_PAGE_JIS_B0 = 39, // 40551 x 57322
	WIA_PAGE_JIS_B1 = 40, // 28661 x 40551
	WIA_PAGE_JIS_B2 = 41, // 20275 x 28661
	WIA_PAGE_JIS_B3 = 42, // 14330 x 20275
	WIA_PAGE_JIS_B4 = 43, // 10118 x 14330
	WIA_PAGE_JIS_B5 = 44, // 7165 x 10118
	WIA_PAGE_JIS_B6 = 45, // 5039 x  7165
	WIA_PAGE_JIS_B7 = 46, // 3582 x  5039
	WIA_PAGE_JIS_B8 = 47, // 2519 x  3582
	WIA_PAGE_JIS_B9 = 48, // 1771 x  2519
	WIA_PAGE_JIS_B10 = 49, // 1259 x  1771

	// JIS A page size constants
	WIA_PAGE_JIS_2A = 50, // 46811 x 66220
	WIA_PAGE_JIS_4A = 51, // 66220 x  93622

	// DIN B page size constants
	WIA_PAGE_DIN_2B = 52, // 55669 x 78740
	WIA_PAGE_DIN_4B = 53, // 78740 x 111338

	// #if (_WIN32_WINNT >=  = &h0600)
	// Additional WIA_IPS_PAGE_SIZE constants:
	WIA_PAGE_AUTO = 100,
	WIA_PAGE_CUSTOM_BASE = 0x8000
	// #endif '#if (_WIN32_WINNT >=  = &h0600)
}

internal enum WIA_DPS_PREVIEW_ : int              // WIA_DPS_PREVIEW constants
{
	WIA_FINAL_SCAN = 0,
	WIA_PREVIEW_SCAN = 1
}
internal enum WIA_DPS_SHOW_PREVIEW_CONTROL_ : int
{
	WIA_SHOW_PREVIEW_CONTROL = 0,
	WIA_DONT_SHOW_PREVIEW_CONTROL = 1
}

internal enum WIA_IPS_PREVIEW_TYPE_ : int            // ' WIA_IPS_PREVIEW_TYPE constants:
{
	WIA_ADVANCED_PREVIEW = 0,
	WIA_BASIC_PREVIEW = 1
}

internal enum WIA_IPS_LAMP_ : int            // ' WIA_IPS_PREVIEW_TYPE constants:
{
	WIA_LAMP_ON = 0,
	WIA_LAMP_OFF = 1
}







#region InternalClasses

[Flags]
internal enum WIA_ERRORS : int
{
	BASE_VAL_WIA_ERROR = int.MinValue + 0x00210000,
	WIA_ERROR_PAPER_EMPTY = BASE_VAL_WIA_ERROR + 3
}
#endregion







/// <summary>WIA property ID and string constants
/// http://msdn.microsoft.com/en-us/library/windows/desktop/ms630196%28v=vs.85%29.aspx
/// https://learn.microsoft.com/is-is/windows-hardware/drivers/image/wia-dps-page-width
/// </summary>
internal enum WIA_PROP_ID : int
{



	/*

public enum WiaProperty
{

ConnectStatus = 1027,
DeviceTime = 1028,
PicturesTaken = 2050,
PicturesRemaining = 2051,

ExposureMode = 2052,
ExposureCompensation = 2053,
ExposureTime = 2054,
FNumber = 2055,
FlashMode = 2056,
FocusMode = 2057,
FocusManualDist = 2058,
ZoomPosition = 2059,
PanPosition = 2060,
TiltPostion = 2061,
TimerMode = 2062,
TimerValue = 2063,
PowerMode = 2064,
BatteryStatus = 2065,
Dimension = 2070,
HorizontalBedSize = 3074,
VerticalBedSize = 3075,
HorizontalSheetFeedSize = 3076,
VerticalSheetFeedSize = 3077,

PlatenColor = 3081,
PadColor = 3082,
FilterSelect = 3083,
DitherSelect = 3084,
DitherPatternData = 3085,

DocumentHandlingCapabilities = 3086,    // FEED = 0x01, FLAT = 0x02, DUP = 0x04, DETECT_FLAT = 0x08, 
						 // DETECT_SCAN = 0x10, DETECT_FEED = 0x20, DETECT_DUP = 0x40, 
						 // DETECT_FEED_AVAIL = 0x80, DETECT_DUP_AVAIL = 0x100

DocumentHandlingStatus = 3087,          // FEED_READY = 0x01, FLAT_READY = 0x02, DUP_READY = 0x04, 
						 // FLAT_COVER_UP = 0x08, PATH_COVER_UP = 0x10, PAPER_JAM = 0x20

DocumentHandlingSelect = 3088,          // FEEDER = 0x001, FLATBED = 0x002, DUPLEX = 0x004, FRONT_FIRST = 0x008
						 // BACK_FIRST = 0x010, FRONT_ONLY = 0x020, BACK_ONLY = 0x040
						 // NEXT_PAGE = 0x080, PREFEED = 0x100, AUTO_ADVANCE = 0x200



HorizontalOpticalResolution = 3090,
VerticalOpticalResolution = 3091,

EndorserCharacters = 3092,
EndorserString = 3093,

ScanAheadPages = 3094,                  // ALL_PAGES = 0
MaxScanTime = 3095,
Pages = 3096,                           // ALL_PAGES = 0

PageSize = 3097,                        // A4 = 0, LETTER = 1, CUSTOM = 2

PageWidth = 3098,
PageHeight = 3099,

TransparencyAdapter = 3101,
TransparecnyAdapterSelect = 3102,
ItemName = 4098,
FullItemName = 4099,
ItemTimeStamp = 4100,
ItemFlags = 4101,
AccessRights = 4102,
DataType = 4103,
BitsPerPixel = 4104,
PreferredFormat = 4105,

Format = 4106,
Compression = 4107,                     // 0 = NONE, JPG = 5, PNG = 8

MediaType = 4108,
ChannelsPerPixel = 4109,
BitsPerChannel = 4110,
Planar = 4111,
PixelsPerLine = 4112,
BytesPerLine = 4113,
NumberOfLines = 4114,
GammaCurves = 4115,
ItemSize = 4116,
ColorProfiles = 4117,
BufferSize = 4118,
RegionType = 4119,
ColorProfileName = 4120,
ApplicationAppliesColorMapping = 4121,
StreamCompatibilityId = 4122,
ThumbData = 5122,
ThumbWidth = 5123,
ThumbHeight = 5124,
AudioAvailable = 5125,
AudioFormat = 5126,
AudioData = 5127,
PicturesPerRow = 5128,
SequenceNumber = 5129,
TimeDelay = 5130,
HorizontalResolution = 6147,
VerticalResolution = 6148,
HorizontalStartPosition = 6149,
VerticalStartPosition = 6150,
HorizontalExtent = 6151,
VerticalExtent = 6152,
PhotometricInterpretation = 6153,
Brightness = 6154,
Contrast = 6155,
Orientation = 6156, // 0 = PORTRAIT, 1 = LANDSCAPE, 2 = 180°, 3 = 270°
Rotation = 6157, // 0 = PORTRAIT, 1 = LANDSCAPE, 2 = 180°, 3 = 270°
Mirror = 6158,
Threshold = 6159,
Invert = 6160,
LampWarmUpTime = 6161,
}

*/





	#region Global

	/// <summary>Unique Device ID</summary>
	WIA_DIP_DEV_ID = 2,

	/// <summary>Manufacturer</summary>
	WIA_DIP_VEND_DESC = 3,

	/// <summary>Description</summary>
	WIA_DIP_DEV_DESC = 4,

	/// <summary>Type</summary>
	WIA_DIP_DEV_TYPE = 5,

	/// <summary>Port</summary>
	WIA_DIP_PORT_NAME = 6,

	/// <summary>Name</summary>
	WIA_DIP_DEV_NAME = 7,

	/// <summary>Server</summary>
	WIA_DIP_SERVER_NAME = 8,

	//Remote Device ID"
	//WIA_DIP_REMOTE_DEV_ID                      =9 '  = &h9

	// L"UI Class ID"
	// WIA_DIP_UI_CLSID                           10 '  = &ha

	// WIA_DIP_HW_CONFIG                          11 '  = &hb
	// WIA_DIP_HW_CONFIG_STR                      L"Hardware Configuration"

	// WIA_DIP_BAUDRATE                           12 '  = &hc
	// WIA_DIP_BAUDRATE_STR                       L"BaudRate"

	// WIA_DIP_STI_GEN_CAPABILITIES               13 '  = &hd
	// WIA_DIP_STI_GEN_CAPABILITIES_STR           L"STI Generic Capabilities"

	/// <summary>WIA Version</summary>
	WIA_DIP_WIA_VERSION = 14,

	/// <summary>Driver Version</summary>
	WIA_DIP_DRIVER_VERSION = 15,

	/// <summary>PnP ID String</summary>
	WIA_DIP_PNP_ID = 16,

	// WIA_DIP_STI_DRIVER_VERSION                 17 '  = &h11
	// WIA_DIP_STI_DRIVER_VERSION_STR             L"STI Driver Version"

	// WIA_DPA_FIRMWARE_VERSION                   1026 '  = &h402
	// WIA_DPA_FIRMWARE_VERSION_STR               L"Firmware Version"

	// WIA_DPA_CONNECT_STATUS                     1027 '  = &h403
	// WIA_DPA_CONNECT_STATUS_STR                 L"Connect Status"

	// WIA_DPA_DEVICE_TIME                        1028 '  = &h404
	// WIA_DPA_DEVICE_TIME_STR                    L"Device Time"

	#endregion

	#region CameraDevice
	// CameraDevicePicturesTaken = WIA_DPC_PICTURES_TAKEN
	// CameraDevicePicturesRemaining = WIA_DPC_PICTURES_REMAINING
	// CameraDeviceExposureMode = WIA_DPC_EXPOSURE_MODE
	// CameraDeviceExposureComp = WIA_DPC_EXPOSURE_COMP
	// CameraDeviceExposureTime = WIA_DPC_EXPOSURE_TIME
	// CameraDeviceFNumber = WIA_DPC_FNUMBER
	// CameraDeviceFlashMode = WIA_DPC_FLASH_MODE
	// CameraDeviceFocusMode = WIA_DPC_FOCUS_MODE
	// CameraDevicePanPosition = WIA_DPC_PAN_POSITION
	// CameraDeviceTiltPosition = WIA_DPC_TILT_POSITION
	// CameraDeviceTimerMode = WIA_DPC_TIMER_MODE
	// CameraDeviceTimerValue = WIA_DPC_TIMER_VALUE
	// CameraDevicePowerMode = WIA_DPC_POWER_MODE
	// CameraDeviceBatteryStatus = WIA_DPC_BATTERY_STATUS
	// CameraDeviceThumbWidth = WIA_DPC_THUMB_WIDTH
	// CameraDeviceThumbHeight = WIA_DPC_THUMB_HEIGHT
	// CameraDevicePictWidth = WIA_DPC_PICT_WIDTH
	// CameraDevicePictHeight = WIA_DPC_PICT_HEIGHT
	// CameraDeviceCompressionSetting = WIA_DPC_COMPRESSION_SETTING
	// CameraDeviceTimelapseInterval = WIA_DPC_TIMELAPSE_INTERVAL
	// CameraDeviceTimelapseNumber = WIA_DPC_TIMELAPSE_NUMBER
	// CameraDeviceBurstInterval = WIA_DPC_BURST_INTERVAL
	// CameraDeviceBurstNumber = WIA_DPC_BURST_NUMBER
	// CameraDeviceEffectMode = WIA_DPC_EFFECT_MODE
	// CameraDeviceDigitalZoom = WIA_DPC_DIGITAL_ZOOM
	// CameraDeviceSharpness = WIA_DPC_SHARPNESS
	// CameraDeviceContrast = WIA_DPC_CONTRAST
	// CameraDeviceCaptureMode = WIA_DPC_CAPTURE_MODE
	// CameraDeviceCaptureDelay = WIA_DPC_CAPTURE_DELAY
	// CameraDeviceExposureIndex = WIA_DPC_EXPOSURE_INDEX
	// CameraDeviceExposureMeteringMode = WIA_DPC_EXPOSURE_METERING_MODE
	// CameraDeviceFocusMeteringMode = WIA_DPC_FOCUS_METERING_MODE
	// CameraDeviceFocusDistance = WIA_DPC_FOCUS_DISTANCE
	// CameraDeviceFocalLength = WIA_DPC_FOCAL_LENGTH
	// CameraDeviceRGBGain = WIA_DPC_RGB_GAIN
	// CameraDeviceWhiteBalance = WIA_DPC_WHITE_BALANCE
	// CameraDeviceUploadURL = WIA_DPC_UPLOAD_URL
	// CameraDeviceArtist = WIA_DPC_ARTIST
	// CameraDeviceCopyrightInfo = WIA_DPC_COPYRIGHT_INFO

	// CameraPictureThumbnail = WIA_IPC_THUMBNAIL
	// CameraPictureThumbWidth = WIA_IPC_THUMB_WIDTH
	// CameraPictureThumbHeight = WIA_IPC_THUMB_HEIGHT
	// CameraPictureAudioAvailable = WIA_IPC_AUDIO_AVAILABLE
	// CameraPictureAudioDataFormat = WIA_IPC_AUDIO_DATA_FORMAT
	// CameraPictureAudioData = WIA_IPC_AUDIO_DATA
	// CameraPictureNumPictPerRow = WIA_IPC_NUM_PICT_PER_ROW
	// CameraPictureSequence = WIA_IPC_SEQUENCE
	// CameraPictureTimedelay = WIA_IPC_TIMEDELAY
	#endregion

	#region ScannerDevice


	/// <summary>Horizontal Bed Size</summary>
	WIA_DPS_HORIZONTAL_BED_SIZE = 3074,
	/// <summary>Vertical Bed Size</summary>
	WIA_DPS_VERTICAL_BED_SIZE = 3075,

	/// <summary>Horizontal Sheet Feed Size</summary>
	WIA_DPS_HORIZONTAL_SHEET_FEED_SIZE = 3076,
	/// <summary>Vertical Sheet Feed Size</summary>
	WIA_DPS_VERTICAL_SHEET_FEED_SIZE = 3077, // = &hc05


	/// <summary>Sheet Feeder Registration</summary>
	WIA_DPS_SHEET_FEEDER_REGISTRATION = 3078, // = &hc06
	/// <summary>Horizontal Bed Registration</summary>
	WIA_DPS_HORIZONTAL_BED_REGISTRATION = 3079, // = &hc07
	/// <summary>Vertical Bed Registration</summary>
	WIA_DPS_VERTICAL_BED_REGISTRATION = 3080, // = &hc08

	/// <summary></summary>
	WIA_DPS_PLATEN_COLOR = 3081, // = &hc09
								 // WIA_DPS_PLATEN_COLOR_STR                   L"Platen Color"
	/// <summary></summary>
	WIA_DPS_PAD_COLOR = 3082, // = &hc0a
							  // WIA_DPS_PAD_COLOR_STR                      L"Pad Color"
	/// <summary></summary>
	WIA_DPS_FILTER_SELECT = 3083, // = &hc0b
								  // WIA_DPS_FILTER_SELECT_STR                  L"Filter Select"
	/// <summary></summary>
	WIA_DPS_DITHER_SELECT = 3084, // = &hc0c
								  // WIA_DPS_DITHER_SELECT_STR                  L"Dither Select"

	/// <summary>Dither Pattern Data</summary>
	WIA_DPS_DITHER_PATTERN_DATA = 3085,

	/// <summary>Document Handling Capabilities</summary>
	WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES = 3086,

	/// <summary>Document Handling Status</summary>
	WIA_DPS_DOCUMENT_HANDLING_STATUS = 3087,

	/// <summary>Document Handling Select</summary>
	WIA_DPS_DOCUMENT_HANDLING_SELECT = 3088,

	/// <summary>Document Handling Capacity</summary>
	WIA_DPS_DOCUMENT_HANDLING_CAPACITY = 3089,

	/// <summary>"Horizontal Optical Resolution (X)"</summary>
	WIA_DPS_OPTICAL_XRES = 3090,

	/// <summary>"Vertical Optical Resolution (Y)"</summary>
	WIA_DPS_OPTICAL_YRES = 3091,

	/// <summary>Endorser Characters</summary>
	WIA_DPS_ENDORSER_CHARACTERS = 3092, // = &hc14

	/// <summary>Endorser String</summary>
	WIA_DPS_ENDORSER_STRING = 3093, // = &hc15

	/// <summary>Scan Ahead Pages</summary>
	WIA_DPS_SCAN_AHEAD_PAGES = 3094, // = &hc16

	/// <summary>Max Scan Time</summary>
	WIA_DPS_MAX_SCAN_TIME = 3095, // = &hc17

	/// <summary>Pages</summary>
	WIA_DPS_PAGES = 3096,

	/// <summary>Page Size</summary>
	WIA_DPS_PAGE_SIZE = 3097,

	/// <summary>the width of the currently selected page, in thousandths of an inch (.001).</summary>
	WIA_DPS_PAGE_WIDTH = 3098, // = &hc1a
	/// <summary>the height, in thousandths of an inch (.001), of the currently selected page.</summary>
	WIA_DPS_PAGE_HEIGHT = 3099, // = &hc1b

	/// <summary>Preview</summary>
	WIA_DPS_PREVIEW = 3100,
	/// <summary>Transparency Adapter</summary>
	WIA_DPS_TRANSPARENCY = 3101,
	/// <summary>Transparency Adapter Select</summary>
	WIA_DPS_TRANSPARENCY_SELECT = 3102,
	/// <summary>Show preview control</summary>
	WIA_DPS_SHOW_PREVIEW_CONTROL = 3103,
	/// <summary>Minimum Horizontal Sheet Feed Size</summary>
	WIA_DPS_MIN_HORIZONTAL_SHEET_FEED_SIZE = 3104,
	/// <summary>Minimum Vertical Sheet Feed Size</summary>
	WIA_DPS_MIN_VERTICAL_SHEET_FEED_SIZE = 3105,
	/// <summary>Transparency Adapter Capabilities</summary>
	WIA_DPS_TRANSPARENCY_CAPABILITIES = 3106,
	/// <summary>Transparency Adapter Status</summary>
	WIA_DPS_TRANSPARENCY_STATUS = 3107,

	// ScannerDeviceSheetFeederRegistration = WIA_DPS_SHEET_FEEDER_REGISTRATION
	// ScannerDeviceHorizontalBedRegistration = WIA_DPS_HORIZONTAL_BED_REGISTRATION
	// ScannerDeviceVerticalBedRegistration = WIA_DPS_VERTICAL_BED_REGISTRATION
	// ScannerDevicePlatenColor = WIA_DPS_PLATEN_COLOR
	// ScannerDevicePadColor = WIA_DPS_PAD_COLOR

	// ScannerDevicePreview = WIA_DPS_PREVIEW
	// ScannerDeviceTransparency = WIA_DPS_TRANSPARENCY
	// ScannerDeviceTransparencySelect = WIA_DPS_TRANSPARENCY_SELECT
	// ScannerDeviceShowPreviewControl = WIA_DPS_SHOW_PREVIEW_CONTROL


	// ScannerPictureCurIntent = WIA_IPS_CUR_INTENT
	// ScannerPictureXres = WIA_IPS_XRES
	// ScannerPictureYres = WIA_IPS_YRES
	// ScannerPictureXpos = WIA_IPS_XPOS
	// ScannerPictureYpos = WIA_IPS_YPOS
	// ScannerPictureXextent = WIA_IPS_XEXTENT
	// ScannerPictureYextent = WIA_IPS_YEXTENT
	// ScannerPicturePhotometricInterp = WIA_IPS_PHOTOMETRIC_INTERP
	// ScannerPictureBrightness = WIA_IPS_BRIGHTNESS
	// ScannerPictureContrast = WIA_IPS_CONTRAST
	// ScannerPictureOrientation = WIA_IPS_ORIENTATION
	// ScannerPictureRotation = WIA_IPS_ROTATION
	// ScannerPictureMirror = WIA_IPS_MIRROR
	// ScannerPictureThreshold = WIA_IPS_THRESHOLD
	// ScannerPictureInvert = WIA_IPS_INVERT
	// ScannerPictureWarmUpTime = WIA_IPS_WARM_UP_TIME

	#endregion

	#region VideoDevice
	// FileDeviceMountPoint = WIA_DPF_MOUNT_POINT
	// VideoDeviceLastPictureTaken = WIA_DPV_LAST_PICTURE_TAKEN
	// VideoDeviceImagesDirectory = WIA_DPV_IMAGES_DIRECTORY
	// VideoDeviceDShowDevicePath = WIA_DPV_DSHOW_DEVICE_PATH
	#endregion

	#region Picture
	// PictureItemName = WIA_IPA_ITEM_NAME
	// PictureFullItemName = WIA_IPA_FULL_ITEM_NAME
	// PictureItemTime = WIA_IPA_ITEM_TIME
	// PictureItemFlags = WIA_IPA_ITEM_FLAGS
	// PictureAccessRights = WIA_IPA_ACCESS_RIGHTS
	// PictureDatatype = WIA_IPA_DATATYPE
	// PictureDepth = WIA_IPA_DEPTH
	// PicturePreferredFormat = WIA_IPA_PREFERRED_FORMAT
	// PictureFormat = WIA_IPA_FORMAT
	// PictureCompression = WIA_IPA_COMPRESSION
	// PictureTymed = WIA_IPA_TYMED
	// PictureChannelsPerPixel = WIA_IPA_CHANNELS_PER_PIXEL
	// PictureBitsPerChannel = WIA_IPA_BITS_PER_CHANNEL
	// PicturePlanar = WIA_IPA_PLANAR
	// PicturePixelsPerLine = WIA_IPA_PIXELS_PER_LINE
	// PictureBytesPerLine = WIA_IPA_BYTES_PER_LINE
	// PictureNumberOfLines = WIA_IPA_NUMBER_OF_LINES
	// PictureGammaCurves = WIA_IPA_GAMMA_CURVES
	// PictureItemSize = WIA_IPA_ITEM_SIZE
	// PictureColorProfile = WIA_IPA_COLOR_PROFILE
	// PictureMinBufferSize = WIA_IPA_MIN_BUFFER_SIZE
	// PictureBufferSize = WIA_IPA_BUFFER_SIZE
	// PictureRegionType = WIA_IPA_REGION_TYPE
	// PictureIcmProfileName = WIA_IPA_ICM_PROFILE_NAME
	// PictureAppColorMapping = WIA_IPA_APP_COLOR_MAPPING
	// PicturePropStreamCompatId = WIA_IPA_PROP_STREAM_COMPAT_ID
	// PictureFilenameExtension = WIA_IPA_FILENAME_EXTENSION
	// PictureSuppressPropertyPage = WIA_IPA_SUPPRESS_PROPERTY_PAGE
	#endregion









	// WIA_DPC_PICTURES_TAKEN                     2050 '  = &h802
	// WIA_DPC_PICTURES_TAKEN_STR                 L"Pictures Taken"

	// WIA_DPC_PICTURES_REMAINING                 2051 '  = &h803
	// WIA_DPC_PICTURES_REMAINING_STR             L"Pictures Remaining"

	// WIA_DPC_EXPOSURE_MODE                      2052 '  = &h804
	// WIA_DPC_EXPOSURE_MODE_STR                  L"Exposure Mode"

	// WIA_DPC_EXPOSURE_COMP                      2053 '  = &h805
	// WIA_DPC_EXPOSURE_COMP_STR                  L"Exposure Compensation"

	// WIA_DPC_EXPOSURE_TIME                      2054 '  = &h806
	// WIA_DPC_EXPOSURE_TIME_STR                  L"Exposure Time"



	// WIA_DPC_FNUMBER                            2055 '  = &h807
	// WIA_DPC_FNUMBER_STR                        L"F Number"

	// WIA_DPC_FLASH_MODE                         2056 '  = &h808
	// WIA_DPC_FLASH_MODE_STR                     L"Flash Mode"

	// WIA_DPC_FOCUS_MODE                         2057 '  = &h809
	// WIA_DPC_FOCUS_MODE_STR                     L"Focus Mode"

	// WIA_DPC_FOCUS_MANUAL_DIST                  2058 '  = &h80a
	// WIA_DPC_FOCUS_MANUAL_DIST_STR              L"Focus Manual Dist"

	// WIA_DPC_ZOOM_POSITION                      2059 '  = &h80b
	// WIA_DPC_ZOOM_POSITION_STR                  L"Zoom Position"

	// WIA_DPC_PAN_POSITION                       2060 '  = &h80c
	// WIA_DPC_PAN_POSITION_STR                   L"Pan Position"

	// WIA_DPC_TILT_POSITION                      2061 '  = &h80d
	// WIA_DPC_TILT_POSITION_STR                  L"Tilt Position"

	// WIA_DPC_TIMER_MODE                         2062 '  = &h80e
	// WIA_DPC_TIMER_MODE_STR                     L"Timer Mode"

	// WIA_DPC_TIMER_VALUE                        2063 '  = &h80f
	// WIA_DPC_TIMER_VALUE_STR                    L"Timer Value"




	// WIA_DPC_POWER_MODE                         2064 '  = &h810
	// WIA_DPC_POWER_MODE_STR                     L"Power Mode"

	// WIA_DPC_BATTERY_STATUS                     2065 '  = &h811
	// WIA_DPC_BATTERY_STATUS_STR                 L"Battery Status"

	// WIA_DPC_THUMB_WIDTH                        2066 '  = &h812
	// WIA_DPC_THUMB_WIDTH_STR                    L"Thumbnail Width"

	// WIA_DPC_THUMB_HEIGHT                       2067 '  = &h813
	// WIA_DPC_THUMB_HEIGHT_STR                   L"Thumbnail Height"



	// WIA_DPC_PICT_WIDTH                         2068 '  = &h814
	// WIA_DPC_PICT_WIDTH_STR                     L"Picture Width"

	// WIA_DPC_PICT_HEIGHT                        2069 '  = &h815
	// WIA_DPC_PICT_HEIGHT_STR                    L"Picture Height"


	// WIA_DPC_DIMENSION                          2070 '  = &h816
	// WIA_DPC_DIMENSION_STR                      L"Dimension"

	// WIA_DPC_COMPRESSION_SETTING                2071 '  = &h817
	// WIA_DPC_COMPRESSION_SETTING_STR            L"Compression Setting"

	// WIA_DPC_FOCUS_METERING                     2072 '  = &h818
	// WIA_DPC_FOCUS_METERING_STR                 L"Focus Metering Mode"

	// WIA_DPC_TIMELAPSE_INTERVAL                 2073 '  = &h819
	// WIA_DPC_TIMELAPSE_INTERVAL_STR             L"Timelapse Interval"

	// WIA_DPC_TIMELAPSE_NUMBER                   2074 '  = &h81a
	// WIA_DPC_TIMELAPSE_NUMBER_STR               L"Timelapse Number"

	// WIA_DPC_BURST_INTERVAL                     2075 '  = &h81b
	// WIA_DPC_BURST_INTERVAL_STR                 L"Burst Interval"

	// WIA_DPC_BURST_NUMBER                       2076 '  = &h81c
	// WIA_DPC_BURST_NUMBER_STR                   L"Burst Number"

	// WIA_DPC_EFFECT_MODE                        2077 '  = &h81d
	// WIA_DPC_EFFECT_MODE_STR                    L"Effect Mode"

	// WIA_DPC_DIGITAL_ZOOM                       2078 '  = &h81e
	// WIA_DPC_DIGITAL_ZOOM_STR                   L"Digital Zoom"

	// WIA_DPC_SHARPNESS                          2079 '  = &h81f
	// WIA_DPC_SHARPNESS_STR                      L"Sharpness"

	// WIA_DPC_CONTRAST                           2080 '  = &h820
	// WIA_DPC_CONTRAST_STR                       L"Contrast"

	// WIA_DPC_CAPTURE_MODE                       2081 '  = &h821
	// WIA_DPC_CAPTURE_MODE_STR                   L"Capture Mode"

	// WIA_DPC_CAPTURE_DELAY                      2082 '  = &h822
	// WIA_DPC_CAPTURE_DELAY_STR                  L"Capture Delay"

	// WIA_DPC_EXPOSURE_INDEX                     2083 '  = &h823
	// WIA_DPC_EXPOSURE_INDEX_STR                 L"Exposure Index"

	// WIA_DPC_EXPOSURE_METERING_MODE             2084 '  = &h824
	// WIA_DPC_EXPOSURE_METERING_MODE_STR         L"Exposure Metering Mode"

	// WIA_DPC_FOCUS_METERING_MODE                2085 '  = &h825
	// WIA_DPC_FOCUS_METERING_MODE_STR            L"Focus Metering Mode"

	// WIA_DPC_FOCUS_DISTANCE                     2086 '  = &h826
	// WIA_DPC_FOCUS_DISTANCE_STR                 L"Focus Distance"

	// WIA_DPC_FOCAL_LENGTH                       2087 '  = &h827
	// WIA_DPC_FOCAL_LENGTH_STR                   L"Focus Length"

	// WIA_DPC_RGB_GAIN                           2088 '  = &h828
	// WIA_DPC_RGB_GAIN_STR                       L"RGB Gain"

	// WIA_DPC_WHITE_BALANCE                      2089 '  = &h829
	// WIA_DPC_WHITE_BALANCE_STR                  L"White Balance"





	// WIA_DPC_UPLOAD_URL                         2090 '  = &h82a
	// WIA_DPC_UPLOAD_URL_STR                     L"Upload URL"

	// WIA_DPC_ARTIST                             2091 '  = &h82b
	// WIA_DPC_ARTIST_STR                         L"Artist"

	// WIA_DPC_COPYRIGHT_INFO                     2092 '  = &h82c
	// WIA_DPC_COPYRIGHT_INFO_STR                 L"Copyright Info"






	// WIA_DPF_MOUNT_POINT                        3330 '  = &hd02
	// WIA_DPF_MOUNT_POINT_STR                    L"Directory mount point"

	// WIA_DPV_LAST_PICTURE_TAKEN                 3586 '  = &he02
	// WIA_DPV_LAST_PICTURE_TAKEN_STR             L"Last Picture Taken"

	// WIA_DPV_IMAGES_DIRECTORY                   3587 '  = &he03
	// WIA_DPV_IMAGES_DIRECTORY_STR               L"Images Directory"

	// WIA_DPV_DSHOW_DEVICE_PATH                  3588 '  = &he04
	// WIA_DPV_DSHOW_DEVICE_PATH_STR              L"Directshow Device Path"

	// WIA_IPA_ITEM_NAME                          4098 '  = &h1002
	// WIA_IPA_ITEM_NAME_STR                      L"Item Name"

	// WIA_IPA_FULL_ITEM_NAME                     4099 '  = &h1003
	// WIA_IPA_FULL_ITEM_NAME_STR                 L"Full Item Name"

	// WIA_IPA_ITEM_TIME                          4100 '  = &h1004
	// WIA_IPA_ITEM_TIME_STR                      L"Item Time Stamp"

	// WIA_IPA_ITEM_FLAGS                         4101 '  = &h1005
	// WIA_IPA_ITEM_FLAGS_STR                     L"Item Flags"

	// WIA_IPA_ACCESS_RIGHTS                      4102 '  = &h1006
	// WIA_IPA_ACCESS_RIGHTS_STR                  L"Access Rights"

	// WIA_IPA_DATATYPE                           4103 '  = &h1007
	// WIA_IPA_DATATYPE_STR                       L"Data Type"

	// WIA_IPA_DEPTH                              4104 '  = &h1008
	// WIA_IPA_DEPTH_STR                          L"Bits Per Pixel"

	// WIA_IPA_PREFERRED_FORMAT                   4105 '  = &h1009
	// WIA_IPA_PREFERRED_FORMAT_STR               L"Preferred Format"

	// WIA_IPA_FORMAT                             4106 '  = &h100a
	// WIA_IPA_FORMAT_STR                         L"Format"

	// WIA_IPA_COMPRESSION                        4107 '  = &h100b
	// WIA_IPA_COMPRESSION_STR                    L"Compression"

	// WIA_IPA_TYMED                              4108 '  = &h100c
	// WIA_IPA_TYMED_STR                          L"Media Type"

	// WIA_IPA_CHANNELS_PER_PIXEL                 4109 '  = &h100d
	// WIA_IPA_CHANNELS_PER_PIXEL_STR             L"Channels Per Pixel"

	// WIA_IPA_BITS_PER_CHANNEL                   4110 '  = &h100e
	// WIA_IPA_BITS_PER_CHANNEL_STR               L"Bits Per Channel"

	// WIA_IPA_PLANAR                             4111 '  = &h100f
	// WIA_IPA_PLANAR_STR                         L"Planar"

	// WIA_IPA_PIXELS_PER_LINE                    4112 '  = &h1010
	// WIA_IPA_PIXELS_PER_LINE_STR                L"Pixels Per Line"

	// WIA_IPA_BYTES_PER_LINE                     4113 '  = &h1011
	// WIA_IPA_BYTES_PER_LINE_STR                 L"Bytes Per Line"

	// WIA_IPA_NUMBER_OF_LINES                    4114 '  = &h1012
	// WIA_IPA_NUMBER_OF_LINES_STR                L"Number of Lines"

	// WIA_IPA_GAMMA_CURVES                       4115 '  = &h1013
	// WIA_IPA_GAMMA_CURVES_STR                   L"Gamma Curves"

	// WIA_IPA_ITEM_SIZE                          4116 '  = &h1014
	// WIA_IPA_ITEM_SIZE_STR                      L"Item Size"

	// WIA_IPA_COLOR_PROFILE                      4117 '  = &h1015
	// WIA_IPA_COLOR_PROFILE_STR                  L"Color Profiles"

	// WIA_IPA_MIN_BUFFER_SIZE                    4118 '  = &h1016
	// WIA_IPA_MIN_BUFFER_SIZE_STR                L"Buffer Size"

	// WIA_IPA_BUFFER_SIZE                        4118 '  = &h1016
	// WIA_IPA_BUFFER_SIZE_STR                    L"Buffer Size"

	// WIA_IPA_REGION_TYPE                        4119 '  = &h1017
	// WIA_IPA_REGION_TYPE_STR                    L"Region Type"

	// WIA_IPA_ICM_PROFILE_NAME                   4120 '  = &h1018
	// WIA_IPA_ICM_PROFILE_NAME_STR               L"Color Profile Name"

	// WIA_IPA_APP_COLOR_MAPPING                  4121 '  = &h1019
	// WIA_IPA_APP_COLOR_MAPPING_STR              L"Application Applies Color Mapping"

	// WIA_IPA_PROP_STREAM_COMPAT_ID              4122 '  = &h101a
	// WIA_IPA_PROP_STREAM_COMPAT_ID_STR          L"Stream Compatibility ID"

	// WIA_IPA_FILENAME_EXTENSION                 4123 '  = &h101b
	// WIA_IPA_FILENAME_EXTENSION_STR             L"Filename extension"

	// WIA_IPA_SUPPRESS_PROPERTY_PAGE             4124 '  = &h101c
	// WIA_IPA_SUPPRESS_PROPERTY_PAGE_STR         L"Suppress a property page"

	// WIA_IPC_THUMBNAIL                          5122 '  = &h1402
	// WIA_IPC_THUMBNAIL_STR                      L"Thumbnail Data"

	// WIA_IPC_THUMB_WIDTH                        5123 '  = &h1403
	// WIA_IPC_THUMB_WIDTH_STR                    L"Thumbnail Width"

	// WIA_IPC_THUMB_HEIGHT                       5124 '  = &h1404
	// WIA_IPC_THUMB_HEIGHT_STR                   L"Thumbnail Height"

	// WIA_IPC_AUDIO_AVAILABLE                    5125 '  = &h1405
	// WIA_IPC_AUDIO_AVAILABLE_STR                L"Audio Available"

	// WIA_IPC_AUDIO_DATA_FORMAT                  5126 '  = &h1406
	// WIA_IPC_AUDIO_DATA_FORMAT_STR              L"Audio Format"

	// WIA_IPC_AUDIO_DATA                         5127 '  = &h1407
	// WIA_IPC_AUDIO_DATA_STR                     L"Audio Data"

	// WIA_IPC_NUM_PICT_PER_ROW                   5128 '  = &h1408
	// WIA_IPC_NUM_PICT_PER_ROW_STR               L"Pictures per Row"

	// WIA_IPC_SEQUENCE                           5129 '  = &h1409
	// WIA_IPC_SEQUENCE_STR                       L"Sequence Number"

	// WIA_IPC_TIMEDELAY                          5130 '  = &h140a
	// WIA_IPC_TIMEDELAY_STR                      L"Time Delay"







	/// <summary>Current Intent"</summary>
	WIA_IPS_CUR_INTENT = 6146,


	#region Setting DPI
	/// <summary>Horizontal Resolution</summary>
	WIA_IPS_XRES = 6147,
	/// <summary>Vertical Resolution</summary>
	WIA_IPS_YRES = 6148,
	#endregion

	#region Setting Crop Region (In pixels)
	/// <summary>Horizontal Start Pixel</summary>
	WIA_IPS_XPOS = 6149,
	/// <summary>Vertical Start Pixel</summary>
	WIA_IPS_YPOS = 6150,

	/// <summary>Width, in pixels, of a selected image to acquire.</summary>
	WIA_IPS_XEXTENT = 6151,
	/// <summary>Height, in pixels, of a selected image to acquire.</summary>
	WIA_IPS_YEXTENT = 6152,
	#endregion






	WIA_IPS_PHOTOMETRIC_INTERP = 6153, // = &h1809
									   // WIA_IPS_PHOTOMETRIC_INTERP_STR             L"Photometric Interpretation"

	/// <summary>Brightness Percent</summary>
	WIA_IPS_BRIGHTNESS = 6154,

	/// <summary>Contrast Percent</summary>
	WIA_IPS_CONTRAST = 6155,


	WIA_IPS_ORIENTATION = 6156, // = &h180c
								// WIA_IPS_ORIENTATION_STR                    L"Orientation"

	WIA_IPS_ROTATION = 6157, // = &h180d
							 // WIA_IPS_ROTATION_STR                       L"Rotation"

	WIA_IPS_MIRROR = 6158, // = &h180e
						   // WIA_IPS_MIRROR_STR                         L"Mirror"

	WIA_IPS_THRESHOLD = 6159, // = &h180f
							  // WIA_IPS_THRESHOLD_STR                      L"Threshold"

	WIA_IPS_INVERT = 6160, // = &h1810
						   // WIA_IPS_INVERT_STR                         L"Invert"

	WIA_IPS_WARM_UP_TIME = 6161, // = &h1811
								 // WIA_IPS_WARM_UP_TIME_STR                   L"Lamp Warm up Time"






	// #if (_WIN32_WINNT >=  = &h0600)

	// '
	// ' New properties, property names and values introduced in Windows Vista:
	// '

	// WIA_DPS_USER_NAME                          3112 '  = &hc28
	// WIA_DPS_USER_NAME_STR                      L"User Name"

	// WIA_DPS_SERVICE_ID                         3113 '  = &hc29
	// WIA_DPS_SERVICE_ID_STR                     L"Service ID"

	// WIA_DPS_DEVICE_ID                          3114 '  = &hc2a
	// WIA_DPS_DEVICE_ID_STR                      L"Device ID"

	// WIA_DPS_GLOBAL_IDENTITY                    3115 '  = &hc2b
	// WIA_DPS_GLOBAL_IDENTITY_STR                L"Global Identity"

	// WIA_DPS_SCAN_AVAILABLE_ITEM                3116 '  = &hc2c
	// WIA_DPS_SCAN_AVAILABLE_ITEM_STR            L"Scan Available Item"


	/// <summary>DeskewX</summary>
	WIA_IPS_DESKEW_X = 6162,
	/// <summary>DeskewY</summary>
	WIA_IPS_DESKEW_Y = 6163,



	/// <summary>Segmentation</summary>
	WIA_IPS_SEGMENTATION = 6164,
	// WIA_SEGMENTATION_FILTER_STR                L"SegmentationFilter"
	// WIA_IMAGEPROC_FILTER_STR                   L"ImageProcessingFilter"




	/// <summary>Maximum Horizontal Scan Size</summary>
	WIA_IPS_MAX_HORIZONTAL_SIZE = 6165,
	/// <summary>Maximum Vertical Scan Size</summary>
	WIA_IPS_MAX_VERTICAL_SIZE = 6166,
	/// <summary>Minimum Horizontal Scan Size</summary>
	WIA_IPS_MIN_HORIZONTAL_SIZE = 6167,
	/// <summary>Minimum Vertical Scan Size</summary>
	WIA_IPS_MIN_VERTICAL_SIZE = 6168,

	/// <summary>Transfer Capabilities</summary>
	WIA_IPS_TRANSFER_CAPABILITIES = 6169,

	/// <summary>Sheet Feeder Registration</summary>
	WIA_IPS_SHEET_FEEDER_REGISTRATION = 3078,

	/// <summary>Document Handling Select</summary>
	WIA_IPS_DOCUMENT_HANDLING_SELECT = 3088,

	/// <summary>Horizontal Optical Resolution</summary>
	WIA_IPS_OPTICAL_XRES = 3090,

	/// <summary>Vertical Optical Resolution</summary>
	WIA_IPS_OPTICAL_YRES = 3091,

	/// <summary>Pages</summary>
	WIA_IPS_PAGES = 3096,

	/// <summary>Page Size</summary>
	WIA_IPS_PAGE_SIZE = 3097,

	/// <summary>Page Width</summary>
	WIA_IPS_PAGE_WIDTH = 3098,

	/// <summary>Page Height</summary>
	WIA_IPS_PAGE_HEIGHT = 3099,

	/// <summary>Preview</summary>
	WIA_IPS_PREVIEW = 3100,

	WIA_IPS_SHOW_PREVIEW_CONTROL = 3103, // = &hc1f            '  WIA_IPS_SHOW_PREVIEW_CONTROL_STR           L"Show preview control"






	// WIA_IPS_FILM_SCAN_MODE                     3104 '  = &hc20
	// WIA_IPS_FILM_SCAN_MODE_STR                 L"Film Scan Mode"

	// WIA_IPS_LAMP                               3105 '  = &hc21
	// WIA_IPS_LAMP_STR                           L"Lamp"

	// WIA_IPS_LAMP_AUTO_OFF                      3106 '  = &hc22
	// WIA_IPS_LAMP_AUTO_OFF_STR                  L"Lamp Auto Off"


	/// <summary>Automatic Deskew</summary>
	WIA_IPS_AUTO_DESKEW = 3107,



	// WIA_IPS_SUPPORTS_CHILD_ITEM_CREATION       3108 '  = &hc24
	// WIA_IPS_SUPPORTS_CHILD_ITEM_CREATION_STR   L"Supports Child Item Creation"

	// WIA_IPS_XSCALING                           3109 '  = &hc25
	// WIA_IPS_XSCALING_STR                       L"Horizontal Scaling"

	// WIA_IPS_YSCALING                           3110 '  = &hc26
	// WIA_IPS_YSCALING_STR                       L"Vertical Scaling"

	/// <summary>Preview Type</summary>
	WIA_IPS_PREVIEW_TYPE = 3111,

	// WIA_IPA_ITEM_CATEGORY                      4125 '  = &h101d
	// WIA_IPA_ITEM_CATEGORY_STR                  L"Item Category"

	// WIA_IPA_UPLOAD_ITEM_SIZE                   4126 '  = &h101e
	// WIA_IPA_UPLOAD_ITEM_SIZE_STR               L"Upload Item Size"

	// WIA_IPA_ITEMS_STORED                       4127 '  = &h101f
	// WIA_IPA_ITEMS_STORED_STR                   L"Items Stored"

	// WIA_IPA_RAW_BITS_PER_CHANNEL               4128 '  = &h1020
	// WIA_IPA_RAW_BITS_PER_CHANNEL_STR           L"Raw Bits Per Channel"

	// WIA_IPS_FILM_NODE_NAME                     4129 '  = &h1021
	// WIA_IPS_FILM_NODE_NAME_STR                 L"Film Node Name"










	// WIA_DPC_PICTURES_TAKEN                     2050 '  = &h802
	// WIA_DPC_PICTURES_TAKEN_STR                 L"Pictures Taken"

	// WIA_DPC_PICTURES_REMAINING                 2051 '  = &h803
	// WIA_DPC_PICTURES_REMAINING_STR             L"Pictures Remaining"

	// WIA_DPC_EXPOSURE_MODE                      2052 '  = &h804
	// WIA_DPC_EXPOSURE_MODE_STR                  L"Exposure Mode"

	// WIA_DPC_EXPOSURE_COMP                      2053 '  = &h805
	// WIA_DPC_EXPOSURE_COMP_STR                  L"Exposure Compensation"

	// WIA_DPC_EXPOSURE_TIME                      2054 '  = &h806
	// WIA_DPC_EXPOSURE_TIME_STR                  L"Exposure Time"



	// WIA_DPC_FNUMBER                            2055 '  = &h807
	// WIA_DPC_FNUMBER_STR                        L"F Number"

	// WIA_DPC_FLASH_MODE                         2056 '  = &h808
	// WIA_DPC_FLASH_MODE_STR                     L"Flash Mode"

	// WIA_DPC_FOCUS_MODE                         2057 '  = &h809
	// WIA_DPC_FOCUS_MODE_STR                     L"Focus Mode"

	// WIA_DPC_FOCUS_MANUAL_DIST                  2058 '  = &h80a
	// WIA_DPC_FOCUS_MANUAL_DIST_STR              L"Focus Manual Dist"

	// WIA_DPC_ZOOM_POSITION                      2059 '  = &h80b
	// WIA_DPC_ZOOM_POSITION_STR                  L"Zoom Position"

	// WIA_DPC_PAN_POSITION                       2060 '  = &h80c
	// WIA_DPC_PAN_POSITION_STR                   L"Pan Position"

	// WIA_DPC_TILT_POSITION                      2061 '  = &h80d
	// WIA_DPC_TILT_POSITION_STR                  L"Tilt Position"

	// WIA_DPC_TIMER_MODE                         2062 '  = &h80e
	// WIA_DPC_TIMER_MODE_STR                     L"Timer Mode"

	// WIA_DPC_TIMER_VALUE                        2063 '  = &h80f
	// WIA_DPC_TIMER_VALUE_STR                    L"Timer Value"




	// WIA_DPC_POWER_MODE                         2064 '  = &h810
	// WIA_DPC_POWER_MODE_STR                     L"Power Mode"

	// WIA_DPC_BATTERY_STATUS                     2065 '  = &h811
	// WIA_DPC_BATTERY_STATUS_STR                 L"Battery Status"

	// WIA_DPC_THUMB_WIDTH                        2066 '  = &h812
	// WIA_DPC_THUMB_WIDTH_STR                    L"Thumbnail Width"

	// WIA_DPC_THUMB_HEIGHT                       2067 '  = &h813
	// WIA_DPC_THUMB_HEIGHT_STR                   L"Thumbnail Height"



	// WIA_DPC_PICT_WIDTH                         2068 '  = &h814
	// WIA_DPC_PICT_WIDTH_STR                     L"Picture Width"

	// WIA_DPC_PICT_HEIGHT                        2069 '  = &h815
	// WIA_DPC_PICT_HEIGHT_STR                    L"Picture Height"


	// WIA_DPC_DIMENSION                          2070 '  = &h816
	// WIA_DPC_DIMENSION_STR                      L"Dimension"

	// WIA_DPC_COMPRESSION_SETTING                2071 '  = &h817
	// WIA_DPC_COMPRESSION_SETTING_STR            L"Compression Setting"

	// WIA_DPC_FOCUS_METERING                     2072 '  = &h818
	// WIA_DPC_FOCUS_METERING_STR                 L"Focus Metering Mode"

	// WIA_DPC_TIMELAPSE_INTERVAL                 2073 '  = &h819
	// WIA_DPC_TIMELAPSE_INTERVAL_STR             L"Timelapse Interval"

	// WIA_DPC_TIMELAPSE_NUMBER                   2074 '  = &h81a
	// WIA_DPC_TIMELAPSE_NUMBER_STR               L"Timelapse Number"

	// WIA_DPC_BURST_INTERVAL                     2075 '  = &h81b
	// WIA_DPC_BURST_INTERVAL_STR                 L"Burst Interval"

	// WIA_DPC_BURST_NUMBER                       2076 '  = &h81c
	// WIA_DPC_BURST_NUMBER_STR                   L"Burst Number"

	// WIA_DPC_EFFECT_MODE                        2077 '  = &h81d
	// WIA_DPC_EFFECT_MODE_STR                    L"Effect Mode"

	// WIA_DPC_DIGITAL_ZOOM                       2078 '  = &h81e
	// WIA_DPC_DIGITAL_ZOOM_STR                   L"Digital Zoom"

	// WIA_DPC_SHARPNESS                          2079 '  = &h81f
	// WIA_DPC_SHARPNESS_STR                      L"Sharpness"

	// WIA_DPC_CONTRAST                           2080 '  = &h820
	// WIA_DPC_CONTRAST_STR                       L"Contrast"

	// WIA_DPC_CAPTURE_MODE                       2081 '  = &h821
	// WIA_DPC_CAPTURE_MODE_STR                   L"Capture Mode"

	// WIA_DPC_CAPTURE_DELAY                      2082 '  = &h822
	// WIA_DPC_CAPTURE_DELAY_STR                  L"Capture Delay"

	// WIA_DPC_EXPOSURE_INDEX                     2083 '  = &h823
	// WIA_DPC_EXPOSURE_INDEX_STR                 L"Exposure Index"

	// WIA_DPC_EXPOSURE_METERING_MODE             2084 '  = &h824
	// WIA_DPC_EXPOSURE_METERING_MODE_STR         L"Exposure Metering Mode"

	// WIA_DPC_FOCUS_METERING_MODE                2085 '  = &h825
	// WIA_DPC_FOCUS_METERING_MODE_STR            L"Focus Metering Mode"

	// WIA_DPC_FOCUS_DISTANCE                     2086 '  = &h826
	// WIA_DPC_FOCUS_DISTANCE_STR                 L"Focus Distance"

	// WIA_DPC_FOCAL_LENGTH                       2087 '  = &h827
	// WIA_DPC_FOCAL_LENGTH_STR                   L"Focus Length"

	// WIA_DPC_RGB_GAIN                           2088 '  = &h828
	// WIA_DPC_RGB_GAIN_STR                       L"RGB Gain"

	// WIA_DPC_WHITE_BALANCE                      2089 '  = &h829
	// WIA_DPC_WHITE_BALANCE_STR                  L"White Balance"





	// WIA_DPC_UPLOAD_URL                         2090 '  = &h82a
	// WIA_DPC_UPLOAD_URL_STR                     L"Upload URL"

	// WIA_DPC_ARTIST                             2091 '  = &h82b
	// WIA_DPC_ARTIST_STR                         L"Artist"

	// WIA_DPC_COPYRIGHT_INFO                     2092 '  = &h82c
	// WIA_DPC_COPYRIGHT_INFO_STR                 L"Copyright Info"






	// WIA_DPF_MOUNT_POINT                        3330 '  = &hd02
	// WIA_DPF_MOUNT_POINT_STR                    L"Directory mount point"

	// WIA_DPV_LAST_PICTURE_TAKEN                 3586 '  = &he02
	// WIA_DPV_LAST_PICTURE_TAKEN_STR             L"Last Picture Taken"

	// WIA_DPV_IMAGES_DIRECTORY                   3587 '  = &he03
	// WIA_DPV_IMAGES_DIRECTORY_STR               L"Images Directory"

	// WIA_DPV_DSHOW_DEVICE_PATH                  3588 '  = &he04
	// WIA_DPV_DSHOW_DEVICE_PATH_STR              L"Directshow Device Path"

	// WIA_IPA_ITEM_NAME                          4098 '  = &h1002
	// WIA_IPA_ITEM_NAME_STR                      L"Item Name"

	// WIA_IPA_FULL_ITEM_NAME                     4099 '  = &h1003
	// WIA_IPA_FULL_ITEM_NAME_STR                 L"Full Item Name"

	// WIA_IPA_ITEM_TIME                          4100 '  = &h1004
	// WIA_IPA_ITEM_TIME_STR                      L"Item Time Stamp"

	// WIA_IPA_ITEM_FLAGS                         4101 '  = &h1005
	// WIA_IPA_ITEM_FLAGS_STR                     L"Item Flags"

	// WIA_IPA_ACCESS_RIGHTS                      4102 '  = &h1006
	// WIA_IPA_ACCESS_RIGHTS_STR                  L"Access Rights"

	// WIA_IPA_DATATYPE                           4103 '  = &h1007
	// WIA_IPA_DATATYPE_STR                       L"Data Type"

	// WIA_IPA_DEPTH                              4104 '  = &h1008
	// WIA_IPA_DEPTH_STR                          L"Bits Per Pixel"

	// WIA_IPA_PREFERRED_FORMAT                   4105 '  = &h1009
	// WIA_IPA_PREFERRED_FORMAT_STR               L"Preferred Format"

	// WIA_IPA_FORMAT                             4106 '  = &h100a
	// WIA_IPA_FORMAT_STR                         L"Format"

	// WIA_IPA_COMPRESSION                        4107 '  = &h100b
	// WIA_IPA_COMPRESSION_STR                    L"Compression"

	// WIA_IPA_TYMED                              4108 '  = &h100c
	// WIA_IPA_TYMED_STR                          L"Media Type"

	// WIA_IPA_CHANNELS_PER_PIXEL                 4109 '  = &h100d
	// WIA_IPA_CHANNELS_PER_PIXEL_STR             L"Channels Per Pixel"

	// WIA_IPA_BITS_PER_CHANNEL                   4110 '  = &h100e
	// WIA_IPA_BITS_PER_CHANNEL_STR               L"Bits Per Channel"

	// WIA_IPA_PLANAR                             4111 '  = &h100f
	// WIA_IPA_PLANAR_STR                         L"Planar"

	// WIA_IPA_PIXELS_PER_LINE                    4112 '  = &h1010
	// WIA_IPA_PIXELS_PER_LINE_STR                L"Pixels Per Line"

	// WIA_IPA_BYTES_PER_LINE                     4113 '  = &h1011
	// WIA_IPA_BYTES_PER_LINE_STR                 L"Bytes Per Line"

	// WIA_IPA_NUMBER_OF_LINES                    4114 '  = &h1012
	// WIA_IPA_NUMBER_OF_LINES_STR                L"Number of Lines"

	// WIA_IPA_GAMMA_CURVES                       4115 '  = &h1013
	// WIA_IPA_GAMMA_CURVES_STR                   L"Gamma Curves"

	// WIA_IPA_ITEM_SIZE                          4116 '  = &h1014
	// WIA_IPA_ITEM_SIZE_STR                      L"Item Size"

	// WIA_IPA_COLOR_PROFILE                      4117 '  = &h1015
	// WIA_IPA_COLOR_PROFILE_STR                  L"Color Profiles"

	// WIA_IPA_MIN_BUFFER_SIZE                    4118 '  = &h1016
	// WIA_IPA_MIN_BUFFER_SIZE_STR                L"Buffer Size"

	// WIA_IPA_BUFFER_SIZE                        4118 '  = &h1016
	// WIA_IPA_BUFFER_SIZE_STR                    L"Buffer Size"

	// WIA_IPA_REGION_TYPE                        4119 '  = &h1017
	// WIA_IPA_REGION_TYPE_STR                    L"Region Type"

	// WIA_IPA_ICM_PROFILE_NAME                   4120 '  = &h1018
	// WIA_IPA_ICM_PROFILE_NAME_STR               L"Color Profile Name"

	// WIA_IPA_APP_COLOR_MAPPING                  4121 '  = &h1019
	// WIA_IPA_APP_COLOR_MAPPING_STR              L"Application Applies Color Mapping"

	// WIA_IPA_PROP_STREAM_COMPAT_ID              4122 '  = &h101a
	// WIA_IPA_PROP_STREAM_COMPAT_ID_STR          L"Stream Compatibility ID"

	// WIA_IPA_FILENAME_EXTENSION                 4123 '  = &h101b
	// WIA_IPA_FILENAME_EXTENSION_STR             L"Filename extension"

	// WIA_IPA_SUPPRESS_PROPERTY_PAGE             4124 '  = &h101c
	// WIA_IPA_SUPPRESS_PROPERTY_PAGE_STR         L"Suppress a property page"

	// WIA_IPC_THUMBNAIL                          5122 '  = &h1402
	// WIA_IPC_THUMBNAIL_STR                      L"Thumbnail Data"

	// WIA_IPC_THUMB_WIDTH                        5123 '  = &h1403
	// WIA_IPC_THUMB_WIDTH_STR                    L"Thumbnail Width"

	// WIA_IPC_THUMB_HEIGHT                       5124 '  = &h1404
	// WIA_IPC_THUMB_HEIGHT_STR                   L"Thumbnail Height"

	// WIA_IPC_AUDIO_AVAILABLE                    5125 '  = &h1405
	// WIA_IPC_AUDIO_AVAILABLE_STR                L"Audio Available"

	// WIA_IPC_AUDIO_DATA_FORMAT                  5126 '  = &h1406
	// WIA_IPC_AUDIO_DATA_FORMAT_STR              L"Audio Format"

	// WIA_IPC_AUDIO_DATA                         5127 '  = &h1407
	// WIA_IPC_AUDIO_DATA_STR                     L"Audio Data"

	// WIA_IPC_NUM_PICT_PER_ROW                   5128 '  = &h1408
	// WIA_IPC_NUM_PICT_PER_ROW_STR               L"Pictures per Row"

	// WIA_IPC_SEQUENCE                           5129 '  = &h1409
	// WIA_IPC_SEQUENCE_STR                       L"Sequence Number"

	// WIA_IPC_TIMEDELAY                          5130 '  = &h140a
	// WIA_IPC_TIMEDELAY_STR                      L"Time Delay"








	// WIA_IPS_FILM_SCAN_MODE                     3104 '  = &hc20
	// WIA_IPS_FILM_SCAN_MODE_STR                 L"Film Scan Mode"

	// WIA_IPS_LAMP                               3105 '  = &hc21
	// WIA_IPS_LAMP_STR                           L"Lamp"

	// WIA_IPS_LAMP_AUTO_OFF                      3106 '  = &hc22
	// WIA_IPS_LAMP_AUTO_OFF_STR                  L"Lamp Auto Off"

	// WIA_IPS_AUTO_DESKEW                        3107 '  = &hc23
	// WIA_IPS_AUTO_DESKEW_STR                    L"Automatic Deskew"

	// WIA_IPS_SUPPORTS_CHILD_ITEM_CREATION       3108 '  = &hc24
	// WIA_IPS_SUPPORTS_CHILD_ITEM_CREATION_STR   L"Supports Child Item Creation"

	// WIA_IPS_XSCALING                           3109 '  = &hc25
	// WIA_IPS_XSCALING_STR                       L"Horizontal Scaling"

	// WIA_IPS_YSCALING                           3110 '  = &hc26
	// WIA_IPS_YSCALING_STR                       L"Vertical Scaling"

	// WIA_IPA_ITEM_CATEGORY                      4125 '  = &h101d
	// WIA_IPA_ITEM_CATEGORY_STR                  L"Item Category"

	// WIA_IPA_UPLOAD_ITEM_SIZE                   4126 '  = &h101e
	// WIA_IPA_UPLOAD_ITEM_SIZE_STR               L"Upload Item Size"

	// WIA_IPA_ITEMS_STORED                       4127 '  = &h101f
	// WIA_IPA_ITEMS_STORED_STR                   L"Items Stored"

	// WIA_IPA_RAW_BITS_PER_CHANNEL               4128 '  = &h1020
	// WIA_IPA_RAW_BITS_PER_CHANNEL_STR           L"Raw Bits Per Channel"

	// WIA_IPS_FILM_NODE_NAME                     4129 '  = &h1021
	// WIA_IPS_FILM_NODE_NAME_STR                 L"Film Node Name"

	// '
	// ' WIA_IPA_ITEM_CATEGORY constants
	// '
	// DEFINE_GUID(WIA_CATEGORY_FINISHED_FILE, = &hff2b77ca,  = &hcf84,  = &h432b,  = &ha7,  = &h35,  = &h3a,  = &h13,  = &h0d,  = &hde,  = &h2a,  = &h88);
	// DEFINE_GUID(WIA_CATEGORY_FLATBED,       = &hfb607b1f,  = &h43f3,  = &h488b,  = &h85,  = &h5b,  = &hfb,  = &h70,  = &h3e,  = &hc3,  = &h42,  = &ha6);
	// DEFINE_GUID(WIA_CATEGORY_FEEDER,        = &hfe131934,  = &hf84c,  = &h42ad,  = &h8d,  = &ha4,  = &h61,  = &h29,  = &hcd,  = &hdd,  = &h72,  = &h88);
	// DEFINE_GUID(WIA_CATEGORY_FILM,          = &hfcf65be7,  = &h3ce3,  = &h4473,  = &haf,  = &h85,  = &hf5,  = &hd3,  = &h7d,  = &h21,  = &hb6,  = &h8a);
	// DEFINE_GUID(WIA_CATEGORY_ROOT,          = &hf193526f,  = &h59b8,  = &h4a26,  = &h98,  = &h88,  = &he1,  = &h6e,  = &h4f,  = &h97,  = &hce,  = &h10);
	// DEFINE_GUID(WIA_CATEGORY_FOLDER,        = &hc692a446,  = &h6f5a,  = &h481d,  = &h85,  = &hbb,  = &h92,  = &he2,  = &he8,  = &h6f,  = &hd3,  = &ha);
	// DEFINE_GUID(WIA_CATEGORY_FEEDER_FRONT,  = &h4823175c,  = &h3b28,  = &h487b,  = &ha7,  = &he6,  = &hee,  = &hbc,  = &h17,  = &h61,  = &h4f,  = &hd1);
	// DEFINE_GUID(WIA_CATEGORY_FEEDER_BACK,   = &h61ca74d4,  = &h39db,  = &h42aa,  = &h89,  = &hb1,  = &h8c,  = &h19,  = &hc9,  = &hcd,  = &h4c,  = &h23);
	// DEFINE_GUID(WIA_CATEGORY_AUTO,          = &hdefe5fd8,  = &h6c97,  = &h4dde,  = &hb1,  = &h1e,  = &hcb,  = &h50,  = &h9b,  = &h27,  = &h0e,  = &h11);

	// '
	// ' GUID for Default Segmentation Filter
	// '
	// DEFINE_GUID(CLSID_WiaDefaultSegFilter,  = &hD4F4D30B,  = &h0B29,  = &h4508,  = &h89,  = &h22,  = &h0C,  = &h57,  = &h97,  = &hD4,  = &h27,  = &h65);

	// '
	// ' WIA_IPS_TRANSFER_CAPABILITIES flags:
	// '
	// WIA_TRANSFER_CHILDREN_SINGLE_SCAN  = &h00000001

	// '
	// ' WIA_IPS_SEGMENTATION_FILTER constants
	// '
	// WIA_USE_SEGMENTATION_FILTER       0
	// WIA_DONT_USE_SEGMENTATION_FILTER  1

	// '
	// ' WIA_IPS_FILM_SCAN_MODE constants
	// '
	// WIA_FILM_COLOR_SLIDE              0
	// WIA_FILM_COLOR_NEGATIVE           1
	// WIA_FILM_BW_NEGATIVE              2

	// '
	// ' WIA_IPS_LAMP constants
	// '
	// WIA_LAMP_ON                       0
	// WIA_LAMP_OFF                      1

	// '
	// ' WIA_IPS_AUTO_DESKEW constants:
	// '
	// WIA_AUTO_DESKEW_ON                0
	// WIA_AUTO_DESKEW_OFF               1

	// '

	// '
	// ' WIA Raw Format header:
	// '
	// typedef struct _WIA_RAW_HEADER
	// {
	// DWORD Tag;
	// DWORD Version;
	// DWORD HeaderSize;
	// DWORD XRes;
	// DWORD YRes;
	// DWORD XExtent;
	// DWORD YExtent;
	// DWORD BytesPerLine;
	// DWORD BitsPerPixel;
	// DWORD ChannelsPerPixel;
	// DWORD DataType;
	// BYTE  BitsPerChannel[8];
	// DWORD Compression;
	// DWORD PhotometricInterp;
	// DWORD LineOrder;
	// DWORD RawDataOffset;
	// DWORD RawDataSize;
	// DWORD PaletteOffset;
	// DWORD PaletteSize;
	// } WIA_RAW_HEADER;

	// typedef struct _WIA_RAW_HEADER *PWIA_RAW_HEADER;

	// #endif '#if (_WIN32_WINNT >=  = &h0600)

	// '
	// ' Use the WIA property offsets to define private WIA properties.
	// '
	// ' Example: (Creating a private WIA property)
	// '
	// '   WIA_THE_PROP         (WIA_PRIVATE_DEVPROP + 1000)
	// '   WIA_THE_PROP_STR     L"The Property")
	// '

	// '
	// ' Private property offset constants
	// '

	// WIA_PRIVATE_DEVPROP  38914 ' offset for private device (root) item properties
	// WIA_PRIVATE_ITEMPROP 71682 ' offset for private item properties

	// '
	// ' WIA image format constants
	// '

	// DEFINE_GUID(WiaImgFmt_UNDEFINED, = &hb96b3ca9, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_RAWRGB,    = &hbca48b55, = &hf272, = &h4371, = &hb0, = &hf1, = &h4a, = &h15, = &h0d, = &h05, = &h7b, = &hb4);
	// DEFINE_GUID(WiaImgFmt_MEMORYBMP, = &hb96b3caa, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_BMP,       = &hb96b3cab, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_EMF,       = &hb96b3cac, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_WMF,       = &hb96b3cad, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_JPEG,      = &hb96b3cae, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_PNG,       = &hb96b3caf, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_GIF,       = &hb96b3cb0, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_TIFF,      = &hb96b3cb1, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_EXIF,      = &hb96b3cb2, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_PHOTOCD,   = &hb96b3cb3, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_FLASHPIX,  = &hb96b3cb4, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_ICO,       = &hb96b3cb5, = &h0728, = &h11d3, = &h9d, = &h7b, = &h00, = &h00, = &hf8, = &h1e, = &hf3, = &h2e);
	// DEFINE_GUID(WiaImgFmt_CIFF,      = &h9821a8ab, = &h3a7e, = &h4215, = &h94, = &he0, = &hd2, = &h7a, = &h46, = &h0c, = &h03, = &hb2);
	// DEFINE_GUID(WiaImgFmt_PICT,      = &ha6bc85d8, = &h6b3e, = &h40ee, = &ha9, = &h5c, = &h25, = &hd4, = &h82, = &he4, = &h1a, = &hdc);
	// DEFINE_GUID(WiaImgFmt_JPEG2K,    = &h344ee2b2, = &h39db, = &h4dde, = &h81, = &h73, = &hc4, = &hb7, = &h5f, = &h8f, = &h1e, = &h49);
	// DEFINE_GUID(WiaImgFmt_JPEG2KX,   = &h43e14614, = &hc80a, = &h4850, = &hba, = &hf3, = &h4b, = &h15, = &h2d, = &hc8, = &hda, = &h27);
	// #if (_WIN32_WINNT >=  = &h0600)
	// DEFINE_GUID(WiaImgFmt_RAW,       = &h6f120719, = &hf1a8, = &h4e07, = &h9a, = &hde, = &h9b, = &h64, = &hc6, = &h3a, = &h3d, = &hcc);
	// DEFINE_GUID(WiaImgFmt_JBIG,      = &h41e8dd92, = &h2f0a, = &h43d4, = &h86, = &h36, = &hf1, = &h61, = &h4b, = &ha1, = &h1e, = &h46);
	// #endif '#if (_WIN32_WINNT >=  = &h0600)


	// '
	// ' WIA document format constants
	// '

	// DEFINE_GUID(WiaImgFmt_RTF,       = &h573dd6a3, = &h4834, = &h432d, = &ha9, = &hb5, = &he1, = &h98, = &hdd, = &h9e, = &h89, = &h0d);
	// DEFINE_GUID(WiaImgFmt_XML,       = &hb9171457, = &hdac8, = &h4884, = &hb3, = &h93, = &h15, = &hb4, = &h71, = &hd5, = &hf0, = &h7e);
	// DEFINE_GUID(WiaImgFmt_HTML,      = &hc99a4e62, = &h99de, = &h4a94, = &hac, = &hca, = &h71, = &h95, = &h6a, = &hc2, = &h97, = &h7d);
	// DEFINE_GUID(WiaImgFmt_TXT,       = &hfafd4d82, = &h723f, = &h421f, = &h93, = &h18, = &h30, = &h50, = &h1a, = &hc4, = &h4b, = &h59);
	// #if (_WIN32_WINNT >=  = &h0600)
	// DEFINE_GUID(WiaImgFmt_PDFA,      = &h9980bd5b, = &h3463, = &h43c7, = &hbd, = &hca, = &h3c, = &haa, = &h14, = &h6f, = &h22, = &h9f);
	// DEFINE_GUID(WiaImgFmt_XPS,       = &h700b4a0f, = &h2011, = &h411c, = &hb4, = &h30, = &hd1, = &he0, = &hb2, = &he1, = &h0b, = &h28);
	// #endif '#if (_WIN32_WINNT >=  = &h0600)

	// '
	// ' WIA video format constants
	// '

	// DEFINE_GUID(WiaImgFmt_MPG,       = &hecd757e4, = &hd2ec, = &h4f57, = &h95, = &h5d, = &hbc, = &hf8, = &ha9, = &h7c, = &h4e, = &h52);
	// DEFINE_GUID(WiaImgFmt_AVI,       = &h32f8ca14, = &h087c, = &h4908, = &hb7, = &hc4, = &h67, = &h57, = &hfe, = &h7e, = &h90, = &hab);

	// '
	// ' WIA audio format constants
	// '

	// DEFINE_GUID(WiaAudFmt_WAV,       = &hf818e146, = &h07af, = &h40ff, = &hae, = &h55, = &hbe, = &h8f, = &h2c, = &h06, = &h5d, = &hbe);
	// DEFINE_GUID(WiaAudFmt_MP3,       = &h0fbc71fb, = &h43bf, = &h49f2, = &h91, = &h90, = &he6, = &hfe, = &hcf, = &hf3, = &h7e, = &h54);
	// DEFINE_GUID(WiaAudFmt_AIFF,      = &h66e2bf4f, = &hb6fc, = &h443f, = &h94, = &hc8, = &h2f, = &h33, = &hc8, = &ha6, = &h5a, = &haf);
	// DEFINE_GUID(WiaAudFmt_WMA,       = &hd61d6413, = &h8bc2, = &h438f, = &h93, = &had, = &h21, = &hbd, = &h48, = &h4d, = &hb6, = &ha1);

	// '
	// ' WIA misc format constants
	// '

	// DEFINE_GUID(WiaImgFmt_ASF,       = &h8d948ee9, = &hd0aa, = &h4a12, = &h9d, = &h9a, = &h9c, = &hc5, = &hde, = &h36, = &h19, = &h9b);
	// DEFINE_GUID(WiaImgFmt_SCRIPT,    = &hfe7d6c53, = &h2dac, = &h446a, = &hb0, = &hbd, = &hd7, = &h3e, = &h21, = &he9, = &h24, = &hc9);
	// DEFINE_GUID(WiaImgFmt_e_Exec,      = &h485da097, = &h141e, = &h4aa5, = &hbb, = &h3b, = &ha5, = &h61, = &h8d, = &h95, = &hd0, = &h2b);
	// DEFINE_GUID(WiaImgFmt_UNICODE16, = &h1b7639b6, = &h6357, = &h47d1, = &h9a, = &h07, = &h12, = &h45, = &h2d, = &hc0, = &h73, = &he9);
	// DEFINE_GUID(WiaImgFmt_DPOF,      = &h369eeeab, = &ha0e8, = &h45ca, = &h86, = &ha6, = &ha8, = &h3c, = &he5, = &h69, = &h7e, = &h28);

	// '
	// ' WIA event constants
	// '

	// DEFINE_GUID(WIA_EVENT_DEVICE_DISCONNECTED, = &h143e4e83, = &h6497, = &h11d2, = &ha2, = &h31, = &h00, = &hc0, = &h4f, = &ha3, = &h18, = &h09);
	// DEFINE_GUID(WIA_EVENT_DEVICE_CONNECTED,    = &ha28bbade, = &h64b6, = &h11d2, = &ha2, = &h31, = &h00, = &hc0, = &h4f, = &ha3, = &h18, = &h09);
	// DEFINE_GUID(WIA_EVENT_ITEM_DELETED,        = &h1d22a559, = &he14f, = &h11d2, = &hb3, = &h26, = &h00, = &hc0, = &h4f, = &h68, = &hce, = &h61);
	// DEFINE_GUID(WIA_EVENT_ITEM_CREATED,        = &h4c8f4ef5, = &he14f, = &h11d2, = &hb3, = &h26, = &h00, = &hc0, = &h4f, = &h68, = &hce, = &h61);
	// DEFINE_GUID(WIA_EVENT_TREE_UPDATED,        = &hc9859b91, = &h4ab2, = &h4cd6, = &ha1, = &hfc, = &h58, = &h2e, = &hec, = &h55, = &he5, = &h85);
	// DEFINE_GUID(WIA_EVENT_VOLUME_INSERT,       = &h9638bbfd, = &hd1bd, = &h11d2, = &hb3, = &h1f, = &h00, = &hc0, = &h4f, = &h68, = &hce, = &h61);
	// DEFINE_GUID(WIA_EVENT_SCAN_IMAGE,          = &ha6c5a715, = &h8c6e, = &h11d2, = &h97, = &h7a, = &h00, = &h00, = &hf8, = &h7a, = &h92, = &h6f);
	// DEFINE_GUID(WIA_EVENT_SCAN_PRINT_IMAGE,    = &hb441f425, = &h8c6e, = &h11d2, = &h97, = &h7a, = &h00, = &h00, = &hf8, = &h7a, = &h92, = &h6f);
	// DEFINE_GUID(WIA_EVENT_SCAN_FAX_IMAGE,      = &hc00eb793, = &h8c6e, = &h11d2, = &h97, = &h7a, = &h00, = &h00, = &hf8, = &h7a, = &h92, = &h6f);
	// DEFINE_GUID(WIA_EVENT_SCAN_OCR_IMAGE,      = &h9d095b89, = &h37d6, = &h4877, = &haf, = &hed, = &h62, = &ha2, = &h97, = &hdc, = &h6d, = &hbe);
	// DEFINE_GUID(WIA_EVENT_SCAN_EMAIL_IMAGE,    = &hc686dcee, = &h54f2, = &h419e, = &h9a, = &h27, = &h2f, = &hc7, = &hf2, = &he9, = &h8f, = &h9e);
	// DEFINE_GUID(WIA_EVENT_SCAN_FILM_IMAGE,     = &h9b2b662c, = &h6185, = &h438c, = &hb6, = &h8b, = &he3, = &h9e, = &he2, = &h5e, = &h71, = &hcb);
	// DEFINE_GUID(WIA_EVENT_SCAN_IMAGE2,         = &hfc4767c1, = &hc8b3, = &h48a2, = &h9c, = &hfa, = &h2e, = &h90, = &hcb, = &h3d, = &h35, = &h90);
	// DEFINE_GUID(WIA_EVENT_SCAN_IMAGE3,         = &h154e27be, = &hb617, = &h4653, = &hac, = &hc5, = &h0f, = &hd7, = &hbd, = &h4c, = &h65, = &hce);
	// DEFINE_GUID(WIA_EVENT_SCAN_IMAGE4,         = &ha65b704a, = &h7f3c, = &h4447, = &ha7, = &h5d, = &h8a, = &h26, = &hdf, = &hca, = &h1f, = &hdf);
	// DEFINE_GUID(WIA_EVENT_STORAGE_CREATED,     = &h353308b2, = &hfe73, = &h46c8, = &h89, = &h5e, = &hfa, = &h45, = &h51, = &hcc, = &hc8, = &h5a);
	// DEFINE_GUID(WIA_EVENT_STORAGE_DELETED,     = &h5e41e75e, = &h9390, = &h44c5, = &h9a, = &h51, = &he4, = &h70, = &h19, = &he3, = &h90, = &hcf);
	// DEFINE_GUID(WIA_EVENT_STI_PROXY,           = &hd711f81f, = &h1f0d, = &h422d, = &h86, = &h41, = &h92, = &h7d, = &h1b, = &h93, = &he5, = &he5);
	// DEFINE_GUID(WIA_EVENT_CANCEL_IO,           = &hc860f7b8, = &h9ccd, = &h41ea, = &hbb, = &hbf, = &h4d, = &hd0, = &h9c, = &h5b, = &h17, = &h95);

	// '
	// ' Power management event GUIDs, sent by the WIA service to drivers
	// '

	// DEFINE_GUID(WIA_EVENT_POWER_SUSPEND,       = &ha0922ff9, = &hc3b4, = &h411c, = &h9e, = &h29, = &h03, = &ha6, = &h69, = &h93, = &hd2, = &hbe);
	// DEFINE_GUID(WIA_EVENT_POWER_RESUME,        = &h618f153e, = &hf686, = &h4350, = &h96, = &h34, = &h41, = &h15, = &ha3, = &h04, = &h83, = &h0c);

	// '
	// ' No action handler and prompt handler
	// '

	// DEFINE_GUID(WIA_EVENT_HANDLER_NO_ACTION,   = &he0372b7d, = &he115, = &h4525, = &hbc, = &h55, = &hb6, = &h29, = &he6, = &h8c, = &h74, = &h5a);
	// DEFINE_GUID(WIA_EVENT_HANDLER_PROMPT,      = &h5f4baad0, = &h4d59, = &h4fcd, = &hb2, = &h13, = &h78, = &h3c, = &he7, = &ha9, = &h2f, = &h22);

	// '
	// ' WIA command constants
	// '

	// DEFINE_GUID(WIA_CMD_SYNCHRONIZE,           = &h9b26b7b2, = &hacad, = &h11d2, = &ha0, = &h93, = &h00, = &hc0, = &h4f, = &h72, = &hdc, = &h3c);
	// DEFINE_GUID(WIA_CMD_TAKE_PICTURE,          = &haf933cac, = &hacad, = &h11d2, = &ha0, = &h93, = &h00, = &hc0, = &h4f, = &h72, = &hdc, = &h3c);
	// DEFINE_GUID(WIA_CMD_DELETE_ALL_ITEMS,      = &he208c170, = &hacad, = &h11d2, = &ha0, = &h93, = &h00, = &hc0, = &h4f, = &h72, = &hdc, = &h3c);
	// DEFINE_GUID(WIA_CMD_CHANGE_DOCUMENT,       = &h04e725b0, = &hacae, = &h11d2, = &ha0, = &h93, = &h00, = &hc0, = &h4f, = &h72, = &hdc, = &h3c);
	// DEFINE_GUID(WIA_CMD_UNLOAD_DOCUMENT,       = &h1f3b3d8e, = &hacae, = &h11d2, = &ha0, = &h93, = &h00, = &hc0, = &h4f, = &h72, = &hdc, = &h3c);
	// DEFINE_GUID(WIA_CMD_DIAGNOSTIC,            = &h10ff52f5, = &hde04, = &h4cf0, = &ha5, = &had, = &h69, = &h1f, = &h8d, = &hce, = &h01, = &h41);
	// DEFINE_GUID(WIA_CMD_FORMAT,                = &hc3a693aa, = &hf788, = &h4d34, = &ha5, = &hb0, = &hbe, = &h71, = &h90, = &h75, = &h9a, = &h24);

	// '
	// ' WIA command constants used for debugging only
	// '

	// DEFINE_GUID(WIA_CMD_DELETE_DEVICE_TREE,    = &h73815942, = &hdbea, = &h11d2, = &h84, = &h16, = &h00, = &hc0, = &h4f, = &ha3, = &h61, = &h45);
	// DEFINE_GUID(WIA_CMD_BUILD_DEVICE_TREE,     = &h9cba5ce0, = &hdbea, = &h11d2, = &h84, = &h16, = &h00, = &hc0, = &h4f, = &ha3, = &h61, = &h45);

	// FACILITY_WIA         33
	// BASE_VAL_WIA_ERROR    = &h00000000
	// BASE_VAL_WIA_SUCCESS  = &h00000000

	// WIA_ERROR_GENERAL_ERROR              MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 1)
	// WIA_ERROR_PAPER_JAM                  MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 2)
	// WIA_ERROR_PAPER_EMPTY                MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 3)
	// WIA_ERROR_PAPER_PROBLEM              MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 4)
	// WIA_ERROR_OFFLINE                    MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 5)
	// WIA_ERROR_BUSY                       MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 6)
	// WIA_ERROR_WARMING_UP                 MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 7)
	// WIA_ERROR_USER_INTERVENTION          MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 8)
	// WIA_ERROR_ITEM_DELETED               MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 9)
	// WIA_ERROR_DEVICE_COMMUNICATION       MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 10)
	// WIA_ERROR_INVALID_COMMAND            MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 11)
	// WIA_ERROR_INCORRECT_HARDWARE_SETTING MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 12)
	// WIA_ERROR_DEVICE_LOCKED              MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 13)
	// WIA_ERROR_EXCEPTION_IN_DRIVER        MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 14)
	// WIA_ERROR_INVALID_DRIVER_RESPONSE    MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 15)
	// WIA_ERROR_COVER_OPEN                 MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 16)
	// WIA_ERROR_LAMP_OFF                   MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 17)
	// WIA_ERROR_DESTINATION                MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 18)
	// WIA_ERROR_NETWORK_RESERVATION_FAILED MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 19)
	// WIA_STATUS_END_OF_MEDIA              MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 1)

	// '
	// ' Definitions for errors and status codes passed to IWiaDataTransfer::BandedDataCallback as the lReason parameter.
	// ' These codes are in addition to the errors defined above; in some cases the SEVERITY_SUCCESS version of
	// ' an error is meant to replace the SEVERITY_ERROR version listed above.
	// '

	// WIA_STATUS_WARMING_UP                MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 2)
	// WIA_STATUS_CALIBRATING               MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 3)
	// WIA_STATUS_RESERVING_NETWORK_DEVICE  MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 6)
	// WIA_STATUS_NETWORK_DEVICE_RESERVED   MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 7)
	// WIA_STATUS_CLEAR                     MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 8)
	// WIA_STATUS_SKIP_ITEM                 MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 9)
	// WIA_STATUS_NOT_HANDLED               MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 10)

	// '
	// ' The value is returned by Scansetting.dll when the user chooses to change the scanner in scandialog
	// '

	// WIA_S_CHANGE_DEVICE                  MAKE_HRESULT(SEVERITY_SUCCESS, FACILITY_WIA, 11)

	// '
	// ' SelectDeviceDlg and SelectDeviceDlgID status code when there are no devices available
	// '

	// WIA_S_NO_DEVICE_AVAILABLE            MAKE_HRESULT(SEVERITY_ERROR, FACILITY_WIA, 21)

	// '
	// ' SelectDeviceDlg and GetImageDlg flag constants
	// '

	// WIA_SELECT_DEVICE_NODEFAULT           = &h00000001

	// '
	// ' DeviceDlg and GetImageDlg flags constants
	// '

	// WIA_DEVICE_DIALOG_SINGLE_IMAGE        = &h00000002  ' Only allow one image to be selected
	// WIA_DEVICE_DIALOG_USE_COMMON_UI       = &h00000004  ' Give preference to the system-provided UI, if available

	// '
	// ' RegisterEventCallbackInterface and RegisterEventCallbackCLSID flag constants
	// '

	// WIA_REGISTER_EVENT_CALLBACK          = &h00000001
	// WIA_UNREGISTER_EVENT_CALLBACK        = &h00000002
	// WIA_SET_DEFAULT_HANDLER              = &h00000004

	// '
	// ' WIA event type constants
	// '

	// WIA_NOTIFICATION_EVENT               = &h00000001
	// WIA_ACTION_EVENT                     = &h00000002

	// '
	// ' Additional WIA raw format constants
	// '

	// WIA_LINE_ORDER_TOP_TO_BOTTOM         = &h00000001
	// WIA_LINE_ORDER_BOTTOM_TO_TOP         = &h00000002

	// '
	// ' WIA event persistent handler flag constants
	// '

	// WIA_IS_DEFAULT_HANDLER               = &h00000001

	// '
	// ' WIA connected and disconnected event description strings
	// '

	// WIA_EVENT_DEVICE_DISCONNECTED_STR L"Device Disconnected"
	// WIA_EVENT_DEVICE_CONNECTED_STR    L"Device Connected"

	// '
	// ' WIA event and command icon resource identifier constants
	// '
	// ' Events   : -1000 to -1499 (Standard), -1500 to -1999 (Custom)
	// ' Commands : -2000 to -2499 (Standard), -2500 to -2999 (Custom)
	// '

	// WIA_ICON_DEVICE_DISCONNECTED (L"sti.dll,-1001")
	// WIA_ICON_DEVICE_CONNECTED    (L"sti.dll,-1001")
	// WIA_ICON_ITEM_DELETED        (L"sti.dll,-1001")
	// WIA_ICON_ITEM_CREATED        (L"sti.dll,-1001")
	// WIA_ICON_TREE_UPDATED        (L"sti.dll,-1001")
	// WIA_ICON_VOLUME_INSERT       (L"sti.dll,-1001")
	// WIA_ICON_SCAN_BUTTON_PRESS   (L"sti.dll,-1001")
	// WIA_ICON_SYNCHRONIZE         (L"sti.dll,-2000")
	// WIA_ICON_TAKE_PICTURE        (L"sti.dll,-2001")
	// WIA_ICON_DELETE_ALL_ITEMS    (L"sti.dll,-2002")
	// WIA_ICON_CHANGE_DOCUMENT     (L"sti.dll,-2003")
	// WIA_ICON_UNLOAD_DOCUMENT     (L"sti.dll,-2004")
	// WIA_ICON_DELETE_DEVICE_TREE  (L"sti.dll,-2005")
	// WIA_ICON_BUILD_DEVICE_TREE   (L"sti.dll,-2006")

	// '
	// ' WIA TYMED constants
	// '

	// TYMED_CALLBACK                     128
	// TYMED_MULTIPAGE_FILE               256
	// TYMED_MULTIPAGE_CALLBACK           512

	// '
	// ' IWiaDataCallback and IWiaMiniDrvCallBack message ID constants
	// '

	// IT_MSG_DATA_HEADER               = &h0001
	// IT_MSG_DATA                      = &h0002
	// IT_MSG_STATUS                    = &h0003
	// IT_MSG_TERMINATION               = &h0004
	// IT_MSG_NEW_PAGE                  = &h0005
	// IT_MSG_FILE_PREVIEW_DATA         = &h0006
	// IT_MSG_FILE_PREVIEW_DATA_HEADER  = &h0007

	// '
	// ' IWiaDataCallback and IWiaMiniDrvCallBack status flag constants
	// '

	// IT_STATUS_TRANSFER_FROM_DEVICE     = &h0001
	// IT_STATUS_PROCESSING_DATA          = &h0002
	// IT_STATUS_TRANSFER_TO_CLIENT       = &h0004
	// IT_STATUS_MASK                     = &h0007 ' any status value that doesn't
	// ' fit the mask is an HRESULT
	// '
	// ' IWiaTransfer flags
	// '

	// WIA_TRANSFER_ACQUIRE_CHILDREN      = &h0001

	// '
	// ' IWiaTransferCallback Message types
	// '

	// WIA_TRANSFER_MSG_STATUS            = &h00001
	// WIA_TRANSFER_MSG_END_OF_STREAM     = &h00002
	// WIA_TRANSFER_MSG_END_OF_TRANSFER   = &h00003
	// WIA_TRANSFER_MSG_DEVICE_STATUS     = &h00005
	// WIA_TRANSFER_MSG_NEW_PAGE          = &h00006

	// '
	// ' IWiaEventCallback code constants
	// '

	// WIA_MAJOR_EVENT_DEVICE_CONNECT     = &h01
	// WIA_MAJOR_EVENT_DEVICE_DISCONNECT  = &h02
	// WIA_MAJOR_EVENT_PICTURE_TAKEN      = &h03
	// WIA_MAJOR_EVENT_PICTURE_DELETED    = &h04

	// '
	// ' WIA device connection status constants
	// '

	// WIA_DEVICE_NOT_CONNECTED         0
	// WIA_DEVICE_CONNECTED             1

	// '
	// ' EnumDeviceCapabilities and drvGetCapabilities flags
	// '

	// WIA_DEVICE_COMMANDS               1
	// WIA_DEVICE_EVENTS                 2

	// '
	// ' EnumDeviceInfo Flags
	// '

	// WIA_DEVINFO_ENUM_ALL               = &h0000000F
	// WIA_DEVINFO_ENUM_LOCAL             = &h00000010


	// '
	// ' WIA item type constants
	// '

	// WiaItemTypeFree                    = &h00000000
	// WiaItemTypeImage                   = &h00000001
	// WiaItemTypeFile                    = &h00000002
	// WiaItemTypeFolder                  = &h00000004
	// WiaItemTypeRoot                    = &h00000008
	// WiaItemTypeAnalyze                 = &h00000010
	// WiaItemTypeAudio                   = &h00000020
	// WiaItemTypeDevice                  = &h00000040
	// WiaItemTypeDeleted                 = &h00000080
	// WiaItemTypeDisconnected            = &h00000100
	// WiaItemTypeHPanorama               = &h00000200
	// WiaItemTypeVPanorama               = &h00000400
	// WiaItemTypeBurst                   = &h00000800
	// WiaItemTypeStorage                 = &h00001000
	// WiaItemTypeTransfer                = &h00002000
	// WiaItemTypeGenerated               = &h00004000
	// WiaItemTypeHasAttachments          = &h00008000
	// WiaItemTypeVideo                   = &h00010000
	// WiaItemTypeRemoved                 = &h80000000
	// '
	// '  = &h00020000 has been reserved for the TWAIN compatiblity layer
	// ' pass-through feature.
	// '
	// #if (_WIN32_WINNT >=  = &h0600)
	// WiaItemTypeDocument                = &h00040000
	// WiaItemTypeProgrammableDataSource  = &h00080000
	// WiaItemTypeMask                    = &h800FFFFF
	// #Else
	// WiaItemTypeMask                    = &h8003FFFF
	// #End If

	// '
	// ' Big max device specific item context
	// '

	// WIA_MAX_CTX_SIZE                   = &h01000000

	// '
	// ' WIA property access flag constants
	// '

	// WIA_PROP_READ             = &h01
	// WIA_PROP_WRITE            = &h02
	// WIA_PROP_RW              (WIA_PROP_READ | WIA_PROP_WRITE)
	// WIA_PROP_SYNC_REQUIRED    = &h04

	// WIA_PROP_NONE             = &h08
	// WIA_PROP_RANGE            = &h10
	// WIA_PROP_LIST             = &h20
	// WIA_PROP_FLAG             = &h40

	// WIA_PROP_CACHEABLE        = &h10000

	// '
	// ' IWiaItem2 CreateChildItem flag constants
	// '

	// COPY_PARENT_PROPERTY_VALUES        = &h40000000

	// '
	// ' WIA item access flag constants
	// '

	// WIA_ITEM_CAN_BE_DELETED   = &h80
	// WIA_ITEM_READ            WIA_PROP_READ
	// WIA_ITEM_WRITE           WIA_PROP_WRITE
	// WIA_ITEM_RD              (WIA_ITEM_READ | WIA_ITEM_CAN_BE_DELETED)
	// WIA_ITEM_RWD             (WIA_ITEM_READ | WIA_ITEM_WRITE | WIA_ITEM_CAN_BE_DELETED)

	// '
	// ' WIA property container constants
	// '

	// WIA_RANGE_MIN                          0
	// WIA_RANGE_NOM                          1
	// WIA_RANGE_MAX                          2
	// WIA_RANGE_STEP                         3
	// WIA_RANGE_NUM_ELEMS                    4

	// WIA_LIST_COUNT                         0
	// WIA_LIST_NOM                           1
	// WIA_LIST_VALUES                        2
	// WIA_LIST_NUM_ELEMS                     2

	// WIA_FLAG_NOM                           0
	// WIA_FLAG_VALUES                        1
	// WIA_FLAG_NUM_ELEMS                     2

	// '
	// ' WIA property LIST container MACROS
	// '

	// WIA_PROP_LIST_COUNT(ppv) (((PROPVARIANT*)ppv)->cal.cElems - WIA_LIST_VALUES)

	// WIA_PROP_LIST_VALUE(ppv, index)                              \\
	// ((index > ((PROPVARIANT*) ppv)->cal.cElems - WIA_LIST_VALUES) || (index < -WIA_LIST_NOM)) ?\\
	// NULL :                                                          \\
	// (((PROPVARIANT*) ppv)->vt == VT_UI1) ?                          \\
	// ((PROPVARIANT*) ppv)->caub.pElems[WIA_LIST_VALUES + index] :    \\
	// (((PROPVARIANT*) ppv)->vt == VT_UI2) ?                          \\
	// ((PROPVARIANT*) ppv)->caui.pElems[WIA_LIST_VALUES + index] :    \\
	// (((PROPVARIANT*) ppv)->vt == VT_UI4) ?                          \\
	// ((PROPVARIANT*) ppv)->caul.pElems[WIA_LIST_VALUES + index] :    \\
	// (((PROPVARIANT*) ppv)->vt == VT_I2) ?                           \\
	// ((PROPVARIANT*) ppv)->cai.pElems[WIA_LIST_VALUES + index] :     \\
	// (((PROPVARIANT*) ppv)->vt == VT_I4) ?                           \\
	// ((PROPVARIANT*) ppv)->cal.pElems[WIA_LIST_VALUES + index] :     \\
	// (((PROPVARIANT*) ppv)->vt == VT_R4) ?                           \\
	// ((PROPVARIANT*) ppv)->caflt.pElems[WIA_LIST_VALUES + index] :   \\
	// (((PROPVARIANT*) ppv)->vt == VT_R8) ?                           \\
	// ((PROPVARIANT*) ppv)->cadbl.pElems[WIA_LIST_VALUES + index] :   \\
	// (((PROPVARIANT*) ppv)->vt == VT_BSTR) ?                         \\
	// (LONG)(((PROPVARIANT*) ppv)->cabstr.pElems[WIA_LIST_VALUES + index]) : \\
	// NULL

	// '
	// ' Microsoft defined WIA property offset constants
	// '

	// WIA_DIP_FIRST                        2
	// WIA_IPA_FIRST                     4098
	// WIA_DPF_FIRST                     3330
	// WIA_IPS_FIRST                     6146
	// WIA_DPS_FIRST                     3074
	// WIA_IPC_FIRST                     5122
	// WIA_NUM_IPC                          9
	// WIA_RESERVED_FOR_NEW_PROPS        1024

	// '
	// ' WIA_DPC_WHITE_BALANCE constants
	// '

	// WHITEBALANCE_MANUAL            1
	// WHITEBALANCE_AUTO              2
	// WHITEBALANCE_ONEPUSH_AUTO      3
	// WHITEBALANCE_DAYLIGHT          4
	// WHITEBALANCE_FLORESCENT        5
	// WHITEBALANCE_TUNGSTEN          6
	// WHITEBALANCE_FLASH             7

	// '
	// ' WIA_DPC_FOCUS_MODE constants
	// '

	// FOCUSMODE_MANUAL               1
	// FOCUSMODE_AUTO                 2
	// FOCUSMODE_MACROAUTO            3

	// '
	// ' WIA_DPC_EXPOSURE_METERING_MODE constants
	// '

	// EXPOSUREMETERING_AVERAGE       1
	// EXPOSUREMETERING_CENTERWEIGHT  2
	// EXPOSUREMETERING_MULTISPOT     3
	// EXPOSUREMETERING_CENTERSPOT    4

	// '
	// ' WIA_DPC_FLASH_MODE constants
	// '

	// FLASHMODE_AUTO                 1
	// FLASHMODE_OFF                  2
	// FLASHMODE_FILL                 3
	// FLASHMODE_REDEYE_AUTO          4
	// FLASHMODE_REDEYE_FILL          5
	// FLASHMODE_EXTERNALSYNC         6

	// '
	// ' WIA_DPC_EXPOSURE_MODE constants
	// '

	// EXPOSUREMODE_MANUAL            1
	// EXPOSUREMODE_AUTO              2
	// EXPOSUREMODE_APERTURE_PRIORITY 3
	// EXPOSUREMODE_SHUTTER_PRIORITY  4
	// EXPOSUREMODE_PROGRAM_CREATIVE  5
	// EXPOSUREMODE_PROGRAM_ACTION    6
	// EXPOSUREMODE_PORTRAIT          7

	// '
	// ' WIA_DPC_CAPTURE_MODE constants
	// '

	// CAPTUREMODE_NORMAL             1
	// CAPTUREMODE_BURST              2
	// CAPTUREMODE_TIMELAPSE          3

	// '
	// ' WIA_DPC_EFFECT_MODE constants
	// '

	// EFFECTMODE_STANDARD            1
	// EFFECTMODE_BW                  2
	// EFFECTMODE_SEPIA               3

	// '
	// ' WIA_DPC_FOCUS_METERING_MODE constants
	// '

	// FOCUSMETERING_CENTERSPOT       1
	// FOCUSMETERING_MULTISPOT        2

	// '
	// ' WIA_DPC_POWER_MODE constants
	// '

	// POWERMODE_LINE                 1
	// POWERMODE_BATTERY              2



	// '
	// ' WIA_IPS_MIRROR flags
	// '

	// MIRRORED                       = &h01




	// '
	// ' WIA_DPS_TRANSPARENCY / WIA_DPS_TRANSPARENCY_STATUS flags
	// '

	// LIGHT_SOURCE_PRESENT_DETECT    = &h01
	// LIGHT_SOURCE_PRESENT           = &h02
	// LIGHT_SOURCE_DETECT_READY      = &h04
	// LIGHT_SOURCE_READY             = &h08

	// '
	// ' WIA_DPS_TRANSPARENCY_CAPABILITIES
	// '

	// TRANSPARENCY_DYNAMIC_FRAME_SUPPORT  = &h01
	// TRANSPARENCY_STATIC_FRAME_SUPPORT   = &h02

	// '
	// ' WIA_DPS_TRANSPARENCY_SELECT flags
	// '

	// LIGHT_SOURCE_SELECT            = &h001 ' currently not used
	// LIGHT_SOURCE_POSITIVE          = &h002
	// LIGHT_SOURCE_NEGATIVE          = &h004

	// '
	// ' WIA_DPS_SCAN_AHEAD_PAGES constants
	// '

	// WIA_SCAN_AHEAD_ALL            0

	// '
	// ' WIA_DPS_PAGES constants
	// '

	// ALL_PAGES                     0

	// '
	// ' Predefined strings for WIA_DPS_ENDORSER_STRING
	// '

	// WIA_ENDORSER_TOK_DATE          L"$DATE$"
	// WIA_ENDORSER_TOK_TIME          L"$TIME$"
	// WIA_ENDORSER_TOK_PAGE_COUNT    L"$PAGE_COUNT$"
	// WIA_ENDORSER_TOK_DAY           L"$DAY$"
	// WIA_ENDORSER_TOK_MONTH         L"$MONTH$"
	// WIA_ENDORSER_TOK_YEAR          L"$YEAR$"



	// '
	// ' WIA_IPA_COMPRESSION constants
	// '

	// WIA_COMPRESSION_NONE           0
	// WIA_COMPRESSION_BI_RLE4        1
	// WIA_COMPRESSION_BI_RLE8        2
	// WIA_COMPRESSION_G3             3
	// WIA_COMPRESSION_G4             4
	// WIA_COMPRESSION_JPEG           5
	// #if (_WIN32_WINNT >=  = &h0600)
	// WIA_COMPRESSION_JBIG           6
	// WIA_COMPRESSION_JPEG2K         7
	// WIA_COMPRESSION_PNG            8
	// #endif '#if (_WIN32_WINNT >=  = &h0600)

	// '
	// ' WIA_IPA_PLANAR constants
	// '

	// WIA_PACKED_PIXEL               0
	// WIA_PLANAR                     1

	// '
	// ' WIA_IPA_DATATYPE constants
	// '

	// WIA_DATA_THRESHOLD             0
	// WIA_DATA_DITHER                1
	// WIA_DATA_GRAYSCALE             2
	// WIA_DATA_COLOR                 3
	// WIA_DATA_COLOR_THRESHOLD       4
	// WIA_DATA_COLOR_DITHER          5
	// #if (_WIN32_WINNT >=  = &h0600)
	// WIA_DATA_RAW_RGB               6
	// WIA_DATA_RAW_BGR               7
	// WIA_DATA_RAW_YUV               8
	// WIA_DATA_RAW_YUVK              9
	// WIA_DATA_RAW_CMY              10
	// WIA_DATA_RAW_CMYK             11
	// #endif '#if (_WIN32_WINNT >=  = &h0600)


	// '
	// ' WIA_IPS_PHOTOMETRIC_INTERP constants
	// '

	// WIA_PHOTO_WHITE_1              0 ' white is 1, black is 0
	// WIA_PHOTO_WHITE_0              1 ' white is 0, black is 1

	// '
	// ' WIA_IPA_SUPPRESS_PROPERTY_PAGE flags
	// '

	// WIA_PROPPAGE_SCANNER_ITEM_GENERAL  = &h00000001
	// WIA_PROPPAGE_CAMERA_ITEM_GENERAL   = &h00000002
	// WIA_PROPPAGE_DEVICE_GENERAL        = &h00000004




	#endregion


}