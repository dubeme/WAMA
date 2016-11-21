using Microsoft.EntityFrameworkCore;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.Models
{
    internal class WamaDbContext : DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<LoginCredential> LoginCredentials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=wama.db;User Id=wama.dev;Password=BAD_P455W0RD;";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}