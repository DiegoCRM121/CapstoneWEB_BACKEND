﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CapstoneWEB.CORE.Entities;

namespace CapstoneWEB.INFRASTRUCTURE.Data;

public partial class CapstoneDbContext : DbContext
{
    public CapstoneDbContext()
    {
    }

    public CapstoneDbContext(DbContextOptions<CapstoneDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmotionDetail> EmotionDetail { get; set; }

    public virtual DbSet<File> File { get; set; }

    public virtual DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CU4P7U7\\SQLEXPRESS;Database=CapstoneDB;User=sa;Pwd=#klOF20-%=1_ZzXpoqT80/7/?;TrustServerCertificate=True");

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
                .HasConstraintName("FK__EmotionDe__idFil__3B75D760");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__EmotionDe__idUse__3A81B327");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.IdFile).HasName("PK__File__775AFE72504C8520");

            entity.Property(e => e.IdFile)
                .ValueGeneratedNever()
                .HasColumnName("idFile");
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
            entity.HasKey(e => e.IdUser).HasName("PK__User__3717C982672263D8");

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("idUser");
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
