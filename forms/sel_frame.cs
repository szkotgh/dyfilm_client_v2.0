using dyfilm_client_v2._0.src;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dyfilm_client_v2._0.src.data_struct;

namespace dyfilm_client_v2._0.forms
{
    public partial class sel_frame : Frame
    {
        private bool isDragging = false;
        private bool wasDragged = false;
        private Point dragStartScreenPos;
        private int scrollStartX;

        public sel_frame()
        {
            InitializeComponent();
            SetDoubleBuffered(frame_flowLayoutPanel1);
            InitializeFrameFlowLayout();
        }

        private void sel_frame_Load(object sender, EventArgs e)
        {
            title1.Text = "프레임을 선택하세요";

            string frameInfoText = File.ReadAllText(config.FRAME_INFO_PATH);
            FrameInfo frameInfo = JsonSerializer.Deserialize<FrameInfo>(frameInfoText);

            foreach (var item in frameInfo.info)
            {
                string frameDescription = item[4].ToString();
                string frameImagePath = Path.Combine(config.FRAME_PATH, item[2].ToString());

                if (File.Exists(frameImagePath))
                {
                    Image image = Image.FromFile(frameImagePath);
                    CreateFrameItem(image, frameDescription);
                }
            }
        }

        private void InitializeFrameFlowLayout()
        {
            frame_flowLayoutPanel1.AutoScroll = true;
            frame_flowLayoutPanel1.HorizontalScroll.Enabled = true;
            frame_flowLayoutPanel1.HorizontalScroll.Visible = true;
            frame_flowLayoutPanel1.VerticalScroll.Enabled = false;
            frame_flowLayoutPanel1.VerticalScroll.Visible = false;
            frame_flowLayoutPanel1.WrapContents = false;
            frame_flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            frame_flowLayoutPanel1.Padding = new Padding(0, 20, 0, 20);

            frame_flowLayoutPanel1.MouseDown += Frame_MouseDown;
            frame_flowLayoutPanel1.MouseMove += Frame_MouseMove;
            frame_flowLayoutPanel1.MouseUp += Frame_MouseUp;
        }

        private void CreateFrameItem(Image img, string description)
        {
            int panelHeight = frame_flowLayoutPanel1.ClientSize.Height - 80;
            int newWidth = (int)((float)panelHeight / img.Height * img.Width);

            PictureBox pictureBox = new PictureBox
            {
                Image = img,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(newWidth, panelHeight),
                Dock = DockStyle.Top,
                Cursor = Cursors.Hand
            };

            pictureBox.MouseDown += Frame_MouseDown;
            pictureBox.MouseMove += Frame_MouseMove;
            pictureBox.MouseUp += Frame_MouseUp;
            pictureBox.MouseClick += (s, e) =>
            {
                if (!wasDragged)
                    utils.warn_msg(description);
            };

            Label label = new Label
            {
                Text = description,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                AutoSize = false,
                Height = 40,
                Font = new Font("맑은 고딕", 10, FontStyle.Regular)
            };

            Panel container = new Panel
            {
                Size = new Size(newWidth, panelHeight + label.Height),
                Margin = new Padding(10)
            };

            SetDoubleBuffered(container);
            container.Controls.Add(pictureBox);
            container.Controls.Add(label);

            frame_flowLayoutPanel1.Controls.Add(container);
        }

        private void Frame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                wasDragged = false;
                dragStartScreenPos = Control.MousePosition;
                scrollStartX = -frame_flowLayoutPanel1.AutoScrollPosition.X;
                frame_flowLayoutPanel1.Cursor = Cursors.Hand;
            }
        }

        private void Frame_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point currentScreenPos = Control.MousePosition;
                int dx = currentScreenPos.X - dragStartScreenPos.X;

                if (Math.Abs(dx) > SystemInformation.DragSize.Width / 2)
                {
                    isDragging = true;
                    wasDragged = true;
                }

                if (isDragging)
                {
                    int newX = scrollStartX - dx;
                    newX = Math.Max(0, Math.Min(newX, frame_flowLayoutPanel1.HorizontalScroll.Maximum));
                    frame_flowLayoutPanel1.AutoScrollPosition = new Point(newX, 0);
                }
            }
        }

        private void Frame_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                frame_flowLayoutPanel1.Cursor = Cursors.Default;

                Task.Delay(100).ContinueWith(_ =>
                {
                    this.Invoke((MethodInvoker)(() => wasDragged = false));
                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sel_frame_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 추가 리소스 정리 필요 없음
        }

        private void SetDoubleBuffered(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
    }
}
