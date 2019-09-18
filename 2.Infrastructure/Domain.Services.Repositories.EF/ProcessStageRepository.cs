using Core.Persistance;
using Domain.Model;
using Domain.Services.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.EF;
using System.Linq;

namespace Domain.Services.Repositories.EF
{
    public class ProcessStageRepository : Repository<Stage, DataBaseContext>, IProcessStageRepository
    {
        public ProcessStageRepository(DataBaseContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public override IQueryable<Stage> QueryEager()
        {
            return Query()
                .Include(x => x.ConsultantDelegate)
                .Include(x => x.ConsultantOwner);
        }

        public void UpdateStage(Stage newStage, Stage existingStage)
        {
            _dbContext.Entry(existingStage).CurrentValues.SetValues(newStage);
        }
    }
}
