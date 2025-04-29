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
            this.frame_flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.FormClosing += sel_frame_FormClosing;
            this.order_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.AutoSize = true;
            this.title1.BackColor = System.Drawing.Color.White;
            this.title1.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title1.Location = new System.Drawing.Point(52, 57);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(176, 57);
            this.title1.TabIndex = 2;
            this.title1.Text = "TITLE 1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(1620, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 90);
            this.button1.TabIndex = 4;
            this.button1.Text = "처음으로";
            this.button1.UseVisualStyleBackColor = true;
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
            this.order_panel.Location = new System.Drawing.Point(0, 970);
            this.order_panel.Name = "order_panel";
            this.order_panel.Size = new System.Drawing.Size(1920, 110);
            this.order_panel.TabIndex = 7;
            // 
            // frame_flowLayoutPanel1
            // 
            this.frame_flowLayoutPanel1.AutoScroll = true;
            this.frame_flowLayoutPanel1.Location = new System.Drawing.Point(12, 150);
            this.frame_flowLayoutPanel1.Name = "frame_flowLayoutPanel1";
            this.frame_flowLayoutPanel1.Size = new System.Drawing.Size(1896, 800);
            this.frame_flowLayoutPanel1.TabIndex = 0;
            this.frame_flowLayoutPanel1.WrapContents = false;
            // 
            // sel_frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.frame_flowLayoutPanel1);
            this.Controls.Add(this.order_panel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.title1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "sel_frame";
            this.Text = "sel_frame";
            this.Load += new System.EventHandler(this.sel_frame_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.sel_frame_FormClosing);
            this.order_panel.ResumeLayout(false);
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
        private System.Windows.Forms.FlowLayoutPanel frame_flowLayoutPanel1;
    }
}