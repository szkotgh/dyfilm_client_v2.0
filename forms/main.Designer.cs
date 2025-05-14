namespace dyfilm_client_v2._0.forms
{
    partial class main
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
            this.touchpictureBox1 = new System.Windows.Forms.PictureBox();
            this.admin_panel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.touchpictureBox1)).BeginInit();
            this.admin_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // touchpictureBox1
            // 
            this.touchpictureBox1.Location = new System.Drawing.Point(0, 0);
            this.touchpictureBox1.Name = "touchpictureBox1";
            this.touchpictureBox1.Size = new System.Drawing.Size(1920, 1080);
            this.touchpictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.touchpictureBox1.TabIndex = 0;
            this.touchpictureBox1.TabStop = false;
            this.touchpictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.touchpictureBox1_MouseDown);
            this.touchpictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.touchpictureBox1_MouseUp);
            // 
            // admin_panel
            // 
            this.admin_panel.BackColor = System.Drawing.Color.LightGray;
            this.admin_panel.Controls.Add(this.button4);
            this.admin_panel.Controls.Add(this.button3);
            this.admin_panel.Controls.Add(this.button2);
            this.admin_panel.Controls.Add(this.button1);
            this.admin_panel.Location = new System.Drawing.Point(0, 0);
            this.admin_panel.Name = "admin_panel";
            this.admin_panel.Size = new System.Drawing.Size(1920, 124);
            this.admin_panel.TabIndex = 1;
            this.admin_panel.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(575, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(257, 74);
            this.button4.TabIndex = 3;
            this.button4.Text = "추가 인쇄";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1641, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(257, 74);
            this.button3.TabIndex = 2;
            this.button3.Text = "닫기";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(299, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(257, 74);
            this.button2.TabIndex = 1;
            this.button2.Text = "프로그램 재시작";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 74);
            this.button1.TabIndex = 0;
            this.button1.Text = "프로그램 종료";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.admin_panel);
            this.Controls.Add(this.touchpictureBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "main";
            this.Text = "main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_Close);
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.touchpictureBox1)).EndInit();
            this.admin_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox touchpictureBox1;
        private System.Windows.Forms.Panel admin_panel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}