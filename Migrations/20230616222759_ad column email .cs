using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadBookMuds.Migrations
{
    public partial class adcolumnemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DemandBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "nbr",
                table: "DemandBook",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "DemandBook");

            migrationBuilder.DropColumn(
                name: "nbr",
                table: "DemandBook");
        }
    }
}
