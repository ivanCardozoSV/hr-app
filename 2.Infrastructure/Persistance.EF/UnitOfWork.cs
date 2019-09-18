using Core.Persistance;
using Core.Persistance.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Persistance.EF
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        protected TContext _dbContext { get; private set; }
        private IDictionary<Type, IRepository> _repositories;

        public UnitOfWork(TContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<Type, IRepository>();
        }

        public int Complete()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CannotCommitTransactionException("An error occurred while committing unit of work changes.", ex);
            }
        }
    }
}
