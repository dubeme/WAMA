using Microsoft.EntityFrameworkCore;

namespace WAMA.Core.Models.Provider
{
    /// <summary>
    /// API contract for creating a <see cref="WamaDbContext"/>
    /// </summary>
    public interface IDbContextProvider
    {
        /// <summary>
        /// Gets a <see cref="WamaDbContext"/>.
        /// </summary>
        /// <returns></returns>
        WamaDbContext GetWamaDbContext();

        /// <summary>
        /// Gets a <see cref="WamaDbContext"/>.
        /// </summary>
        /// <param name="dbOption">The database option.</param>
        /// <returns></returns>
        WamaDbContext GetWamaDbContext(DbContextOptions dbOption);
    }
}