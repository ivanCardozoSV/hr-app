using HrApp.API.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HrApp.API
{
    class CandidateCommand : HttpCommand
    {
        private readonly string endpoint;

        public CandidateCommand ()
        {
            this.endpoint = api + "Candidates";
        }
    
        public override HttpResponseMessage Execute()
        {
            var reciever = HttpReceiver.GetReceiver();
            return reciever.Get(endpoint);
        }
    }
}
