using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HrApp.API
{
    
    class HttpReceiver
    {
        private static HttpReceiver Instance;
        private HttpClient httpClient;

        public static HttpReceiver GetReceiver()
        {
            if (Instance == null) 
                Instance = new HttpReceiver();
            return Instance;
        }

        private HttpReceiver()
        {
            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(10);
        }

        public HttpReceiver SetToken(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return Instance;
        }

        public HttpResponseMessage PostJson(string url, string json)
        {

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var req = httpClient.PostAsync(url, content);
            req.Wait();

            return req.Result;
        }

        public HttpResponseMessage Get(string url)
        {
            var req = httpClient.GetAsync(url);
            req.Wait();
            return req.Result;
        }


    }
}
