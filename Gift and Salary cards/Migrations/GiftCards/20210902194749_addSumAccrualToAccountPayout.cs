using Microsoft.EntityFrameworkCore.Migrations;

namespace Gift_and_Salary_cards.Migrations.GiftCards
{
    public partial class addSumAccrualToAccountPayout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SumNeedAccrualToAccount",
                table: "Payout",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SumNeedAccrualToAccount",
                table: "Payout");
        }
    }
}
