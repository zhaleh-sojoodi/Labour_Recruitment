﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using roleDemo.Models.LabourerRecruitment;

namespace roleDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200417091505_IntialCreate")]
    partial class IntialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.Availability", b =>
                {
                    b.Property<int>("AvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("availability_id");

                    b.Property<string>("AvailabilityTime")
                        .HasColumnName("availability_time")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int?>("LabourerId")
                        .HasColumnName("labourer_id");

                    b.HasKey("AvailabilityId");

                    b.HasIndex("LabourerId");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("client_id");

                    b.Property<string>("ClientCity")
                        .HasColumnName("client_city")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("ClientEmail")
                        .HasColumnName("client_email")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("ClientName")
                        .HasColumnName("client_name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ClientPhoneNumber")
                        .HasColumnName("client_phone_number")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("ClientState")
                        .HasColumnName("client_state")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<int?>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("ClientId");

                    b.HasIndex("UserId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.ClientQualityRating", b =>
                {
                    b.Property<int>("QualityRating")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("quality_rating");

                    b.Property<int?>("ClientId")
                        .HasColumnName("client_id");

                    b.Property<int?>("JobId")
                        .HasColumnName("job_id");

                    b.Property<double?>("Rating")
                        .HasColumnName("rating");

                    b.HasKey("QualityRating")
                        .HasName("PK__ClientQu__5440651358CA4B58");

                    b.HasIndex("ClientId");

                    b.HasIndex("JobId");

                    b.ToTable("ClientQualityRating");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("incident_id");

                    b.Property<DateTime?>("IncidentDate")
                        .HasColumnName("incident_date")
                        .HasColumnType("date");

                    b.Property<string>("IncidentDescription")
                        .HasColumnName("incident_description")
                        .HasColumnType("text");

                    b.Property<string>("IncidentFile")
                        .HasColumnName("incident_file")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<int?>("IncidentTypeId")
                        .HasColumnName("incident_type_id");

                    b.Property<int?>("JobId")
                        .HasColumnName("job_id");

                    b.Property<int?>("LabourerId")
                        .HasColumnName("labourer_id");

                    b.HasKey("IncidentId");

                    b.HasIndex("IncidentTypeId");

                    b.HasIndex("JobId");

                    b.HasIndex("LabourerId");

                    b.ToTable("Incident");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.IncidentType", b =>
                {
                    b.Property<int>("IncidentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("incident_type_id");

                    b.Property<string>("IncidentTypeName")
                        .HasColumnName("incident_type_name")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("IncidentTypeId");

                    b.ToTable("IncidentType");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("job_id");

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int?>("ClientId")
                        .HasColumnName("client_id");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnName("end_date")
                        .HasColumnType("date");

                    b.Property<bool?>("InProgress")
                        .HasColumnName("inProgress");

                    b.Property<bool?>("IsComplete")
                        .HasColumnName("isComplete");

                    b.Property<string>("JobDescription")
                        .HasColumnName("job_description")
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .HasColumnName("postal_code")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<DateTime?>("StartDate")
                        .HasColumnName("start_date")
                        .HasColumnType("date");

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Street")
                        .HasColumnName("street")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("JobId");

                    b.HasIndex("ClientId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.JobSkill", b =>
                {
                    b.Property<int>("JobSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("job_skill_id");

                    b.Property<int?>("JobId")
                        .HasColumnName("job_id");

                    b.Property<int?>("NumberNeeded")
                        .HasColumnName("number_needed");

                    b.Property<int?>("SkillId")
                        .HasColumnName("skill_id");

                    b.HasKey("JobSkillId");

                    b.HasIndex("JobId");

                    b.HasIndex("SkillId");

                    b.ToTable("JobSkill");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.Labourer", b =>
                {
                    b.Property<int>("LabourerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("labourer_id");

                    b.Property<bool?>("IsAvailable")
                        .HasColumnName("isAvailable");

                    b.Property<string>("LabourerEmail")
                        .HasColumnName("labourer_email")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("LabourerFirstName")
                        .HasColumnName("labourer_first_name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LabourerLastName")
                        .HasColumnName("labourer_last_name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("LabourerSin")
                        .HasColumnName("labourer_SIN");

                    b.Property<int?>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("LabourerId");

                    b.HasIndex("UserId");

                    b.ToTable("Labourer");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.LabourerDailyQualityRating", b =>
                {
                    b.Property<int>("DailyQualityRating")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("daily_quality_rating");

                    b.Property<int?>("JobId")
                        .HasColumnName("job_id");

                    b.Property<int?>("LabourerId")
                        .HasColumnName("labourer_id");

                    b.Property<double?>("Rating")
                        .HasColumnName("rating");

                    b.Property<DateTime?>("RatingDate")
                        .HasColumnName("rating_date")
                        .HasColumnType("date");

                    b.HasKey("DailyQualityRating")
                        .HasName("PK__Labourer__61640B197493ADBC");

                    b.HasIndex("JobId");

                    b.HasIndex("LabourerId");

                    b.ToTable("LabourerDailyQualityRating");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.LabourerSafetyRating", b =>
                {
                    b.Property<int>("SafetyRating")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("safety_rating");

                    b.Property<int?>("JobId")
                        .HasColumnName("job_id");

                    b.Property<int?>("LabourerId")
                        .HasColumnName("labourer_id");

                    b.Property<double?>("Rating")
                        .HasColumnName("rating");

                    b.HasKey("SafetyRating")
                        .HasName("PK__Labourer__0A004E492D01DB68");

                    b.HasIndex("JobId");

                    b.HasIndex("LabourerId");

                    b.ToTable("LabourerSafetyRating");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.LabourerSkill", b =>
                {
                    b.Property<int>("LabourerSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("labourer_skill_id");

                    b.Property<int?>("LabourerId")
                        .HasColumnName("labourer_id");

                    b.Property<int?>("SkillId")
                        .HasColumnName("skill_id");

                    b.HasKey("LabourerSkillId");

                    b.HasIndex("LabourerId");

                    b.HasIndex("SkillId");

                    b.ToTable("LabourerSkill");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("skill_id");

                    b.Property<decimal?>("PayRate")
                        .HasColumnName("pay_rate")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("SkillName")
                        .HasColumnName("skill_name")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("SkillId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.SystemUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("user_id");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Role")
                        .HasColumnName("role")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("UserId")
                        .HasName("PK__SystemUs__B9BE370F34B081F3");

                    b.ToTable("SystemUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.Availability", b =>
                {
                    b.HasOne("roleDemo.Models.LabourerRecruitment.Labourer", "Labourer")
                        .WithMany("Availability")
                        .HasForeignKey("LabourerId")
                        .HasConstraintName("FK__Availabil__labou__2C3393D0");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.Client", b =>
                {
                    b.HasOne("roleDemo.Models.LabourerRecruitment.SystemUser", "User")
                        .WithMany("Client")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Client__user_id__267ABA7A");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.ClientQualityRating", b =>
                {
                    b.HasOne("roleDemo.Models.LabourerRecruitment.Client", "Client")
                        .WithMany("ClientQualityRating")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK__ClientQua__clien__34C8D9D1");

                    b.HasOne("roleDemo.Models.LabourerRecruitment.Job", "Job")
                        .WithMany("ClientQualityRating")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK__ClientQua__job_i__33D4B598");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.Incident", b =>
                {
                    b.HasOne("roleDemo.Models.LabourerRecruitment.IncidentType", "IncidentType")
                        .WithMany("Incident")
                        .HasForeignKey("IncidentTypeId")
                        .HasConstraintName("FK__Incident__incide__4316F928");

                    b.HasOne("roleDemo.Models.LabourerRecruitment.Job", "Job")
                        .WithMany("Incident")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK__Incident__job_id__412EB0B6");

                    b.HasOne("roleDemo.Models.LabourerRecruitment.Labourer", "Labourer")
                        .WithMany("Incident")
                        .HasForeignKey("LabourerId")
                        .HasConstraintName("FK__Incident__labour__4222D4EF");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.Job", b =>
                {
                    b.HasOne("roleDemo.Models.LabourerRecruitment.Client", "Client")
                        .WithMany("Job")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK__Job__client_id__2F10007B");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.JobSkill", b =>
                {
                    b.HasOne("roleDemo.Models.LabourerRecruitment.Job", "Job")
                        .WithMany("JobSkill")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK__JobSkill__job_id__45F365D3");

                    b.HasOne("roleDemo.Models.LabourerRecruitment.Skill", "Skill")
                        .WithMany("JobSkill")
                        .HasForeignKey("SkillId")
                        .HasConstraintName("FK__JobSkill__skill___46E78A0C");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.Labourer", b =>
                {
                    b.HasOne("roleDemo.Models.LabourerRecruitment.SystemUser", "User")
                        .WithMany("Labourer")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Labourer__user_i__29572725");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.LabourerDailyQualityRating", b =>
                {
                    b.HasOne("roleDemo.Models.LabourerRecruitment.Job", "Job")
                        .WithMany("LabourerDailyQualityRating")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK__LabourerD__job_i__3B75D760");

                    b.HasOne("roleDemo.Models.LabourerRecruitment.Labourer", "Labourer")
                        .WithMany("LabourerDailyQualityRating")
                        .HasForeignKey("LabourerId")
                        .HasConstraintName("FK__LabourerD__labou__3C69FB99");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.LabourerSafetyRating", b =>
                {
                    b.HasOne("roleDemo.Models.LabourerRecruitment.Job", "Job")
                        .WithMany("LabourerSafetyRating")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK__LabourerS__job_i__37A5467C");

                    b.HasOne("roleDemo.Models.LabourerRecruitment.Labourer", "Labourer")
                        .WithMany("LabourerSafetyRating")
                        .HasForeignKey("LabourerId")
                        .HasConstraintName("FK__LabourerS__labou__38996AB5");
                });

            modelBuilder.Entity("roleDemo.Models.LabourerRecruitment.LabourerSkill", b =>
                {
                    b.HasOne("roleDemo.Models.LabourerRecruitment.Labourer", "Labourer")
                        .WithMany("LabourerSkill")
                        .HasForeignKey("LabourerId")
                        .HasConstraintName("FK__LabourerS__labou__49C3F6B7");

                    b.HasOne("roleDemo.Models.LabourerRecruitment.Skill", "Skill")
                        .WithMany("LabourerSkill")
                        .HasForeignKey("SkillId")
                        .HasConstraintName("FK__LabourerS__skill__4AB81AF0");
                });
#pragma warning restore 612, 618
        }
    }
}
