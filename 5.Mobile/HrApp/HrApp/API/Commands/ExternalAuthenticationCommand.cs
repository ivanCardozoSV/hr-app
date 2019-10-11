using HrApp.API.DTO;
using HrApp.Models.DTO;
using HrApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HrApp.API
{
    public class ExternalAuthenticationCommand : HttpCommand
    {
        private readonly TokenDTO token; 
        private readonly string endpoint;

        public ExternalAuthenticationCommand(TokenDTO token)
        {
            this.token = token;
            this.endpoint = api + "Auth/loginExternal";
        }

        public override HttpResponseMessage Execute()
        {
            var credentialsJson = JsonConvert.SerializeObject(token);
            var httpClient = HttpReceiver.GetReceiver();

            var res = httpClient.PostJson(endpoint, credentialsJson);

            return res;
        }
    }
}
