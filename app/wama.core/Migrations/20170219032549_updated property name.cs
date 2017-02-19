using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WAMA.Core.Migrations
{
    public partial class updatedpropertyname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstitutionAffliation",
                table: "UserAccounts");

            migrationBuilder.AddColumn<int>(
                name: "InstitutionAffiliation",
                table: "UserAccounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstitutionAffiliation",
                table: "UserAccounts");

            migrationBuilder.AddColumn<int>(
                name: "InstitutionAffliation",
                table: "UserAccounts",
                nullable: false,
                defaultValue: 0);
        }
    }
}
