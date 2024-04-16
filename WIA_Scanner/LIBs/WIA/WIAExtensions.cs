#nullable enable

using Vector = WIA.Vector;


namespace uom.WIA2;


internal static class Extensions_WIA
{

	#region WIAImageToNETImage

	internal static MemoryStream WIAImageToRawBytes(this WIA.ImageFile I)
	{
		Vector vector = I.FileData;
		byte[] abBuffer = (byte[])vector.get_BinaryData();
		MemoryStream ms = new(abBuffer);
		return ms;
	}

	/// <summary>Все преобразования в памяти - может глюкнуть на больших DPI из-за нехватки памяти!</summary>
	internal static Image WIAImageToNETImageMem(this WIA.ImageFile I)
	{
		using MemoryStream ms = WIAImageToRawBytes(I);
		Image netIMG = Image.FromStream(ms);
		return netIMG;
	}

	/// <summary>Используем временный файл - обячно работает всегда.</summary>
	internal static FileInfo WIAImageToNETImageFile(this WIA.ImageFile wiaImage, WIA_IMAGE_FORMATS fmt, int? imageQualityPercent = null, FileInfo? fileToSave = null)
	{
		var wiaFormatimgFormat = fmt.eGetOutputInfoForImageFormat();// "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";// WIA.FormatID.wiaFormatPNG;

		/*
					WIA.ImageProcess myip = new WIA.ImageProcess();  // use to compress jpeg.
					myip.Filters.Add(myip.FilterInfos["Convert"].FilterID);
					myip.Filters[1].Properties["FormatID"].set_Value(WIA.FormatID.wiaFormatJPEG);
					myip.Filters[1].Properties["Quality"].set_Value(jpgQuality);

					image = myip.Apply(image);  // apply the filters
					image.SaveFile(outputFilename);
				 */

		WIA.ImageProcess myip = new WIA.ImageProcess();  // use to compress jpeg.
		myip.Filters.Add(myip.FilterInfos["Convert"].FilterID);
		Filter fltConvert = myip.Filters[1];
		fltConvert.Properties.eSetWiaPropertyValue("FormatID", wiaFormatimgFormat.ImageFormatGUIDString);
		if (imageQualityPercent.HasValue) fltConvert.Properties.eSetWiaPropertyValue("Quality", imageQualityPercent.Value.eCheckRange(0, 100));
		wiaImage = myip.Apply(wiaImage);  // apply the filters

		/*
		 
		myip = new WIA.ImageProcess();

		myip.Filters.Add()

		myip.Filters.Add(myip.FilterInfos["Exif"].FilterID);
		Filter fltExIff = myip.Filters[1];

		fltExIff.Properties

		//fltExIff.Properties.eSetWiaPropertyValue("271", "CARDA Industries Inc.");
		//.Filters.Add(.FilterInfos("Exif").FilterID)
		var prrr = fltExIff.Properties[271];
		prrr.Type = WIA.WiaPropertyType.StringPropertyType;


		fltExIff.Properties["ID"].set_Value(271);
		fltExIff.Properties["Type"].set_Value(WIA.WiaPropertyType.StringPropertyType);
		fltExIff.Properties["Value"].set_Value("ssssss");
		wiaImage = myip.Apply(wiaImage);  // apply the filters
		*/


		fileToSave ??= new(System.IO.Path.GetTempFileName());
		fileToSave.eDeleteIfExist();
		wiaImage.SaveFile(fileToSave.FullName);
		return fileToSave;
	}

	#endregion


	#region Get / Set Property


	internal static WIA.Property eGetWiaPropertyByID(this WIA.Properties props, string propID)
		=> props[propID];

	internal static WIA.Property eGetWiaPropertyByID(this WIA.Properties props, WIA_PROP_ID propID)
		=> props.eGetWiaPropertyByID(((int)propID).ToString());

	internal static WIA.Property eGetWiaPropertyByID(this WIA.Item item, WIA_PROP_ID propID)
		=> item.Properties.eGetWiaPropertyByID(propID);





	/// <summary>Searching for property by ID that may be not exist</summary>
	internal static WIA.Property? eSearchWiaPropertyByID(this WIA.Properties props, WIA_PROP_ID propID)
	{
		foreach (WIA.Property prop in props)
			if (prop.PropertyID == (int)propID) return prop;

		return null;
	}

	/// <summary>Searching for property by ID that may be not exist</summary>
	internal static WIA.Property? eSearchWiaPropertyByID(this WIA.Item item, WIA_PROP_ID propID)
		=> item.Properties.eSearchWiaPropertyByID(propID);








	internal static T? eGetWiaPropertyValueSafe<T>(this WIA.Properties props, WIA_PROP_ID propID)
		=> props.eSearchWiaPropertyByID(propID).eGetWiaPropertyValue<T>(default, true);

	internal static T? eGetWiaPropertyValueSafe<T>(this WIA.Item item, WIA_PROP_ID propID)
		=> item.Properties.eGetWiaPropertyValueSafe<T>(propID);






	internal static T? eGetWiaPropertyValue<T>(this WIA.Property? prop, T? defaultValue, bool throwOnError = false)
	{
		try
		{
			object? val = prop?.get_Value();
			return (val == null)
				? defaultValue
				: (T)val!;
		}
		catch
		{
			if (throwOnError) throw;
			return defaultValue;
		}
	}

	internal static T eGetWiaPropertyValue<T>(this WIA.Properties props, WIA_PROP_ID propID, T defaultValue, bool throwOnError = false)
		=> props.eGetWiaPropertyByID(propID).eGetWiaPropertyValue(defaultValue, throwOnError)!;


	internal static T eGetWiaPropertyValue<T>(this WIA.Item item, WIA_PROP_ID propID, T defaultValue, bool throwOnError = false)
		=> item.Properties.eGetWiaPropertyValue<T>(propID, defaultValue, throwOnError);






	internal static void eSetWiaPropertyValue(this WIA.Property? prop, object newValue)
		=> prop?.set_Value(ref newValue);

	internal static void eSetWiaPropertyValue(this WIA.Properties props, WIA_PROP_ID propID, object newValue)
	{
		WIA.Property prop = props.eGetWiaPropertyByID(propID);
		prop.set_Value(ref newValue);
	}
	internal static void eSetWiaPropertyValue(this WIA.Properties props, string propID, object newValue)
	{
		WIA.Property prop = props.eGetWiaPropertyByID(propID);
		prop.set_Value(ref newValue);
	}

	internal static void eSetWiaPropertyValue(this WIA.Item wiaItem, WIA_PROP_ID propID, object newValue)
		=> wiaItem.Properties.eSetWiaPropertyValue(propID, newValue);


	internal static (bool PropertyFound, WIA.Property? Property, T? oldValue) eSetWiaPropertyValueSafe<T>(this WIA.Item wiaItem, WIA_PROP_ID propID, T newValue)
	{
		WIA.Property? prop = wiaItem.eSearchWiaPropertyByID(propID);
		var oldValue = prop.eGetWiaPropertyValue<T>(default, false);
		prop?.eSetWiaPropertyValue(newValue!);
		return (prop != null, prop, oldValue);
	}

	#endregion



	#region DUMP

	internal static string eDumpWiaProperties(this WIA.Properties props)
	{
		List<String> lProps = new();
		foreach (WIA.Property prop in props)
		{
			WIA.WiaPropertyType pt = (WIA.WiaPropertyType)prop.Type;
			string s = $"{prop.Name}:{pt} ({prop.PropertyID}) = ";
			Object? val = prop.get_Value();
			if (val == null)
				s += "[null]";
			else if (prop.IsVector)
				s += "[binary]";
			else
				s += val.ToString().eEncloseC();

			lProps.Add(s);
		}
		var rows = lProps
			.OrderBy(s => s)
			.ToArray();
		return string.Join("\n", rows);
		/*
		System.Text.StringBuilder sbResult = new();
		sbResult.AppendLine(s);
		return sbResult.ToString();
		 */
	}



	#endregion


	private static Guid eToFormatGuid(this WIA_IMAGE_FORMATS f)
	{
		FieldInfo? staticGuidField = typeof(WIAConst)
			.GetFields(BindingFlags.Static | BindingFlags.NonPublic)
			.Where(fi => fi.FieldType == typeof(System.Guid))
			.Select(fi => (FieldData: fi, FormatAttribute: fi.GetCustomAttribute<WiaFormatAttribute>()))
			.Where(m => (m.FormatAttribute != null) && (m.FormatAttribute!.Format == f))
			.Select(fi => fi.FieldData)
			.FirstOrDefault();

		if (staticGuidField == null) throw new ArgumentOutOfRangeException(nameof(f));
		Guid g = (Guid)staticGuidField.GetValue(null);
		return g;

		/*
		return f switch
		{
			WIA_IMAGE_FORMATS.WiaImgFmt_BMP => WIA_Const.WiaImgFmt_BMP,
			WIA_IMAGE_FORMATS.WiaImgFmt_EMF => WIA_Const.WiaImgFmt_EMF,
			WIA_IMAGE_FORMATS.WiaImgFmt_WMF => WIA_Const.WiaImgFmt_WMF,
			WIA_IMAGE_FORMATS.WiaImgFmt_JPEG => WIA_Const.WiaImgFmt_JPEG,
			WIA_IMAGE_FORMATS.WiaImgFmt_PNG => WIA_Const.WiaImgFmt_PNG,
			WIA_IMAGE_FORMATS.WiaImgFmt_GIF => WIA_Const.WiaImgFmt_GIF,
			WIA_IMAGE_FORMATS.WiaImgFmt_TIFF => WIA_Const.WiaImgFmt_TIFF,
			WIA_IMAGE_FORMATS.WiaImgFmt_ICO => WIA_Const.WiaImgFmt_ICO,
			_ => throw new ArgumentOutOfRangeException(nameof(f))
		};
		  */

	}

	internal static (Guid ImageFormatGUID, string ImageFormatGUIDString, string FileExtension) eGetOutputInfoForImageFormat(this WIA_IMAGE_FORMATS f)
	{
		WiaFormatFileExtensionAttribute? extAttr = f.eGetEnumFieldCustomAttributes<WiaFormatFileExtensionAttribute>().FirstOrDefault();
		if (extAttr == null) throw new ArgumentOutOfRangeException(nameof(f));
		string ext = extAttr.FileExtension;
		Guid formatGuid = f.eToFormatGuid();
		/*
					string ext = formatGuid switch
					{
						var g when (g == WIA_Const.WiaImgFmt_BMP) => ".bmp",
						var g when (g == WIA_Const.WiaImgFmt_EMF) => ".emf",
						var g when (g == WIA_Const.WiaImgFmt_WMF) => ".wmf",
						var g when (g == WIA_Const.WiaImgFmt_JPEG) => ".jpg",
						var g when (g == WIA_Const.WiaImgFmt_PNG) => ".png",
						var g when (g == WIA_Const.WiaImgFmt_GIF) => ".gif",
						var g when (g == WIA_Const.WiaImgFmt_TIFF) => ".tif",
						var g when (g == WIA_Const.WiaImgFmt_ICO) => ".tif",
						_ => throw new ArgumentOutOfRangeException(nameof(f))
					};
		 */
		return (formatGuid, '{' + formatGuid.ToString().ToUpper() + '}', ext);
	}


	internal static bool eHasCompressionQualityParameter(this WIA_IMAGE_FORMATS f)
	{
		WiaFormatQualityAttribute? fqa = f.eGetEnumFieldCustomAttributes<WiaFormatQualityAttribute>()?.FirstOrDefault();
		return (fqa == null)
			? false
			: fqa!.HasQualityParam;
	}

	/*
	internal static bool eHasCompressionQualityParameter(this WIA_IMAGE_FORMATS? f)
	{
		WiaFormatQualityAttribute? fqa = f?.eGetEnumFieldCustomAttributes<WiaFormatQualityAttribute>()?.FirstOrDefault();
		return (fqa == null)
			? false
			: fqa!.HasQualityParam;
	}
	 */
}