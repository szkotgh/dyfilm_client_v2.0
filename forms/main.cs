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

        private void main_Load(object sender, EventArgs e)
        {
            // load main_image
            PictureBox gifPictureBox = new PictureBox();
            gifPictureBox.Image = Image.FromFile(config.MAIN_IMAGE_PATH);
            gifPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            gifPictureBox.Dock = DockStyle.Fill;

            touch_panel.Controls.Add(gifPictureBox);
        }

        private void touch_panel_click(object sender, EventArgs e)
        {
            this.Hide();
            new first().ShowDialog();
        }
    }
}
