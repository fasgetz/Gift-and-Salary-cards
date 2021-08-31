using Microsoft.EntityFrameworkCore.Migrations;

namespace Gift_and_Salary_cards.Migrations.GiftCards
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "testEntity",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "testEntity",
                table: "Payment");
        }
    }
}
