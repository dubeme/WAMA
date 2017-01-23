namespace WAMA.Core.Models.Provider
{
    public interface IDbContextProvider
    {
        WamaDbContext GetWamaDbContext();
    }
}