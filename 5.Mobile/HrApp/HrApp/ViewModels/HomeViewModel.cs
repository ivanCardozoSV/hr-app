using ApiServer.Contracts.Process;
using HrApp.API.Beans;
using HrApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.ViewModels
{
    public class HomeViewModel
    {
        private IProcessService _processService;
        private ICandidateService _candidateService;

        public HomeViewModel(IProcessService processService, ICandidateService candidateService)
        {
            _processService = processService;
            _candidateService = candidateService;
        }

        public IEnumerable<ReadedProcessViewModel> GetProcesses()
        {
            return _processService.Get();
        }

        public IEnumerable<CandidatesResponse> GetCandidates()
        {
            return _candidateService.Get();
        }
    }
}
