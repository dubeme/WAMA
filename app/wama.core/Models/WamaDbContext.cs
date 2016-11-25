using Microsoft.EntityFrameworkCore;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.Models
{
    public class WamaDbContext : DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<LogInCredential> LogInCredentials { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Waiver> Waivers { get; set; }
        public DbSet<CheckInActivity> CheckInActivities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=wama.db;User Id=wama.dev;Password=BAD_P455W0RD;";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}