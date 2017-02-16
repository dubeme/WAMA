using WAMA.Core.Models;
using WAMA.Core.Models.Provider;

namespace WAMA.Core.Providers
{
    public class DbContextProvider : IDbContextProvider
    {
        public WamaDbContext GetWamaDbContext()
        {
            return new WamaDbContext();
        }
    }
}