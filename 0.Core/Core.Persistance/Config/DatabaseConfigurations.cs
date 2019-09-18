using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Config
{
    public class DatabaseConfigurations
    {
        public bool InMemoryMode { get; }

        public bool RunMigrations { get; }

        public string ConnectionString { get; }

        public bool RunSeed { get; }

        public DatabaseConfigurations(bool inMemoryMode, bool runMigrations, bool runSeed,string connectionString)
        {
            InMemoryMode = inMemoryMode;
            RunMigrations = runMigrations;
            RunSeed = runSeed;
            ConnectionString = connectionString;
        }
    }
}
