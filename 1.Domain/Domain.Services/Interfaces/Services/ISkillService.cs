using Domain.Services.Contracts.Skill;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces.Services
{
    public interface ISkillService
    {
        CreatedSkillContract Create(CreateSkillContract contract);
        ReadedSkillContract Read(int id);
        void Update(UpdateSkillContract contract);
        void Delete(int id);
        IEnumerable<ReadedSkillContract> List();
    }
}
