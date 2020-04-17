﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace roleDemo.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentType",
                columns: table => new
                {
                    incident_type_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    incident_type_name = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentType", x => x.incident_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    skill_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    skill_name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    pay_rate = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.skill_id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    password = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    role = table.Column<string>(unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SystemUs__B9BE370F34B081F3", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    client_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<int>(nullable: true),
                    client_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    client_email = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    client_phone_number = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    client_city = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    client_state = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.client_id);
                    table.ForeignKey(
                        name: "FK__Client__user_id__267ABA7A",
                        column: x => x.user_id,
                        principalTable: "SystemUser",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Labourer",
                columns: table => new
                {
                    labourer_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<int>(nullable: true),
                    labourer_first_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    labourer_last_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    labourer_SIN = table.Column<int>(nullable: true),
                    labourer_email = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    isAvailable = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labourer", x => x.labourer_id);
                    table.ForeignKey(
                        name: "FK__Labourer__user_i__29572725",
                        column: x => x.user_id,
                        principalTable: "SystemUser",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    job_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    client_id = table.Column<int>(nullable: true),
                    title = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    job_description = table.Column<string>(type: "text", nullable: true),
                    start_date = table.Column<DateTime>(type: "date", nullable: true),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    inProgress = table.Column<bool>(nullable: true),
                    isComplete = table.Column<bool>(nullable: true),
                    street = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    city = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    state = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    postal_code = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.job_id);
                    table.ForeignKey(
                        name: "FK__Job__client_id__2F10007B",
                        column: x => x.client_id,
                        principalTable: "Client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    availability_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    labourer_id = table.Column<int>(nullable: true),
                    availability_time = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.availability_id);
                    table.ForeignKey(
                        name: "FK__Availabil__labou__2C3393D0",
                        column: x => x.labourer_id,
                        principalTable: "Labourer",
                        principalColumn: "labourer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabourerSkill",
                columns: table => new
                {
                    labourer_skill_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    labourer_id = table.Column<int>(nullable: true),
                    skill_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourerSkill", x => x.labourer_skill_id);
                    table.ForeignKey(
                        name: "FK__LabourerS__labou__49C3F6B7",
                        column: x => x.labourer_id,
                        principalTable: "Labourer",
                        principalColumn: "labourer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LabourerS__skill__4AB81AF0",
                        column: x => x.skill_id,
                        principalTable: "Skill",
                        principalColumn: "skill_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientQualityRating",
                columns: table => new
                {
                    quality_rating = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    job_id = table.Column<int>(nullable: true),
                    client_id = table.Column<int>(nullable: true),
                    rating = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClientQu__5440651358CA4B58", x => x.quality_rating);
                    table.ForeignKey(
                        name: "FK__ClientQua__clien__34C8D9D1",
                        column: x => x.client_id,
                        principalTable: "Client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ClientQua__job_i__33D4B598",
                        column: x => x.job_id,
                        principalTable: "Job",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    incident_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    job_id = table.Column<int>(nullable: true),
                    labourer_id = table.Column<int>(nullable: true),
                    incident_type_id = table.Column<int>(nullable: true),
                    incident_date = table.Column<DateTime>(type: "date", nullable: true),
                    incident_description = table.Column<string>(type: "text", nullable: true),
                    incident_file = table.Column<string>(unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.incident_id);
                    table.ForeignKey(
                        name: "FK__Incident__incide__4316F928",
                        column: x => x.incident_type_id,
                        principalTable: "IncidentType",
                        principalColumn: "incident_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Incident__job_id__412EB0B6",
                        column: x => x.job_id,
                        principalTable: "Job",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Incident__labour__4222D4EF",
                        column: x => x.labourer_id,
                        principalTable: "Labourer",
                        principalColumn: "labourer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobSkill",
                columns: table => new
                {
                    job_skill_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    job_id = table.Column<int>(nullable: true),
                    skill_id = table.Column<int>(nullable: true),
                    number_needed = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkill", x => x.job_skill_id);
                    table.ForeignKey(
                        name: "FK__JobSkill__job_id__45F365D3",
                        column: x => x.job_id,
                        principalTable: "Job",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__JobSkill__skill___46E78A0C",
                        column: x => x.skill_id,
                        principalTable: "Skill",
                        principalColumn: "skill_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabourerDailyQualityRating",
                columns: table => new
                {
                    daily_quality_rating = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    job_id = table.Column<int>(nullable: true),
                    labourer_id = table.Column<int>(nullable: true),
                    rating = table.Column<double>(nullable: true),
                    rating_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Labourer__61640B197493ADBC", x => x.daily_quality_rating);
                    table.ForeignKey(
                        name: "FK__LabourerD__job_i__3B75D760",
                        column: x => x.job_id,
                        principalTable: "Job",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LabourerD__labou__3C69FB99",
                        column: x => x.labourer_id,
                        principalTable: "Labourer",
                        principalColumn: "labourer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabourerSafetyRating",
                columns: table => new
                {
                    safety_rating = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    job_id = table.Column<int>(nullable: true),
                    labourer_id = table.Column<int>(nullable: true),
                    rating = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Labourer__0A004E492D01DB68", x => x.safety_rating);
                    table.ForeignKey(
                        name: "FK__LabourerS__job_i__37A5467C",
                        column: x => x.job_id,
                        principalTable: "Job",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LabourerS__labou__38996AB5",
                        column: x => x.labourer_id,
                        principalTable: "Labourer",
                        principalColumn: "labourer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Availability_labourer_id",
                table: "Availability",
                column: "labourer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Client_user_id",
                table: "Client",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientQualityRating_client_id",
                table: "ClientQualityRating",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientQualityRating_job_id",
                table: "ClientQualityRating",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_incident_type_id",
                table: "Incident",
                column: "incident_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_job_id",
                table: "Incident",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_labourer_id",
                table: "Incident",
                column: "labourer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Job_client_id",
                table: "Job",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_job_id",
                table: "JobSkill",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_skill_id",
                table: "JobSkill",
                column: "skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_Labourer_user_id",
                table: "Labourer",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_LabourerDailyQualityRating_job_id",
                table: "LabourerDailyQualityRating",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_LabourerDailyQualityRating_labourer_id",
                table: "LabourerDailyQualityRating",
                column: "labourer_id");

            migrationBuilder.CreateIndex(
                name: "IX_LabourerSafetyRating_job_id",
                table: "LabourerSafetyRating",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_LabourerSafetyRating_labourer_id",
                table: "LabourerSafetyRating",
                column: "labourer_id");

            migrationBuilder.CreateIndex(
                name: "IX_LabourerSkill_labourer_id",
                table: "LabourerSkill",
                column: "labourer_id");

            migrationBuilder.CreateIndex(
                name: "IX_LabourerSkill_skill_id",
                table: "LabourerSkill",
                column: "skill_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Availability");

            migrationBuilder.DropTable(
                name: "ClientQualityRating");

            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "JobSkill");

            migrationBuilder.DropTable(
                name: "LabourerDailyQualityRating");

            migrationBuilder.DropTable(
                name: "LabourerSafetyRating");

            migrationBuilder.DropTable(
                name: "LabourerSkill");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "IncidentType");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Labourer");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "SystemUser");
        }
    }
}
