﻿using Core.Persistance;
using Domain.Model;
using Domain.Services.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services.Repositories.EF
{
    public class ClientStageRepository : Repository<ClientStage, DataBaseContext>, IClientStageRepository
    {
        public ClientStageRepository(DataBaseContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {

        }

        public override IQueryable<ClientStage> QueryEager()
        {
            return Query()
                .Include(x => x.ConsultantDelegate)
                .Include(x => x.ConsultantOwner);
        }

        public void UpdateClientStage(ClientStage newStage, ClientStage existingStage)
        {
            _dbContext.Entry(existingStage).CurrentValues.SetValues(newStage);
        }
    }
}
