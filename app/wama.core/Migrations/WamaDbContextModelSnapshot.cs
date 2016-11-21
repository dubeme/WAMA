using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WAMA.Core.Models;
using Models.DTOs;

namespace WAMA.Core.Migrations
{
    [DbContext(typeof(WamaDbContext))]
    partial class WamaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WAMA.Core.Models.DTOs.LoginCredential", b =>
                {
                    b.Property<int>("__ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<bool>("RequiresPassword");

                    b.Property<string>("UserId");

                    b.Property<DateTimeOffset>("__CreatedOn");

                    b.HasKey("__ID");

                    b.ToTable("LoginCredentials");
                });

            modelBuilder.Entity("WAMA.Core.Models.DTOs.UserAccount", b =>
                {
                    b.Property<int>("__ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountType");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MemberId");

                    b.Property<DateTimeOffset>("__CreatedOn");

                    b.HasKey("__ID");

                    b.ToTable("UserAccounts");
                });
        }
    }
}
