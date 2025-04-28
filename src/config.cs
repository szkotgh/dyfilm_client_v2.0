using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dyfilm_client_v2._0.src
{
    internal class config
    {
        // Path Variable
        public static string HOME_PATH = Application.StartupPath;

        public static string SOURCE_PATH = Path.Combine(Application.StartupPath, "src");
        public static string MAIN_IMAGE_PATH = Path.Combine(SOURCE_PATH, "main_image.gif");
        public static string AUTH_RESULT_PATH = Path.Combine(SOURCE_PATH, "auth_result.json");

        public static string FRAME_PATH = Path.Combine(SOURCE_PATH, "frames");
        public static string FRAME_INFO_PATH = Path.Combine(FRAME_PATH, "info.json");

        public static string CAPTURE_PATH = Path.Combine(SOURCE_PATH, "capture");

        public static string CAPFRAME_PATH = Path.Combine(SOURCE_PATH, "capframe");

        // Properties Variable
        public static string version;
        public static string auth_token;
        public static string process_url;

        public static void dir_init()
        {
            if (!Directory.Exists(SOURCE_PATH))
                Directory.CreateDirectory(SOURCE_PATH);

            if (!Directory.Exists(FRAME_PATH))
                Directory.CreateDirectory(FRAME_PATH);

            if (!Directory.Exists(CAPTURE_PATH))
                Directory.CreateDirectory(CAPTURE_PATH);

            if (!Directory.Exists(CAPFRAME_PATH))
                Directory.CreateDirectory(CAPFRAME_PATH);
        }

        public static void properties_init()
        {
            version = Properties.Settings.Default.version;
            auth_token = Properties.Settings.Default.auth_token;
            process_url = Properties.Settings.Default.process_url;
        }
    }
}
