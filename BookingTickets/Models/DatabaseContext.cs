using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CategoryCar> CategoryCars { get; set; }

    public virtual DbSet<Chair> Chairs { get; set; }

    public virtual DbSet<ChairCar> ChairCars { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DiscountDetail> DiscountDetails { get; set; }

    public virtual DbSet<Freeway> Freeways { get; set; }

    public virtual DbSet<InvoiceCar> InvoiceCars { get; set; }

    public virtual DbSet<InvoiceDetailCar> InvoiceDetailCars { get; set; }

    public virtual DbSet<InvoiceShipping> InvoiceShippings { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    public virtual DbSet<Time> Times { get; set; }

    public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-6ND9H3D\\PPL;Database=BOOKINGTICKET;user id=sa;password=loi123;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07157792CB");

            entity.ToTable("Account");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Car__3214EC07FDFD8DE2");

            entity.ToTable("Car");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.LicensePlates)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Car_Category_Car");
        });

        modelBuilder.Entity<CategoryCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07D2E491C6");

            entity.ToTable("CategoryCar");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
        });

        modelBuilder.Entity<Chair>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chair__3214EC072E33FB06");

            entity.ToTable("Chair");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
        });

        modelBuilder.Entity<ChairCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChairCar__3214EC0771A4BA16");

            entity.ToTable("ChairCar");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.IdCarNavigation).WithMany(p => p.ChairCars)
                .HasForeignKey(d => d.IdCar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChairCar_Car");

            entity.HasOne(d => d.IdChairNavigation).WithMany(p => p.ChairCars)
                .HasForeignKey(d => d.IdChair)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChairCar_Chair");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC07B5638298");

            entity.ToTable("Discount");

            entity.Property(e => e.Content)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.DateEnd).HasColumnType("date");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
        });

        modelBuilder.Entity<DiscountDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC0743C24C56");

            entity.ToTable("DiscountDetail");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.DiscountDetails)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscountDetail_Account");

            entity.HasOne(d => d.IdDiscountNavigation).WithMany(p => p.DiscountDetails)
                .HasForeignKey(d => d.IdDiscount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscountDetail_Discount");
        });

        modelBuilder.Entity<Freeway>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Freeway__3214EC074483C1FF");

            entity.ToTable("Freeway");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
        });

        modelBuilder.Entity<InvoiceCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceC__3214EC0780937781");

            entity.ToTable("InvoiceCar");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Note)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.InvoiceCars)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceCar_Account");
        });

        modelBuilder.Entity<InvoiceDetailCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceD__3214EC073BFFA031");

            entity.ToTable("InvoiceDetailCar");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.IdChairCarNavigation).WithMany(p => p.InvoiceDetailCars)
                .HasForeignKey(d => d.IdChairCar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetailCar_ChairCar");

            entity.HasOne(d => d.IdIvoiceCarNavigation).WithMany(p => p.InvoiceDetailCars)
                .HasForeignKey(d => d.IdIvoiceCar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetailCar_InvoiceCar");
        });

        modelBuilder.Entity<InvoiceShipping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceS__3214EC071E9C8A59");

            entity.ToTable("InvoiceShipping");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.DeliveryAddress)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DeliveryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DeliveryPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RecipientAddress)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RecipientName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecipientPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.InvoiceShippings)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceShipping_Account");

            entity.HasOne(d => d.IdShippingNavigation).WithMany(p => p.InvoiceShippings)
                .HasForeignKey(d => d.IdShipping)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceShipping_Shipping");
        });

        modelBuilder.Entity<Shipping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipping__3214EC07625694EA");

            entity.ToTable("Shipping");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Pakage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasDefaultValueSql("((0))");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Weight).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Time>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Time__3214EC076A0BBC93");

            entity.ToTable("Time");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Line)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
        });

        modelBuilder.Entity<WorkSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkSche__3214EC07BBD93B70");

            entity.ToTable("WorkSchedule");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.WorkDay).HasColumnType("date");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.WorkSchedules)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkSchedule_Account");

            entity.HasOne(d => d.IdCarNavigation).WithMany(p => p.WorkSchedules)
                .HasForeignKey(d => d.IdCar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkSchedule_Car");

            entity.HasOne(d => d.IdFreewayNavigation).WithMany(p => p.WorkSchedules)
                .HasForeignKey(d => d.IdFreeway)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkSchedule_Freeway");

            entity.HasOne(d => d.IdTimeNavigation).WithMany(p => p.WorkSchedules)
                .HasForeignKey(d => d.IdTime)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkSchedule_Time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
