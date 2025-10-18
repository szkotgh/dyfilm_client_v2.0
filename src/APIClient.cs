using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using dyfilm_client_v2._0.src;

namespace dyfilm_client_v2._0
{
    class APIClient
    {
        private static readonly HttpClient instance = new HttpClient();

        // 새롭게 추가된 오버로드: form-urlencoded 방식
        public static async Task<byte[]> RequestFormAsync(string url, Dictionary<string, string> formData)
        {
            try
            {
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    // Authorization 헤더 추가
                    if (!string.IsNullOrEmpty(Config.auth_token))
                    {
                        requestMessage.Headers.Authorization = new AuthenticationHeaderValue(Config.auth_token);
                    }

                    // form-urlencoded 형식으로 Content 설정
                    requestMessage.Content = new FormUrlEncodedContent(formData);

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

        // 기존 JSON 전송 방식은 그대로 유지
        public static async Task<byte[]> RequestAsync(string url, string method = "GET", string postData = null)
        {
            try
            {
                using (var requestMessage = new HttpRequestMessage(new HttpMethod(method), url))
                {
                    if (!string.IsNullOrEmpty(Config.auth_token))
                    {
                        requestMessage.Headers.Authorization = new AuthenticationHeaderValue(Config.auth_token);
                    }

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

        public static async Task<byte[]> SendRequestAsync(HttpRequestMessage request)
        {
            try
            {
                var response = await instance.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
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
