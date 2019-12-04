using Core.Persistance;
using Domain.Model;
using Persistance.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services.Repositories.EF
{
    public class PostulantRepository : Repository<Postulant, DataBaseContext>
    {
        public PostulantRepository(DataBaseContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {

        }

        public override IQueryable<Postulant> Query()
        {
            return base.Query();
        }

        public override IQueryable<Postulant> QueryEager()
        {
            return Query();
        }
    }
}
