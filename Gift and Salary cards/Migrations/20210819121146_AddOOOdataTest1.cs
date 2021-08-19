using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gift_and_Salary_cards.Migrations
{
    public partial class AddOOOdataTest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "FamilyRepresentative",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "NameRepresentative",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "SurnameRepresentative",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "dateBirthRepresentative",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "nameOrganization",
            //    table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FamilyRepresentative",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameRepresentative",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurnameRepresentative",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateBirthRepresentative",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "nameOrganization",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
