using System;
using System.Collections.Generic;
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
        public virtual DbSet<Agetype> Agetypes { get; set; } = null!;
        public virtual DbSet<Amenity> Amenities { get; set; } = null!;
        public virtual DbSet<Bedtype> Bedtypes { get; set; } = null!;
        public virtual DbSet<Bloodgroup> Bloodgroups { get; set; } = null!;
        public virtual DbSet<Cityarea> Cityareas { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Designation> Designations { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Locationtype> Locationtypes { get; set; } = null!;
        public virtual DbSet<Maritalstatus> Maritalstatuses { get; set; } = null!;
        public virtual DbSet<Nationality> Nationalities { get; set; } = null!;
        public virtual DbSet<Religion> Religions { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=103.168.19.36;database=HMS_Masters_Dev;uid=gvrhms;pwd=ByCYRq3aSPZGGHW6", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Addresstype>(entity =>
            {
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

            modelBuilder.Entity<Agetype>(entity =>
            {
                entity.ToTable("agetypes");

                entity.HasComment("This table is used for the type of age like years , months and days")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.AgeTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("AgeTypeID");

                entity.Property(e => e.Agetypename)
                    .HasMaxLength(100)
                    .HasColumnName("AGETYPENAME");

                entity.Property(e => e.Blocked)
                    .HasColumnType("int(11)")
                    .HasColumnName("BLOCKED");

                entity.Property(e => e.Comments).HasMaxLength(100);

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATEDATE");

                entity.Property(e => e.Dspk)
                    .HasColumnType("int(11)")
                    .HasColumnName("DSPK");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.Moddate).HasColumnType("datetime");

                entity.Property(e => e.Routid)
                    .HasColumnType("int(11)")
                    .HasColumnName("routid")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Rowseq)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
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

            modelBuilder.Entity<Amenity>(entity =>
            {
                entity.HasKey(e => e.AmenitieId)
                    .HasName("PRIMARY");

                entity.ToTable("amenities");

                entity.HasComment("This is used to determine the type of aminities")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Amenitie, "UQ_Amenities_Amenitie$")
                    .IsUnique();

                entity.HasIndex(e => e.Code, "UQ_Amenities_Code")
                    .IsUnique();

                entity.Property(e => e.AmenitieId)
                    .HasColumnType("int(11)")
                    .HasColumnName("AmenitieID");

                entity.Property(e => e.Amenitie).HasMaxLength(100);

                entity.Property(e => e.Amenitie2L).HasMaxLength(400);

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

                entity.Property(e => e.Moddate)
                    .HasColumnType("datetime")
                    .HasColumnName("moddate");

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

            modelBuilder.Entity<Bedtype>(entity =>
            {
                entity.HasKey(e => new { e.BedTypeId, e.BedType1, e.PatientType, e.ServiceId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                entity.ToTable("bedtypes");

                entity.HasComment("This is used to specify the types of beds")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.ServiceId, "FK_BedTypes$ServiceID$_Services$ServiceID$");

                entity.HasIndex(e => e.BedTypeId, "UQ_BedTypes_$BedTypeID$")
                    .IsUnique();

                entity.HasIndex(e => e.BedType1, "UQ_BedTypes_BedType")
                    .IsUnique();

                entity.HasIndex(e => e.Code, "UQ_BedTypes_Code")
                    .IsUnique();

                entity.Property(e => e.BedTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("BedTypeID");

                entity.Property(e => e.BedType1)
                    .HasMaxLength(100)
                    .HasColumnName("BedType");

                entity.Property(e => e.PatientType).HasColumnType("int(11)");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ServiceID");

                entity.Property(e => e.AdvanceDeposit).HasPrecision(20, 5);

                entity.Property(e => e.BedType2l).HasMaxLength(100);

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

                entity.Property(e => e.Moddate).HasColumnType("datetime");

                entity.Property(e => e.Routid)
                    .HasColumnType("int(11)")
                    .HasColumnName("routid")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Rowseq)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("rowseq")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ShortName).HasMaxLength(30);

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("int(11)")
                    .HasColumnName("USERID");

                entity.Property(e => e.Workstationid)
                    .HasMaxLength(100)
                    .HasColumnName("workstationid");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Bedtypes)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BedTypes$ServiceID$_Services$ServiceID$");
            });

            modelBuilder.Entity<Bloodgroup>(entity =>
            {
                entity.ToTable("bloodgroups");

                entity.HasComment("This table contains the blood groups details")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Bloodgroup1, "UQ_BloodGroups_BloodGroup$")
                    .IsUnique();

                entity.Property(e => e.BloodGroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("BloodGroupID");

                entity.Property(e => e.Blocked)
                    .HasColumnType("int(11)")
                    .HasColumnName("BLOCKED");

                entity.Property(e => e.BloodGroup2L).HasMaxLength(400);

                entity.Property(e => e.Bloodgroup1)
                    .HasMaxLength(30)
                    .HasColumnName("bloodgroup");

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

            modelBuilder.Entity<Cityarea>(entity =>
            {
                entity.ToTable("cityarea");

                entity.HasComment("This table is used to specify the city")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.CityAreaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CityAreaID");

                entity.Property(e => e.Area).HasMaxLength(50);

                entity.Property(e => e.Area2L).HasMaxLength(100);

                entity.Property(e => e.Blocked)
                    .HasColumnType("int(11)")
                    .HasColumnName("BLOCKED");

                entity.Property(e => e.CityId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CityID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("CODE");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATEDATE");

                entity.Property(e => e.Dspk)
                    .HasColumnType("int(11)")
                    .HasColumnName("DSPK");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

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

                entity.Property(e => e.ZoneId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ZoneID");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.HasComment("This table is used to store the countires names")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Country1, "UQ_Countries_Country$")
                    .IsUnique();

                entity.Property(e => e.CountryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CountryID");

                entity.Property(e => e.Blocked)
                    .HasColumnType("int(11)")
                    .HasColumnName("BLOCKED");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("CODE");

                entity.Property(e => e.Country1)
                    .HasMaxLength(50)
                    .HasColumnName("Country");

                entity.Property(e => e.Country2L).HasMaxLength(400);

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Dspk)
                    .HasColumnType("int(11)")
                    .HasColumnName("DSPK");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.Moddate)
                    .HasColumnType("datetime")
                    .HasColumnName("MODDATE");

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

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.HospDeptId)
                    .HasName("PRIMARY");

                entity.ToTable("departments");

                entity.HasComment("This table contains the departments avaiable in each hospital")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.HospitalId, "FK_Departments$HospitalID$_Hospitals$HospitalID$");

                entity.HasIndex(e => new { e.HospitalId, e.DepartmentId, e.Name, e.Type, e.Blocked }, "UQ_Dep$HospId_DepId_Name_Type_Blocked$")
                    .IsUnique();

                entity.HasIndex(e => new { e.DepartmentId, e.HospDeptId }, "UQ_Departments_$DepartmentID$HospDeptId$")
                    .IsUnique();

                entity.HasIndex(e => new { e.HospDeptId, e.HospitalId }, "UQ_Departments_$HospDeptId$HospitalID$")
                    .IsUnique();

                entity.Property(e => e.HospDeptId).HasColumnType("int(11)");

                entity.Property(e => e.Blocked)
                    .HasColumnType("int(11)")
                    .HasColumnName("BLOCKED");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasColumnName("CODE");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.DepartmentId).HasColumnType("int(11)");

                entity.Property(e => e.Dspk)
                    .HasColumnType("int(11)")
                    .HasColumnName("DSPK");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.HospitalId)
                    .HasColumnType("int(11)")
                    .HasColumnName("HospitalID");

                entity.Property(e => e.IsStore).HasColumnType("int(11)");

                entity.Property(e => e.Moddate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Name2l).HasMaxLength(400);

                entity.Property(e => e.ParentDeptId).HasColumnType("int(11)");

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

                entity.Property(e => e.Type).HasMaxLength(2);

                entity.Property(e => e.Userid)
                    .HasColumnType("int(11)")
                    .HasColumnName("USERID");

                entity.Property(e => e.Workstationid)
                    .HasMaxLength(100)
                    .HasColumnName("workstationid");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("designations");

                entity.HasComment("This table is used to store the designation of the employees")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Code, "UQ_Designations_Code")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "UQ_Designations_Name$")
                    .IsUnique();

                entity.Property(e => e.DesignationId).HasColumnType("int(11)");

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
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Name).HasMaxLength(50);

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

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("genders");

                entity.HasComment("Genders master table")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Gender1, "UQ_Genders_Gender$")
                    .IsUnique();

                entity.Property(e => e.GenderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("GenderID");

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
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Gender1)
                    .HasMaxLength(30)
                    .HasColumnName("Gender");

                entity.Property(e => e.Gender2L).HasMaxLength(400);

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

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("languages");

                entity.HasComment("Languages master table")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Code, "UQ_Languages_Code")
                    .IsUnique();

                entity.HasIndex(e => e.Language1, "UQ_Languages_Language$")
                    .IsUnique();

                entity.Property(e => e.LanguageId).HasColumnType("int(11)");

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
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Language1)
                    .HasMaxLength(50)
                    .HasColumnName("Language");

                entity.Property(e => e.Language2L).HasMaxLength(400);

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

            modelBuilder.Entity<Locationtype>(entity =>
            {
                entity.ToTable("locationtypes");

                entity.HasComment("Location type details will be avaliable")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.LocationtypeId)
                    .HasColumnType("tinyint(4)")
                    .ValueGeneratedNever()
                    .HasColumnName("locationtypeID");

                entity.Property(e => e.Blocked).HasColumnType("tinyint(4)");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Createdate).HasColumnType("datetime");

                entity.Property(e => e.Dspk)
                    .HasColumnType("int(11)")
                    .HasColumnName("DSPK");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Modifydate).HasColumnType("datetime");

                entity.Property(e => e.Rowseq)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("rowseq")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Workstationid)
                    .HasMaxLength(100)
                    .HasColumnName("workstationid");
            });

            modelBuilder.Entity<Maritalstatus>(entity =>
            {
                entity.ToTable("maritalstatus");

                entity.HasComment("Marital status master table")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.MarStatus, "UQ_MaritalStatus_MarStatus$")
                    .IsUnique();

                entity.Property(e => e.MaritalStatusId)
                    .HasColumnType("int(11)")
                    .HasColumnName("MaritalStatusID");

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
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.MarStatus).HasMaxLength(30);

                entity.Property(e => e.MarStatus2L).HasMaxLength(400);

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

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("nationalities");

                entity.HasComment(" nationalities master table                                           ")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Code, "UQ_Nationalities_Code")
                    .IsUnique();

                entity.HasIndex(e => e.Nationality1, "UQ_Nationalities_Nationality$")
                    .IsUnique();

                entity.Property(e => e.NationalityId)
                    .HasColumnType("int(11)")
                    .HasColumnName("NationalityID");

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
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Nationality1)
                    .HasMaxLength(50)
                    .HasColumnName("Nationality");

                entity.Property(e => e.Nationality2L).HasMaxLength(400);

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

            modelBuilder.Entity<Religion>(entity =>
            {
                entity.ToTable("religions");

                entity.HasComment("Master table for religion")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Code, "UQ_Religions_Code")
                    .IsUnique();

                entity.HasIndex(e => e.Religion1, "UQ_Religions_Religion$")
                    .IsUnique();

                entity.Property(e => e.ReligionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ReligionID");

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
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Moddate).HasColumnType("datetime");

                entity.Property(e => e.Religion1)
                    .HasMaxLength(50)
                    .HasColumnName("Religion");

                entity.Property(e => e.Religion2L).HasMaxLength(400);

                entity.Property(e => e.ReligionGroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ReligionGroupID");

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

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.HasComment("No Info")
                    .HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => new { e.ParentServiceId, e.ServiceTypeId }, "FKServicesParentServiceIDServiceTypeIDServicesServiceIDServiceTy");

                entity.HasIndex(e => new { e.ServiceTypeId, e.IsSingleSpeciality, e.IssingleDomain }, "FKServicesServiceTypeIDIsSingleSpecialityISSingleDomainServiceTy");

                entity.HasIndex(e => new { e.ServiceId, e.ServiceTypeId }, "UQ_SERVICES_$SERVICEID$_$SERVICETYPEID$")
                    .IsUnique();

                entity.HasIndex(e => e.DisplayName, "UQ_Services_$DisplayName$")
                    .IsUnique();

                entity.HasIndex(e => e.ServiceName, "UQ_Services_$ServiceName$")
                    .IsUnique();

                entity.Property(e => e.ServiceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ServiceID");

                entity.Property(e => e.BillType)
                    .HasMaxLength(4)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Blocked)
                    .HasColumnType("int(11)")
                    .HasColumnName("BLOCKED");

                entity.Property(e => e.CalSequence).HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("CODE");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.DependOnBed).HasDefaultValueSql("'0'");

                entity.Property(e => e.DependOnboth).HasDefaultValueSql("'0'");

                entity.Property(e => e.DisplayName).HasMaxLength(50);

                entity.Property(e => e.DisplayName2l).HasMaxLength(100);

                entity.Property(e => e.DoctorPayout).HasMaxLength(4);

                entity.Property(e => e.DoctorPayoutHope).HasMaxLength(4);

                entity.Property(e => e.DomConfigurationKey)
                    .HasMaxLength(50)
                    .HasColumnName("Dom_ConfigurationKey");

                entity.Property(e => e.Dspk)
                    .HasColumnType("int(11)")
                    .HasColumnName("DSPK");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.HispriceType)
                    .HasMaxLength(2)
                    .HasColumnName("HISPriceType")
                    .IsFixedLength();

                entity.Property(e => e.IsParent).HasColumnType("int(11)");

                entity.Property(e => e.IsSchedulable).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsSingleSpeciality).HasColumnType("int(11)");

                entity.Property(e => e.IsVisible).HasColumnType("int(11)");

                entity.Property(e => e.IssingleDomain).HasColumnName("ISSingleDomain");

                entity.Property(e => e.ItemHop).HasMaxLength(4);

                entity.Property(e => e.Moddate).HasColumnType("datetime");

                entity.Property(e => e.Opedit)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("OPEdit");

                entity.Property(e => e.OrdCancelStatus)
                    .HasMaxLength(100)
                    .HasColumnName("Ord_CancelStatus");

                entity.Property(e => e.OrdConfigurationKey)
                    .HasMaxLength(50)
                    .HasColumnName("Ord_ConfigurationKey");

                entity.Property(e => e.ParentServiceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ParentServiceID");

                entity.Property(e => e.PatientType).HasColumnType("int(11)");

                entity.Property(e => e.PrintSequence).HasColumnType("int(11)");

                entity.Property(e => e.Routid)
                    .HasColumnType("int(11)")
                    .HasColumnName("routid")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Rowseq)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("rowseq")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ServiceGroupName).HasMaxLength(100);

                entity.Property(e => e.ServiceName).HasMaxLength(50);

                entity.Property(e => e.ServiceName2L).HasMaxLength(400);

                entity.Property(e => e.ServiceTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ServiceTypeID");

                entity.Property(e => e.SpcConfigurationKey)
                    .HasMaxLength(50)
                    .HasColumnName("Spc_ConfigurationKey");

                entity.Property(e => e.SpecProfDependent)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("int(11)")
                    .HasColumnName("USERID");

                entity.Property(e => e.Workstationid)
                    .HasMaxLength(100)
                    .HasColumnName("workstationid");

                entity.HasOne(d => d.ServiceNavigation)
                    .WithMany(p => p.InverseServiceNavigation)
                    .HasPrincipalKey(p => new { p.ServiceId, p.ServiceTypeId })
                    .HasForeignKey(d => new { d.ParentServiceId, d.ServiceTypeId })
                    .HasConstraintName("FKServicesParentServiceIDServiceTypeIDServicesServiceIDServiceTy");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
