using dyfilm_client_v2._0.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dyfilm_client_v2._0.forms
{
    public partial class main : Frame
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Close(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void main_Load(object sender, EventArgs e)
        {
            touchpictureBox1.Image = Image.FromFile(Config.MAIN_IMAGE_PATH);
            touchpictureBox1.Dock = DockStyle.Fill;
        }

        private DateTime mouseDownTime;

        private void touchpictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownTime = DateTime.Now;
        }

        private void touchpictureBox1_MouseUp(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.Now - mouseDownTime;
            if (duration.Seconds >= 3)
            {
                admin_panel.Visible = true;
                return;
            }

            new sel_frame().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utils.RestartApplication();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            admin_panel.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new capframe_print().ShowDialog();
        }
    }
}
