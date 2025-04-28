using dyfilm_client_v2._0.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dyfilm_client_v2._0.src.data_struct;
using System.Reflection;

namespace dyfilm_client_v2._0.forms
{
    public partial class sel_frame : Frame
    {
        private bool isDragging = false;
        private Point dragStartScreenPos;
        private int scrollStartX;

        public sel_frame()
        {
            InitializeComponent();
            SetDoubleBuffered(frame_flowLayoutPanel1);
        }

        private void sel_frame_Load(object sender, EventArgs e)
        {
            title1.Text = "프레임을 선택하세요";

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

            string frame_info_txt = File.ReadAllText(config.FRAME_INFO_PATH);
            data_struct.FrameInfo frame_info_json = JsonSerializer.Deserialize<FrameInfo>(frame_info_txt);

            foreach (var item in frame_info_json.info)
            {
                string frame_desc = item[4].ToString();
                string frame_path = Path.Combine(config.FRAME_PATH, item[2].ToString());

                if (File.Exists(frame_path))
                {
                    Image img = Image.FromFile(frame_path);
                    PictureBox pic = new PictureBox();

                    int panelHeight = frame_flowLayoutPanel1.ClientSize.Height - 80;
                    int imgWidth = img.Width;
                    int imgHeight = img.Height;
                    int newWidth = (int)((float)panelHeight / imgHeight * imgWidth);

                    pic.Image = img;
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.Size = new Size(newWidth, panelHeight);
                    pic.Dock = DockStyle.Top;
                    pic.Cursor = Cursors.Hand;

                    pic.MouseDown += Frame_MouseDown;
                    pic.MouseMove += Frame_MouseMove;
                    pic.MouseUp += Frame_MouseUp;
                    pic.MouseClick += (s, ee) => { utils.warn_msg(frame_desc); };

                    Label lbl = new Label();
                    lbl.Text = frame_desc;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Dock = DockStyle.Bottom;
                    lbl.AutoSize = false;
                    lbl.Height = 40;
                    lbl.Font = new Font("맑은 고딕", 10, FontStyle.Regular);

                    Panel container = new Panel();
                    SetDoubleBuffered(container);
                    container.Size = new Size(newWidth, panelHeight + lbl.Height);
                    container.Margin = new Padding(10, 10, 10, 10);
                    container.Controls.Add(pic);
                    container.Controls.Add(lbl);

                    frame_flowLayoutPanel1.Controls.Add(container);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartScreenPos = Control.MousePosition;
                scrollStartX = frame_flowLayoutPanel1.AutoScrollPosition.X;
                frame_flowLayoutPanel1.Cursor = Cursors.Hand;
            }
        }

        private void Frame_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentScreenPos = Control.MousePosition;
                int dx = dragStartScreenPos.X - currentScreenPos.X;
                int newX = scrollStartX + dx;

                int maxScroll = frame_flowLayoutPanel1.HorizontalScroll.Maximum;
                newX = Math.Max(0, Math.Min(newX, maxScroll));

                frame_flowLayoutPanel1.AutoScrollPosition = new Point(newX, 0);
            }
        }

        private void Frame_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                frame_flowLayoutPanel1.Cursor = Cursors.Default;
            }
        }

        private void SetDoubleBuffered(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
    }
}