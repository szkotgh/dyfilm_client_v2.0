using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using dyfilm_client_v2._0.src;
using System;
using System.Linq;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq.Expressions;

namespace dyfilm_client_v2._0.forms
{
    public partial class create_capframe : Frame
    {
        private List<string> upload_c_id = new List<string> { };
        public static string cf_id = null;
        public static bool is_capture = false;
        public static int print_count = 1;
        private int currentPage = 0;
        private bool is_skiped = false;

        public create_capframe()
        {
            InitializeComponent();
            this.is_skiped = false;
        }

        private async void create_capframe_Load(object sender, EventArgs e)
        {
            while (true) {
                string uploadUrl = Config.process_url + "/device/capture/regi_capture";

                try
                {
                    if (cf_id == null)
                    {
                        int index = 0;
                        int progress_ud_value = Convert.ToInt32(70 / Temp.capture_paths.Count);

                        foreach (var path in Temp.capture_paths)
                        {
                            index++;
                            sub_title.Text = $"서버에 사진을 전송하고 있습니다. ({index}/{Temp.capture_paths.Count})";
                            progressBar1.Value = index * progress_ud_value;

                            byte[] imageData = File.ReadAllBytes(path);
                            using (var content = new MultipartFormDataContent())
                            {
                                var imageContent = new ByteArrayContent(imageData);
                                imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                                content.Add(imageContent, "image", Path.GetFileName(path));

                                using (var request = new HttpRequestMessage(HttpMethod.Post, uploadUrl))
                                {
                                    if (!string.IsNullOrEmpty(Config.auth_token))
                                    {
                                        request.Headers.Authorization = new AuthenticationHeaderValue(Config.auth_token);
                                    }

                                    request.Content = content;

                                    var responseBytes = await APIClient.SendRequestAsync(request);
                                    if (responseBytes == null)
                                    {
                                        throw new Exception("Capture 업로드에 실패했습니다. " + uploadUrl);
                                    }
                                    else
                                    {
                                        string jsonString1 = System.Text.Encoding.UTF8.GetString(responseBytes);
                                        var json1 = System.Text.Json.JsonDocument.Parse(jsonString1);
                                        if (json1.RootElement.TryGetProperty("info", out var infoValue1))
                                        {
                                            upload_c_id.Add(infoValue1.GetString());
                                        }
                                    }
                                }
                            }
                        }

                        sub_title.Text = "사진 제작 명령을 전송하고 있습니다.";
                        progressBar1.Value = 85;

                        // 캡프레임 생성 요청
                        var formBody = new Dictionary<string, string>();
                        for (int i = 0; i < upload_c_id.Count; i++)
                            formBody.Add($"c_id_{i + 1}", upload_c_id[i]);
                        formBody.Add("f_id", Temp.select_f_id);

                        string capframeUrl = Config.process_url + "/device/capframe/capframe_create";
                        var response2 = await APIClient.RequestFormAsync(capframeUrl, formBody);
                        if (response2 == null)
                        {
                            throw new Exception("CapFrame 생성 요청에 실패했습니다. url=" + capframeUrl + " params=" + string.Join(", ", formBody.Select(kv => $"{kv.Key}: {kv.Value}")));
                        }

                        string jsonString = System.Text.Encoding.UTF8.GetString(response2);
                        var json = System.Text.Json.JsonDocument.Parse(jsonString);
                        if (json.RootElement.TryGetProperty("info", out var infoValue))
                        {
                            cf_id = infoValue.GetString();
                        }
                    }

                    sub_title.Text = "제작된 사진을 받아오고 있습니다.";
                    progressBar1.Value = 100;

                    string capframeGetUrl;
                    if (is_capture)
                        capframeGetUrl = Config.process_url + "/device/capture/capture_get?c_id=" + cf_id;
                    else
                        capframeGetUrl = Config.process_url + "/device/capframe/capframe_get?cf_id=" + cf_id;

                    var response3 = await APIClient.RequestAsync(capframeGetUrl, method: "GET");
                    if (response3 == null)
                    {
                        throw new Exception("CapFrame 다운로드에 실패했습니다. " + capframeGetUrl);
                    }

                    string capframePath = Path.Combine(Config.FRAME_PATH, cf_id + ".png");
                    File.WriteAllBytes(capframePath, response3);

                    // printing
                    result_pictureBox.Image = Image.FromFile(capframePath);
                    progressBar1.Style = ProgressBarStyle.Marquee;
                    title1.Text = "사진이 완성되었습니다.";
                    main_title.Text = "출력 중입니다.";
                    sub_title.Text = "프린터에 사진 출력 명령을 전송했습니다.";
                    await Task.Delay(100);

                    PrintImage(capframePath);

                    main_title.Text = "프린터를 기다려 사진을 찾아가주세요.";
                    label3.BackColor = Color.CornflowerBlue;
                    for (int i = 10; i > 0; i--)
                    {
                        if (this.is_skiped)
                        {
                            break;
                        }
                        sub_title.Text = i + "초 뒤 초기 화면으로 이동합니다.";
                        await Task.Delay(1000);
                    }

                    break;
                }
                catch (Exception eee)
                {
                    if (Utils.ask_msg("CapFrame 생성 중 오류가 발생했습니다.\n" + eee.ToString() + "\n재시도 하시겠습니까?"))
                    {
                        continue;
                    }

                    this.Close();
                    return;
                }
            }

            // 메인 화면으로 이동
            this.Close();
            return;
        }
        public void PrintImage(string imagePath)
        {
            PrintDocument printDoc = new PrintDocument();
            
            // Apply settings based on configured printer type
            PrinterConfig.PrinterType printerType = PrinterConfig.GetCurrentPrinterType();
            printDoc.DefaultPageSettings.Margins = PrinterConfig.GetMargins(printerType);
            printDoc.DefaultPageSettings.PaperSize = PrinterConfig.GetPaperSize(printerType);

            printDoc.PrintPage += (sender, e) =>
            {
                using (Image imgRaw = Image.FromFile(imagePath))
                {
                    Image img = (Image)imgRaw.Clone();

                    // Determine image rotation based on printer type
                    if (PrinterConfig.ShouldRotateImage(printerType) && img.Height > img.Width)
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }

                    Rectangle bounds = e.PageBounds;
                    RectangleF drawRect = PrinterConfig.CalculateImageBounds(printerType, img, bounds);
                    e.Graphics.DrawImage(img, drawRect);

                    img.Dispose();
                }

                currentPage++;
                e.HasMorePages = currentPage < print_count;
            };

            currentPage = 0;
            printDoc.Print();
        }

        private void sub_title_Click(object sender, EventArgs e)
        {
            this.is_skiped = true;
        }
    }
}
