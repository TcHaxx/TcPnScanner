using dsian.TcPnScanner.CLI.Packets;
using dsian.TcPnScanner.CLI.PnDevice;
using System.Buffers.Binary;
using System.Xml.Serialization;

namespace dsian.TcPnScanner.CLI.Export.TC;

internal class XtiExporter : IExporter
{
    public MemoryStream Export(IEnumerable<Device> devices)
    {
        Guard.ThrowIfNull(devices, nameof(devices));

        if (!devices.Any())
        {
            return new MemoryStream(Array.Empty<byte>());
        }

        var tcSmItem = MapDevices(devices);

        return Serialize(tcSmItem);
    }

    private static TcSmItem MapDevices(IEnumerable<Device> devices)
    {
        var tcSmItem = Create();

        var boxes = new List<TcSmItemDeviceBox>(devices.Count(x => x.PnIoConnectRequestPacket is not null));
        foreach (var device in devices.Where(x => x.PnIoConnectRequestPacket is not null))
        {
            var box = new TcSmItemDeviceBox
            {
                BoxType = Constants.BOXTYPE_PROFINET_GENERIC,
                Comment = $"""
                auto-generated by {AssemblyHelper.Name} v{AssemblyHelper.Version}
                """,
                Id = (uint)boxes.Count + 1u,
                Name = device.NameOfStation,
                Vars = DefaultBoxVars.GetDefaultVars(),
                Profinet = GetProfinetParameter(device),
                ImageId = Constants.BOX_IMAGE_ID
            };
            boxes.Add(box);
        }

        tcSmItem.Device.Box = boxes.ToArray();
        return tcSmItem;
    }

    private static TcSmItem Create()
    {
        return new TcSmItem
        {
            TcSmVersion = 1,
            ClassName = "CDevEthernetProtocolPnSlaveDef",
            TcVersion = "3.1.4024.0",
            SubType = Constants.IODEVICETYPE_PROFINETIODEVICE,
            Device = new TcSmItemDevice
            {
                Id = 1,
                DevType = Constants.IODEVICETYPE_PROFINETIODEVICE,
                AmsPort = Constants.AMS_PORT_USEDEFAULT,
                Name = "__FILENAME__",
                Image = new TcSmItemDeviceImage
                {
                    Id = 1,
                    AddrType = 1,
                    ImageType = 3,
                    Name = "Image"
                },
                AmsNetId = "127.0.0.1.2.1",
                RemoteName = "",
                Profinet = new TcSmItemDeviceProfinet
                {
                    AddPortCount = 1,
                    PLCPortNr = 851,
                },
            }
        };
    }

    private static TcSmItemDeviceBoxProfinet GetProfinetParameter(Device device)
    {
        Guard.ThrowIfNull(device.PnIoConnectRequestPacket);

        var ioCRBlockReqInput = device.PnIoConnectRequestPacket.IOCRBlockReqInput;
        if (ioCRBlockReqInput.APIs.Length == 0)
        {
            throw new InvalidDataException($"Expected API length > 0");
        }

        return new TcSmItemDeviceBoxProfinet
        {
            DeviceId = ExtractDeviceId(device.PnIoConnectRequestPacket.DceRpcRequestHeader.ObjectUUID),
            VendorId = ExtractVendorId(device.PnIoConnectRequestPacket.DceRpcRequestHeader.ObjectUUID),
            VendorName = "dsian",
            FrameOffset = Constants.BOX_PROFINET_FRAME_OFFSET,
            Flags = Constants.BOX_PROFINET_FLAGS,
            FlagsSpecified = true,
            BoxOnDeviceTyp = Constants.IODEVICETYPE_PROFINETIODEVICE,
            ProtocolType = 4,
            MaxPhysSlotNr = 255,
            InstanceServerPort = 50000,
            InstanceClientPort = 50001,
            DefaultDNSName = device.NameOfStation,
            InstanceId = ExtractInstanceId(device.PnIoConnectRequestPacket.DceRpcRequestHeader.ObjectUUID),
            InstanceIdSpecified = true,
            InstanceNumberOfAPIs = 1,
            InstanceNumberOfARs = ioCRBlockReqInput.APIs[0].NumberOfIODataObjects,
            MinDeviceInterval = device.PnIoConnectRequestPacket.IOCRBlockReqInput.SendClockFactor,

            API = new TcSmItemDeviceBoxProfinetAPI
            {
                Name = "API",
                Id = 1,
                ImageId = Constants.API_IMAGE_ID,
                Module = GetModules(device.PnIoConnectRequestPacket.ExpectedSubmoduleBlockRequests)
            }
        };
    }

    private static TcSmItemDeviceBoxProfinetAPIModule[] GetModules(List<ExpectedSubmoduleBlockReq> expectedSubmoduleBlockRequests)
    {
        var modules = new List<TcSmItemDeviceBoxProfinetAPIModule>(expectedSubmoduleBlockRequests.Count);

        foreach (var module in expectedSubmoduleBlockRequests)
        {
            var api = module.APIs.First();

            bool isDap = api.SlotNumber == 0;
            modules.Add(new TcSmItemDeviceBoxProfinetAPIModule
            {
                Id = PrintAsHex(CreateModuleIndex(Constants.MODULE_INDEX_START, (ushort)(api.SlotNumber + 1))),
                DAP = isDap,
                DAPSpecified = isDap,
                ModuleIdentNumber = api.ModuleIdentNumber,
                Name = isDap ? "Term 1 (DAP Module)" : $"Term {api.SlotNumber + 1}{PrintTermIoLabel(api)}",
                SlotNumber = api.SlotNumber,
                SlotNumberSpecified = true,
                ImageId = Constants.TERM_IMAGE_ID,
                SubModule = GetSubModules(api)
            });
        }

        return modules.ToArray();
    }

    private static string PrintTermIoLabel(APIExpectedSubmoduleBlockReq expectedSubmoduleBlockRequests)
    {
        if (expectedSubmoduleBlockRequests.NumberOfSubmodules is not 1)
        {
            return string.Empty;
        }

        var subModule = expectedSubmoduleBlockRequests.Submodules.First();
        return PrintSubTermIoLabel(subModule);
    }

    private static string PrintSubTermIoLabel(Submodule submodule)
    {

        switch (submodule.SubmoduleProperties & 0x3)
        {
            default:
            case 0:
                return string.Empty;
            case 1:
                return $" ({submodule.DataDescriptionInput.SubmoduleDataLength} Byte Input)";
            case 2:
                return $" ({submodule.DataDescriptionOutput.SubmoduleDataLength} Byte Output)";
            case 3:
                if (submodule.DataDescriptionInput.SubmoduleDataLength == submodule.DataDescriptionOutput.SubmoduleDataLength)
                {
                    return $" ({submodule.DataDescriptionInput.SubmoduleDataLength} Byte In- and Output)";
                }
                return $" ({submodule.DataDescriptionInput.SubmoduleDataLength} Byte In- and {submodule.DataDescriptionOutput.SubmoduleDataLength} Byte Output)";
        }
    }

    private static TcSmItemDeviceBoxProfinetAPIModuleSubModule[] GetSubModules(APIExpectedSubmoduleBlockReq api)
    {

        var subModules = new List<TcSmItemDeviceBoxProfinetAPIModuleSubModule>(api.Submodules.Length);

        foreach (var submodule in api.Submodules)
        {
            var subModuleToAdd = new TcSmItemDeviceBoxProfinetAPIModuleSubModule
            {
                Id = PrintAsHex(CreateModuleIndex(Constants.SUBMODULE_INDEX_START, (ushort)(submodule.SubslotNumber + 1))),
                Name = $"Subterm {submodule.SubslotNumber}{PrintSubTermIoLabel(submodule)}",
                SubSlotNumber = submodule.SubslotNumber,
                SubModuleIdentNumber = submodule.SubmoduleIdentNumber,
                IsFixSubmodule = true,
                ImageId = Constants.SUBTERM_IMAGE_ID,
                APINr = api.APIId,
                APINrSpecified = api.APIId != 0,
                Vars = GetIoVarsForSubmodule(submodule)

            };
            if (IsPortSubmodule(submodule))
            {
                subModuleToAdd.Name += $" (Port {submodule.SubslotNumber - (Constants.SUBSLOT_NR_PORT1 - 1)})";
                subModuleToAdd.PortData = "";
                subModuleToAdd.TypeOfSubModule = 2;
                subModuleToAdd.AddSubModFlags = 28;
            }
            subModules.Add(subModuleToAdd);
        }

        return subModules.ToArray();
    }

    private static TcSmItemDeviceBoxProfinetAPIModuleSubModuleVars[] GetIoVarsForSubmodule(Submodule submodule)
    {
        return new TcSmItemDeviceBoxProfinetAPIModuleSubModuleVars[]
        {
            new TcSmItemDeviceBoxProfinetAPIModuleSubModuleVars
            {
                VarGrpType = 1,
                Name = "Inputs",
                Var = GetIoForSubmodule(submodule.DataDescriptionOutput)
            },
            new TcSmItemDeviceBoxProfinetAPIModuleSubModuleVars
            {
                VarGrpType = 2,
                Name = "Outputs",
                Var = GetIoForSubmodule(submodule.DataDescriptionInput)
            }
        };
    }

    private static TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVar[] GetIoForSubmodule(DataDescription dataDescription)
    {
        if (dataDescription.SubmoduleDataLength == 0)
        {
            return Array.Empty<TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVar>();
        }
        var vars = new List<TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVar>();

        var ioLabel = dataDescription.DataDescriptionType == DataDescriptionTypeEnum.Input ? "Input" : "Output";

        var length = dataDescription.SubmoduleDataLength;
        if (length > 1)
        {
            vars.Add(new TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVar
            {
                Name = $"{length} Byte {ioLabel}",
                Type = new TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVarType
                {
                    GUID = $"{{18071995-0000-0000-0000-0003{length:X08}}}",
                    Value = $"ARRAY [0..{length - 1}] OF BYTE"
                }
            });
        }
        else
        {
            vars.Add(new TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVar
            {
                Name = $"1 Byte {ioLabel}",
                Type = new TcSmItemDeviceBoxProfinetAPIModuleSubModuleVarsVarType
                {
                    GUID = "{18071995-0000-0000-0000-000000000001}",
                    Value = "BYTE"
                }
            });
        }

        return vars.ToArray();
    }
    private static MemoryStream Serialize(TcSmItem tcSmItem)
    {
        var xml = new XmlSerializer(typeof(TcSmItem));
        var memStream = new MemoryStream();
        xml.Serialize(memStream, tcSmItem);
        memStream.Position = 0;
        return memStream;
    }
    private static uint ExtractInstanceId(byte[] objectUUID)
    {
        var instanceId = BinaryPrimitives.ReadUInt16BigEndian(objectUUID.AsSpan()[^6..]);
        return instanceId;
    }

    private static uint ExtractVendorId(byte[] objectUUID)
    {
        var vendorId = BinaryPrimitives.ReadUInt16BigEndian(objectUUID.AsSpan()[^2..]);
        return vendorId;
    }

    private static uint ExtractDeviceId(byte[] objectUUID)
    {
        var devId = BinaryPrimitives.ReadUInt16BigEndian(objectUUID.AsSpan()[^4..]);
        return devId;
    }

    private static uint CreateModuleIndex(uint index, ushort slotSubSlot)
    {
        return index | slotSubSlot;
    }
    private static string PrintAsHex(uint index)
    {
        return $"#x{index:X08}";
    }
    private static bool IsPortSubmodule(in Submodule submodule)
    {
        return submodule.SubslotNumber >= Constants.SUBSLOT_NR_PORT1 && submodule.SubslotNumber <= Constants.SUBSLOT_NR_PORT2;
    }
}
