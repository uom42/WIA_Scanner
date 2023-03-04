#nullable enable


namespace uom.WIA2.Scanner;


internal class ScannerCaps
{
	private const float HUNDREDS_TO_INCHES = 100f;
	private const float THOUSANDS_TO_INCHES = 1_000f;

	private readonly ScannerDevice _openedDevice;

	internal ScannerCaps(ScannerDevice dev) { _openedDevice = dev; }


	protected Properties _props => _openedDevice._props;


	public Point OpticalDPI
	=> new(
		_props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_OPTICAL_XRES, 0),
		_props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_OPTICAL_YRES, 0)
		);

	/*

/// <summary>Page size in Inches (for WinXP)</summary>
public SizeF PageSizeIn_XP
=> new(
_props.eGetPropertyValue(WIA_PROP_ID.WIA_DPS_PAGE_WIDTH, 0) / HUNDREDS_TO_INCHES,
_props.eGetPropertyValue(WIA_PROP_ID.WIA_DPS_PAGE_HEIGHT, 0) / HUNDREDS_TO_INCHES
);
	 */

	public WIA_PAGE_SIZE PageSizeType
		=> _props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_PAGE_SIZE, WIA_PAGE_SIZE.WIA_PAGE_CUSTOM);


	/// <summary>Page size in Inches</summary>
	public SizeF PageSizeIn
		=> new(
			_props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_PAGE_WIDTH, 0) / HUNDREDS_TO_INCHES,
			_props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_PAGE_HEIGHT, 0) / HUNDREDS_TO_INCHES
			);


	#region DocumentHandlingCaps

	public WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES DocumentHandlingCaps
		=> _props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES, (WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES)0);

	public bool DocumentHandlingCaps_CanAutoFeed
		=> DocumentHandlingCaps.HasFlag(WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES.FEED);

	public bool DocumentHandlingCaps_CanDuplex
		=> DocumentHandlingCaps_CanAutoFeed && DocumentHandlingCaps.HasFlag(WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES.DUP);




	public int DocumentHandlingCapacity
		=> _props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_DOCUMENT_HANDLING_CAPACITY, -1);


	/// <summary>НесколькоИсточниковБумаги</summary>
	public bool DocumentHandlingCaps_MultuSources
	{
		get
		{
			WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES dhc = DocumentHandlingCaps;
			return dhc.HasFlag(WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES.FEED) && dhc.HasFlag(WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES.FLAT);
		}
	}





	#endregion


	public FlatBedCaps? FlatBed_Caps
		=> DocumentHandlingCaps.HasFlag(WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES.FLAT)
		? new FlatBedCaps(this)
		: null;


	internal class FlatBedCaps
	{
		private ScannerCaps _scanCaps;
		internal FlatBedCaps(ScannerCaps scanCaps) { _scanCaps = scanCaps; }

		/// <summary>the physical horizontal dimension of a scanner's flatbed. Dimensions are defined as (WIDTH x HEIGHT) in 1/1000ths of an inch</summary>
		public SizeF SizeIn
			=> new(
				_scanCaps._props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_HORIZONTAL_BED_SIZE, 0) / THOUSANDS_TO_INCHES,
				_scanCaps._props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_VERTICAL_BED_SIZE, 0) / THOUSANDS_TO_INCHES
				);

		/// <summary>Размеры минимального и максимального документа. Dimensions are defined as (WIDTH x HEIGHT) in 1/1000ths of an inch</summary>	 
		public SizeF MinScanSizeIn
			=> new(
				_scanCaps._props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_MIN_HORIZONTAL_SIZE, 0) / THOUSANDS_TO_INCHES,
				_scanCaps._props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_MIN_VERTICAL_SIZE, 0) / THOUSANDS_TO_INCHES
				);

		public SizeF MaxScanSizeIn
			=> new(
				_scanCaps._props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_MAX_HORIZONTAL_SIZE, 0) / THOUSANDS_TO_INCHES,
				_scanCaps._props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_IPS_MAX_VERTICAL_SIZE, 0) / THOUSANDS_TO_INCHES
				);



		/// <summary>Contains the registration, or horizontal alignment, for documents placed on the flatbed. 
		/// The minidriver creates and maintains this property.</summary>
		public WIA_HORIZONTAL_REGISTRATIONS HorizontalBedRegistration
			=> _scanCaps._props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_HORIZONTAL_BED_REGISTRATION, WIA_HORIZONTAL_REGISTRATIONS.LEFT_JUSTIFIED);

		/// <summary>Contains the registration, or vertical alignment and edge detection, for documents placed on the flatbed. 
		/// The minidriver creates and maintains this property.</summary>
		public WIA_VERTICAL_BED_REGISTRATIONS VerticalBedRegistration
			=> _scanCaps._props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_VERTICAL_BED_REGISTRATION, WIA_VERTICAL_BED_REGISTRATIONS.TOP_JUSTIFIED);

	}


	public FeederCaps? Feeder_Caps
		=> DocumentHandlingCaps.HasFlag(WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES.FEED)
		? new FeederCaps(this)
		: null;


	internal class FeederCaps
	{
		private ScannerCaps _scanCaps;
		internal FeederCaps(ScannerCaps scanCaps) { _scanCaps = scanCaps; }



		/// <summary>Dimensions are defined as (WIDTH x HEIGHT) in 1/1000ths of an inch</summary>
		public SizeF SheetSizeIn
			=> new(
				_scanCaps._props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_HORIZONTAL_SHEET_FEED_SIZE, 0) / THOUSANDS_TO_INCHES,
				_scanCaps._props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_VERTICAL_SHEET_FEED_SIZE, 0) / THOUSANDS_TO_INCHES
			);


		/// <summary>'contains the physical dimensions of the smallest page that a scanner's document feeder can scan. Dimensions are defined as (WIDTH x HEIGHT) in 1/1000ths of an inch</summary>
		public SizeF MinSheetScanSizeIn
			=> new(
				_scanCaps._props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_MIN_HORIZONTAL_SHEET_FEED_SIZE, 0) / THOUSANDS_TO_INCHES,
				_scanCaps._props.eGetWiaPropertyValue(WIA_PROP_ID.WIA_DPS_MIN_VERTICAL_SHEET_FEED_SIZE, 0) / THOUSANDS_TO_INCHES
				);



		/// <summary>Contains the registration, or alignment and edge detection, for documents that are placed on the flatbed. 
		/// The minidriver creates and maintains this property. 
		/// This property indicates how the sheet is horizontally positioned on the scanning head of a handheld or sheet-fed scanner. 
		/// The property is used to predict where across the scan head a document is placed.
		/// For scanners that support more than one scan head, this property is relative to the topmost scan head.
		/// This property is mandatory for sheet-fed, scroll-fed, and handheld scanners.
		/// </summary>
		public WIA_HORIZONTAL_REGISTRATIONS? SheetFeederRegistration
			=> _scanCaps._props.eGetWiaPropertyValueSafe<WIA_HORIZONTAL_REGISTRATIONS>(WIA_PROP_ID.WIA_DPS_SHEET_FEEDER_REGISTRATION);

	}





	/*
	// PlatenColor = WIA_DPS_PLATEN_COLOR
	// PadColor = WIA_DPS_PAD_COLOR
	// DocumentHandlingStatus = WIA_DPS_DOCUMENT_HANDLING_STATUS
	// DocumentHandlingSelect = WIA_DPS_DOCUMENT_HANDLING_SELECT
	// DocumentHandlingCapacity = WIA_DPS_DOCUMENT_HANDLING_CAPACITY
	*/

}
