using System.Collections.Generic;
using ApiServer.Contracts.Process;

namespace HrApp.Services.Interfaces
{
    public interface IProcessService
    {
        IEnumerable<ReadedProcessViewModel> Get();
    }
}