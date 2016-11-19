using Microsoft.EntityFrameworkCore;
using WAMA.Core.Models.POCOs;

namespace WAMA.Core.Models
{
    internal class WamaDbContext : DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<LoginCredential> LoginCredentials { get; set; }
    }
}