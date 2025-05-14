using AForge.Video;
using AForge.Video.DirectShow;
using dyfilm_client_v2._0.src;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace dyfilm_client_v2._0.forms
{
    public partial class camera_capture : Frame
    {
        private FilterInfoCollection videoDevices;     // 연결된 모든 웹캠 목록
        private VideoCaptureDevice videoSource;        // 선택된 웹캠
        private CancellationTokenSource captureCancellation;
        private SoundPlayer soundPlayer = new SoundPlayer(Path.Combine(Config.SHUTTER_SOUND_PATH));

        public camera_capture()
        {
            InitializeComponent();
        }

        private void camera_capture_Load(object sender, EventArgs e)
        {
            start_button.Text = "촬영 시작하기\n[" + Temp.select_frame_capture_count + "컷, 10초 타이머]";
            Temp.capture_paths.Clear();

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                Utils.warn_msg("카메라 연결을 확인하십시오.\n사진을 촬영할 수 없습니다.");
                this.Close();
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString); // 첫 번째
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            videoSource.Start();
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            if (live_pictureBox.InvokeRequired)
            {
                live_pictureBox.BeginInvoke(new Action(() =>
                {
                    live_pictureBox.Image?.Dispose();
                    live_pictureBox.Image = bitmap;
                }));
            }
            else
            {
                live_pictureBox.Image?.Dispose();
                live_pictureBox.Image = bitmap;
            }
        }

        private void camera_capture_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (captureCancellation != null && !captureCancellation.Token.IsCancellationRequested)
            {
                captureCancellation.Cancel();
            }

            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            are_you_ready_panel.Visible = false;
            timer_title.Visible = true;
            index_title.Visible = true;

            int captureCount = Temp.select_frame_capture_count;
            int delayInSeconds = 10;

            captureCancellation = new CancellationTokenSource();

            try
            {
                for (int i = 0; i < captureCount; i++)
                {
                    int photoIndex = i + 1;

                    for (int t = delayInSeconds; t > 0; t--)
                    {
                        timer_title.BackColor = Color.Black;
                        if (t <= 5)
                            timer_title.BackColor = Color.Red;

                        UpdateTitleText($"{photoIndex}번째 사진 촬영 {t}초 전");
                        timer_title.Text = t.ToString();
                        index_title.Text = photoIndex.ToString();
                        await Task.Delay(1000, captureCancellation.Token);

                        if (captureCancellation.Token.IsCancellationRequested)
                        {
                            throw new TaskCanceledException();
                        }
                    }

                    UpdateTitleText($"{photoIndex}번째 사진 촬영 됨");
                    StopVideoFrame();
                    SaveCurrentFrame();
                    soundPlayer.Play();

                    await Task.Delay(1500, captureCancellation.Token);

                    if (captureCancellation.Token.IsCancellationRequested)
                    {
                        throw new TaskCanceledException();
                    }

                    ResumeVideoFrame();
                }

                // complete capture
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                }

                UpdateTitleText("촬영 완료");
                create_capframe.cf_id = null;
                create_capframe.is_capture = false;
                create_capframe.print_count = 1;
                new create_capframe().ShowDialog();
                this.Close();
            }
            catch (TaskCanceledException)
            {
                Utils.warn_msg("사진 촬영이 취소되었습니다.");
                this.Close();
            }
        }


        private void UpdateTitleText(string text)
        {
            if (title1.InvokeRequired)
            {
                title1.Invoke((MethodInvoker)(() => title1.Text = text));
            }
            else
            {
                title1.Text = text;
            }
        }

        private void StopVideoFrame()
        {
            if (videoSource != null)
            {
                videoSource.NewFrame -= VideoSource_NewFrame;
            }
        }

        private void ResumeVideoFrame()
        {
            if (videoSource != null)
            {
                videoSource.NewFrame += VideoSource_NewFrame;
            }
        }

        private void SaveCurrentFrame()
        {
            if (live_pictureBox.Image != null)
            {
                Bitmap bitmap = new Bitmap(live_pictureBox.Image);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string filename = $"{timestamp}.jpg";
                string fullPath = Path.Combine(Config.CAPTURE_PATH, filename);

                Temp.capture_paths.Add(fullPath);

                bitmap.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                bitmap.Dispose();
            }
        }

    }
}
