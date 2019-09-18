using Core.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using DependencyInjection.Config;

namespace Persistance.EF
{
    public abstract class Migrator<TContext> : IMigrator where TContext : DbContext
    {
        TContext _context;

        public Migrator(TContext context)
        {
            _context = context;
        }
        
        public void Migrate(DatabaseConfigurations dbConfig)
        {
            var isDatabaseModified = false;
            if (dbConfig.RunMigrations)
            {
                //_context.Database.Migrate();
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();
                isDatabaseModified = true;
            }
            if (dbConfig.RunSeed)
            {
                SeedData(_context);
                isDatabaseModified = true;
            }

            if (isDatabaseModified)
            {
                _context.SaveChanges();
                _context.Dispose();
            }
        }

        protected virtual void SeedData(TContext context)
        {
            throw new NotImplementedException();
        }
    }
}
