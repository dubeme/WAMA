using Microsoft.EntityFrameworkCore;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.Models
{
    /// <summary>
    /// Represents WamaDbContext
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class WamaDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the user accounts of this WamaDbContext.
        /// </summary>
        public DbSet<UserAccount> UserAccounts { get; set; }

        /// <summary>
        /// Gets or sets the log in credentials of this WamaDbContext.
        /// </summary>
        public DbSet<LogInCredential> LogInCredentials { get; set; }

        /// <summary>
        /// Gets or sets the certifications of this WamaDbContext.
        /// </summary>
        public DbSet<Certification> Certifications { get; set; }

        /// <summary>
        /// Gets or sets the waivers of this WamaDbContext.
        /// </summary>
        public DbSet<Waiver> Waivers { get; set; }

        /// <summary>
        /// Gets or sets the check in activities of this WamaDbContext.
        /// </summary>
        public DbSet<CheckInActivity> CheckInActivities { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WamaDbContext"/> class.
        /// </summary>
        public WamaDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WamaDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public WamaDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = @"Server=(localdb)\mssqllocaldb;Database=wama.db;User Id=wama.dev;Password=BAD_P455W0RD;";
                optionsBuilder.UseSqlServer(connection);
            }
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
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