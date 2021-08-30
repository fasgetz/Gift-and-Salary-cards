using Microsoft.EntityFrameworkCore.Migrations;

namespace Gift_and_Salary_cards.Migrations
{
    public partial class AddPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone",
                table: "AspNetUsers");
        }
    }
}
