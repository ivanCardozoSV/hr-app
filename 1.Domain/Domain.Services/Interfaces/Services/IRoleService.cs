using Domain.Services.Contracts.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces.Services
{
    public interface IRoleService
    {
        CreatedRoleContract Create(CreateRoleContract contract);
        ReadedRoleContract Read(int Id);
        void Update(UpdateRoleContract contract);
        void Delete(int Id);
        IEnumerable<ReadedRoleContract> List();
    }
}
