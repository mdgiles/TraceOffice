//using SML.Common.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TraceForms.Models
{
    class ApiInvoker
    {/*
        public static async Task<string> SendRequestGet(string token, string url)
        {
            return await SendRequestGet(token, url, null, null);
        }

        public static async Task<string> SendRequestGet(string token, string url, Dictionary<string, string> parameters)
        {
            return await SendRequestGet(token, url, parameters, null);
        }

        public static async Task<string> SendRequestGet(string token, string url, Dictionary<string, string> parameters, Dictionary<string, string> headers)
        {
            string queryString = url;
            if (!string.IsNullOrEmpty(token)) {
                queryString += $"?apiKey={token}";
            }
            if (parameters != null) {
                foreach (var parameter in parameters) {
                    queryString += $"&{parameter.Key}={parameter.Value}";
                }
            }
            return await SendRequest(HttpMethod.Get, queryString, null, headers);
        }

        public static async Task<string> SendRequestPost(string url, string content, Dictionary<string, string> headers)
        {
            return await SendRequest(HttpMethod.Post, url, content, headers);
        }

        public static async Task<string> SendRequestPost(string token, string url, string content)
        {
            if (!string.IsNullOrEmpty(token)) {
                url = url + $"?apiKey={token}";
            }
            return await SendRequest(HttpMethod.Post, url, content, null);
        }

        public static async Task<string> SendRequestPut(string url, string content)
        {
            return await SendRequest(HttpMethod.Put, url, content, null);
        }

        public static async Task<string> SendRequestDelete(string url)
        {
            return await SendRequest(HttpMethod.Delete, url, null, null);
        }

        public static async Task<string> SendRequest(HttpMethod method, string url, string content, Dictionary<string, string> headers)
        {
            string responseString = string.Empty;

            try {
                using (HttpClient client = new HttpClient(new LoggingHandler(new HttpClientHandler(), true))) {
                    using (HttpRequestMessage request = new HttpRequestMessage(method, url)) {
                        if (!string.IsNullOrEmpty(content)) {
                            request.Content = new StringContent(content);
                            request.Content.Headers.Clear();
                            request.Content.Headers.Add("Content-Type", "application/json");
                        }
                        if (headers != null) {
                            foreach (var header in headers) {
                                request.Headers.Add(header.Key, header.Value);
                            }
                        }
                        //request.Headers.Add("Authorization", "Bearer " + token);
                        using (var response = await client.SendAsync(request).ConfigureAwait(false)) {
                            responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            if (!response.IsSuccessStatusCode) {
                                NLog.LogManager.GetCurrentClassLogger().Error(responseString);
                                responseString = string.Empty;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                NLog.LogManager.GetCurrentClassLogger().Error(ex);
            }

            return responseString;
        }

        public static async Task<Byte[]> GetBytes(string token, string url)
        {
            Byte[] bytes = null;

            try {
                //Don't use a LoggingHandler here because we don't want the pdfs logged
                using (HttpClient client = new HttpClient(new HttpClientHandler(), false)) {
                    using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url)) {
                        request.Headers.Add("Authorization", "Bearer " + token);
                        using (var response = await client.SendAsync(request).ConfigureAwait(false)) {
                            if (response.IsSuccessStatusCode) {
                                using (Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false)) {
                                    stream.Position = 0;
                                    using (MemoryStream ms = new MemoryStream()) {
                                        await stream.CopyToAsync(ms);
                                        ms.Position = 0;
                                        bytes = ms.ToArray();
                                        ms.Close();
                                    }
                                    stream.Close();
                                }
                            }
                            else {
                                NLog.LogManager.GetCurrentClassLogger().Error($"{response.StatusCode} {response.ReasonPhrase}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                NLog.LogManager.GetCurrentClassLogger().Error(ex);
            }

            return bytes;
        }

        public static string GetFile(string url)
        {
            Uri uri = new Uri(url);
            string file = string.Empty;
            using (WebClient wc = new WebClient()) {
                using (MemoryStream stream = new MemoryStream(wc.DownloadData(uri))) {
                    stream.Position = 0;
                    byte[] bytes = stream.ToArray();
                    file = Convert.ToBase64String(bytes);
                    stream.Close();
                }
            }
            return file;
        }*/

    }
}
