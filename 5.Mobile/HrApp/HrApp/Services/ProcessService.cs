using ApiServer.Contracts.Process;
using HrApp.API.Interfaces;
using HrApp.API.Queries;
using HrApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Services
{
    public class ProcessService : IProcessService
    {
        private IHRApi _api;
        public ProcessService(IHRApi api)
        {
            _api = api;
        }

        public IEnumerable<ReadedProcessViewModel> Get()
        {
            var result = JsonConvert.DeserializeObject<IEnumerable<ReadedProcessViewModel>>(_api.Execute(new GetProcessesQuery()));

            return result;
        }
    }
}
