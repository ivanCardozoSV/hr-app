using HrApp.API;
using HrApp.API.Beans;
using HrApp.API.Interfaces;
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
        private IHRApi _api;
        public CandidateService(IHRApi api)
        {
            _api = api;
        }
        
        public IEnumerable<CandidatesResponse> Get()
        {
            var result = JsonConvert.DeserializeObject<CandidatesBeanResponse>(_api.Execute(new GetCandidatesQuery()),
                    CandidateJSONResponseConverter.getInstance());

            return result.Candidates;
        }
    }
}
