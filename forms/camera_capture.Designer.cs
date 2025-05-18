namespace dyfilm_client_v2._0.forms
{
    partial class camera_capture
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
            this.index_title = new System.Windows.Forms.Label();
            this.timer_title = new System.Windows.Forms.Label();
            this.are_you_ready_panel = new System.Windows.Forms.Panel();
            this.start_button = new System.Windows.Forms.Button();
            this.order_panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.title1 = new System.Windows.Forms.Label();
            this.live_pictureBox = new System.Windows.Forms.PictureBox();
            this.are_you_ready_panel.SuspendLayout();
            this.order_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.live_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // index_title
            // 
            this.index_title.BackColor = System.Drawing.Color.Black;
            this.index_title.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 68.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.index_title.ForeColor = System.Drawing.Color.White;
            this.index_title.Location = new System.Drawing.Point(0, 400);
            this.index_title.Name = "index_title";
            this.index_title.Size = new System.Drawing.Size(142, 154);
            this.index_title.TabIndex = 11;
            this.index_title.Text = "1";
            this.index_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.index_title.Visible = false;
            // 
            // timer_title
            // 
            this.timer_title.BackColor = System.Drawing.Color.Black;
            this.timer_title.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 68.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.timer_title.ForeColor = System.Drawing.Color.White;
            this.timer_title.Location = new System.Drawing.Point(1778, 400);
            this.timer_title.Name = "timer_title";
            this.timer_title.Size = new System.Drawing.Size(142, 154);
            this.timer_title.TabIndex = 10;
            this.timer_title.Text = "10";
            this.timer_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timer_title.Visible = false;
            // 
            // are_you_ready_panel
            // 
            this.are_you_ready_panel.Controls.Add(this.start_button);
            this.are_you_ready_panel.Location = new System.Drawing.Point(160, 143);
            this.are_you_ready_panel.Name = "are_you_ready_panel";
            this.are_you_ready_panel.Size = new System.Drawing.Size(1600, 783);
            this.are_you_ready_panel.TabIndex = 9;
            // 
            // start_button
            // 
            this.start_button.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.start_button.Location = new System.Drawing.Point(345, 204);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(882, 348);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "촬영 시작\r\n[n컷, 10초 타이머 연속]";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // order_panel
            // 
            this.order_panel.Controls.Add(this.label3);
            this.order_panel.Controls.Add(this.label2);
            this.order_panel.Controls.Add(this.label1);
            this.order_panel.Location = new System.Drawing.Point(0, 956);
            this.order_panel.Name = "order_panel";
            this.order_panel.Size = new System.Drawing.Size(1920, 110);
            this.order_panel.TabIndex = 8;
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
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PaleGreen;
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
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.CornflowerBlue;
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(1633, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 90);
            this.button1.TabIndex = 6;
            this.button1.Text = "처음으로";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // title1
            // 
            this.title1.AutoSize = true;
            this.title1.BackColor = System.Drawing.Color.White;
            this.title1.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title1.Location = new System.Drawing.Point(42, 38);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(580, 57);
            this.title1.TabIndex = 5;
            this.title1.Text = "촬영 시작 버튼을 눌러주세요.";
            // 
            // live_pictureBox
            // 
            this.live_pictureBox.Location = new System.Drawing.Point(160, 143);
            this.live_pictureBox.Name = "live_pictureBox";
            this.live_pictureBox.Size = new System.Drawing.Size(1600, 783);
            this.live_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.live_pictureBox.TabIndex = 1;
            this.live_pictureBox.TabStop = false;
            // 
            // camera_capture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.timer_title);
            this.Controls.Add(this.index_title);
            this.Controls.Add(this.are_you_ready_panel);
            this.Controls.Add(this.order_panel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.title1);
            this.Controls.Add(this.live_pictureBox);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "camera_capture";
            this.Text = "s";
            this.Load += new System.EventHandler(this.camera_capture_Load);
            this.are_you_ready_panel.ResumeLayout(false);
            this.order_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.live_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox live_pictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label title1;
        private System.Windows.Forms.Panel order_panel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel are_you_ready_panel;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Label timer_title;
        private System.Windows.Forms.Label index_title;
    }
}