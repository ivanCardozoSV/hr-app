using HrApp.API;
using HrApp.API.Beans;
using HrApp.API.Json;
using HrApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Services
{
    public class CandidateService: ICandidateService
    {
        public IEnumerable<CandidatesResponse> Get()
        {
            var api = HRApi.getApi();
            var command = new CandidateCommand();
            var res = api.Execute(command);
            var result = JsonConvert.DeserializeObject<CandidatesBeanResponse>(res,
                    CandidateJSONResponseConverter.getInstance());


            return result.Candidates;
        }
    }
}
