using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using dyfilm_client_v2._0.src;
using System;

namespace dyfilm_client_v2._0.forms
{
    public partial class create_capframe : Frame
    {
        private List<string> imagePathsToUpload;  // 파일 경로 리스트

        public create_capframe()
        {
            InitializeComponent();
        }

        private async void create_capframe_Load(object sender, EventArgs e)
        {
            string uploadUrl = Config.process_url + "/device/capture/regi_capture";

            foreach (var path in Temp.select_c_id)
            {
                try
                {
                    byte[] imageData = File.ReadAllBytes(path);
                    using (var content = new MultipartFormDataContent())
                    {
                        var imageContent = new ByteArrayContent(imageData);
                        imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                        content.Add(imageContent, "image", Path.GetFileName(path));

                        using (var request = new HttpRequestMessage(HttpMethod.Post, uploadUrl))
                        {
                            // 인증 헤더 설정
                            if (!string.IsNullOrEmpty(Properties.Settings.Default.auth_token))
                            {
                                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Properties.Settings.Default.auth_token);
                            }

                            request.Content = content;

                            // 업로드 요청
                            var response = await APIClient.SendRequestAsync(request);
                            if (response == null)
                            {
                                MessageBox.Show("업로드 실패: " + Path.GetFileName(path));
                            }
                            else
                            {
                                Console.WriteLine("업로드 성공: " + Path.GetFileName(path));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"파일 업로드 중 오류 발생:\n{path}\n{ex}");
                }
            }

            MessageBox.Show("모든 이미지 업로드 완료");
        }

    }
}
