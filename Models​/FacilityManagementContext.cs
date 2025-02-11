﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FacilityManagement.Models​;

public partial class FacilityManagementContext : DbContext
{
    public FacilityManagementContext()
    {
    }

    public FacilityManagementContext(DbContextOptions<FacilityManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Campus> Campuses { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Usage> Usages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DAMQUOCDAN;Database=FacilityManagement;uid=sa;pwd=1234;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4E8E6F894A9");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Username, "UQ__Admin__536C85E4B146017F").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Admin__A9D10534C72F4071").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AdminName).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDE4F615AED1");

            entity.ToTable("Building");

            entity.Property(e => e.BuildingId).HasColumnName("BuildingID");
            entity.Property(e => e.BuildingName).HasMaxLength(255);
            entity.Property(e => e.CampusId).HasColumnName("CampusID");

            entity.HasOne(d => d.Campus).WithMany(p => p.Buildings)
                .HasForeignKey(d => d.CampusId)
                .HasConstraintName("FK__Building__Campus__398D8EEE");
        });

        modelBuilder.Entity<Campus>(entity =>
        {
            entity.HasKey(e => e.CampusId).HasName("PK__Campus__FD598D364A88DDAE");

            entity.ToTable("Campus");

            entity.Property(e => e.CampusId).HasColumnName("CampusID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CampusName).HasMaxLength(255);
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId).HasName("PK__Equipmen__34474599724B8E75");

            entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");
            entity.Property(e => e.EquipmentName).HasMaxLength(255);
            entity.Property(e => e.EquipmentType).HasMaxLength(100);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Có s?n");

            entity.HasOne(d => d.Room).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Equipment__RoomI__3F466844");
        });

        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.HasKey(e => e.MaintenanceId).HasName("PK__Maintena__E60542B5FA4BC11C");

            entity.ToTable("Maintenance");

            entity.Property(e => e.MaintenanceId).HasColumnName("MaintenanceID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Chua gi?i quy?t");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("FK__Maintenan__Equip__4316F928");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__3286391959B42197");

            entity.ToTable("Room");

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.BuildingId).HasColumnName("BuildingID");
            entity.Property(e => e.RoomName).HasMaxLength(255);
            entity.Property(e => e.RoomType).HasMaxLength(100);

            entity.HasOne(d => d.Building).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK__Room__BuildingID__3C69FB99");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF7CC72145D");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.AssignedRoomId).HasColumnName("AssignedRoomID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.StaffName).HasMaxLength(255);

            entity.HasOne(d => d.AssignedRoom).WithMany(p => p.Staff)
                .HasForeignKey(d => d.AssignedRoomId)
                .HasConstraintName("FK__Staff__AssignedR__46E78A0C");
        });

        modelBuilder.Entity<Usage>(entity =>
        {
            entity.HasKey(e => e.UsageId).HasName("PK__Usage__29B197C09C9CE1AA");

            entity.ToTable("Usage");

            entity.Property(e => e.UsageId).HasColumnName("UsageID");
            entity.Property(e => e.Purpose).HasMaxLength(255);
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.UsedBy).HasMaxLength(255);

            entity.HasOne(d => d.Room).WithMany(p => p.Usages)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Usage__RoomID__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
