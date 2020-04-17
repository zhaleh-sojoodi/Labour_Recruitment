using Microsoft.EntityFrameworkCore.Migrations;

namespace roleDemo.Data.Migrations
{
    public partial class addPassWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassWord",
                table: "Labourers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LabourerSkill",
                columns: table => new
                {
                    LabourerSkillID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LabourerID = table.Column<int>(nullable: false),
                    SkillID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourerSkill", x => x.LabourerSkillID);
                    table.ForeignKey(
                        name: "FK_LabourerSkill_Labourers_LabourerID",
                        column: x => x.LabourerID,
                        principalTable: "Labourers",
                        principalColumn: "LabourerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabourerSkill_LabourerID",
                table: "LabourerSkill",
                column: "LabourerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabourerSkill");

            migrationBuilder.DropColumn(
                name: "PassWord",
                table: "Labourers");
        }
    }
}
