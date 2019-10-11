using HrApp.API;
using HrApp.API.Interfaces;
using HrApp.Models.DTO;
using HrApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Services
{
    public class LoginService : ILoginService
    {
        private IHRApi _api;
        public LoginService(IHRApi api)
        {
            _api = api;
        }
        
        public string Authenticate(string userName, string password)
        {
            //API ENDPOINT
            HttpCommand.Setup(Constants.APIEndpoint);
            _api.Setup(userName, password);

            var result = JsonConvert.DeserializeObject<TokenDTO>(_api.Execute(new GetCandidatesQuery()));

            return result.Token;
        }

        public string AuthenticateExternal(string tkn)
        {
            var token = new TokenDTO()
            {
                Token = tkn
            };

            var result = JsonConvert.DeserializeObject<TokenDTO>(
                            _api.Execute(new ExternalAuthenticationCommand(token)));

            return result.Token;
        }
    }
}
