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
    public partial class camera_capture : Frame
    {
        public static string sel_f_id = null;
        Camera camera = new Camera();
        private System.Windows.Forms.Timer liveViewTimer;

        public camera_capture()
        {
            InitializeComponent();
        }

        private void camera_capture_Load(object sender, EventArgs e)
        {
            if (camera.Initialize())
                MessageBox.Show("카메라 초기화 성공");
            else
                MessageBox.Show("카메라 초기화 실패");


        }
        private void btnInit_Click(object sender, EventArgs e)
        {
        }

        private void btnShoot_Click(object sender, EventArgs e)
        {
            camera.TakePhoto();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            camera.Terminate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            camera.TakePhoto();
        }

        private void LiveViewTimer_Tick(object sender, EventArgs e)
        {
            Bitmap bmp = camera.GetLiveViewImage();
            if (bmp != null)
            {
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = bmp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            camera.StartLiveView();

            liveViewTimer = new System.Windows.Forms.Timer();
            liveViewTimer.Interval = 100; // 10fps
            liveViewTimer.Tick += LiveViewTimer_Tick;
            liveViewTimer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            liveViewTimer?.Stop();
            camera.StopLiveView();
        }
    }
}
