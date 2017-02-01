using Microsoft.EntityFrameworkCore.Migrations;

namespace WAMA.Core.Migrations
{
    public partial class updatefieldsandforeignkeydeletebehaviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_UserAccounts_MemberId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckInActivities_UserAccounts_MemberId",
                table: "CheckInActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_LogInCredentials_UserAccounts_MemberId",
                table: "LogInCredentials");

            migrationBuilder.DropForeignKey(
                name: "FK_Waivers_UserAccounts_MemberId",
                table: "Waivers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserAccounts",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_UserAccounts_MemberId",
                table: "Certifications",
                column: "MemberId",
                principalTable: "UserAccounts",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckInActivities_UserAccounts_MemberId",
                table: "CheckInActivities",
                column: "MemberId",
                principalTable: "UserAccounts",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogInCredentials_UserAccounts_MemberId",
                table: "LogInCredentials",
                column: "MemberId",
                principalTable: "UserAccounts",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Waivers_UserAccounts_MemberId",
                table: "Waivers",
                column: "MemberId",
                principalTable: "UserAccounts",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_UserAccounts_MemberId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckInActivities_UserAccounts_MemberId",
                table: "CheckInActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_LogInCredentials_UserAccounts_MemberId",
                table: "LogInCredentials");

            migrationBuilder.DropForeignKey(
                name: "FK_Waivers_UserAccounts_MemberId",
                table: "Waivers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserAccounts");

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_UserAccounts_MemberId",
                table: "Certifications",
                column: "MemberId",
                principalTable: "UserAccounts",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckInActivities_UserAccounts_MemberId",
                table: "CheckInActivities",
                column: "MemberId",
                principalTable: "UserAccounts",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LogInCredentials_UserAccounts_MemberId",
                table: "LogInCredentials",
                column: "MemberId",
                principalTable: "UserAccounts",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Waivers_UserAccounts_MemberId",
                table: "Waivers",
                column: "MemberId",
                principalTable: "UserAccounts",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}