using Microsoft.EntityFrameworkCore;
using System;
using WAMA.Core.Models;
using WAMA.Core.Models.Provider;

namespace WAMA.Core.Providers
{
    /// <summary>
    /// Represents DbContextProvider
    /// </summary>
    /// <seealso cref="WAMA.Core.Models.Provider.IDbContextProvider" />
    public class DbContextProvider : IDbContextProvider
    {
        private DbContextOptions dbContextOptions;

        public DbContextProvider(DbContextOptions _dbContextOptions)
        {
            dbContextOptions = _dbContextOptions;
        }

        /// <summary>
        /// Gets a <see cref="WamaDbContext" />.
        /// </summary>
        /// <returns></returns>
        public WamaDbContext GetWamaDbContext()
        {
            return new WamaDbContext(dbContextOptions);
        }

        /// <summary>
        /// Gets a <see cref="WamaDbContext" />.
        /// </summary>
        /// <param name="dbOption">The database option.</param>
        /// <returns></returns>
        public WamaDbContext GetWamaDbContext(DbContextOptions dbOption)
        {
            throw new NotImplementedException();
        }
    }
}