namespace dyfilm_client_v2._0.forms
{
    partial class create_capframe
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
            this.result_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.result_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.AutoSize = true;
            this.title1.BackColor = System.Drawing.Color.White;
            this.title1.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title1.Location = new System.Drawing.Point(42, 38);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(483, 57);
            this.title1.TabIndex = 6;
            this.title1.Text = "사진을 만들고 있습니다.";
            // 
            // result_pictureBox
            // 
            this.result_pictureBox.Location = new System.Drawing.Point(160, 149);
            this.result_pictureBox.Name = "result_pictureBox";
            this.result_pictureBox.Size = new System.Drawing.Size(1600, 783);
            this.result_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.result_pictureBox.TabIndex = 7;
            this.result_pictureBox.TabStop = false;
            // 
            // create_capframe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.result_pictureBox);
            this.Controls.Add(this.title1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "create_capframe";
            this.Text = "create_capframe";
            this.Load += new System.EventHandler(this.create_capframe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.result_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title1;
        private System.Windows.Forms.PictureBox result_pictureBox;
    }
}