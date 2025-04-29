using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dyfilm_client_v2._0
{
    class APIClient
    {
        private static readonly HttpClient instance = new HttpClient();

        public static async Task<byte[]> RequestAsync(string url, string method = "GET", string postData = null)
        {
            try
            {
                using (var requestMessage = new HttpRequestMessage(new HttpMethod(method), url))
                {
                    // Authorization 헤더 추가
                    if (!string.IsNullOrEmpty(Properties.Settings.Default.auth_token))
                    {
                        requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Properties.Settings.Default.auth_token);
                    }

                    // POST인 경우, Body에 데이터 추가
                    if (method.ToUpper() == "POST" && postData != null)
                    {
                        requestMessage.Content = new StringContent(postData, Encoding.UTF8, "application/json");
                    }

                    var response = await instance.SendAsync(requestMessage);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsByteArrayAsync();
                    }
                    else
                    {
                        Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception during request: {e}");
            }
            return null;
        }
    }
}
