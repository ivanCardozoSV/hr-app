using Core.Persistance;
using Domain.Model;
using Persistance.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services.Repositories.EF
{
    public class UserRepository : Repository<User, DataBaseContext>
    {
        public UserRepository(DataBaseContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public override IQueryable<User> Query()
        {
            return base.Query();
        }

        public override IQueryable<User> QueryEager()
        {
            return Query();
        }
    }
}
