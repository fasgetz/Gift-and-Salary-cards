﻿// <auto-generated />
using System;
using Gift_and_Salary_cards.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gift_and_Salary_cards.Migrations.GiftCards
{
    [DbContext(typeof(GiftCardsContext))]
    [Migration("20210901101210_InitialNew111s")]
    partial class InitialNew111s
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.BankStoreAccount", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("BankBicName")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("CustAccount")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PaymentPurpose")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("payment_purpose");

                    b.HasKey("Id");

                    b.ToTable("BankStoreAccount");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.CardBank", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("NumberCard")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("CardBank");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.CheckPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateRegistered")
                        .HasColumnType("datetime");

                    b.Property<string>("FiscalAccumulatorNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FiscalAttribute")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FIscalAttribute");

                    b.Property<string>("FiscalDocumentNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IdCheckCloudCash")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IdCheckInUkassa")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("IdPayment")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdPayment");

                    b.ToTable("CheckPayment");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.ComissionService", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<decimal?>("Procent")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("ComissionService");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressPaymentShip")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CitizenshipCodeEmployee")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CityPaymentShip")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("DateBirthEmployee")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateOfIssueEmployee")
                        .HasColumnType("date");

                    b.Property<string>("FamilyEmployee")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameEmployee")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneEmployee")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PostCodePaymentShip")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("SeriesAndNumbPasspEmployee")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SurnameEmployee")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressEmp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("addressEmp");

                    b.Property<string>("CityEmp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cityEmp");

                    b.Property<string>("CountryEmp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("countryEmp");

                    b.Property<DateTime>("DateBirthEmp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("dateBirthEmp")
                        .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DocIssueDateEmp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("docIssueDateEmp")
                        .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                    b.Property<string>("DocNumberEmp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("docNumberEmp");

                    b.Property<string>("FamilyEmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("IdComission")
                        .HasColumnType("smallint");

                    b.Property<string>("IdUkassa")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("MoneyPayEmployee")
                        .HasColumnType("money")
                        .HasColumnName("moneyPayEmployee");

                    b.Property<string>("NameEmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PayerPhone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PaymentUserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumberEmp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostcodeEmp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("postcodeEmp");

                    b.Property<decimal>("SumPayment")
                        .HasColumnType("money");

                    b.Property<string>("SurnameEmp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdComission");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.PaymentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateStatus")
                        .HasColumnType("datetime");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<short?>("StatusPaymentId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.HasIndex("StatusPaymentId");

                    b.ToTable("PaymentStatuses");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.Payout", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<decimal?>("SumToPayoutEmployee")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("IdEmployee");

                    b.ToTable("Payout");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.RequestPayout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short?>("ErrorId")
                        .HasColumnType("smallint");

                    b.Property<int?>("IdPayout")
                        .HasColumnType("int");

                    b.Property<short?>("IdStatus")
                        .HasColumnType("smallint");

                    b.Property<string>("RequestDate")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true);

                    b.Property<string>("RequestId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ResponseMessage")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("IdPayout");

                    b.HasIndex("IdStatus");

                    b.ToTable("RequestPayout");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.RequestPayoutBankSynonim", b =>
                {
                    b.Property<int>("IdRequest")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("reason");

                    b.Property<string>("SkrCardBin")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("skr_cardBin");

                    b.Property<string>("SkrCardLast4")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("skr_cardLast4");

                    b.Property<string>("SkrDestinationCardBankName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("skr_destinationCardBankName");

                    b.Property<string>("SkrDestinationCardCountryCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("skr_destinationCardCountryCode");

                    b.Property<string>("SkrDestinationCardPanmask")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("skr_destinationCardPanmask");

                    b.Property<string>("SkrDestinationCardProductCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("skr_destinationCardProductCode");

                    b.Property<string>("SkrDestinationCardProductName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("skr_destinationCardProductName");

                    b.Property<string>("SkrDestinationCardSynonim")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("skr_destinationCardSynonim");

                    b.Property<string>("SkrDestinationCardType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("skr_destinationCardType");

                    b.HasKey("IdRequest")
                        .HasName("PK_RequestPayoutDataType");

                    b.ToTable("RequestPayoutBankSynonim");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.StatusPaymentType", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StatusName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("StatusPaymentType");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.StatusPayoutType", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StatusName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("StatusPayoutType");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.BankStoreAccount", b =>
                {
                    b.HasOne("Gift_and_Salary_cards.Models.DataBase.Payment", "IdNavigation")
                        .WithOne("BankStoreAccount")
                        .HasForeignKey("Gift_and_Salary_cards.Models.DataBase.BankStoreAccount", "Id")
                        .HasConstraintName("FK_BankStoreAccount_Payment")
                        .IsRequired();

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.CardBank", b =>
                {
                    b.HasOne("Gift_and_Salary_cards.Models.DataBase.Payment", "IdNavigation")
                        .WithOne("CardBank")
                        .HasForeignKey("Gift_and_Salary_cards.Models.DataBase.CardBank", "Id")
                        .HasConstraintName("FK_CardBank_Payment")
                        .IsRequired();

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.CheckPayment", b =>
                {
                    b.HasOne("Gift_and_Salary_cards.Models.DataBase.Payment", "IdPaymentNavigation")
                        .WithMany("CheckPayments")
                        .HasForeignKey("IdPayment")
                        .HasConstraintName("FK_CheckPayment_Payment")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("IdPaymentNavigation");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.Payment", b =>
                {
                    b.HasOne("Gift_and_Salary_cards.Models.DataBase.ComissionService", "IdComissionNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("IdComission")
                        .HasConstraintName("FK_Payment_ComissionService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdComissionNavigation");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.PaymentStatus", b =>
                {
                    b.HasOne("Gift_and_Salary_cards.Models.DataBase.Payment", "Payment")
                        .WithMany("PaymentStatuses")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK_PaymentStatuses_Payment")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gift_and_Salary_cards.Models.DataBase.StatusPaymentType", "StatusPayment")
                        .WithMany("PaymentStatuses")
                        .HasForeignKey("StatusPaymentId")
                        .HasConstraintName("FK_PaymentStatuses_StatusPayment")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Payment");

                    b.Navigation("StatusPayment");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.Payout", b =>
                {
                    b.HasOne("Gift_and_Salary_cards.Models.DataBase.Payment", "IdNavigation")
                        .WithOne("Payout")
                        .HasForeignKey("Gift_and_Salary_cards.Models.DataBase.Payout", "Id")
                        .HasConstraintName("FK_Payout_Payment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gift_and_Salary_cards.Models.DataBase.Employee", "IdEmployeeNavigation")
                        .WithMany("Payouts")
                        .HasForeignKey("IdEmployee")
                        .HasConstraintName("FK_Payout_Employees")
                        .IsRequired();

                    b.Navigation("IdEmployeeNavigation");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.RequestPayout", b =>
                {
                    b.HasOne("Gift_and_Salary_cards.Models.DataBase.Payout", "IdPayoutNavigation")
                        .WithMany("RequestPayouts")
                        .HasForeignKey("IdPayout")
                        .HasConstraintName("FK_StatusPayout_Payout");

                    b.HasOne("Gift_and_Salary_cards.Models.DataBase.StatusPayoutType", "IdStatusNavigation")
                        .WithMany("RequestPayouts")
                        .HasForeignKey("IdStatus")
                        .HasConstraintName("FK_StatusPayout_StatusPayoutType");

                    b.Navigation("IdPayoutNavigation");

                    b.Navigation("IdStatusNavigation");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.RequestPayoutBankSynonim", b =>
                {
                    b.HasOne("Gift_and_Salary_cards.Models.DataBase.RequestPayout", "IdRequestNavigation")
                        .WithOne("RequestPayoutBankSynonim")
                        .HasForeignKey("Gift_and_Salary_cards.Models.DataBase.RequestPayoutBankSynonim", "IdRequest")
                        .HasConstraintName("FK_RequestPayoutBankSynonim_RequestPayout")
                        .IsRequired();

                    b.Navigation("IdRequestNavigation");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.ComissionService", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.Employee", b =>
                {
                    b.Navigation("Payouts");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.Payment", b =>
                {
                    b.Navigation("BankStoreAccount");

                    b.Navigation("CardBank");

                    b.Navigation("CheckPayments");

                    b.Navigation("PaymentStatuses");

                    b.Navigation("Payout");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.Payout", b =>
                {
                    b.Navigation("RequestPayouts");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.RequestPayout", b =>
                {
                    b.Navigation("RequestPayoutBankSynonim");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.StatusPaymentType", b =>
                {
                    b.Navigation("PaymentStatuses");
                });

            modelBuilder.Entity("Gift_and_Salary_cards.Models.DataBase.StatusPayoutType", b =>
                {
                    b.Navigation("RequestPayouts");
                });
#pragma warning restore 612, 618
        }
    }
}
