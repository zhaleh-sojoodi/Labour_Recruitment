﻿using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace roleDemo.Models.LabourerRecruitment
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Availability> Availability { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientQualityRating> ClientQualityRating { get; set; }
        public virtual DbSet<Incident> Incident { get; set; }
        public virtual DbSet<IncidentType> IncidentType { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobSkill> JobSkill { get; set; }
        public virtual DbSet<Labourer> Labourer { get; set; }
        public virtual DbSet<LabourerDailyQualityRating> LabourerDailyQualityRating { get; set; }
        public virtual DbSet<LabourerSafetyRating> LabourerSafetyRating { get; set; }
        public virtual DbSet<LabourerSkill> LabourerSkill { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SystemUser> SystemUser { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Availability>(entity =>
            {
                entity.Property(e => e.AvailabilityId).HasColumnName("availability_id");

                entity.Property(e => e.AvailabilityTime)
                    .HasColumnName("availability_time")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LabourerId).HasColumnName("labourer_id");

                entity.HasOne(d => d.Labourer)
                    .WithMany(p => p.Availability)
                    .HasForeignKey(d => d.LabourerId)
                    .HasConstraintName("FK__Availabil__labou__2C3393D0");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientCity)
                    .HasColumnName("client_city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClientEmail)
                    .HasColumnName("client_email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .HasColumnName("client_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientPhoneNumber)
                    .HasColumnName("client_phone_number")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ClientState)
                    .HasColumnName("client_state")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Client__user_id__267ABA7A");
            });

            modelBuilder.Entity<ClientQualityRating>(entity =>
            {
                entity.HasKey(e => e.QualityRating)
                    .HasName("PK__ClientQu__5440651358CA4B58");

                entity.Property(e => e.QualityRating).HasColumnName("quality_rating");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientQualityRating)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__ClientQua__clien__34C8D9D1");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.ClientQualityRating)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__ClientQua__job_i__33D4B598");
            });

            modelBuilder.Entity<Incident>(entity =>
            {
                entity.Property(e => e.IncidentId).HasColumnName("incident_id");

                entity.Property(e => e.IncidentDate)
                    .HasColumnName("incident_date")
                    .HasColumnType("date");

                entity.Property(e => e.IncidentDescription)
                    .HasColumnName("incident_description")
                    .HasColumnType("text");

                entity.Property(e => e.IncidentFile)
                    .HasColumnName("incident_file")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IncidentTypeId).HasColumnName("incident_type_id");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.LabourerId).HasColumnName("labourer_id");

                entity.HasOne(d => d.IncidentType)
                    .WithMany(p => p.Incident)
                    .HasForeignKey(d => d.IncidentTypeId)
                    .HasConstraintName("FK__Incident__incide__4316F928");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Incident)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__Incident__job_id__412EB0B6");

                entity.HasOne(d => d.Labourer)
                    .WithMany(p => p.Incident)
                    .HasForeignKey(d => d.LabourerId)
                    .HasConstraintName("FK__Incident__labour__4222D4EF");
            });

            modelBuilder.Entity<IncidentType>(entity =>
            {
                entity.Property(e => e.IncidentTypeId).HasColumnName("incident_type_id");

                entity.Property(e => e.IncidentTypeName)
                    .HasColumnName("incident_type_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.InProgress).HasColumnName("inProgress");

                entity.Property(e => e.IsComplete).HasColumnName("isComplete");

                entity.Property(e => e.JobDescription)
                    .HasColumnName("job_description")
                    .HasColumnType("text");

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Job__client_id__2F10007B");
            });

            modelBuilder.Entity<JobSkill>(entity =>
            {
                entity.Property(e => e.JobSkillId).HasColumnName("job_skill_id");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.NumberNeeded).HasColumnName("number_needed");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobSkill)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__JobSkill__job_id__45F365D3");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.JobSkill)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK__JobSkill__skill___46E78A0C");
            });

            modelBuilder.Entity<Labourer>(entity =>
            {
                entity.Property(e => e.LabourerId).HasColumnName("labourer_id");

                entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");

                entity.Property(e => e.LabourerEmail)
                    .HasColumnName("labourer_email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LabourerFirstName)
                    .HasColumnName("labourer_first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LabourerLastName)
                    .HasColumnName("labourer_last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LabourerSin).HasColumnName("labourer_SIN");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Labourer)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Labourer__user_i__29572725");
            });

            modelBuilder.Entity<LabourerDailyQualityRating>(entity =>
            {
                entity.HasKey(e => e.DailyQualityRating)
                    .HasName("PK__Labourer__61640B197493ADBC");

                entity.Property(e => e.DailyQualityRating).HasColumnName("daily_quality_rating");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.LabourerId).HasColumnName("labourer_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RatingDate)
                    .HasColumnName("rating_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.LabourerDailyQualityRating)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__LabourerD__job_i__3B75D760");

                entity.HasOne(d => d.Labourer)
                    .WithMany(p => p.LabourerDailyQualityRating)
                    .HasForeignKey(d => d.LabourerId)
                    .HasConstraintName("FK__LabourerD__labou__3C69FB99");
            });

            modelBuilder.Entity<LabourerSafetyRating>(entity =>
            {
                entity.HasKey(e => e.SafetyRating)
                    .HasName("PK__Labourer__0A004E492D01DB68");

                entity.Property(e => e.SafetyRating).HasColumnName("safety_rating");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.LabourerId).HasColumnName("labourer_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.LabourerSafetyRating)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__LabourerS__job_i__37A5467C");

                entity.HasOne(d => d.Labourer)
                    .WithMany(p => p.LabourerSafetyRating)
                    .HasForeignKey(d => d.LabourerId)
                    .HasConstraintName("FK__LabourerS__labou__38996AB5");
            });

            modelBuilder.Entity<LabourerSkill>(entity =>
            {
                entity.Property(e => e.LabourerSkillId).HasColumnName("labourer_skill_id");

                entity.Property(e => e.LabourerId).HasColumnName("labourer_id");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.HasOne(d => d.Labourer)
                    .WithMany(p => p.LabourerSkill)
                    .HasForeignKey(d => d.LabourerId)
                    .HasConstraintName("FK__LabourerS__labou__49C3F6B7");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.LabourerSkill)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK__LabourerS__skill__4AB81AF0");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.PayRate)
                    .HasColumnName("pay_rate")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SkillName)
                    .HasColumnName("skill_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__SystemUs__B9BE370F34B081F3");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });
        }
    }
}
