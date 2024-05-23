using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DizonCoop.Entities;

public partial class DizonCoopContext : DbContext
{
    public DizonCoopContext()
    {
    }

    public DizonCoopContext(DbContextOptions<DizonCoopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientInfo> ClientInfos { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=DizonCoop;TrustServerCertificate=true;Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClientIn__3214EC072FB5BC9A");

            entity.ToTable("ClientInfo");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.CivilStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NameOfFather)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NameOfMother)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Occupation)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Relgion)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__loan__3213E83F528C9E43");

            entity.ToTable("loan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateCreated)
                .HasColumnType("date")
                .HasColumnName("date_created");
            entity.Property(e => e.Deduction).HasColumnName("deduction");
            entity.Property(e => e.DueDate)
                .HasColumnType("date")
                .HasColumnName("due_date");
            entity.Property(e => e.Interest).HasColumnName("interest");
            entity.Property(e => e.NoPayment).HasColumnName("no_payment");
            entity.Property(e => e.Penalty).HasColumnName("penalty");
            entity.Property(e => e.RecievableAmount).HasColumnName("recievable_amount");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserType__3213E83FE597DAB5");

            entity.ToTable("UserType");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
