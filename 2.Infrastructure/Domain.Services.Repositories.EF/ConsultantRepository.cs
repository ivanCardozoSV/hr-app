using Core.Persistance;
using Domain.Model;
using Persistance.EF;
using System.Linq;

namespace Domain.Services.Repositories.EF
{
    public class ConsultantRepository : Repository<Consultant, DataBaseContext>
    {
        public ConsultantRepository(DataBaseContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {

        }

        public override IQueryable<Consultant> QueryEager()
        {
            return Query();
        }
    }
}
