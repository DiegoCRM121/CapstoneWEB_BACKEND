using System;
using System.Collections.Generic;
using CapstoneWEB.CORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace CapstoneWEB.INFRASTRUCTURE.Data;

public partial class CapstoneWebBdContext : DbContext
{
    public CapstoneWebBdContext()
    {
    }

    public CapstoneWebBdContext(DbContextOptions<CapstoneWebBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmotionDetail> EmotionDetail { get; set; }

    public virtual DbSet<CORE.Entities.File> File { get; set; }

    public virtual DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmotionDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Detail)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("detail");
            entity.Property(e => e.IdFile).HasColumnName("idFile");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdFileNavigation).WithMany()
                .HasForeignKey(d => d.IdFile)
                .HasConstraintName("FK__EmotionDe__idFil__286302EC");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__EmotionDe__idUse__276EDEB3");
        });

        modelBuilder.Entity<CORE.Entities.File>(entity =>
        {
            entity.HasKey(e => e.IdFile).HasName("PK__File__775AFE721EE690C4");

            entity.Property(e => e.IdFile).HasColumnName("idFile");
            entity.Property(e => e.FileName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("fileName");
            entity.Property(e => e.FileType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fileType");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__3717C982C3ABB804");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birthDate");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.SecondName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("secondName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
