using dyfilm_client_v2._0.src;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dyfilm_client_v2._0.src.DataStruct;

namespace dyfilm_client_v2._0.forms
{
    public partial class sel_frame : Frame
    {
        private bool isDragging = false;
        private bool wasDragged = false;
        private Point dragStartScreenPos;
        private int scrollStartX;
        private string select_f_id;
        private int select_frame_capture_count;

        private Panel overlayPanel;  // 전체를 덮을 Panel
        private Label dragTextLabel;  // "좌우로 드래그" 텍스트를 표시할 Label

        public sel_frame()
        {
            InitializeComponent();
            SetDoubleBuffered(frame_flowLayoutPanel);
            InitializeFrameFlowLayout();
        }

        private void sel_frame_Load(object sender, EventArgs e)
        {
            string frameInfoText = File.ReadAllText(Config.FRAME_INFO_PATH);
            FrameInfo frameInfo = JsonSerializer.Deserialize<FrameInfo>(frameInfoText);

            foreach (var item in frameInfo.info)
            {
                if (item[1].ToString() == "0")
                    continue;

                string frame_count = item[3].ToString();
                DataStruct.Frame frame_info_json = JsonSerializer.Deserialize<DataStruct.Frame>(frame_count);
                int capture_count = frame_info_json.captures.Count;

                string frameDescription = item[4].ToString() + " [" + capture_count + "컷]";
                string frameImagePath = Path.Combine(Config.FRAME_PATH, item[2].ToString());

                if (File.Exists(frameImagePath))
                {
                    Image image = Image.FromFile(frameImagePath);
                    CreateFrameItem(image, frameDescription, item[0].ToString(), capture_count);
                }
            }
        }

        private void InitializeFrameFlowLayout()
        {
            frame_flowLayoutPanel.AutoScroll = true;
            frame_flowLayoutPanel.HorizontalScroll.Enabled = true;
            frame_flowLayoutPanel.HorizontalScroll.Visible = true;
            frame_flowLayoutPanel.VerticalScroll.Enabled = false;
            frame_flowLayoutPanel.VerticalScroll.Visible = false;
            frame_flowLayoutPanel.WrapContents = false;
            frame_flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            frame_flowLayoutPanel.Padding = new Padding(0, 20, 0, 20);

            frame_flowLayoutPanel.MouseDown += Frame_MouseDown;
            frame_flowLayoutPanel.MouseMove += Frame_MouseMove;
            frame_flowLayoutPanel.MouseUp += Frame_MouseUp;
        }

        private void DragTextLabel_MouseDown(object sender, MouseEventArgs e)
        {
            overlayPanel.Visible = false;
        }

        private void CreateFrameItem(Image img, string description, string f_id, int frame_capture_count)
        {
            int panelHeight = frame_flowLayoutPanel.ClientSize.Height - 120;
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
                {
                    confirm_frame.Visible = true;
                    pictureBox1.Image = img;
                    select_f_id = f_id;
                    select_frame_capture_count = frame_capture_count;
                }
            };

            Label label = new Label
            {
                Text = description,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Bottom,
                AutoSize = false,
                Height = 46,
                Font = new Font("AppleSDGothicNeoEB00", 20, FontStyle.Bold)
            };
            label.MouseDown += Frame_MouseDown;
            label.MouseMove += Frame_MouseMove;
            label.MouseUp += Frame_MouseUp;

            Panel container = new Panel
            {
                Size = new Size(newWidth, panelHeight + label.Height + 8),
                Margin = new Padding(10)
            };

            SetDoubleBuffered(container);
            container.Controls.Add(pictureBox);
            container.Controls.Add(label);

            frame_flowLayoutPanel.Controls.Add(container);
        }

        private void Frame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                wasDragged = false;
                dragStartScreenPos = Control.MousePosition;
                scrollStartX = -frame_flowLayoutPanel.AutoScrollPosition.X;
                frame_flowLayoutPanel.Cursor = Cursors.Hand;
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
                    newX = Math.Max(0, Math.Min(newX, frame_flowLayoutPanel.HorizontalScroll.Maximum));
                    frame_flowLayoutPanel.AutoScrollPosition = new Point(newX, 0);
                }
            }
        }

        private void Frame_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                frame_flowLayoutPanel.Cursor = Cursors.Default;

                Task.Delay(100).ContinueWith(_ =>
                {
                    this.Invoke((MethodInvoker)(() => wasDragged = false));
                });
            }
        }

        private void SetDoubleBuffered(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            confirm_frame.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Temp.select_f_id = select_f_id;
            Temp.select_frame_capture_count = select_frame_capture_count;
            new camera_capture().ShowDialog();
        }
    }
}
