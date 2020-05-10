using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CenterTaskbar
{
    internal static class DisplaySettings
    {
        private const int ENUM_CURRENT_SETTINGS = -1;

        [DllImport("user32.dll")]
        private static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

        //public static void ListAllDisplayModes()
        //{
        //    var vDevMode = new DEVMODE();
        //    var i = 0;
        //    while (EnumDisplaySettings(null, i, ref vDevMode))
        //    {
        //        Console.WriteLine("Width:{0} Height:{1} Color:{2} Frequency:{3}",
        //            vDevMode.dmPelsWidth,
        //            vDevMode.dmPelsHeight,
        //            1 << vDevMode.dmBitsPerPel, vDevMode.dmDisplayFrequency
        //        );
        //        i++;
        //    }
        //}

        public static int CurrentRefreshRate()
        {
            var vDevMode = new DEVMODE();
            if (EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref vDevMode))
                return vDevMode.dmDisplayFrequency;
            return 60;
        }
        //const int ENUM_REGISTRY_SETTINGS = -2;

        [StructLayout(LayoutKind.Sequential)]
        private readonly struct DEVMODE
        {
            //private const int CCHDEVICENAME = 0x20;
            //private const int CCHFORMNAME = 0x20;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            private readonly string dmDeviceName;

            private readonly short dmSpecVersion;
            private readonly short dmDriverVersion;
            private readonly short dmSize;
            private readonly short dmDriverExtra;
            private readonly int dmFields;
            private readonly int dmPositionX;
            private readonly int dmPositionY;
            private readonly ScreenOrientation dmDisplayOrientation;
            private readonly int dmDisplayFixedOutput;
            private readonly short dmColor;
            private readonly short dmDuplex;
            private readonly short dmYResolution;
            private readonly short dmTTOption;
            private readonly short dmCollate;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            private readonly string dmFormName;

            private readonly short dmLogPixels;
            private readonly int dmBitsPerPel;
            private readonly int dmPelsWidth;
            private readonly int dmPelsHeight;
            private readonly int dmDisplayFlags;
            public readonly int dmDisplayFrequency;
            private readonly int dmICMMethod;
            private readonly int dmICMIntent;
            private readonly int dmMediaType;
            private readonly int dmDitherType;
            private readonly int dmReserved1;
            private readonly int dmReserved2;
            private readonly int dmPanningWidth;
            private readonly int dmPanningHeight;
        }
    }
}