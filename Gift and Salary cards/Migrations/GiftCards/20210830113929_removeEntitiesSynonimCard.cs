using Microsoft.EntityFrameworkCore.Migrations;

namespace Gift_and_Salary_cards.Migrations.GiftCards
{
    public partial class removeEntitiesSynonimCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reason",
                table: "BankCardPayout");

            migrationBuilder.DropColumn(
                name: "skr_cardBin",
                table: "BankCardPayout");

            migrationBuilder.DropColumn(
                name: "skr_cardLast4",
                table: "BankCardPayout");

            migrationBuilder.DropColumn(
                name: "skr_destinationCardBankName",
                table: "BankCardPayout");

            migrationBuilder.DropColumn(
                name: "skr_destinationCardCountryCode",
                table: "BankCardPayout");

            migrationBuilder.DropColumn(
                name: "skr_destinationCardPanmask",
                table: "BankCardPayout");

            migrationBuilder.DropColumn(
                name: "skr_destinationCardProductCode",
                table: "BankCardPayout");

            migrationBuilder.DropColumn(
                name: "skr_destinationCardProductName",
                table: "BankCardPayout");

            migrationBuilder.DropColumn(
                name: "skr_destinationCardSynonim",
                table: "BankCardPayout");

            migrationBuilder.DropColumn(
                name: "skr_destinationCardType",
                table: "BankCardPayout");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "reason",
                table: "BankCardPayout",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "skr_cardBin",
                table: "BankCardPayout",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "skr_cardLast4",
                table: "BankCardPayout",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "skr_destinationCardBankName",
                table: "BankCardPayout",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "skr_destinationCardCountryCode",
                table: "BankCardPayout",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "skr_destinationCardPanmask",
                table: "BankCardPayout",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "skr_destinationCardProductCode",
                table: "BankCardPayout",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "skr_destinationCardProductName",
                table: "BankCardPayout",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "skr_destinationCardSynonim",
                table: "BankCardPayout",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "skr_destinationCardType",
                table: "BankCardPayout",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
