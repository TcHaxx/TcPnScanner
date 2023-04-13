namespace dsian.TcPnScanner.CLI.Export.TC
{
    internal static class Constants
    {
        /// <summary>
        /// <see href="https://infosys.beckhoff.com/english.php?content=../content/1033/tc3_automationinterface/242788619.html">ITcSmTreeItem Item Sub Types: Devices</see> - PROFINET Slave
        /// </summary>
        internal const uint IODEVICETYPE_PROFINETIODEVICE = 115;

        /// <summary>
        /// <see href="https://infosys.beckhoff.com/english.php?content=../content/1033/tc3_automationinterface/242791563.html">ITcSmTreeItem Item Sub Types: Boxes</see> - Generic Profinet Box
        /// </summary>
        internal const uint BOXTYPE_PROFINET_GENERIC = 9131;

        /// <summary>
        /// <see href="https://infosys.beckhoff.com/english.php?content=../content/1033/tc3_ads.net/9408352011.html">AmsPort Enumeration</see> - USEDEFAULT
        /// </summary>
        internal const uint AMS_PORT_USEDEFAULT = 65535;

        internal const uint MODULE_INDEX_START = 0x031D0000u;

        internal const uint SUBMODULE_INDEX_START = 0x031C0000u;

        internal const uint BOX_IMAGE_ID = 121;

        internal const uint API_IMAGE_ID = 4;

        internal const uint TERM_IMAGE_ID = 182;

        internal const uint SUBTERM_IMAGE_ID = 183;

        /// <summary>
        /// Flags, i.e. "Get Station Name from Tree"
        /// </summary>
        internal const uint BOX_PROFINET_FLAGS = 0x410u;

        internal const uint BOX_PROFINET_FRAME_OFFSET = 0x8000u;
    }
}
