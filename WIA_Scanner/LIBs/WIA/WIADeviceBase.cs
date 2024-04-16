#nullable enable

using uom.AutoDisposable;


namespace uom.WIA2;


internal abstract class WIADeviceBase : AutoDisposableCOM
{
	protected WIAManager _manager;
	protected DeviceInfo _comDevInfo;

	internal WIADeviceBase(WIAManager mgr, DeviceInfo comDevInfo)
	{
		_manager = mgr;
		_comDevInfo = comDevInfo;
		RegisterDisposableCOMObject(_comDevInfo);

		ReadProperties();
	}



	public String ID => _comDevInfo.DeviceID;

	public string UniqueDeviceID { get; private set; } = string.Empty;
	public string Name { get; private set; } = string.Empty;
	public string Manufacturer { get; private set; } = string.Empty;
	public string Description { get; private set; } = string.Empty;
	public string WIAVersion { get; private set; } = string.Empty;
	public string DriverVersion { get; private set; } = string.Empty;
	public string PnPIDString { get; private set; } = string.Empty;




	public override string ToString() => Name;



	public WiaDeviceType DeviceType => _comDevInfo.Type;


	private void ReadProperties()
	{

		foreach (WIA.Property rProp in _comDevInfo.Properties)
			InitProperty(rProp);

		//string sPropertiesDump = _comDevInfo.Properties.eDumpWiaProperties();
		//Debug.WriteLine(sPropertiesDump);
	}

	private void InitProperty(WIA.Property rProp)
	{
		WIA_PROP_ID id = (WIA_PROP_ID)rProp.PropertyID;

		//string propName = rProp.Name ?? "";			if (string.IsNullOrWhiteSpace(propName)) return;

		object? propValue = rProp.get_Value();
		if (propValue == null) return;

		InitProperty(id, propValue);
	}

	protected virtual void InitProperty(WIA_PROP_ID id, object propValue)
	{
		switch (id)
		{
			case WIA_PROP_ID.WIA_DIP_DEV_ID: { UniqueDeviceID = propValue.ToString(); break; }
			case WIA_PROP_ID.WIA_DIP_VEND_DESC: { Manufacturer = propValue.ToString(); break; }
			case WIA_PROP_ID.WIA_DIP_DEV_DESC: { Description = propValue.ToString(); break; }
			case WIA_PROP_ID.WIA_DIP_DEV_NAME: { Name = propValue.ToString(); break; }
			case WIA_PROP_ID.WIA_DIP_WIA_VERSION: { WIAVersion = propValue.ToString(); break; }
			case WIA_PROP_ID.WIA_DIP_DRIVER_VERSION: { DriverVersion = propValue.ToString(); break; }
			case WIA_PROP_ID.WIA_DIP_PNP_ID: { PnPIDString = propValue.ToString(); break; }
			default: break;
		}
	}

}


