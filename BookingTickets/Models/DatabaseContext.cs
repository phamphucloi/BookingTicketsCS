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
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07D8F7BE69");

            entity.ToTable("Account");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.DoB).HasColumnType("date");
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
            entity.Property(e => e.SecurityCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.LicensePlates).HasName("PK__Car__AE763D1746DD994A");

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
                .HasConstraintName("FK_Car_Category_Car");
        });

        modelBuilder.Entity<CategoryCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC079D9254EB");

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
            entity.HasKey(e => e.Id).HasName("PK__Chair__3214EC07AEFF28A6");

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
            entity.HasKey(e => e.Id).HasName("PK__ChairCar__3214EC077C87A101");

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
                .HasConstraintName("FK_ChairCar_Car");

            entity.HasOne(d => d.IdChairNavigation).WithMany(p => p.ChairCars)
                .HasForeignKey(d => d.IdChair)
                .HasConstraintName("FK_ChairCar_Chair");

            entity.HasOne(d => d.IdTimeLineNavigation).WithMany(p => p.ChairCars)
                .HasForeignKey(d => d.IdTimeLine)
                .HasConstraintName("FK_ChairCar_TimeLine");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC07FD9B6417");

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
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC073EA5546A");

            entity.ToTable("DiscountDetail");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.DiscountDetails)
                .HasForeignKey(d => d.IdAccount)
                .HasConstraintName("FK_DiscountDetail_Account");

            entity.HasOne(d => d.IdDiscountNavigation).WithMany(p => p.DiscountDetails)
                .HasForeignKey(d => d.IdDiscount)
                .HasConstraintName("FK_DiscountDetail_Discount");
        });

        modelBuilder.Entity<Freeway>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Freeway__3214EC07245DF834");

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
                .HasConstraintName("FK_Freeway_PlaceFrom");

            entity.HasOne(d => d.IdToNavigation).WithMany(p => p.Freeways)
                .HasForeignKey(d => d.IdTo)
                .HasConstraintName("FK_Freeway_PlaceTo");
        });

        modelBuilder.Entity<InvoiceCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceC__3214EC0719CEBAFB");

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
                .HasConstraintName("FK_InvoiceCar_Account");
        });

        modelBuilder.Entity<InvoiceDetailCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceD__3214EC0726FD7FE8");

            entity.ToTable("InvoiceDetailCar");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.IdChairCarNavigation).WithMany(p => p.InvoiceDetailCars)
                .HasForeignKey(d => d.IdChairCar)
                .HasConstraintName("FK_InvoiceDetailCar_ChairCar");

            entity.HasOne(d => d.IdIvoiceCarNavigation).WithMany(p => p.InvoiceDetailCars)
                .HasForeignKey(d => d.IdIvoiceCar)
                .HasConstraintName("FK_InvoiceDetailCar_InvoiceCar");
        });

        modelBuilder.Entity<InvoiceShipping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceS__3214EC07136A6416");

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
                .HasConstraintName("FK_InvoiceShipping_Account");

            entity.HasOne(d => d.IdShippingNavigation).WithMany(p => p.InvoiceShippings)
                .HasForeignKey(d => d.IdShipping)
                .HasConstraintName("FK_InvoiceShipping_Shipping");
        });

        modelBuilder.Entity<PlaceFrom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlaceFro__3214EC0706D0FCC7");

            entity.ToTable("PlaceFrom");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PlaceTo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlaceTo__3214EC076EBB5DDD");

            entity.ToTable("PlaceTo");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Shipping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipping__3214EC07D260A5FA");

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
            entity.HasKey(e => e.Id).HasName("PK__TimeLine__3214EC07B899CDB4");

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
            entity.HasKey(e => e.Id).HasName("PK__WorkSche__3214EC07F76D7715");

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
                .HasConstraintName("FK_WorkSchedule_Account");

            entity.HasOne(d => d.IdCarNavigation).WithMany(p => p.WorkSchedules)
                .HasForeignKey(d => d.IdCar)
                .HasConstraintName("FK_WorkSchedule_Car");

            entity.HasOne(d => d.IdFreewayNavigation).WithMany(p => p.WorkSchedules)
                .HasForeignKey(d => d.IdFreeway)
                .HasConstraintName("FK_WorkSchedule_Freeway");

            entity.HasOne(d => d.IdTimeLineNavigation).WithMany(p => p.WorkSchedules)
                .HasForeignKey(d => d.IdTimeLine)
                .HasConstraintName("FK_WorkSchedule_TimeLine");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
