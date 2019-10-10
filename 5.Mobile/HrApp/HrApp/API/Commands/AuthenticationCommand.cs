using HrApp.API.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HrApp.API
{
    class AuthenticationCommand : HttpCommand
    {
        private readonly Credentials credentials; 
        private readonly string endpoint;
        private readonly HRApi hrApi;

        public AuthenticationCommand (Credentials credentials)
        {
            this.credentials = credentials;
            this.endpoint = api + "Auth/login";
        }

        public override HttpResponseMessage Execute()
        {
            var credentialsJson = JsonConvert.SerializeObject(credentials);
            var httpClient = HttpReceiver.GetReceiver();

            var res = httpClient.PostJson(endpoint, credentialsJson);

            return res;
        }
    }
}
