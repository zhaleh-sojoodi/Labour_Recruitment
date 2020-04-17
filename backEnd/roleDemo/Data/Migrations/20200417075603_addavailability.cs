using Microsoft.EntityFrameworkCore.Migrations;

namespace roleDemo.Data.Migrations
{
    public partial class addavailability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Availability",
                table: "Labourers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Labourers");
        }
    }
}
