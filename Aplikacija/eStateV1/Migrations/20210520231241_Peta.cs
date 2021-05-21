using Microsoft.EntityFrameworkCore.Migrations;

namespace eStateV1.Migrations
{
    public partial class Peta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Nekretnina",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BrojSoba",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrojSprata",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ImaBalkon",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Lift",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Namjesten",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Novogradnja",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Parking",
                table: "Nekretnina",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "BrojSoba",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "BrojSprata",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "ImaBalkon",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "Lift",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "Namjesten",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "Novogradnja",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "Parking",
                table: "Nekretnina");
        }
    }
}
