using Microsoft.EntityFrameworkCore;
using System;
using WAMA.Core.Models;
using WAMA.Core.Models.Provider;
using WAMA.Core.Providers;

namespace WAMAcut.Helpers
{
    public class DummyDbContextProvider : DbContextProvider, IDbContextProvider
    {
        private DbContextOptions dbContextOptions;

        public DummyDbContextProvider() : this((new DbContextOptionsBuilder<WamaDbContext>())
                .UseInMemoryDatabase()
                .Options)
        {
        }

        public DummyDbContextProvider(DbContextOptions dbOption) : base(dbOption)
        {
            dbContextOptions = dbOption;
        }

        public new WamaDbContext GetWamaDbContext()
        {
            return new WamaDbContext(dbContextOptions);
        }

        public new WamaDbContext GetWamaDbContext(DbContextOptions dbOption)
        {
            throw new NotImplementedException();
        }

        public static WamaDbContext GetSqlServerDbOption()
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=wama.db;User Id=wama.dev;Password=BAD_P455W0RD;";

            return new WamaDbContext((new DbContextOptionsBuilder<WamaDbContext>())
                .UseSqlServer(connection)
                .Options);
        }
    }
}