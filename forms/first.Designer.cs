namespace dyfilm_client_v2._0.forms
{
    partial class first
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.title1 = new System.Windows.Forms.Label();
            this.title2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.AutoSize = true;
            this.title1.BackColor = System.Drawing.Color.White;
            this.title1.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title1.Location = new System.Drawing.Point(52, 56);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(176, 57);
            this.title1.TabIndex = 1;
            this.title1.Text = "TITLE 1";
            this.title1.Click += new System.EventHandler(this.title1_Click);
            // 
            // title2
            // 
            this.title2.AutoSize = true;
            this.title2.BackColor = System.Drawing.Color.White;
            this.title2.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title2.ForeColor = System.Drawing.Color.DimGray;
            this.title2.Location = new System.Drawing.Point(56, 191);
            this.title2.Name = "title2";
            this.title2.Size = new System.Drawing.Size(110, 35);
            this.title2.TabIndex = 2;
            this.title2.Text = "TITLE 2";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(62, 135);
            this.progressBar1.MarqueeAnimationSpeed = 20;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1796, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(62, 597);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(305, 87);
            this.button1.TabIndex = 4;
            this.button1.Text = "설정으로";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // first
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.title2);
            this.Controls.Add(this.title1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "first";
            this.Load += new System.EventHandler(this.first_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title1;
        private System.Windows.Forms.Label title2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
    }
}
