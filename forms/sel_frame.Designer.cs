namespace dyfilm_client_v2._0.forms
{
    partial class sel_frame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.order_panel = new System.Windows.Forms.Panel();
            this.frame_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.confirm_frame = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.order_panel.SuspendLayout();
            this.confirm_frame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.AutoSize = true;
            this.title1.BackColor = System.Drawing.Color.White;
            this.title1.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title1.Location = new System.Drawing.Point(42, 38);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(778, 57);
            this.title1.TabIndex = 2;
            this.title1.Text = "좌우로 드래그해 프레임을 선택해주세요";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(1633, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 90);
            this.button1.TabIndex = 4;
            this.button1.Text = "처음으로";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PaleGreen;
            this.label1.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(640, 100);
            this.label1.TabIndex = 6;
            this.label1.Text = "1. 프레임 선택";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(640, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(640, 100);
            this.label2.TabIndex = 7;
            this.label2.Text = "2. 사진 촬영";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1280, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(640, 100);
            this.label3.TabIndex = 8;
            this.label3.Text = "3. 사진 인화";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // order_panel
            // 
            this.order_panel.Controls.Add(this.label3);
            this.order_panel.Controls.Add(this.label2);
            this.order_panel.Controls.Add(this.label1);
            this.order_panel.Location = new System.Drawing.Point(0, 956);
            this.order_panel.Name = "order_panel";
            this.order_panel.Size = new System.Drawing.Size(1920, 110);
            this.order_panel.TabIndex = 7;
            // 
            // frame_flowLayoutPanel
            // 
            this.frame_flowLayoutPanel.AutoScroll = true;
            this.frame_flowLayoutPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.frame_flowLayoutPanel.Location = new System.Drawing.Point(0, 130);
            this.frame_flowLayoutPanel.Name = "frame_flowLayoutPanel";
            this.frame_flowLayoutPanel.Size = new System.Drawing.Size(1920, 800);
            this.frame_flowLayoutPanel.TabIndex = 0;
            this.frame_flowLayoutPanel.WrapContents = false;
            // 
            // confirm_frame
            // 
            this.confirm_frame.BackColor = System.Drawing.Color.WhiteSmoke;
            this.confirm_frame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.confirm_frame.Controls.Add(this.label4);
            this.confirm_frame.Controls.Add(this.button3);
            this.confirm_frame.Controls.Add(this.button2);
            this.confirm_frame.Controls.Add(this.pictureBox1);
            this.confirm_frame.Location = new System.Drawing.Point(191, 29);
            this.confirm_frame.Name = "confirm_frame";
            this.confirm_frame.Size = new System.Drawing.Size(1523, 996);
            this.confirm_frame.TabIndex = 0;
            this.confirm_frame.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(40, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(597, 57);
            this.label4.TabIndex = 8;
            this.label4.Text = "선택한 프레임을 확인해주세요";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button3.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(828, 876);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(551, 82);
            this.button3.TabIndex = 2;
            this.button3.Text = "사진 찍기";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(136, 876);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(551, 82);
            this.button2.TabIndex = 1;
            this.button2.Text = "다시 고르기";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(50, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1416, 736);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sel_frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.confirm_frame);
            this.Controls.Add(this.frame_flowLayoutPanel);
            this.Controls.Add(this.order_panel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.title1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "sel_frame";
            this.ShowInTaskbar = false;
            this.Text = "sel_frame";
            this.Load += new System.EventHandler(this.sel_frame_Load);
            this.order_panel.ResumeLayout(false);
            this.confirm_frame.ResumeLayout(false);
            this.confirm_frame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel order_panel;
        private System.Windows.Forms.FlowLayoutPanel frame_flowLayoutPanel;
        private System.Windows.Forms.Panel confirm_frame;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
    }
}