﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using labourRecruitment.Models.LabourRecruitment;

namespace labourRecruitment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200507044811_IntialCreate")]
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

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.Availability", b =>
                {
                    b.Property<int>("AvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("availability_id");

                    b.Property<string>("AvailabilityDay")
                        .HasColumnName("availability_day")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("AvailabilityId");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.AvailabilityLabourer", b =>
                {
                    b.Property<int>("AvailabilityLobourerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("availabilityLobourer_id");

                    b.Property<int?>("AvailabilityId")
                        .HasColumnName("availability_id");

                    b.Property<int?>("LabourerId")
                        .HasColumnName("labourer_id");

                    b.HasKey("AvailabilityLobourerId")
                        .HasName("PK__Availabi__786BC512ACB8B3CF");

                    b.HasIndex("AvailabilityId");

                    b.HasIndex("LabourerId");

                    b.ToTable("AvailabilityLabourer");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("client_id");

                    b.Property<string>("ClientCity")
                        .HasColumnName("client_city")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("ClientDescription")
                        .HasColumnName("client_description")
                        .HasMaxLength(50)
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

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.IncidentReport", b =>
                {
                    b.Property<int>("IncidentReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("incident_report_id");

                    b.Property<bool?>("AdminNotified")
                        .HasColumnName("adminNotified");

                    b.Property<DateTime?>("IncidentReportDate")
                        .HasColumnName("incident_report_date")
                        .HasColumnType("date");

                    b.Property<string>("IncidentReportDescription")
                        .HasColumnName("incident_report_description")
                        .HasColumnType("text");

                    b.Property<string>("IncidentReportFile")
                        .HasColumnName("incident_report_file")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<int?>("IncidentTypeId")
                        .HasColumnName("incident_type_id");

                    b.Property<int?>("JobId")
                        .HasColumnName("job_id");

                    b.HasKey("IncidentReportId");

                    b.HasIndex("IncidentTypeId");

                    b.HasIndex("JobId");

                    b.ToTable("IncidentReport");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.IncidentType", b =>
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

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.Job", b =>
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

                    b.Property<DateTime>("EndDate")
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

                    b.Property<bool?>("ScheduleDone")
                        .HasColumnName("schedule_done");

                    b.Property<DateTime>("StartDate")
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

                    b.Property<int?>("TotalHired")
                        .HasColumnName("total_hired");

                    b.HasKey("JobId");

                    b.HasIndex("ClientId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.JobLabourer", b =>
                {
                    b.Property<int>("JobLabourerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("job_labourer_id");

                    b.Property<double>("ClientQualityRating")
                        .HasColumnName("client_quality_rating");

                    b.Property<int>("Duration")
                        .HasColumnName("duration");

                    b.Property<DateTime>("EndDay")
                        .HasColumnName("end_day")
                        .HasColumnType("datetime");

                    b.Property<int>("JobId")
                        .HasColumnName("job_id");

                    b.Property<int>("LabourerId")
                        .HasColumnName("labourer_id");

                    b.Property<double>("LabourerSafetyRating")
                        .HasColumnName("labourer_safety_rating");

                    b.Property<bool>("SafetyMeetingCompleted")
                        .HasColumnName("safety_meeting_completed");

                    b.Property<int>("SkillId")
                        .HasColumnName("skill_id");

                    b.Property<DateTime>("StartDay")
                        .HasColumnName("start_day")
                        .HasColumnType("datetime");

                    b.HasKey("JobLabourerId");

                    b.HasIndex("JobId");

                    b.HasIndex("LabourerId");

                    b.HasIndex("SkillId");

                    b.ToTable("JobLabourer");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.JobSkill", b =>
                {
                    b.Property<int>("JobSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("job_skill_id");

                    b.Property<int>("JobId")
                        .HasColumnName("job_id");

                    b.Property<int>("NumberNeeded")
                        .HasColumnName("number_needed");

                    b.Property<int>("SkillId")
                        .HasColumnName("skill_id");

                    b.HasKey("JobSkillId");

                    b.HasIndex("JobId");

                    b.HasIndex("SkillId");

                    b.ToTable("JobSkill");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.Labourer", b =>
                {
                    b.Property<int>("LabourerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("labourer_id");

                    b.Property<bool>("IsAvailable")
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

                    b.Property<bool>("OnLeave")
                        .HasColumnName("onLeave");

                    b.Property<int?>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("LabourerId");

                    b.HasIndex("UserId");

                    b.ToTable("Labourer");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.LabourerAttendance", b =>
                {
                    b.Property<int>("LabourerAttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("labourer_attendance_id");

                    b.Property<double?>("DailyQualityRating");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<int?>("JobId")
                        .HasColumnName("job_id");

                    b.Property<int?>("LabourerId")
                        .HasColumnName("labourer_id");

                    b.HasKey("LabourerAttendanceId");

                    b.HasIndex("JobId");

                    b.HasIndex("LabourerId");

                    b.ToTable("LabourerAttendance");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.LabourerIncidentReport", b =>
                {
                    b.Property<int>("LabourerIncidentReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("labourer_incident_report_id");

                    b.Property<int?>("IncidentReportId")
                        .HasColumnName("incident_report_id");

                    b.Property<int?>("LabourerId")
                        .HasColumnName("labourer_id");

                    b.HasKey("LabourerIncidentReportId");

                    b.HasIndex("IncidentReportId");

                    b.HasIndex("LabourerId");

                    b.ToTable("LabourerIncidentReport");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.LabourerSkill", b =>
                {
                    b.Property<int>("LabourerSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("labourer_skill_id");

                    b.Property<int>("LabourerId")
                        .HasColumnName("labourer_id");

                    b.Property<int>("SkillId")
                        .HasColumnName("skill_id");

                    b.HasKey("LabourerSkillId");

                    b.HasIndex("LabourerId");

                    b.HasIndex("SkillId");

                    b.ToTable("LabourerSkill");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("skill_id");

                    b.Property<decimal?>("AdminReceives")
                        .HasColumnName("admin_receives")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("LabourerReceives")
                        .HasColumnName("labourer_receives")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("SkillName")
                        .HasColumnName("skill_name")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("SkillId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.SystemUser", b =>
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
                        .HasName("PK__SystemUs__B9BE370FF3E568C0");

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

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.AvailabilityLabourer", b =>
                {
                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Availability", "Availability")
                        .WithMany("AvailabilityLabourer")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK__Availabil__avail__2F10007B");

                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Labourer", "Labourer")
                        .WithMany("AvailabilityLabourer")
                        .HasForeignKey("LabourerId")
                        .HasConstraintName("FK__Availabil__labou__2E1BDC42");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.Client", b =>
                {
                    b.HasOne("labourRecruitment.Models.LabourRecruitment.SystemUser", "User")
                        .WithMany("Client")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Client__user_id__267ABA7A");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.IncidentReport", b =>
                {
                    b.HasOne("labourRecruitment.Models.LabourRecruitment.IncidentType", "IncidentType")
                        .WithMany("IncidentReport")
                        .HasForeignKey("IncidentTypeId")
                        .HasConstraintName("FK__IncidentR__incid__3C69FB99");

                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Job", "Job")
                        .WithMany("IncidentReport")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK__IncidentR__job_i__3D5E1FD2");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.Job", b =>
                {
                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Client", "Client")
                        .WithMany("Job")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK__Job__client_id__31EC6D26");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.JobLabourer", b =>
                {
                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Job", "Job")
                        .WithMany("JobLabourer")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK__JobLabour__job_i__47DBAE45")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Labourer", "Labourer")
                        .WithMany("JobLabourer")
                        .HasForeignKey("LabourerId")
                        .HasConstraintName("FK__JobLabour__labou__48CFD27E")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Skill", "Skill")
                        .WithMany("JobLabourer")
                        .HasForeignKey("SkillId")
                        .HasConstraintName("FK__JobLabour__skill__49C3F6B7")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.JobSkill", b =>
                {
                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Job", "Job")
                        .WithMany("JobSkill")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK__JobSkill__job_id__403A8C7D")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Skill", "Skill")
                        .WithMany("JobSkill")
                        .HasForeignKey("SkillId")
                        .HasConstraintName("FK__JobSkill__skill___412EB0B6")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.Labourer", b =>
                {
                    b.HasOne("labourRecruitment.Models.LabourRecruitment.SystemUser", "User")
                        .WithMany("Labourer")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Labourer__user_i__29572725");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.LabourerAttendance", b =>
                {
                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Job", "Job")
                        .WithMany("LabourerAttendance")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK__LabourerA__job_i__36B12243");

                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Labourer", "Labourer")
                        .WithMany("LabourerAttendance")
                        .HasForeignKey("LabourerId")
                        .HasConstraintName("FK__LabourerA__labou__37A5467C");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.LabourerIncidentReport", b =>
                {
                    b.HasOne("labourRecruitment.Models.LabourRecruitment.IncidentReport", "IncidentReport")
                        .WithMany("LabourerIncidentReport")
                        .HasForeignKey("IncidentReportId")
                        .HasConstraintName("FK__LabourerI__incid__4D94879B");

                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Labourer", "Labourer")
                        .WithMany("LabourerIncidentReport")
                        .HasForeignKey("LabourerId")
                        .HasConstraintName("FK__LabourerI__labou__4CA06362");
                });

            modelBuilder.Entity("labourRecruitment.Models.LabourRecruitment.LabourerSkill", b =>
                {
                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Labourer", "Labourer")
                        .WithMany("LabourerSkill")
                        .HasForeignKey("LabourerId")
                        .HasConstraintName("FK__LabourerS__labou__440B1D61")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("labourRecruitment.Models.LabourRecruitment.Skill", "Skill")
                        .WithMany("LabourerSkill")
                        .HasForeignKey("SkillId")
                        .HasConstraintName("FK__LabourerS__skill__44FF419A")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
