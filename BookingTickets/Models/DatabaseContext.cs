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

    public virtual DbSet<PlaceFrom> PlaceFroms { get; set; }

    public virtual DbSet<PlaceTo> PlaceTos { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    public virtual DbSet<TimeLine> TimeLines { get; set; }

    public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-6ND9H3D\\PPL;Database=BOOKINGTICKET;user id=sa;password=loi123;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07496D8C2D");

            entity.ToTable("Account");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.DoB).HasColumnType("datetime");
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
            entity.HasKey(e => e.LicensePlates).HasName("PK__Car__AE763D17366D5AD6");

            entity.ToTable("Car");

            entity.Property(e => e.LicensePlates)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.NameCar)
                .HasMaxLength(80)
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
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0733F76A38");

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
            entity.HasKey(e => e.Id).HasName("PK__Chair__3214EC0719866906");

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
            entity.HasKey(e => e.Id).HasName("PK__ChairCar__3214EC078468A66E");

            entity.ToTable("ChairCar");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.IdCar)
                .HasMaxLength(20)
                .IsUnicode(false);
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
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC073BE37B43");

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
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC073FF0C3D3");

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
            entity.HasKey(e => e.Id).HasName("PK__Freeway__3214EC07607D30AA");

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

            entity.HasOne(d => d.IdFromNavigation).WithMany(p => p.Freeways)
                .HasForeignKey(d => d.IdFrom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Freeway_PlaceFrom");

            entity.HasOne(d => d.IdToNavigation).WithMany(p => p.Freeways)
                .HasForeignKey(d => d.IdTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Freeway_PlaceTo");
        });

        modelBuilder.Entity<InvoiceCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceC__3214EC0735D3BD83");

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
            entity.HasKey(e => e.Id).HasName("PK__InvoiceD__3214EC07B7D82DDB");

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
            entity.HasKey(e => e.Id).HasName("PK__InvoiceS__3214EC07A56EFEE1");

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

        modelBuilder.Entity<PlaceFrom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlaceFro__3214EC073B290F06");

            entity.ToTable("PlaceFrom");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PlaceTo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlaceTo__3214EC0732F9A254");

            entity.ToTable("PlaceTo");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Shipping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipping__3214EC07D9E6DDD7");

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

        modelBuilder.Entity<TimeLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TimeLine__3214EC070B40735E");

            entity.ToTable("TimeLine");

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
            entity.HasKey(e => e.Id).HasName("PK__WorkSche__3214EC070B0838FC");

            entity.ToTable("WorkSchedule");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.IdCar)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
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

            entity.HasOne(d => d.IdTimeLineNavigation).WithMany(p => p.WorkSchedules)
                .HasForeignKey(d => d.IdTimeLine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkSchedule_TimeLine");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
