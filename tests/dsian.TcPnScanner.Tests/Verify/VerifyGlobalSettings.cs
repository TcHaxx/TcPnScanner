using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dsian.TcPnScanner.Tests.Verify
{
   
    public class VerifyGlobalSettings
    {
        private static VerifySettings? _settings;
        public static VerifySettings GetGlobalSettings()
        {

            return _settings ?? Instantiate();
        }

        private static VerifySettings Instantiate()
        {
            _settings = new VerifySettings();
            _settings.UseDirectory("./Verify");
            _settings.AddExtraSettings((s) => s.Converters.Add(new JsonIpAddressConverter()));
            _settings.AddExtraSettings((s) => s.Converters.Add(new JsonPhysicalAddressConverter()));
            return _settings;
        }
    }
}
