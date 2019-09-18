using Core.Persistance;
using Domain.Model;
using Persistance.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Repositories.EF
{
    public class CandidateProfileRepository : Repository<CandidateProfile, DataBaseContext>
    {
        public CandidateProfileRepository(DataBaseContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public override IQueryable<CandidateProfile> Query()
        {
            return base.Query();
        }

        public override IQueryable<CandidateProfile> QueryEager()
        {
            return Query().Include(c => c.CommunityItems);
        }

        public override CandidateProfile Update(CandidateProfile entity)
        {
            //Remuevo previo set de items del Perfil. El usuario puede haber creado, eliminado o editado existentes
            var previousItems = _dbContext.Community.Where(t => t.ProfileId == entity.Id);
            _dbContext.Community.RemoveRange(previousItems);

            foreach (var item in entity.CommunityItems)
            {
                _dbContext.Community.Add(item);
            }

            return base.Update(entity);
        }
    }
}
