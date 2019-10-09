using Domain.Model;
using HrApp.API;
using HrApp.API.Beans;
using HrApp.API.Json;
using HrApp.Services.Interfaces;
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
        private readonly ICandidateService _candidateService;
        public List<CandidatesResponse> CandidateList { get; set; }

        public CandidateViewModel(ICandidateService candidateService)
        {
            _candidateService = candidateService;
            CandidateList = _candidateService.Get().ToList();
        }
    }
            
}
