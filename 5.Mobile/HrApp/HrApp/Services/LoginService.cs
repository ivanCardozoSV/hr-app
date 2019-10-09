using HrApp.API;
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
        public string Authenticate(string userName, string password)
        {
            //API ENDPOINT
            HttpCommand.Setup(Constants.APIEndpoint);
            HRApi.getApi().Setup(userName, password);

            var api = HRApi.getApi();
            var command = new CandidateCommand();
            var res = api.Execute(command);

            //var resultss = JsonConvert.DeserializeObject<IEnumerable<Candidate>>(res);

            var result = JsonConvert.DeserializeObject<TokenDTO>(res);

            return result.Token;
        }

        public string AuthenticateExternal(string tkn)
        {
            var token = new TokenDTO()
            {
                Token = tkn
            };

            var api = HRApi.getApi();
            var command = new ExternalAuthenticationCommand(token);
            var res = api.Execute(command);
            var result = JsonConvert.DeserializeObject<TokenDTO>(res);

            return result.Token;
        }
    }
}
