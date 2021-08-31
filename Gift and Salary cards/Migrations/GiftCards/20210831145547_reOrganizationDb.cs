using Microsoft.EntityFrameworkCore.Migrations;

namespace Gift_and_Salary_cards.Migrations.GiftCards
{
    public partial class reOrganizationDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Payment_AccountBankStore",
            //    table: "Payment");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Payment_BankCardPayout",
            //    table: "Payment");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Payment",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "BankCardPayout",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddColumn<int>(
            //    name: "IdPayment",
            //    table: "BankCardPayout",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "AccountBankStore",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddColumn<int>(
            //    name: "IdPayment",
            //    table: "AccountBankStore",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_BankCardPayout",
            //    table: "BankCardPayout",
            //    column: "IdPayment",
            //    unique: true,
            //    filter: "[IdPayment] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AccountBankStore",
            //    table: "AccountBankStore",
            //    column: "IdPayment",
            //    unique: true,
            //    filter: "[IdPayment] IS NOT NULL");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AccountBankStore_Payment",
            //    table: "AccountBankStore",
            //    column: "IdPayment",
            //    principalTable: "Payment",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BankCardPayout_Payment",
            //    table: "BankCardPayout",
            //    column: "IdPayment",
            //    principalTable: "Payment",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AccountBankStore_Payment",
            //    table: "AccountBankStore");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_BankCardPayout_Payment",
            //    table: "BankCardPayout");

            //migrationBuilder.DropIndex(
            //    name: "IX_BankCardPayout",
            //    table: "BankCardPayout");

            //migrationBuilder.DropIndex(
            //    name: "IX_AccountBankStore",
            //    table: "AccountBankStore");

            //migrationBuilder.DropColumn(
            //    name: "IdPayment",
            //    table: "BankCardPayout");

            //migrationBuilder.DropColumn(
            //    name: "IdPayment",
            //    table: "AccountBankStore");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Payment",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "BankCardPayout",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "AccountBankStore",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Payment_AccountBankStore",
            //    table: "Payment",
            //    column: "Id",
            //    principalTable: "AccountBankStore",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Payment_BankCardPayout",
            //    table: "Payment",
            //    column: "Id",
            //    principalTable: "BankCardPayout",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
