using SharpPcap.LibPcap;
using System.Text;

namespace dsian.TcPnScanner.CLI;

public static class CaptureDevices
{
    /// <summary>
    /// Gets available capture devices <see cref="LibPcapLiveDeviceList"/>.
    /// </summary>
    /// <returns></returns>
    public static LibPcapLiveDeviceList GetCaptureDevices()
    {
        var devices = LibPcapLiveDeviceList.Instance;
        return devices;
    }

    public static LibPcapLiveDevice FindByName(string name)
    {
        var devices = GetCaptureDevices();
        var foundDeviceOrNull = devices.FirstOrDefault(x => x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase) || x.Description.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        return foundDeviceOrNull ?? throw new Exception($"No device matches name '{name}'\n{PrintDeviceList(devices)}");
    }

    public static LibPcapLiveDevice AskUserForCapDevice()
    {
        var devices = GetCaptureDevices();
        if (!devices.Any())
        {
            throw new Exception("No devices were found");
        }

        Console.WriteLine(PrintDeviceList(devices));
        var selection = WaitForUserSelection();
        if (selection < 0 || selection > devices.Count - 1)
        {
            throw new Exception($"Invalid selection");
        }

        return devices[selection];
    }

    private static string PrintDeviceList(LibPcapLiveDeviceList devices)
    {
        var sb = new StringBuilder();
        sb.AppendLine();
        sb.AppendLine("The following devices are available on this machine:");
        sb.AppendLine("----------------------------------------------------");
        sb.AppendLine();
        int i = 0;
        foreach (var dev in devices)
        {
            sb.AppendLine($"{i}) {dev.Name} {dev.Description}");
            i++;
        }
        sb.AppendLine();
        return sb.ToString();
    }

    private static int WaitForUserSelection()
    {
        Console.Write("-- Please choose a device to capture on: ");
        var userInput = Console.ReadLine();
        if (!int.TryParse(userInput, out int result))
        {
            throw new Exception($"Invalid input '{userInput}'");
        }
        return result;
    }
}
