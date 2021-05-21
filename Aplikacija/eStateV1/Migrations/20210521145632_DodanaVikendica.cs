using Microsoft.EntityFrameworkCore.Migrations;

namespace eStateV1.Migrations
{
    public partial class DodanaVikendica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Vikendica_BrojSoba",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrojSpratova",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Namjeseten",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Vikendica_Parking",
                table: "Nekretnina",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vikendica_BrojSoba",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "BrojSpratova",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "Namjeseten",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "Vikendica_Parking",
                table: "Nekretnina");
        }
    }
}
