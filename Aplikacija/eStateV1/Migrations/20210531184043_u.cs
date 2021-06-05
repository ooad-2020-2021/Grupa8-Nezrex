using Microsoft.EntityFrameworkCore.Migrations;

namespace eStateV1.Migrations
{
    public partial class u : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KucaId",
                table: "Slike",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slike_KucaId",
                table: "Slike",
                column: "KucaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slike_Nekretnina_KucaId",
                table: "Slike",
                column: "KucaId",
                principalTable: "Nekretnina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slike_Nekretnina_KucaId",
                table: "Slike");

            migrationBuilder.DropIndex(
                name: "IX_Slike_KucaId",
                table: "Slike");

            migrationBuilder.DropColumn(
                name: "KucaId",
                table: "Slike");
        }
    }
}
