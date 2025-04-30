using AForge.Video;
using AForge.Video.DirectShow;
using dyfilm_client_v2._0.src;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace dyfilm_client_v2._0.forms
{
    public partial class camera_capture : Frame
    {
        private FilterInfoCollection videoDevices;     // 연결된 모든 웹캠 목록
        private VideoCaptureDevice videoSource;        // 선택된 웹캠
        private CancellationTokenSource captureCancellation;

        public camera_capture()
        {
            InitializeComponent();
        }

        private void camera_capture_Load(object sender, EventArgs e)
        {
            start_button.Text = "촬영 시작하기\n[10초 타이머 " + Temp.select_frame_capture_count + "컷]";
            Temp.select_c_id.Clear();

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                Utils.warn_msg("웹캠이 연결되어 있지 않습니다.");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString); // 첫 번째 웹캠 선택
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            are_you_ready_panel.Visible = false;

            int captureCount = Temp.select_frame_capture_count;
            int delayInSeconds = 10;

            captureCancellation = new CancellationTokenSource();

            try
            {
                for (int i = 0; i < captureCount; i++)
                {
                    int photoIndex = i + 1;

                    // 카운트다운: 10초 ~ 1초
                    for (int t = delayInSeconds; t > 0; t--)
                    {
                        UpdateTitleText($"{photoIndex}번째 사진 촬영 {t}초 전");
                        await Task.Delay(1000, captureCancellation.Token);
                    }

                    // 촬영 텍스트 표시
                    UpdateTitleText($"{photoIndex}번째 사진 촬영 됨");

                    // 영상 정지
                    StopVideoFrame();

                    // 촬영
                    SaveCurrentFrame();

                    // 3초 대기 (영상 정지 상태)
                    await Task.Delay(3000, captureCancellation.Token);

                    // 영상 재개
                    ResumeVideoFrame();
                }

                UpdateTitleText("촬영 완료");
                new create_capframe().ShowDialog();
                this.Close();
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("사진 촬영이 취소되었습니다.");
                this.Close();
            }
        }

        // UI 스레드 안전하게 title1.Text 갱신
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

        // 영상 정지
        private void StopVideoFrame()
        {
            if (videoSource != null)
            {
                videoSource.NewFrame -= VideoSource_NewFrame;
            }
        }

        // 영상 재개
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
                string filename = $"{Temp.select_c_id}_{timestamp}.jpg";
                string fullPath = Path.Combine(Config.CAPTURE_PATH, filename);

                Directory.CreateDirectory(Config.CAPTURE_PATH); // 폴더 없을 시 생성
                bitmap.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                bitmap.Dispose();
            }
        }

    }
}
