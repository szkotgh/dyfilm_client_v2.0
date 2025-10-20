namespace dyfilm_client_v2._0.forms
{
    partial class settings
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblProcessUrl = new System.Windows.Forms.Label();
            this.txtProcessUrl = new System.Windows.Forms.TextBox();
            this.lblAuthToken = new System.Windows.Forms.Label();
            this.txtAuthToken = new System.Windows.Forms.TextBox();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTestPrint = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("AppleSDGothicNeoB00", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(52, 56);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(332, 57);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "클라이언트 설정";
            // 
            // lblProcessUrl
            // 
            this.lblProcessUrl.AutoSize = true;
            this.lblProcessUrl.Font = new System.Drawing.Font("AppleSDGothicNeoB00", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProcessUrl.Location = new System.Drawing.Point(157, 199);
            this.lblProcessUrl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProcessUrl.Name = "lblProcessUrl";
            this.lblProcessUrl.Size = new System.Drawing.Size(136, 32);
            this.lblProcessUrl.TabIndex = 1;
            this.lblProcessUrl.Text = "서버 도메인";
            this.lblProcessUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProcessUrl
            // 
            this.txtProcessUrl.Font = new System.Drawing.Font("AppleSDGothicNeoB00", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProcessUrl.Location = new System.Drawing.Point(353, 191);
            this.txtProcessUrl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtProcessUrl.Name = "txtProcessUrl";
            this.txtProcessUrl.Size = new System.Drawing.Size(924, 52);
            this.txtProcessUrl.TabIndex = 2;
            // 
            // lblAuthToken
            // 
            this.lblAuthToken.AutoSize = true;
            this.lblAuthToken.Font = new System.Drawing.Font("AppleSDGothicNeoB00", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAuthToken.Location = new System.Drawing.Point(180, 301);
            this.lblAuthToken.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAuthToken.Name = "lblAuthToken";
            this.lblAuthToken.Size = new System.Drawing.Size(113, 32);
            this.lblAuthToken.TabIndex = 3;
            this.lblAuthToken.Text = "인증 토큰";
            this.lblAuthToken.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAuthToken
            // 
            this.txtAuthToken.Font = new System.Drawing.Font("AppleSDGothicNeoB00", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAuthToken.Location = new System.Drawing.Point(353, 293);
            this.txtAuthToken.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtAuthToken.Name = "txtAuthToken";
            this.txtAuthToken.Size = new System.Drawing.Size(924, 52);
            this.txtAuthToken.TabIndex = 4;
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Font = new System.Drawing.Font("AppleSDGothicNeoB00", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPrinter.Location = new System.Drawing.Point(157, 576);
            this.lblPrinter.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(136, 32);
            this.lblPrinter.TabIndex = 8;
            this.lblPrinter.Text = "인쇄 설정값";
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinter.Font = new System.Drawing.Font("AppleSDGothicNeoB00", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbPrinter.FormattingEnabled = true;
            this.cmbPrinter.Items.AddRange(new object[] {
            "SELPHY CP1300",
            "DNP DP-QW410"});
            this.cmbPrinter.Location = new System.Drawing.Point(353, 568);
            this.cmbPrinter.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(727, 47);
            this.cmbPrinter.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("AppleSDGothicNeoB00", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(157, 488);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "기본 프린터";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("AppleSDGothicNeoB00", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(346, 483);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 39);
            this.label2.TabIndex = 13;
            this.label2.Text = "Default Printer Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTestPrint
            // 
            this.btnTestPrint.Location = new System.Drawing.Point(1088, 568);
            this.btnTestPrint.Name = "btnTestPrint";
            this.btnTestPrint.Size = new System.Drawing.Size(189, 47);
            this.btnTestPrint.TabIndex = 14;
            this.btnTestPrint.Text = "테스트 출력";
            this.btnTestPrint.UseVisualStyleBackColor = true;
            this.btnTestPrint.Click += new System.EventHandler(this.btnTestPrint_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 20F);
            this.button1.Location = new System.Drawing.Point(139, 700);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 77);
            this.button1.TabIndex = 15;
            this.button1.Text = "저장";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 18F);
            this.button2.Location = new System.Drawing.Point(398, 700);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(228, 77);
            this.button2.TabIndex = 16;
            this.button2.Text = "기본값 불러오기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 18F);
            this.button3.Location = new System.Drawing.Point(917, 700);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(228, 77);
            this.button3.TabIndex = 17;
            this.button3.Text = "취소";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("AppleSDGothicNeoEB00", 18F);
            this.btnRefresh.Location = new System.Drawing.Point(658, 700);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(228, 77);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.ControlBox = false;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTestPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPrinter);
            this.Controls.Add(this.lblPrinter);
            this.Controls.Add(this.txtAuthToken);
            this.Controls.Add(this.lblAuthToken);
            this.Controls.Add(this.txtProcessUrl);
            this.Controls.Add(this.lblProcessUrl);
            this.Controls.Add(this.lblTitle);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(8, 12, 8, 12);
            this.MinimizeBox = false;
            this.Name = "settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "설정";
            this.Load += new System.EventHandler(this.settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProcessUrl;
        private System.Windows.Forms.TextBox txtProcessUrl;
        private System.Windows.Forms.Label lblAuthToken;
        private System.Windows.Forms.TextBox txtAuthToken;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTestPrint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnRefresh;
    }
}
