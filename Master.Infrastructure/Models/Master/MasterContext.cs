using System;
using System.Collections.Generic;
using Master.Infrastructure.Models.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Master.Infrastructure.Models.Master
{
    public partial class MasterContext : DbContext
    {
        public MasterContext()
        {
        }

        public MasterContext(DbContextOptions<MasterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresstype> Addresstypes { get; set; } = null!;
        public virtual DbSet<Admissiontype> Admissiontypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               optionsBuilder.UseMySql("server=;database=HMS_Masters_Dev;uid=gvrhms;pwd=", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Addresstype>(entity =>
            {
                entity.HasKey(e => e.AddressTypeId);

                entity.ToTable("addresstypes");

                entity.HasComment("This is used to deteremine the type of address ")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.AddressTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("AddressTypeID");

                entity.Property(e => e.AddressType1)
                    .HasMaxLength(50)
                    .HasColumnName("AddressType");

                entity.Property(e => e.Createdate).HasColumnType("datetime");

                entity.Property(e => e.Dspk)
                    .HasColumnType("int(11)")
                    .HasColumnName("DSPK");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.Moddate).HasColumnType("datetime");

                entity.Property(e => e.Rowseq)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("rowseq")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("USerId");

                entity.Property(e => e.Workstationid)
                    .HasMaxLength(100)
                    .HasColumnName("workstationid");
            });

            modelBuilder.Entity<Admissiontype>(entity =>
            {
                entity.HasKey(e=>e.Id);
                entity.ToTable("admissiontype");

                entity.HasComment("This table is used to fetch the type of admission")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Code, "UQ_ADMISSIONTYPE_Code")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "UQ_AdmissionType_Name$")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Blocked)
                    .HasColumnType("int(11)")
                    .HasColumnName("BLOCKED");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("CODE");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Dspk)
                    .HasColumnType("int(11)")
                    .HasColumnName("DSPK");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.FacilityId)
                    .HasColumnType("int(11)")
                    .HasColumnName("FacilityID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Name2l).HasMaxLength(400);

                entity.Property(e => e.Routid)
                    .HasColumnType("int(11)")
                    .HasColumnName("routid")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Rowseq)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("rowseq")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("int(11)")
                    .HasColumnName("USERID");

                entity.Property(e => e.Workstationid)
                    .HasMaxLength(100)
                    .HasColumnName("workstationid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
