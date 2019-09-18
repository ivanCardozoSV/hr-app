using Domain.Services.Contracts.Consultant;
using System.Collections.Generic;

namespace Domain.Services.Interfaces.Services
{
    public interface IConsultantService
    {
        CreatedConsultantContract Create(CreateConsultantContract contract);

        ReadedConsultantContract Read(int id);

        IEnumerable<ReadedConsultantContract> List();

        ReadedConsultantByNameContract GetConsultantsByName(string name);

        void Update(UpdateConsultantContract contract);
        void Delete(int id);
    }
}
