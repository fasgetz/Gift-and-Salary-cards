using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gift_and_Salary_cards.Migrations.GiftCards
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ComissionService",
            //    columns: table => new
            //    {
            //        Id = table.Column<short>(type: "smallint", nullable: false),
            //        Procent = table.Column<decimal>(type: "money", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ComissionService", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Employees",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NameEmployee = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        FamilyEmployee = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        SurnameEmployee = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        SeriesAndNumbPasspEmployee = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
            //        DateOfIssueEmployee = table.Column<DateTime>(type: "date", nullable: false),
            //        PhoneEmployee = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
            //        DateBirthEmployee = table.Column<DateTime>(type: "date", nullable: false),
            //        CitizenshipCodeEmployee = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
            //        CityPaymentShip = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        AddressPaymentShip = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        PostCodePaymentShip = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Employees", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StatusPaymentType",
            //    columns: table => new
            //    {
            //        Id = table.Column<short>(type: "smallint", nullable: false),
            //        StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StatusPaymentType", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StatusPayoutType",
            //    columns: table => new
            //    {
            //        Id = table.Column<short>(type: "smallint", nullable: false),
            //        StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StatusPayoutType", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SynonimCard",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NumberCard = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
            //        reason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        skr_destinationCardProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        skr_destinationCardProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        skr_destinationCardSynonim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        skr_destinationCardType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        skr_cardBin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        skr_cardLast4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        skr_destinationCardCountryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        skr_destinationCardBankName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        skr_destinationCardPanmask = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SynonimCard", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TypesOfPayout",
            //    columns: table => new
            //    {
            //        Id = table.Column<short>(type: "smallint", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TypesOfPayout", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Payment",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdUkassa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        PaymentUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
            //        IdComission = table.Column<short>(type: "smallint", nullable: false),
            //        SumPayment = table.Column<decimal>(type: "money", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        PayerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        PayerPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Payment", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Payment_ComissionService",
            //            column: x => x.IdComission,
            //            principalTable: "ComissionService",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CheckPayment",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdPayment = table.Column<int>(type: "int", nullable: true),
            //        IdCheckInUkassa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        IdCheckCloudCash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        FiscalDocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        FiscalAccumulatorNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        FIscalAttribute = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        DateRegistered = table.Column<DateTime>(type: "datetime", nullable: true),
            //        Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CheckPayment", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CheckPayment_Payment",
            //            column: x => x.IdPayment,
            //            principalTable: "Payment",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PaymentStatuses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PaymentId = table.Column<int>(type: "int", nullable: true),
            //        StatusPaymentId = table.Column<short>(type: "smallint", nullable: true),
            //        DateStatus = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PaymentStatuses", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_PaymentStatuses_Payment",
            //            column: x => x.PaymentId,
            //            principalTable: "Payment",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_PaymentStatuses_StatusPayment",
            //            column: x => x.StatusPaymentId,
            //            principalTable: "StatusPaymentType",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Payout",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        IdEmployee = table.Column<int>(type: "int", nullable: false),
            //        TypePayout = table.Column<short>(type: "smallint", nullable: false),
            //        SumToPayoutEmployee = table.Column<decimal>(type: "money", nullable: true),
            //        Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
            //        DateCreate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Payout", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Payout_Employees",
            //            column: x => x.IdEmployee,
            //            principalTable: "Employees",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Payout_Payment",
            //            column: x => x.Id,
            //            principalTable: "Payment",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StatusPayout",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdPayout = table.Column<int>(type: "int", nullable: true),
            //        IdStatus = table.Column<short>(type: "smallint", nullable: true),
            //        RequestDate = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
            //        RequestId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        ResponseMessage = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        ErrorId = table.Column<short>(type: "smallint", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StatusPayout", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_StatusPayout_Payout",
            //            column: x => x.IdPayout,
            //            principalTable: "Payout",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_StatusPayout_StatusPayoutType",
            //            column: x => x.IdStatus,
            //            principalTable: "StatusPayoutType",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TypePayout",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        IdType = table.Column<short>(type: "smallint", nullable: true),
            //        IdDataCardOrBankAccount = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TypePayout", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TypePayout_Payout",
            //            column: x => x.Id,
            //            principalTable: "Payout",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_TypePayout_SynonimCard",
            //            column: x => x.IdDataCardOrBankAccount,
            //            principalTable: "SynonimCard",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_TypePayout_TypesOfPayout",
            //            column: x => x.IdType,
            //            principalTable: "TypesOfPayout",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_CheckPayment_IdPayment",
            //    table: "CheckPayment",
            //    column: "IdPayment");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Payment_IdComission",
            //    table: "Payment",
            //    column: "IdComission");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PaymentStatuses_PaymentId",
            //    table: "PaymentStatuses",
            //    column: "PaymentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PaymentStatuses_StatusPaymentId",
            //    table: "PaymentStatuses",
            //    column: "StatusPaymentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Payout_IdEmployee",
            //    table: "Payout",
            //    column: "IdEmployee");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StatusPayout_IdPayout",
            //    table: "StatusPayout",
            //    column: "IdPayout");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StatusPayout_IdStatus",
            //    table: "StatusPayout",
            //    column: "IdStatus");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TypePayout_IdDataCardOrBankAccount",
            //    table: "TypePayout",
            //    column: "IdDataCardOrBankAccount");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TypePayout_IdType",
            //    table: "TypePayout",
            //    column: "IdType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CheckPayment");

            //migrationBuilder.DropTable(
            //    name: "PaymentStatuses");

            //migrationBuilder.DropTable(
            //    name: "StatusPayout");

            //migrationBuilder.DropTable(
            //    name: "TypePayout");

            //migrationBuilder.DropTable(
            //    name: "StatusPaymentType");

            //migrationBuilder.DropTable(
            //    name: "StatusPayoutType");

            //migrationBuilder.DropTable(
            //    name: "Payout");

            //migrationBuilder.DropTable(
            //    name: "SynonimCard");

            //migrationBuilder.DropTable(
            //    name: "TypesOfPayout");

            //migrationBuilder.DropTable(
            //    name: "Employees");

            //migrationBuilder.DropTable(
            //    name: "Payment");

            //migrationBuilder.DropTable(
            //    name: "ComissionService");
        }
    }
}
