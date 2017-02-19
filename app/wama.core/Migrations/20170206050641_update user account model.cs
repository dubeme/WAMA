using Microsoft.EntityFrameworkCore.Migrations;

namespace WAMA.Core.Migrations
{
    public partial class updateuseraccountmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query = $@"UPDATE [UserAccounts]
                SET [Gender] = (
                    CASE WHEN [Gender] = 'Male' THEN 1
                    ELSE (
                        CASE WHEN [Gender] = 'Female' THEN 2 ELSE 0 END) END)";

            migrationBuilder.Sql(query);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "UserAccounts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstitutionAffliation",
                table: "UserAccounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstitutionAffliation",
                table: "UserAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "UserAccounts",
                nullable: true,
                oldClrType: typeof(int));

            var query = $@"UPDATE [UserAccounts]
                SET [Gender] = (
                    CASE WHEN [Gender] = 1 THEN 'Male'
                    ELSE (
                        CASE WHEN [Gender] = 2 THEN 'Female' ELSE 'Unknown' END) END)";

            migrationBuilder.Sql(query);
        }
    }
}