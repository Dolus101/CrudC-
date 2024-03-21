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
