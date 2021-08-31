using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gift_and_Salary_cards.Migrations.GiftCards
{
    public partial class addEntetiesEmployeeAndOther : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FamilyEmp",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEmp",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberEmp",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurnameEmp",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "addressEmp",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cityEmp",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "countryEmp",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateBirthEmp",
                table: "Payment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "docIssueDateEmp",
                table: "Payment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "docNumberEmp",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "moneyPayEmployee",
                table: "Payment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "postcodeEmp",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyEmp",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "NameEmp",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PhoneNumberEmp",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "SurnameEmp",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "addressEmp",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "cityEmp",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "countryEmp",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "dateBirthEmp",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "docIssueDateEmp",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "docNumberEmp",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "moneyPayEmployee",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "postcodeEmp",
                table: "Payment");
        }
    }
}
