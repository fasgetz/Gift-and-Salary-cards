using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gift_and_Salary_cards.Models.DataBase
{
    public partial class GiftCardsContext : DbContext
    {
        public GiftCardsContext()
        {
        }

        public GiftCardsContext(DbContextOptions<GiftCardsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CheckPayment> CheckPayments { get; set; }
        public virtual DbSet<ComissionService> ComissionServices { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public virtual DbSet<Payout> Payouts { get; set; }
        public virtual DbSet<StatusPaymentType> StatusPaymentTypes { get; set; }
        public virtual DbSet<StatusPayout> StatusPayouts { get; set; }
        public virtual DbSet<StatusPayoutType> StatusPayoutTypes { get; set; }
        public virtual DbSet<SynonimCard> SynonimCards { get; set; }
        public virtual DbSet<TypePayout> TypePayouts { get; set; }
        public virtual DbSet<TypesOfPayout> TypesOfPayouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<CheckPayment>(entity =>
            {
                entity.ToTable("CheckPayment");

                entity.Property(e => e.DateRegistered).HasColumnType("datetime");

                entity.Property(e => e.FiscalAccumulatorNumber).HasMaxLength(50);

                entity.Property(e => e.FiscalAttribute)
                    .HasMaxLength(50)
                    .HasColumnName("FIscalAttribute");

                entity.Property(e => e.FiscalDocumentNumber).HasMaxLength(50);

                entity.Property(e => e.IdCheckCloudCash).HasMaxLength(100);

                entity.Property(e => e.IdCheckInUkassa).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.IdPaymentNavigation)
                    .WithMany(p => p.CheckPayments)
                    .HasForeignKey(d => d.IdPayment)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CheckPayment_Payment");
            });

            modelBuilder.Entity<ComissionService>(entity =>
            {
                entity.ToTable("ComissionService");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Procent).HasColumnType("money");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.AddressPaymentShip)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CitizenshipCodeEmployee)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.CityPaymentShip)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DateBirthEmployee).HasColumnType("date");

                entity.Property(e => e.DateOfIssueEmployee).HasColumnType("date");

                entity.Property(e => e.FamilyEmployee)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NameEmployee)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneEmployee)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.PostCodePaymentShip)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.SeriesAndNumbPasspEmployee)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SurnameEmployee)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.IdUkassa).HasMaxLength(150);

                entity.Property(e => e.PayerEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PayerPhone).HasMaxLength(50);

                entity.Property(e => e.PaymentUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.SumPayment).HasColumnType("money");

                entity.HasOne(d => d.IdComissionNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.IdComission)
                    .HasConstraintName("FK_Payment_ComissionService");
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.Property(e => e.DateStatus).HasColumnType("datetime");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.PaymentStatuses)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PaymentStatuses_Payment");

                entity.HasOne(d => d.StatusPayment)
                    .WithMany(p => p.PaymentStatuses)
                    .HasForeignKey(d => d.StatusPaymentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PaymentStatuses_StatusPayment");
            });

            modelBuilder.Entity<Payout>(entity =>
            {
                entity.ToTable("Payout");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(128);

                entity.Property(e => e.SumToPayoutEmployee).HasColumnType("money");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Payout)
                    .HasForeignKey<Payout>(d => d.Id)
                    .HasConstraintName("FK_Payout_Payment");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Payouts)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payout_Employees");
            });

            modelBuilder.Entity<StatusPaymentType>(entity =>
            {
                entity.ToTable("StatusPaymentType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<StatusPayout>(entity =>
            {
                entity.ToTable("StatusPayout");

                entity.Property(e => e.RequestDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.RequestId).HasMaxLength(100);

                entity.Property(e => e.ResponseMessage).HasMaxLength(150);

                entity.HasOne(d => d.IdPayoutNavigation)
                    .WithMany(p => p.StatusPayouts)
                    .HasForeignKey(d => d.IdPayout)
                    .HasConstraintName("FK_StatusPayout_Payout");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.StatusPayouts)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_StatusPayout_StatusPayoutType");
            });

            modelBuilder.Entity<StatusPayoutType>(entity =>
            {
                entity.ToTable("StatusPayoutType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<SynonimCard>(entity =>
            {
                entity.ToTable("SynonimCard");

                entity.Property(e => e.NumberCard).HasMaxLength(16);

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .HasColumnName("reason");

                entity.Property(e => e.SkrCardBin)
                    .HasMaxLength(50)
                    .HasColumnName("skr_cardBin");

                entity.Property(e => e.SkrCardLast4)
                    .HasMaxLength(50)
                    .HasColumnName("skr_cardLast4");

                entity.Property(e => e.SkrDestinationCardBankName)
                    .HasMaxLength(50)
                    .HasColumnName("skr_destinationCardBankName");

                entity.Property(e => e.SkrDestinationCardCountryCode)
                    .HasMaxLength(50)
                    .HasColumnName("skr_destinationCardCountryCode");

                entity.Property(e => e.SkrDestinationCardPanmask)
                    .HasMaxLength(50)
                    .HasColumnName("skr_destinationCardPanmask");

                entity.Property(e => e.SkrDestinationCardProductCode)
                    .HasMaxLength(50)
                    .HasColumnName("skr_destinationCardProductCode");

                entity.Property(e => e.SkrDestinationCardProductName)
                    .HasMaxLength(50)
                    .HasColumnName("skr_destinationCardProductName");

                entity.Property(e => e.SkrDestinationCardSynonim)
                    .HasMaxLength(50)
                    .HasColumnName("skr_destinationCardSynonim");

                entity.Property(e => e.SkrDestinationCardType)
                    .HasMaxLength(50)
                    .HasColumnName("skr_destinationCardType");
            });

            modelBuilder.Entity<TypePayout>(entity =>
            {
                entity.ToTable("TypePayout");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TypePayoutNavigation)
                    .HasForeignKey<TypePayout>(d => d.Id)
                    .HasConstraintName("FK_TypePayout_Payout");

                entity.HasOne(d => d.IdDataCardOrBankAccountNavigation)
                    .WithMany(p => p.TypePayouts)
                    .HasForeignKey(d => d.IdDataCardOrBankAccount)
                    .HasConstraintName("FK_TypePayout_SynonimCard");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.TypePayouts)
                    .HasForeignKey(d => d.IdType)
                    .HasConstraintName("FK_TypePayout_TypesOfPayout");
            });

            modelBuilder.Entity<TypesOfPayout>(entity =>
            {
                entity.ToTable("TypesOfPayout");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
