using Microsoft.EntityFrameworkCore.Migrations;

namespace LahorWebApp.Migrations
{
    public partial class updatenarudzba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzbe_KlijentiFizickoLice_KlijentFizickoLiceId",
                table: "Narudzbe");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzbe_KlijentiPravnoLice_KlijentPravnoLiceId",
                table: "Narudzbe");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzbe_Uposlenici_AutorUposlenikId",
                table: "Narudzbe");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzbe_UpravnoOsoblje_AutorUpravnoId",
                table: "Narudzbe");

            migrationBuilder.DropIndex(
                name: "IX_Narudzbe_AutorUposlenikId",
                table: "Narudzbe");

            migrationBuilder.DropIndex(
                name: "IX_Narudzbe_AutorUpravnoId",
                table: "Narudzbe");

            migrationBuilder.DropIndex(
                name: "IX_Narudzbe_KlijentFizickoLiceId",
                table: "Narudzbe");

            migrationBuilder.DropIndex(
                name: "IX_Narudzbe_KlijentPravnoLiceId",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "AutorUposlenikId",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "AutorUpravnoId",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "KlijentFizickoLiceId",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "KlijentPravnoLiceId",
                table: "Narudzbe");

            migrationBuilder.AddColumn<int>(
                name: "KlijentId",
                table: "Narudzbe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RadnikId",
                table: "Narudzbe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_KlijentId",
                table: "Narudzbe",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_RadnikId",
                table: "Narudzbe",
                column: "RadnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzbe_Klijenti_KlijentId",
                table: "Narudzbe",
                column: "KlijentId",
                principalTable: "Klijenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzbe_Radnici_RadnikId",
                table: "Narudzbe",
                column: "RadnikId",
                principalTable: "Radnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzbe_Klijenti_KlijentId",
                table: "Narudzbe");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzbe_Radnici_RadnikId",
                table: "Narudzbe");

            migrationBuilder.DropIndex(
                name: "IX_Narudzbe_KlijentId",
                table: "Narudzbe");

            migrationBuilder.DropIndex(
                name: "IX_Narudzbe_RadnikId",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "KlijentId",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "RadnikId",
                table: "Narudzbe");

            migrationBuilder.AddColumn<int>(
                name: "AutorUposlenikId",
                table: "Narudzbe",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AutorUpravnoId",
                table: "Narudzbe",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KlijentFizickoLiceId",
                table: "Narudzbe",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KlijentPravnoLiceId",
                table: "Narudzbe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_AutorUposlenikId",
                table: "Narudzbe",
                column: "AutorUposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_AutorUpravnoId",
                table: "Narudzbe",
                column: "AutorUpravnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_KlijentFizickoLiceId",
                table: "Narudzbe",
                column: "KlijentFizickoLiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_KlijentPravnoLiceId",
                table: "Narudzbe",
                column: "KlijentPravnoLiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzbe_KlijentiFizickoLice_KlijentFizickoLiceId",
                table: "Narudzbe",
                column: "KlijentFizickoLiceId",
                principalTable: "KlijentiFizickoLice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzbe_KlijentiPravnoLice_KlijentPravnoLiceId",
                table: "Narudzbe",
                column: "KlijentPravnoLiceId",
                principalTable: "KlijentiPravnoLice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzbe_Uposlenici_AutorUposlenikId",
                table: "Narudzbe",
                column: "AutorUposlenikId",
                principalTable: "Uposlenici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzbe_UpravnoOsoblje_AutorUpravnoId",
                table: "Narudzbe",
                column: "AutorUpravnoId",
                principalTable: "UpravnoOsoblje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
