using Microsoft.EntityFrameworkCore.Migrations;

namespace eStateV1.Migrations
{
    public partial class Treca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nekretnina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    DetaljniOpis = table.Column<string>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nekretnina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nekretnina_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nekretnina_KorisnikId",
                table: "Nekretnina",
                column: "KorisnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nekretnina");
        }
    }
}
