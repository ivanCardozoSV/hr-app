using Domain.Model;
using Domain.Model.Enum;
using HrApp.API;
using HrApp.API.Beans;
using HrApp.API.Json;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HrApp.ViewModels
{
    public class CandidateViewModel : BaseViewModel
    {
        public List<CandidatesResponse> CandidateList { get; set; }
        public object Status { get; private set; }

        public CandidateViewModel()
        {
            CandidateList = new List<CandidatesResponse>();
            CandidateList = GetCandidateOrderByNew();
        }

        public List<CandidatesResponse> GetCandidateOrderByNew()
        {
            var api = HRApi.getApi();
            var command = new CandidateCommand();
            var res = api.Execute(command);
            var result = JsonConvert.DeserializeObject<CandidatesBeanResponse>(res,
                    CandidateJSONResponseConverter.getInstance());
            return result.Candidates.OrderBy(x => (int)x.Status).ToList();
        }
    }
            
}
