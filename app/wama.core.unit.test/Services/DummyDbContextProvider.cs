using Microsoft.EntityFrameworkCore;
using System;
using WAMA.Core.Models;
using WAMA.Core.Models.Provider;

namespace WAMAcut.Services
{
    public class DummyDbContextProvider : IDbContextProvider
    {
        private DbContextOptions dbContextOptions;

        public DummyDbContextProvider(DbContextOptions dbOption)
        {
            dbContextOptions = dbOption;
        }

        public WamaDbContext GetWamaDbContext()
        {
            return new WamaDbContext(dbContextOptions);
        }

        public WamaDbContext GetWamaDbContext(DbContextOptions dbOption)
        {
            throw new NotImplementedException();
        }
    }
}