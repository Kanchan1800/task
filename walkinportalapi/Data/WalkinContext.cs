using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using walkinportalapi.Models;

namespace walkinportalapi.Data
{
    public partial class WalkinContext : DbContext
    {
        public WalkinContext()
        {
        }

        public WalkinContext(DbContextOptions<WalkinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; } = null!;
        public virtual DbSet<ApplicationMapsRole> ApplicationMapsRoles { get; set; } = null!;
        public virtual DbSet<Educationalqualification> Educationalqualifications { get; set; } = null!;
        public virtual DbSet<Expertisein> Expertiseins { get; set; } = null!;
        public virtual DbSet<Familiartech> Familiarteches { get; set; } = null!;
        public virtual DbSet<Prefferedrole> Prefferedroles { get; set; } = null!;
        public virtual DbSet<Professionalqualification> Professionalqualifications { get; set; } = null!;
        public virtual DbSet<ProfessionalqualificationHasExpertisein> ProfessionalqualificationHasExpertiseins { get; set; } = null!;
        public virtual DbSet<ProfessionalqualificationHasFamiliartech> ProfessionalqualificationHasFamiliarteches { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Temp> Temps { get; set; } = null!;
        public virtual DbSet<Timeslot> Timeslots { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Walkin> Walkins { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.WalkinId, e.UsersId, e.TimeslotsId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                entity.ToTable("application");

                entity.HasIndex(e => e.TimeslotsId, "fk_application_timeslots1_idx");

                entity.HasIndex(e => e.UsersId, "fk_application_users2_idx");

                entity.HasIndex(e => e.WalkinId, "fk_application_walkin_1_idx");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.WalkinId).HasColumnName("Walkin_Id");

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.Property(e => e.TimeslotsId).HasColumnName("Timeslots_Id");

                entity.Property(e => e.Resume).HasMaxLength(45);

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_application_users2");

                entity.HasOne(d => d.Walkin)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.WalkinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_application_walkin_1");
            });

            modelBuilder.Entity<ApplicationMapsRole>(entity =>
            {
                entity.HasKey(e => new { e.ApplicationId, e.RolesId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("application_maps_roles");

                entity.HasIndex(e => e.ApplicationId, "fk_application_has_roles_application1_idx");

                entity.HasIndex(e => e.RolesId, "fk_application_has_roles_roles1_idx");

                entity.Property(e => e.ApplicationId).HasColumnName("Application_Id");

                entity.Property(e => e.RolesId).HasColumnName("Roles_Id");
            });

            modelBuilder.Entity<Educationalqualification>(entity =>
            {
                entity.HasKey(e => new { e.EducationalQualificationsId, e.UsersId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("educationalqualifications");

                entity.HasIndex(e => e.UsersId, "fk_EducationalQualifications_Users1_idx");

                entity.Property(e => e.EducationalQualificationsId).ValueGeneratedOnAdd();

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.Property(e => e.College).HasMaxLength(45);

                entity.Property(e => e.CollegeLocation).HasMaxLength(45);

                entity.Property(e => e.PassingYear).HasMaxLength(45);

                entity.Property(e => e.Qualification).HasMaxLength(45);

                entity.Property(e => e.Stream).HasMaxLength(45);

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Educationalqualifications)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EducationalQualifications_Users1");
            });

            modelBuilder.Entity<Expertisein>(entity =>
            {
                entity.ToTable("expertisein");

                entity.Property(e => e.TechName).HasMaxLength(45);
            });

            modelBuilder.Entity<Familiartech>(entity =>
            {
                entity.ToTable("familiartech");

                entity.Property(e => e.TechName).HasMaxLength(45);
            });

            modelBuilder.Entity<Prefferedrole>(entity =>
            {
                entity.HasKey(e => e.PrefferedRolesId)
                    .HasName("PRIMARY");

                entity.ToTable("prefferedroles");

                entity.Property(e => e.RoleName).HasMaxLength(45);
            });

            modelBuilder.Entity<Professionalqualification>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UsersId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("professionalqualification");

                entity.HasIndex(e => e.UsersId, "fk_ProfessionalQualification_Users1_idx");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.Property(e => e.CurrentCtc)
                    .HasMaxLength(45)
                    .HasColumnName("Current_ctc");

                entity.Property(e => e.ExpectedCtc)
                    .HasMaxLength(45)
                    .HasColumnName("Expected_ctc");

                entity.Property(e => e.ExperienceYears).HasMaxLength(45);

                entity.Property(e => e.NoticeDuration).HasMaxLength(45);

                entity.Property(e => e.NoticePeriodEnds).HasMaxLength(45);

                entity.Property(e => e.RoleBefore).HasMaxLength(45);

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Professionalqualifications)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProfessionalQualification_Users1");
            });

            modelBuilder.Entity<ProfessionalqualificationHasExpertisein>(entity =>
            {
                entity.HasKey(e => new { e.ProfessionalQualificationId, e.ExpertiseInId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("professionalqualification_has_expertisein");

                entity.HasIndex(e => e.ExpertiseInId, "fk_ProfessionalQualification_has_ExpertiseIn_ExpertiseIn1_idx");

                entity.HasIndex(e => e.ProfessionalQualificationId, "fk_ProfessionalQualification_has_ExpertiseIn_ProfessionalQu_idx");

                entity.Property(e => e.ProfessionalQualificationId).HasColumnName("ProfessionalQualification_Id");

                entity.Property(e => e.ExpertiseInId).HasColumnName("ExpertiseIn_Id");

                entity.HasOne(d => d.ExpertiseIn)
                    .WithMany(p => p.ProfessionalqualificationHasExpertiseins)
                    .HasForeignKey(d => d.ExpertiseInId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProfessionalQualification_has_ExpertiseIn_ExpertiseIn1");
            });

            modelBuilder.Entity<ProfessionalqualificationHasFamiliartech>(entity =>
            {
                entity.HasKey(e => new { e.ProfessionalQualificationId, e.FamiliarTechId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("professionalqualification_has_familiartech");

                entity.HasIndex(e => e.FamiliarTechId, "fk_ProfessionalQualification_has_FamiliarTech_FamiliarTech1_idx");

                entity.HasIndex(e => e.ProfessionalQualificationId, "fk_ProfessionalQualification_has_FamiliarTech_ProfessionalQ_idx");

                entity.Property(e => e.ProfessionalQualificationId).HasColumnName("ProfessionalQualification_Id");

                entity.Property(e => e.FamiliarTechId).HasColumnName("FamiliarTech_Id");

                entity.HasOne(d => d.FamiliarTech)
                    .WithMany(p => p.ProfessionalqualificationHasFamiliarteches)
                    .HasForeignKey(d => d.FamiliarTechId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProfessionalQualification_has_FamiliarTech_FamiliarTech1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.WalkinId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("roles");

                entity.HasIndex(e => e.WalkinId, "fk_roles_walkin_1_idx");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.WalkinId).HasColumnName("Walkin_Id");

                entity.Property(e => e.Description).HasMaxLength(45);

                entity.Property(e => e.Package).HasMaxLength(45);

                entity.Property(e => e.ProcessDescription).HasMaxLength(45);

                entity.Property(e => e.Requirements).HasMaxLength(45);

                entity.Property(e => e.RoleTitle).HasMaxLength(45);

                entity.HasOne(d => d.Walkin)
                    .WithMany(p => p.RolesNavigation)
                    .HasForeignKey(d => d.WalkinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_roles_walkin_1");
            });

            modelBuilder.Entity<Temp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("temp");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Timeslot>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.WalkinId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("timeslots");

                entity.HasIndex(e => e.WalkinId, "fk_timeslots_walkin_1_idx");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.WalkinId).HasColumnName("Walkin_Id");

                entity.Property(e => e.SlotDetails).HasMaxLength(45);

                entity.HasOne(d => d.Walkin)
                    .WithMany(p => p.Timeslots)
                    .HasForeignKey(d => d.WalkinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_timeslots_walkin_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(45)
                    .HasColumnName("Email_id");

                entity.Property(e => e.Firstname).HasMaxLength(45);

                entity.Property(e => e.Lastname).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(45);

                entity.Property(e => e.PortfolioUrl).HasMaxLength(45);

                entity.Property(e => e.Status).HasMaxLength(45);

                entity.HasMany(d => d.PrefferedRoles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UsersHasPrefferedrole",
                        l => l.HasOne<Prefferedrole>().WithMany().HasForeignKey("PrefferedRolesId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_Users_has_PrefferedRoles_PrefferedRoles1"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UsersId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_Users_has_PrefferedRoles_Users1"),
                        j =>
                        {
                            j.HasKey("UsersId", "PrefferedRolesId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("users_has_prefferedroles");

                            j.HasIndex(new[] { "PrefferedRolesId" }, "fk_Users_has_PrefferedRoles_PrefferedRoles1_idx");

                            j.HasIndex(new[] { "UsersId" }, "fk_Users_has_PrefferedRoles_Users1_idx");

                            j.IndexerProperty<int>("UsersId").HasColumnName("Users_Id");

                            j.IndexerProperty<int>("PrefferedRolesId").HasColumnName("PrefferedRoles_Id");
                        });
            });

            modelBuilder.Entity<Walkin>(entity =>
            {
                entity.ToTable("walkin");

                entity.Property(e => e.Duration).HasMaxLength(45);

                entity.Property(e => e.ExamInstructions).HasMaxLength(45);

                entity.Property(e => e.ExpiresIn).HasMaxLength(45);

                entity.Property(e => e.GeneralInstructions).HasMaxLength(45);

                entity.Property(e => e.InternshipDetaisl).HasMaxLength(45);

                entity.Property(e => e.Location).HasMaxLength(45);

                entity.Property(e => e.Roles).HasMaxLength(45);

                entity.Property(e => e.SystemRequirements).HasMaxLength(45);

                entity.Property(e => e.Title).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
