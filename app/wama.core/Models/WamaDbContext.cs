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

        public WamaDbContext()
        {
        }

        public WamaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = @"Server=(localdb)\mssqllocaldb;Database=wama.db;User Id=wama.dev;Password=BAD_P455W0RD;";
                optionsBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>()
                .HasAlternateKey(ua => ua.MemberId);

            modelBuilder.Entity<Certification>()
                .HasOne(cert => cert.Member)
                .WithMany(ua => ua.Certifications)
                .HasForeignKey(cert => cert.MemberId)
                .HasPrincipalKey(ua => ua.MemberId)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<CheckInActivity>()
                .HasOne(cia => cia.Member)
                .WithMany(ua => ua.CheckInActivities)
                .HasForeignKey(cia => cia.MemberId)
                .HasPrincipalKey(ua => ua.MemberId)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<LogInCredential>()
                .HasOne(lc => lc.Member)
                .WithOne(ua => ua.LogInCredential)
                .HasForeignKey<LogInCredential>(lc => lc.MemberId)
                .HasPrincipalKey<UserAccount>(ua => ua.MemberId)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<Waiver>()
                .HasOne(wv => wv.Member)
                .WithMany(ua => ua.Waivers)
                .HasForeignKey(wv => wv.MemberId)
                .HasPrincipalKey(ua => ua.MemberId)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);
        }
    }
}