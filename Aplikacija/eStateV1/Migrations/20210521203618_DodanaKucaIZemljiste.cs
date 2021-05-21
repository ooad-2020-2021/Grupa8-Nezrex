using Microsoft.EntityFrameworkCore.Migrations;

namespace eStateV1.Migrations
{
    public partial class DodanaKucaIZemljiste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Namjestena",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stan_BrojSoba",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Stan_Parking",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Vikendica_BrojSpratova",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GradjevinskaDozvola",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "KomunalniPrikljucak",
                table: "Nekretnina",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UrbanistickaDozvola",
                table: "Nekretnina",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Namjestena",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "Stan_BrojSoba",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "Stan_Parking",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "Vikendica_BrojSpratova",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "GradjevinskaDozvola",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "KomunalniPrikljucak",
                table: "Nekretnina");

            migrationBuilder.DropColumn(
                name: "UrbanistickaDozvola",
                table: "Nekretnina");
        }
    }
}
