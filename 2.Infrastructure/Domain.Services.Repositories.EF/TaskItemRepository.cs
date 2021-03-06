﻿using Core.Persistance;
using Domain.Model;
using Persistance.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services.Repositories.EF
{
    public class TaskItemRepository : Repository<TaskItem, DataBaseContext>
    {
        public TaskItemRepository(DataBaseContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {

        }

        public override IQueryable<TaskItem> Query()
        {
            return base.Query();
        }
    }
}
