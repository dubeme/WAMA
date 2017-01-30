using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WAMA.Core.Migrations
{
    public partial class addmorefieldsaspernewrequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "UserAccounts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasBeenApproved",
                table: "UserAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "UserAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "HasBeenApproved",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "UserAccounts");
        }
    }
}
