using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PFAS_WEB_API.Models;

public partial class SacpDbContext : DbContext
{
    public SacpDbContext()
    {
    }

    public SacpDbContext(DbContextOptions<SacpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditLogger> AuditLoggers { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<FileStatus> FileStatuses { get; set; }

    public virtual DbSet<FileStatusType> FileStatusTypes { get; set; }

    public virtual DbSet<FileType> FileTypes { get; set; }

    public virtual DbSet<PensionerType> PensionerTypes { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestStatus> RequestStatuses { get; set; }

    public virtual DbSet<RequestType> RequestTypes { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CE92CDI\\SQLEXPRESS;Database=SACP_DB; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditLogger>(entity =>
        {
            entity.HasKey(e => e.AuditId);

            entity.ToTable("AuditLogger");

            entity.Property(e => e.AuditId)
                .ValueGeneratedNever()
                .HasColumnName("AuditID");
            entity.Property(e => e.Action).IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");

            entity.HasOne(d => d.Staff).WithMany(p => p.AuditLoggers)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditLogger_Staff");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.Property(e => e.BankId)
                .ValueGeneratedNever()
                .HasColumnName("BankID");
            entity.Property(e => e.BankCode)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.BankName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.DepartmentId)
                .ValueGeneratedNever()
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.Property(e => e.FileId)
                .ValueGeneratedNever()
                .HasColumnName("FileID");
            entity.Property(e => e.BankId).HasColumnName("BankID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeletedOn).HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.FileCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FileName).IsUnicode(false);
            entity.Property(e => e.FileTypeId).HasColumnName("FileTypeID");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PensionTypeId).HasColumnName("PensionTypeID");

            entity.HasOne(d => d.Bank).WithMany(p => p.Files)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Files_Banks");

            entity.HasOne(d => d.Department).WithMany(p => p.Files)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Files_Departments");

            entity.HasOne(d => d.FileType).WithMany(p => p.Files)
                .HasForeignKey(d => d.FileTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Files_FileTypes");

            entity.HasOne(d => d.PensionType).WithMany(p => p.Files)
                .HasForeignKey(d => d.PensionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Files_PensionerTypes");
        });

        modelBuilder.Entity<FileStatus>(entity =>
        {
            entity.Property(e => e.FileStatusId)
                .ValueGeneratedNever()
                .HasColumnName("FileStatusID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.FileStatusTypeId).HasColumnName("FileStatusTypeID");

            entity.HasOne(d => d.File).WithMany(p => p.FileStatuses)
                .HasForeignKey(d => d.FileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FileStatuses_Files");

            entity.HasOne(d => d.FileStatusType).WithMany(p => p.FileStatuses)
                .HasForeignKey(d => d.FileStatusTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FileStatuses_FileStatusTypes");
        });

        modelBuilder.Entity<FileStatusType>(entity =>
        {
            entity.Property(e => e.FileStatusTypeId)
                .ValueGeneratedNever()
                .HasColumnName("FileStatusTypeID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.FileStatusType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FileStatusType");
        });

        modelBuilder.Entity<FileType>(entity =>
        {
            entity.Property(e => e.FileTypeId)
                .ValueGeneratedNever()
                .HasColumnName("FileTypeID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.FileType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FileType");
        });

        modelBuilder.Entity<PensionerType>(entity =>
        {
            entity.Property(e => e.PensionerTypeId)
                .ValueGeneratedNever()
                .HasColumnName("PensionerTypeID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.PensionerType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PensionerType");

            entity.HasOne(d => d.Department).WithMany(p => p.PensionerTypes)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PensionerTypes_Departments");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("RequestID");
            entity.Property(e => e.DateRequested).HasColumnType("datetime");
            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.RequestStatusId).HasColumnName("RequestStatusID");
            entity.Property(e => e.RequestTypeId).HasColumnName("RequestTypeID");

            entity.HasOne(d => d.File).WithMany(p => p.Requests)
                .HasForeignKey(d => d.FileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Requests_Files");

            entity.HasOne(d => d.RequestStatus).WithMany(p => p.Requests)
                .HasForeignKey(d => d.RequestStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Requests_RequestStatus");

            entity.HasOne(d => d.RequestType).WithMany(p => p.Requests)
                .HasForeignKey(d => d.RequestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Requests_RequestTypes");
        });

        modelBuilder.Entity<RequestStatus>(entity =>
        {
            entity.ToTable("RequestStatus");

            entity.Property(e => e.RequestStatusId)
                .ValueGeneratedNever()
                .HasColumnName("RequestStatusID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.RequestStatus1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RequestStatus");
        });

        modelBuilder.Entity<RequestType>(entity =>
        {
            entity.Property(e => e.RequestTypeId)
                .ValueGeneratedNever()
                .HasColumnName("RequestTypeID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Request)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("StaffID");
            entity.Property(e => e.PasswordHash).IsUnicode(false);
            entity.Property(e => e.StaffEmail).IsUnicode(false);
            entity.Property(e => e.StaffName).IsUnicode(false);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");

            entity.HasOne(d => d.Unit).WithMany(p => p.Staff)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK_Staff_Units");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.Property(e => e.UnitId)
                .ValueGeneratedNever()
                .HasColumnName("UnitID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.UnitDescription).IsUnicode(false);
            entity.Property(e => e.UnitName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Units)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Units_Departments");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
