using Microsoft.EntityFrameworkCore;

namespace WAMA.Core.Models.Provider
{
    public interface IDbContextProvider
    {
        WamaDbContext GetWamaDbContext();

        WamaDbContext GetWamaDbContext(DbContextOptions dbOption);
    }
}