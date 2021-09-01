using Microsoft.EntityFrameworkCore.Migrations;

namespace Gift_and_Salary_cards.Migrations.GiftCards
{
    public partial class InitialNew111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AccountBankStore");

            //migrationBuilder.DropTable(
            //    name: "BankCardPayout");

            //migrationBuilder.CreateTable(
            //    name: "BankStoreAccount",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        BankBicName = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
            //        CustAccount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
            //        payment_purpose = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BankStoreAccount", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_BankStoreAccount_Payment",
            //            column: x => x.Id,
            //            principalTable: "Payment",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CardBank",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        NumberCard = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CardBank", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CardBank_Payment",
            //            column: x => x.Id,
            //            principalTable: "Payment",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "BankStoreAccount");

            //migrationBuilder.DropTable(
            //    name: "CardBank");

            //migrationBuilder.CreateTable(
            //    name: "AccountBankStore",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BankBicName = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
            //        CustAccount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
            //        IdPayment = table.Column<int>(type: "int", nullable: true),
            //        payment_purpose = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AccountBankStore", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AccountBankStore_Payment",
            //            column: x => x.IdPayment,
            //            principalTable: "Payment",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BankCardPayout",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdPayment = table.Column<int>(type: "int", nullable: true),
            //        NumberCard = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BankCardPayout", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_BankCardPayout_Payment",
            //            column: x => x.IdPayment,
            //            principalTable: "Payment",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AccountBankStore",
            //    table: "AccountBankStore",
            //    column: "IdPayment",
            //    unique: true,
            //    filter: "[IdPayment] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BankCardPayout",
            //    table: "BankCardPayout",
            //    column: "IdPayment",
            //    unique: true,
            //    filter: "[IdPayment] IS NOT NULL");
        }
    }
}
