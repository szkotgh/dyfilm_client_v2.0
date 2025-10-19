using dyfilm_client_v2._0.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dyfilm_client_v2._0.forms
{
    public partial class settings : Frame
    {
        public settings()
        {
            InitializeComponent();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            // Load current settings and display in text boxes
            LoadCurrentSettings();
            
            // Add event handler for printer selection change
            cmbPrinter.SelectedIndexChanged += CmbPrinter_SelectedIndexChanged;
        }

        private void CmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Refresh default printer name display when printer selection changes
            PrinterSettings defaultPrinterName = PrinterConfig.GetDefaultPrinterSettings();
            label2.Text = defaultPrinterName.PrinterName;
        }

        private void LoadCurrentSettings()
        {
            txtProcessUrl.Text = ConfigManager.GetValue("process_url");
            txtAuthToken.Text = ConfigManager.GetValue("auth_token");
            
            // Load printer settings
            string printerType = ConfigManager.GetValue("printer_type");
            if (printerType == "DNP_DP_QW410")
            {
                cmbPrinter.SelectedIndex = 1;
            }
            else
            {
                cmbPrinter.SelectedIndex = 0; // Default: SELPHY_CP1300
            }
            
            // Load and display default printer name
            string defaultPrinterName = PrinterConfig.GetDefaultPrinterSettings().PrinterName;
            label2.Text = defaultPrinterName;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(txtProcessUrl.Text))
                {
                    MessageBox.Show("프로세스 URL을 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProcessUrl.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAuthToken.Text))
                {
                    MessageBox.Show("인증 토큰을 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAuthToken.Focus();
                    return;
                }

                // Save configuration values
                ConfigManager.SetValue("process_url", txtProcessUrl.Text.Trim());
                ConfigManager.SetValue("auth_token", txtAuthToken.Text.Trim());
                
                // Save printer settings
                string selectedPrinter = cmbPrinter.SelectedItem.ToString();
                if (selectedPrinter == "DNP DP-QW410")
                {
                    ConfigManager.SetValue("printer_type", "DNP_DP_QW410");
                }
                else
                {
                    ConfigManager.SetValue("printer_type", "SELPHY_CP1300");
                }
                
                // Save to file
                ConfigManager.SaveConfig();
                
                // Update global variables in Config class
                Config.auth_token = txtAuthToken.Text.Trim();
                Config.process_url = txtProcessUrl.Text.Trim();

                MessageBox.Show("설정이 성공적으로 저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"설정 저장 중 오류가 발생했습니다:\n{ex.Message}", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Reset to default values
            txtProcessUrl.Text = "https://film.dyhs.kr";
            txtAuthToken.Text = "";
            cmbPrinter.SelectedIndex = 0; // SELPHY CP1300
            label2.Text = PrinterConfig.GetDefaultPrinterSettings().PrinterName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTestPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // Print test page
                PrintTestPage();
                MessageBox.Show("출력되었습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"출력 중 오류가 발생했습니다:\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintTestPage()
        {
            using (PrintDocument printDoc = new PrintDocument())
            {
                // Apply currently selected printer settings
                string selectedPrinter = cmbPrinter.SelectedItem.ToString();
                PrinterConfig.PrinterType printerType = selectedPrinter == "DNP DP-QW410" ? 
                    PrinterConfig.PrinterType.DNP_DP_QW410 : 
                    PrinterConfig.PrinterType.SELPHY_CP1300;

                printDoc.DefaultPageSettings.Margins = PrinterConfig.GetMargins(printerType);
                printDoc.DefaultPageSettings.PaperSize = PrinterConfig.GetPaperSize(printerType);

                printDoc.PrintPage += (sender, e) =>
                {
                    using (Font titleFont = new Font("맑은 고딕", 16, FontStyle.Bold))
                    using (Font contentFont = new Font("맑은 고딕", 10))
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        Rectangle bounds = e.PageBounds;
                        
                        // Title
                        string title = "클라이언트 프린터 테스트";
                        SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
                        float titleX = (bounds.Width - titleSize.Width) / 2;
                        e.Graphics.DrawString(title, titleFont, brush, titleX, 50);

                        // Default Printer information
                        string printerInfo = $"기본 프린터: {PrinterConfig.GetDefaultPrinterSettings().PrinterName}";
                        SizeF infoSize = e.Graphics.MeasureString(printerInfo, contentFont);
                        float infoX = (bounds.Width - infoSize.Width) / 2;
                        e.Graphics.DrawString(printerInfo, contentFont, brush, infoX, 100);

                        // Paper size information
                        string paperInfo = $"용지 크기: {printDoc.DefaultPageSettings.PaperSize.PaperName} ({printDoc.DefaultPageSettings.PaperSize.Width}x{printDoc.DefaultPageSettings.PaperSize.Height})";
                        SizeF paperSize = e.Graphics.MeasureString(paperInfo, contentFont);
                        float paperX = (bounds.Width - paperSize.Width) / 2;
                        e.Graphics.DrawString(paperInfo, contentFont, brush, paperX, 130);

                        // Margin information
                        string marginInfo = $"여백: {printDoc.DefaultPageSettings.Margins.Top},{printDoc.DefaultPageSettings.Margins.Bottom},{printDoc.DefaultPageSettings.Margins.Left},{printDoc.DefaultPageSettings.Margins.Right}";
                        SizeF marginSize = e.Graphics.MeasureString(marginInfo, contentFont);
                        float marginX = (bounds.Width - marginSize.Width) / 2;
                        e.Graphics.DrawString(marginInfo, contentFont, brush, marginX, 160);

                        // CMYK Test pattern
                        int startY = bounds.Height / 2 - 100;
                        int lineSpacing = 2;
                        int linesPerColor = 20;
                        int totalLines = linesPerColor * 4;
                        int colorBlockHeight = linesPerColor * lineSpacing;
                        // Cyan
                        using (Pen cyanPen = new Pen(Color.Cyan, 1))
                        {
                            for (int i = 0; i < linesPerColor; i++)
                            {
                                int y = startY + (i * lineSpacing);
                                e.Graphics.DrawLine(cyanPen, 50, y, bounds.Width - 50, y);
                            }
                        }
                        // Magenta
                        using (Pen magentaPen = new Pen(Color.Magenta, 1))
                        {
                            for (int i = 0; i < linesPerColor; i++)
                            {
                                int y = startY + colorBlockHeight + (i * lineSpacing);
                                e.Graphics.DrawLine(magentaPen, 50, y, bounds.Width - 50, y);
                            }
                        }
                        // Yellow
                        using (Pen yellowPen = new Pen(Color.Yellow, 1))
                        {
                            for (int i = 0; i < linesPerColor; i++)
                            {
                                int y = startY + (colorBlockHeight * 2) + (i * lineSpacing);
                                e.Graphics.DrawLine(yellowPen, 50, y, bounds.Width - 50, y);
                            }
                        }
                        // Black
                        using (Pen blackPen = new Pen(Color.Black, 1))
                        {
                            for (int i = 0; i < linesPerColor; i++)
                            {
                                int y = startY + (colorBlockHeight * 3) + (i * lineSpacing);
                                e.Graphics.DrawLine(blackPen, 50, y, bounds.Width - 50, y);
                            }
                        }

                        // Bottom message
                        DateTime now = DateTime.Now;
                        string bottomMsg = $"{now.Year}.{now.Month:D2}.{now.Day:D2}-{now.Hour:D2}:{now.Minute:D2}:{now.Second:D2}  정상 출력되었습니다.";
                        SizeF bottomSize = e.Graphics.MeasureString(bottomMsg, contentFont);
                        float bottomX = (bounds.Width - bottomSize.Width) / 2;
                        e.Graphics.DrawString(bottomMsg, contentFont, brush, bottomX, bounds.Height - 50);
                    }
                };

                printDoc.Print();
            }
        }
    }
}
