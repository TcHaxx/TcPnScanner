#nullable disable
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class TcSmItem
{

    private TcSmItemDataType[] dataTypesField;

    private TcSmItemDevice deviceField;

    private decimal tcSmVersionField;

    private string tcVersionField;

    private string classNameField;

    private uint subTypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("DataType", IsNullable = false)]
    public TcSmItemDataType[] DataTypes
    {
        get
        {
            return this.dataTypesField;
        }
        set
        {
            this.dataTypesField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDevice Device
    {
        get
        {
            return this.deviceField;
        }
        set
        {
            this.deviceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TcSmVersion
    {
        get
        {
            return this.tcSmVersionField;
        }
        set
        {
            this.tcSmVersionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TcVersion
    {
        get
        {
            return this.tcVersionField;
        }
        set
        {
            this.tcVersionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ClassName
    {
        get
        {
            return this.classNameField;
        }
        set
        {
            this.classNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint SubType
    {
        get
        {
            return this.subTypeField;
        }
        set
        {
            this.subTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDataType
{

    private TcSmItemDataTypeName nameField;

    private uint bitSizeField;

    private TcSmItemDataTypeBaseType baseTypeField;

    private TcSmItemDataTypeArrayInfo arrayInfoField;

    /// <remarks/>
    public TcSmItemDataTypeName Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public uint BitSize
    {
        get
        {
            return this.bitSizeField;
        }
        set
        {
            this.bitSizeField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDataTypeBaseType BaseType
    {
        get
        {
            return this.baseTypeField;
        }
        set
        {
            this.baseTypeField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDataTypeArrayInfo ArrayInfo
    {
        get
        {
            return this.arrayInfoField;
        }
        set
        {
            this.arrayInfoField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDataTypeName
{

    private string gUIDField;

    private bool iecBaseTypeField;

    private bool autoDeleteTypeField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string GUID
    {
        get
        {
            return this.gUIDField;
        }
        set
        {
            this.gUIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IecBaseType
    {
        get
        {
            return this.iecBaseTypeField;
        }
        set
        {
            this.iecBaseTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool AutoDeleteType
    {
        get
        {
            return this.autoDeleteTypeField;
        }
        set
        {
            this.autoDeleteTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDataTypeBaseType
{

    private string gUIDField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string GUID
    {
        get
        {
            return this.gUIDField;
        }
        set
        {
            this.gUIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDataTypeArrayInfo
{

    private uint lBoundField;

    private uint elementsField;

    /// <remarks/>
    public uint LBound
    {
        get
        {
            return this.lBoundField;
        }
        set
        {
            this.lBoundField = value;
        }
    }

    /// <remarks/>
    public uint Elements
    {
        get
        {
            return this.elementsField;
        }
        set
        {
            this.elementsField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDevice
{

    private string nameField;

    private string devDataField;

    private TcSmItemDeviceImage imageField;

    private TcSmItemDeviceBox[] boxField;

    private TcSmItemDeviceProfinet profinetField;

    private uint idField;

    private uint devTypeField;

    private uint amsPortField;

    private string amsNetIdField;

    private string remoteNameField;

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
    public string DevData
    {
        get
        {
            return this.devDataField;
        }
        set
        {
            this.devDataField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDeviceImage Image
    {
        get
        {
            return this.imageField;
        }
        set
        {
            this.imageField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Box")]
    public TcSmItemDeviceBox[] Box
    {
        get
        {
            return this.boxField;
        }
        set
        {
            this.boxField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDeviceProfinet Profinet
    {
        get
        {
            return this.profinetField;
        }
        set
        {
            this.profinetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint DevType
    {
        get
        {
            return this.devTypeField;
        }
        set
        {
            this.devTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint AmsPort
    {
        get
        {
            return this.amsPortField;
        }
        set
        {
            this.amsPortField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string AmsNetId
    {
        get
        {
            return this.amsNetIdField;
        }
        set
        {
            this.amsNetIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string RemoteName
    {
        get
        {
            return this.remoteNameField;
        }
        set
        {
            this.remoteNameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceImage
{

    private string nameField;

    private uint idField;

    private uint addrTypeField;

    private uint imageTypeField;

    private uint sizeInField;

    private uint sizeOutField;

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint AddrType
    {
        get
        {
            return this.addrTypeField;
        }
        set
        {
            this.addrTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint ImageType
    {
        get
        {
            return this.imageTypeField;
        }
        set
        {
            this.imageTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint SizeIn
    {
        get
        {
            return this.sizeInField;
        }
        set
        {
            this.sizeInField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint SizeOut
    {
        get
        {
            return this.sizeOutField;
        }
        set
        {
            this.sizeOutField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBox
{

    private string nameField;

    private string commentField;

    private uint imageIdField;

    private TcSmItemDeviceBoxVars[] varsField;

    private TcSmItemDeviceBoxProfinet profinetField;

    private uint idField;

    private uint boxTypeField;

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public string Comment
    {
        get
        {
            return this.commentField;
        }
        set
        {
            this.commentField = value;
        }
    }

    /// <remarks/>
    public uint ImageId
    {
        get
        {
            return this.imageIdField;
        }
        set
        {
            this.imageIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Vars")]
    public TcSmItemDeviceBoxVars[] Vars
    {
        get
        {
            return this.varsField;
        }
        set
        {
            this.varsField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDeviceBoxProfinet Profinet
    {
        get
        {
            return this.profinetField;
        }
        set
        {
            this.profinetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint BoxType
    {
        get
        {
            return this.boxTypeField;
        }
        set
        {
            this.boxTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxVars
{

    private string nameField;

    private TcSmItemDeviceBoxVarsVar varField;

    private uint varGrpTypeField;

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDeviceBoxVarsVar Var
    {
        get
        {
            return this.varField;
        }
        set
        {
            this.varField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint VarGrpType
    {
        get
        {
            return this.varGrpTypeField;
        }
        set
        {
            this.varGrpTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxVarsVar
{

    private string nameField;

    private string commentField;

    private string typeField;

    private uint bitOffsField;

    private bool bitOffsFieldSpecified;

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public string Comment
    {
        get
        {
            return this.commentField;
        }
        set
        {
            this.commentField = value;
        }
    }

    /// <remarks/>
    public string Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    public uint BitOffs
    {
        get
        {
            return this.bitOffsField;
        }
        set
        {
            this.bitOffsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool BitOffsSpecified
    {
        get
        {
            return this.bitOffsFieldSpecified;
        }
        set
        {
            this.bitOffsFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinet
{

    private TcSmItemDeviceBoxProfinetGsdmlValue[] gsdmlValueField;

    private TcSmItemDeviceBoxProfinetGsdmlUnitDiag gsdmlUnitDiagField;

    private TcSmItemDeviceBoxProfinetGsdmlChannelDiag[] gsdmlChannelDiagField;

    private TcSmItemDeviceBoxProfinetUsedGsdmlModule[] usedGsdmlModuleField;

    private TcSmItemDeviceBoxProfinetUsedGsdmlSubModule[] usedGsdmlSubModuleField;

    private TcSmItemDeviceBoxProfinetAPI aPIField;

    private uint deviceIdField;

    private uint vendorIdField;

    private uint frameOffsetField;

    private uint protocolTypeField;

    private uint boxOnDeviceTypField;

    private uint maxPhysSlotNrField;

    private uint instanceServerPortField;

    private uint instanceClientPortField;

    private uint instanceNumberOfARsField;

    private uint instanceNumberOfAPIsField;

    private uint minDeviceIntervalField;

    private uint savePnIoBoxValuesField;

    private bool savePnIoBoxValuesFieldSpecified;

    private string boxTypeInfoField;

    private string gSDMLPathField;

    private string imagePathField;

    private string mainFamilyField;

    private string productFamilyField;

    private string orderNrField;

    private string defaultDNSNameField;

    private string vendorNameField;

    private string famDescriptionField;

    private string graphicFileField;

    private string sWVersionField;

    private string hWVersionField;

    private uint altLanguageField;

    private bool altLanguageFieldSpecified;

    private uint instanceIdField;

    private bool instanceIdFieldSpecified;

    private uint macAdd5Field;

    private bool macAdd5FieldSpecified;

    private uint flagsField;

    private bool flagsFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("GsdmlValue")]
    public TcSmItemDeviceBoxProfinetGsdmlValue[] GsdmlValue
    {
        get
        {
            return this.gsdmlValueField;
        }
        set
        {
            this.gsdmlValueField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDeviceBoxProfinetGsdmlUnitDiag GsdmlUnitDiag
    {
        get
        {
            return this.gsdmlUnitDiagField;
        }
        set
        {
            this.gsdmlUnitDiagField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("GsdmlChannelDiag")]
    public TcSmItemDeviceBoxProfinetGsdmlChannelDiag[] GsdmlChannelDiag
    {
        get
        {
            return this.gsdmlChannelDiagField;
        }
        set
        {
            this.gsdmlChannelDiagField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("UsedGsdmlModule")]
    public TcSmItemDeviceBoxProfinetUsedGsdmlModule[] UsedGsdmlModule
    {
        get
        {
            return this.usedGsdmlModuleField;
        }
        set
        {
            this.usedGsdmlModuleField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("UsedGsdmlSubModule")]
    public TcSmItemDeviceBoxProfinetUsedGsdmlSubModule[] UsedGsdmlSubModule
    {
        get
        {
            return this.usedGsdmlSubModuleField;
        }
        set
        {
            this.usedGsdmlSubModuleField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDeviceBoxProfinetAPI API
    {
        get
        {
            return this.aPIField;
        }
        set
        {
            this.aPIField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint DeviceId
    {
        get
        {
            return this.deviceIdField;
        }
        set
        {
            this.deviceIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint VendorId
    {
        get
        {
            return this.vendorIdField;
        }
        set
        {
            this.vendorIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint FrameOffset
    {
        get
        {
            return this.frameOffsetField;
        }
        set
        {
            this.frameOffsetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint ProtocolType
    {
        get
        {
            return this.protocolTypeField;
        }
        set
        {
            this.protocolTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint BoxOnDeviceTyp
    {
        get
        {
            return this.boxOnDeviceTypField;
        }
        set
        {
            this.boxOnDeviceTypField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint MaxPhysSlotNr
    {
        get
        {
            return this.maxPhysSlotNrField;
        }
        set
        {
            this.maxPhysSlotNrField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint InstanceServerPort
    {
        get
        {
            return this.instanceServerPortField;
        }
        set
        {
            this.instanceServerPortField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint InstanceClientPort
    {
        get
        {
            return this.instanceClientPortField;
        }
        set
        {
            this.instanceClientPortField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint InstanceNumberOfARs
    {
        get
        {
            return this.instanceNumberOfARsField;
        }
        set
        {
            this.instanceNumberOfARsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint InstanceNumberOfAPIs
    {
        get
        {
            return this.instanceNumberOfAPIsField;
        }
        set
        {
            this.instanceNumberOfAPIsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint MinDeviceInterval
    {
        get
        {
            return this.minDeviceIntervalField;
        }
        set
        {
            this.minDeviceIntervalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint SavePnIoBoxValues
    {
        get
        {
            return this.savePnIoBoxValuesField;
        }
        set
        {
            this.savePnIoBoxValuesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool SavePnIoBoxValuesSpecified
    {
        get
        {
            return this.savePnIoBoxValuesFieldSpecified;
        }
        set
        {
            this.savePnIoBoxValuesFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string BoxTypeInfo
    {
        get
        {
            return this.boxTypeInfoField;
        }
        set
        {
            this.boxTypeInfoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string GSDMLPath
    {
        get
        {
            return this.gSDMLPathField;
        }
        set
        {
            this.gSDMLPathField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ImagePath
    {
        get
        {
            return this.imagePathField;
        }
        set
        {
            this.imagePathField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string MainFamily
    {
        get
        {
            return this.mainFamilyField;
        }
        set
        {
            this.mainFamilyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ProductFamily
    {
        get
        {
            return this.productFamilyField;
        }
        set
        {
            this.productFamilyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string OrderNr
    {
        get
        {
            return this.orderNrField;
        }
        set
        {
            this.orderNrField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string DefaultDNSName
    {
        get
        {
            return this.defaultDNSNameField;
        }
        set
        {
            this.defaultDNSNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string VendorName
    {
        get
        {
            return this.vendorNameField;
        }
        set
        {
            this.vendorNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string FamDescription
    {
        get
        {
            return this.famDescriptionField;
        }
        set
        {
            this.famDescriptionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string GraphicFile
    {
        get
        {
            return this.graphicFileField;
        }
        set
        {
            this.graphicFileField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SWVersion
    {
        get
        {
            return this.sWVersionField;
        }
        set
        {
            this.sWVersionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string HWVersion
    {
        get
        {
            return this.hWVersionField;
        }
        set
        {
            this.hWVersionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint AltLanguage
    {
        get
        {
            return this.altLanguageField;
        }
        set
        {
            this.altLanguageField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool AltLanguageSpecified
    {
        get
        {
            return this.altLanguageFieldSpecified;
        }
        set
        {
            this.altLanguageFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint InstanceId
    {
        get
        {
            return this.instanceIdField;
        }
        set
        {
            this.instanceIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool InstanceIdSpecified
    {
        get
        {
            return this.instanceIdFieldSpecified;
        }
        set
        {
            this.instanceIdFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint MacAdd5
    {
        get
        {
            return this.macAdd5Field;
        }
        set
        {
            this.macAdd5Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool MacAdd5Specified
    {
        get
        {
            return this.macAdd5FieldSpecified;
        }
        set
        {
            this.macAdd5FieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint Flags
    {
        get
        {
            return this.flagsField;
        }
        set
        {
            this.flagsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool FlagsSpecified
    {
        get
        {
            return this.flagsFieldSpecified;
        }
        set
        {
            this.flagsFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetGsdmlValue
{

    private string[] recordTextField;

    private string idField;

    private string contentField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RecordText")]
    public string[] RecordText
    {
        get
        {
            return this.recordTextField;
        }
        set
        {
            this.recordTextField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Content
    {
        get
        {
            return this.contentField;
        }
        set
        {
            this.contentField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetGsdmlUnitDiag
{

    private TcSmItemDeviceBoxProfinetGsdmlUnitDiagUnitDiagData[] unitDiagDataField;

    private uint userStructureIdentField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("UnitDiagData")]
    public TcSmItemDeviceBoxProfinetGsdmlUnitDiagUnitDiagData[] UnitDiagData
    {
        get
        {
            return this.unitDiagDataField;
        }
        set
        {
            this.unitDiagDataField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint UserStructureIdent
    {
        get
        {
            return this.userStructureIdentField;
        }
        set
        {
            this.userStructureIdentField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetGsdmlUnitDiagUnitDiagData
{

    private string nameField;

    private string dataTypeField;

    private uint byteOffsetField;

    private bool byteOffsetFieldSpecified;

    private uint bitOffsetField;

    private bool bitOffsetFieldSpecified;

    private uint bitLengthField;

    private bool bitLengthFieldSpecified;

    private string valueItemTargetField;

    private uint dataLengthField;

    private bool dataLengthFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string DataType
    {
        get
        {
            return this.dataTypeField;
        }
        set
        {
            this.dataTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint ByteOffset
    {
        get
        {
            return this.byteOffsetField;
        }
        set
        {
            this.byteOffsetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ByteOffsetSpecified
    {
        get
        {
            return this.byteOffsetFieldSpecified;
        }
        set
        {
            this.byteOffsetFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint BitOffset
    {
        get
        {
            return this.bitOffsetField;
        }
        set
        {
            this.bitOffsetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool BitOffsetSpecified
    {
        get
        {
            return this.bitOffsetFieldSpecified;
        }
        set
        {
            this.bitOffsetFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint BitLength
    {
        get
        {
            return this.bitLengthField;
        }
        set
        {
            this.bitLengthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool BitLengthSpecified
    {
        get
        {
            return this.bitLengthFieldSpecified;
        }
        set
        {
            this.bitLengthFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ValueItemTarget
    {
        get
        {
            return this.valueItemTargetField;
        }
        set
        {
            this.valueItemTargetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint DataLength
    {
        get
        {
            return this.dataLengthField;
        }
        set
        {
            this.dataLengthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DataLengthSpecified
    {
        get
        {
            return this.dataLengthFieldSpecified;
        }
        set
        {
            this.dataLengthFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetGsdmlChannelDiag
{

    private string typeInfoField;

    private uint errorTypeField;

    private uint aPIField;

    private bool aPIFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TypeInfo
    {
        get
        {
            return this.typeInfoField;
        }
        set
        {
            this.typeInfoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint ErrorType
    {
        get
        {
            return this.errorTypeField;
        }
        set
        {
            this.errorTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint API
    {
        get
        {
            return this.aPIField;
        }
        set
        {
            this.aPIField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool APISpecified
    {
        get
        {
            return this.aPIFieldSpecified;
        }
        set
        {
            this.aPIFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetUsedGsdmlModule
{

    private uint slotField;

    private TcSmItemDeviceBoxProfinetUsedGsdmlModuleSubSlot[] subSlotField;

    private uint moduleIdentNumberField;

    private string moduleNameField;

    private string infoTextField;

    private string orderNumberField;

    private string idField;

    private string moduleCategoryField;

    /// <remarks/>
    public uint Slot
    {
        get
        {
            return this.slotField;
        }
        set
        {
            this.slotField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SubSlot")]
    public TcSmItemDeviceBoxProfinetUsedGsdmlModuleSubSlot[] SubSlot
    {
        get
        {
            return this.subSlotField;
        }
        set
        {
            this.subSlotField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint ModuleIdentNumber
    {
        get
        {
            return this.moduleIdentNumberField;
        }
        set
        {
            this.moduleIdentNumberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ModuleName
    {
        get
        {
            return this.moduleNameField;
        }
        set
        {
            this.moduleNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string InfoText
    {
        get
        {
            return this.infoTextField;
        }
        set
        {
            this.infoTextField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string OrderNumber
    {
        get
        {
            return this.orderNumberField;
        }
        set
        {
            this.orderNumberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ModuleCategory
    {
        get
        {
            return this.moduleCategoryField;
        }
        set
        {
            this.moduleCategoryField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetUsedGsdmlModuleSubSlot
{

    private string possibleSubModuleField;

    private string insertedSubModuleIDField;

    private uint subSlotNumberField;

    private bool isFixedField;

    /// <remarks/>
    public string PossibleSubModule
    {
        get
        {
            return this.possibleSubModuleField;
        }
        set
        {
            this.possibleSubModuleField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string InsertedSubModuleID
    {
        get
        {
            return this.insertedSubModuleIDField;
        }
        set
        {
            this.insertedSubModuleIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint SubSlotNumber
    {
        get
        {
            return this.subSlotNumberField;
        }
        set
        {
            this.subSlotNumberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsFixed
    {
        get
        {
            return this.isFixedField;
        }
        set
        {
            this.isFixedField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetUsedGsdmlSubModule
{

    private TcSmItemDeviceBoxProfinetUsedGsdmlSubModuleDataItemIn[] dataItemInField;

    private TcSmItemDeviceBoxProfinetUsedGsdmlSubModuleDataItemOut[] dataItemOutField;

    private TcSmItemDeviceBoxProfinetUsedGsdmlSubModuleRecord recordField;

    private uint subModuleIdentNumberField;

    private uint subSlotNumberField;

    private bool subSlotNumberFieldSpecified;

    private string idField;

    private string subModuleNameField;

    private string infoTextField;

    private uint aPINrField;

    private bool aPINrFieldSpecified;

    private string virtRealDataField;

    private string subModuleCategoryField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("DataItemIn")]
    public TcSmItemDeviceBoxProfinetUsedGsdmlSubModuleDataItemIn[] DataItemIn
    {
        get
        {
            return this.dataItemInField;
        }
        set
        {
            this.dataItemInField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("DataItemOut")]
    public TcSmItemDeviceBoxProfinetUsedGsdmlSubModuleDataItemOut[] DataItemOut
    {
        get
        {
            return this.dataItemOutField;
        }
        set
        {
            this.dataItemOutField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDeviceBoxProfinetUsedGsdmlSubModuleRecord Record
    {
        get
        {
            return this.recordField;
        }
        set
        {
            this.recordField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint SubModuleIdentNumber
    {
        get
        {
            return this.subModuleIdentNumberField;
        }
        set
        {
            this.subModuleIdentNumberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint SubSlotNumber
    {
        get
        {
            return this.subSlotNumberField;
        }
        set
        {
            this.subSlotNumberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool SubSlotNumberSpecified
    {
        get
        {
            return this.subSlotNumberFieldSpecified;
        }
        set
        {
            this.subSlotNumberFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SubModuleName
    {
        get
        {
            return this.subModuleNameField;
        }
        set
        {
            this.subModuleNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string InfoText
    {
        get
        {
            return this.infoTextField;
        }
        set
        {
            this.infoTextField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint APINr
    {
        get
        {
            return this.aPINrField;
        }
        set
        {
            this.aPINrField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool APINrSpecified
    {
        get
        {
            return this.aPINrFieldSpecified;
        }
        set
        {
            this.aPINrFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string VirtRealData
    {
        get
        {
            return this.virtRealDataField;
        }
        set
        {
            this.virtRealDataField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SubModuleCategory
    {
        get
        {
            return this.subModuleCategoryField;
        }
        set
        {
            this.subModuleCategoryField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetUsedGsdmlSubModuleDataItemIn
{

    private string nameField;

    private uint varSizeField;

    private string varTypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint VarSize
    {
        get
        {
            return this.varSizeField;
        }
        set
        {
            this.varSizeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string VarType
    {
        get
        {
            return this.varTypeField;
        }
        set
        {
            this.varTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetUsedGsdmlSubModuleDataItemOut
{

    private string nameField;

    private uint varSizeField;

    private string varTypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint VarSize
    {
        get
        {
            return this.varSizeField;
        }
        set
        {
            this.varSizeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string VarType
    {
        get
        {
            return this.varTypeField;
        }
        set
        {
            this.varTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetUsedGsdmlSubModuleRecord
{

    private uint constDataField;

    private TcSmItemDeviceBoxProfinetUsedGsdmlSubModuleRecordRecordDataDef recordDataDefField;

    private string nameField;

    private uint lengthField;

    private uint indexField;

    /// <remarks/>
    public uint ConstData
    {
        get
        {
            return this.constDataField;
        }
        set
        {
            this.constDataField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDeviceBoxProfinetUsedGsdmlSubModuleRecordRecordDataDef RecordDataDef
    {
        get
        {
            return this.recordDataDefField;
        }
        set
        {
            this.recordDataDefField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint Length
    {
        get
        {
            return this.lengthField;
        }
        set
        {
            this.lengthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint Index
    {
        get
        {
            return this.indexField;
        }
        set
        {
            this.indexField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetUsedGsdmlSubModuleRecordRecordDataDef
{

    private uint[] allowedValueField;

    private string nameField;

    private string dataTypeField;

    private uint dataLengthField;

    private bool dataLengthFieldSpecified;

    private bool visibleField;

    private bool changeableField;

    private string valueItemTargetField;

    private uint maxAllowedValueField;

    private bool maxAllowedValueFieldSpecified;

    private uint defaultValueField;

    private bool defaultValueFieldSpecified;

    private uint bitLengthField;

    private bool bitLengthFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AllowedValue")]
    public uint[] AllowedValue
    {
        get
        {
            return this.allowedValueField;
        }
        set
        {
            this.allowedValueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string DataType
    {
        get
        {
            return this.dataTypeField;
        }
        set
        {
            this.dataTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint DataLength
    {
        get
        {
            return this.dataLengthField;
        }
        set
        {
            this.dataLengthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DataLengthSpecified
    {
        get
        {
            return this.dataLengthFieldSpecified;
        }
        set
        {
            this.dataLengthFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool Visible
    {
        get
        {
            return this.visibleField;
        }
        set
        {
            this.visibleField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool Changeable
    {
        get
        {
            return this.changeableField;
        }
        set
        {
            this.changeableField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ValueItemTarget
    {
        get
        {
            return this.valueItemTargetField;
        }
        set
        {
            this.valueItemTargetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint MaxAllowedValue
    {
        get
        {
            return this.maxAllowedValueField;
        }
        set
        {
            this.maxAllowedValueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool MaxAllowedValueSpecified
    {
        get
        {
            return this.maxAllowedValueFieldSpecified;
        }
        set
        {
            this.maxAllowedValueFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint DefaultValue
    {
        get
        {
            return this.defaultValueField;
        }
        set
        {
            this.defaultValueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DefaultValueSpecified
    {
        get
        {
            return this.defaultValueFieldSpecified;
        }
        set
        {
            this.defaultValueFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint BitLength
    {
        get
        {
            return this.bitLengthField;
        }
        set
        {
            this.bitLengthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool BitLengthSpecified
    {
        get
        {
            return this.bitLengthFieldSpecified;
        }
        set
        {
            this.bitLengthFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetAPI
{

    private string nameField;

    private uint imageIdField;

    private TcSmItemDeviceBoxProfinetAPIModule[] moduleField;

    private uint idField;

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public uint ImageId
    {
        get
        {
            return this.imageIdField;
        }
        set
        {
            this.imageIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Module")]
    public TcSmItemDeviceBoxProfinetAPIModule[] Module
    {
        get
        {
            return this.moduleField;
        }
        set
        {
            this.moduleField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetAPIModule
{

    private string nameField;

    private string commentField;

    private uint imageIdField;

    private TcSmItemDeviceBoxProfinetAPIModuleSubModule[] subModuleField;

    private string idField;

    private bool dAPField;

    private bool dAPFieldSpecified;

    private uint moduleIdentNumberField;

    private string moduleInfoField;

    private uint slotNumberField;

    private bool slotNumberFieldSpecified;

    private string moduleIDField;

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public string Comment
    {
        get
        {
            return this.commentField;
        }
        set
        {
            this.commentField = value;
        }
    }

    /// <remarks/>
    public uint ImageId
    {
        get
        {
            return this.imageIdField;
        }
        set
        {
            this.imageIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SubModule")]
    public TcSmItemDeviceBoxProfinetAPIModuleSubModule[] SubModule
    {
        get
        {
            return this.subModuleField;
        }
        set
        {
            this.subModuleField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool DAP
    {
        get
        {
            return this.dAPField;
        }
        set
        {
            this.dAPField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DAPSpecified
    {
        get
        {
            return this.dAPFieldSpecified;
        }
        set
        {
            this.dAPFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint ModuleIdentNumber
    {
        get
        {
            return this.moduleIdentNumberField;
        }
        set
        {
            this.moduleIdentNumberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ModuleInfo
    {
        get
        {
            return this.moduleInfoField;
        }
        set
        {
            this.moduleInfoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint SlotNumber
    {
        get
        {
            return this.slotNumberField;
        }
        set
        {
            this.slotNumberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool SlotNumberSpecified
    {
        get
        {
            return this.slotNumberFieldSpecified;
        }
        set
        {
            this.slotNumberFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ModuleID
    {
        get
        {
            return this.moduleIDField;
        }
        set
        {
            this.moduleIDField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetAPIModuleSubModule
{

    private string nameField;

    private string commentField;

    private uint imageIdField;

    private TcSmItemDeviceBoxProfinetAPIModuleSubModuleRecord recordField;

    private TcSmItemDeviceBoxProfinetAPIModuleSubModuleVars[] varsField;

    private string idField;

    private uint subModuleIdentNumberField;

    private uint subSlotNumberField;

    private bool isFixSubmoduleField;

    private string subModuleIDField;

    private uint addSubModFlagsField;

    private bool addSubModFlagsFieldSpecified;

    private string interfaceDataField;

    private uint irtPropDataField;

    private bool irtPropDataFieldSpecified;

    private string portDataField;

    private uint aPINrField;

    private bool aPINrFieldSpecified;

    private uint ioInputMinFactorField;

    private bool ioInputMinFactorFieldSpecified;

    private uint ioOutputMinFactorField;

    private bool ioOutputMinFactorFieldSpecified;

    private string virtRealDataField;

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public string Comment
    {
        get
        {
            return this.commentField;
        }
        set
        {
            this.commentField = value;
        }
    }

    /// <remarks/>
    public uint ImageId
    {
        get
        {
            return this.imageIdField;
        }
        set
        {
            this.imageIdField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDeviceBoxProfinetAPIModuleSubModuleRecord Record
    {
        get
        {
            return this.recordField;
        }
        set
        {
            this.recordField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Vars")]
    public TcSmItemDeviceBoxProfinetAPIModuleSubModuleVars[] Vars
    {
        get
        {
            return this.varsField;
        }
        set
        {
            this.varsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint SubModuleIdentNumber
    {
        get
        {
            return this.subModuleIdentNumberField;
        }
        set
        {
            this.subModuleIdentNumberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint SubSlotNumber
    {
        get
        {
            return this.subSlotNumberField;
        }
        set
        {
            this.subSlotNumberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsFixSubmodule
    {
        get
        {
            return this.isFixSubmoduleField;
        }
        set
        {
            this.isFixSubmoduleField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SubModuleID
    {
        get
        {
            return this.subModuleIDField;
        }
        set
        {
            this.subModuleIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint AddSubModFlags
    {
        get
        {
            return this.addSubModFlagsField;
        }
        set
        {
            this.addSubModFlagsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool AddSubModFlagsSpecified
    {
        get
        {
            return this.addSubModFlagsFieldSpecified;
        }
        set
        {
            this.addSubModFlagsFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string InterfaceData
    {
        get
        {
            return this.interfaceDataField;
        }
        set
        {
            this.interfaceDataField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint IrtPropData
    {
        get
        {
            return this.irtPropDataField;
        }
        set
        {
            this.irtPropDataField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IrtPropDataSpecified
    {
        get
        {
            return this.irtPropDataFieldSpecified;
        }
        set
        {
            this.irtPropDataFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string PortData
    {
        get
        {
            return this.portDataField;
        }
        set
        {
            this.portDataField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint APINr
    {
        get
        {
            return this.aPINrField;
        }
        set
        {
            this.aPINrField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool APINrSpecified
    {
        get
        {
            return this.aPINrFieldSpecified;
        }
        set
        {
            this.aPINrFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint IoInputMinFactor
    {
        get
        {
            return this.ioInputMinFactorField;
        }
        set
        {
            this.ioInputMinFactorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IoInputMinFactorSpecified
    {
        get
        {
            return this.ioInputMinFactorFieldSpecified;
        }
        set
        {
            this.ioInputMinFactorFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint IoOutputMinFactor
    {
        get
        {
            return this.ioOutputMinFactorField;
        }
        set
        {
            this.ioOutputMinFactorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IoOutputMinFactorSpecified
    {
        get
        {
            return this.ioOutputMinFactorFieldSpecified;
        }
        set
        {
            this.ioOutputMinFactorFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string VirtRealData
    {
        get
        {
            return this.virtRealDataField;
        }
        set
        {
            this.virtRealDataField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetAPIModuleSubModuleRecord
{

    private uint lengthField;

    private uint indexField;

    private uint constDataField;

    private bool constDataFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint Length
    {
        get
        {
            return this.lengthField;
        }
        set
        {
            this.lengthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint Index
    {
        get
        {
            return this.indexField;
        }
        set
        {
            this.indexField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint ConstData
    {
        get
        {
            return this.constDataField;
        }
        set
        {
            this.constDataField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ConstDataSpecified
    {
        get
        {
            return this.constDataFieldSpecified;
        }
        set
        {
            this.constDataFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetAPIModuleSubModuleVars
{

    private string nameField;

    private TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVar[] varField;

    private uint varGrpTypeField;

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Var")]
    public TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVar[] Var
    {
        get
        {
            return this.varField;
        }
        set
        {
            this.varField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint VarGrpType
    {
        get
        {
            return this.varGrpTypeField;
        }
        set
        {
            this.varGrpTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVar
{

    private string nameField;

    private TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVarType typeField;

    private uint bitOffsField;

    private string swappingField;

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVarType Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    public uint BitOffs
    {
        get
        {
            return this.bitOffsField;
        }
        set
        {
            this.bitOffsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Swapping
    {
        get
        {
            return this.swappingField;
        }
        set
        {
            this.swappingField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVarType
{

    private string gUIDField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string GUID
    {
        get
        {
            return this.gUIDField;
        }
        set
        {
            this.gUIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceProfinet
{

    private TcSmItemDeviceProfinetEthernet ethernetField;

    private uint pLCPortNrField;

    private uint addPortCountField;

    /// <remarks/>
    public TcSmItemDeviceProfinetEthernet Ethernet
    {
        get
        {
            return this.ethernetField;
        }
        set
        {
            this.ethernetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint PLCPortNr
    {
        get
        {
            return this.pLCPortNrField;
        }
        set
        {
            this.pLCPortNrField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint AddPortCount
    {
        get
        {
            return this.addPortCountField;
        }
        set
        {
            this.addPortCountField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class TcSmItemDeviceProfinetEthernet
{

    private bool promiscuousModeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool PromiscuousMode
    {
        get
        {
            return this.promiscuousModeField;
        }
        set
        {
            this.promiscuousModeField = value;
        }
    }
}

