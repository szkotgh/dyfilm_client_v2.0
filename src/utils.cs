using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dyfilm_client_v2._0.src
{
    internal class utils
    {

        public static void RestartApplication()
        {
            string exePath = Application.ExecutablePath;

            Process.Start(exePath);
            Application.Exit();
        }

        public static void info_msg(string msg, string caption = "정보")
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void warn_msg(string msg, string caption = "경고")
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ask_msg(string msg, string caption = "확인")
        {
            return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes;
        }
    }
}
