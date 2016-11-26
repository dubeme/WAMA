using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WAMA.Core.Migrations
{
    public partial class addrelationshipswithuseraccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginCredentials",
                table: "LoginCredentials");

            migrationBuilder.RenameTable(
                name: "LoginCredentials",
                newName: "LogInCredentials");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LogInCredentials",
                newName: "MemberId");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "UserAccounts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuspended",
                table: "UserAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "__LastUpdatedOn",
                table: "UserAccounts",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "LogInCredentials",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "__LastUpdatedOn",
                table: "LogInCredentials",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserAccounts_MemberId",
                table: "UserAccounts",
                column: "MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogInCredentials",
                table: "LogInCredentials",
                column: "__ID");

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    __ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CertifiedOn = table.Column<DateTimeOffset>(nullable: false),
                    ExpiresOn = table.Column<DateTimeOffset>(nullable: false),
                    MemberId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    __CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    __LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.__ID);
                    table.ForeignKey(
                        name: "FK_Certifications_UserAccounts_MemberId",
                        column: x => x.MemberId,
                        principalTable: "UserAccounts",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckInActivities",
                columns: table => new
                {
                    __ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckInDateTime = table.Column<DateTimeOffset>(nullable: false),
                    MemberId = table.Column<string>(nullable: true),
                    __CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    __LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckInActivities", x => x.__ID);
                    table.ForeignKey(
                        name: "FK_CheckInActivities_UserAccounts_MemberId",
                        column: x => x.MemberId,
                        principalTable: "UserAccounts",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Waivers",
                columns: table => new
                {
                    __ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<string>(nullable: true),
                    SignedOn = table.Column<DateTimeOffset>(nullable: false),
                    __CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    __LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waivers", x => x.__ID);
                    table.ForeignKey(
                        name: "FK_Waivers_UserAccounts_MemberId",
                        column: x => x.MemberId,
                        principalTable: "UserAccounts",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogInCredentials_MemberId",
                table: "LogInCredentials",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_MemberId",
                table: "Certifications",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckInActivities_MemberId",
                table: "CheckInActivities",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Waivers_MemberId",
                table: "Waivers",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogInCredentials_UserAccounts_MemberId",
                table: "LogInCredentials",
                column: "MemberId",
                principalTable: "UserAccounts",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogInCredentials_UserAccounts_MemberId",
                table: "LogInCredentials");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "CheckInActivities");

            migrationBuilder.DropTable(
                name: "Waivers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserAccounts_MemberId",
                table: "UserAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogInCredentials",
                table: "LogInCredentials");

            migrationBuilder.DropIndex(
                name: "IX_LogInCredentials_MemberId",
                table: "LogInCredentials");

            migrationBuilder.DropColumn(
                name: "IsSuspended",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "__LastUpdatedOn",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "__LastUpdatedOn",
                table: "LogInCredentials");

            migrationBuilder.RenameTable(
                name: "LogInCredentials",
                newName: "LoginCredentials");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "LoginCredentials",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "UserAccounts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LoginCredentials",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginCredentials",
                table: "LoginCredentials",
                column: "__ID");
        }
    }
}
