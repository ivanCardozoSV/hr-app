using Domain.Model;
using HrApp.API;
using HrApp.API.Beans;
using HrApp.API.Json;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HrApp.ViewModels
{
    public class CandidateViewModel : BaseViewModel
    {
        public List<CandidatesResponse> CandidateList { get; set; }

        public CandidateViewModel()
        {
            CandidateList = new List<CandidatesResponse>();
            CandidateList = GetCandidates();
        }


        public List<CandidatesResponse> GetCandidates()
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
