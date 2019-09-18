using Domain.Services.Contracts.Process;
using System.Collections.Generic;

namespace Domain.Services.Interfaces.Services
{
    public interface IProcessService
    {
        CreatedProcessContract Create(CreateProcessContract contract);

        ReadedProcessContract Read(int id);

        void Update(UpdateProcessContract contract);

        void Delete(int id);

        IEnumerable<ReadedProcessContract> List();

        void Approve(int processID);

        void Reject(int id, string rejectionReason);
    }
}
