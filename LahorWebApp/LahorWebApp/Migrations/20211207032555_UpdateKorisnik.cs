using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateKorisnik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UpravnoOsoblje_KorisnikID",
                table: "UpravnoOsoblje");

            migrationBuilder.DropIndex(
                name: "IX_Uposlenici_KorisnikID",
                table: "Uposlenici");

            migrationBuilder.DropIndex(
                name: "IX_KlijentiPravnoLice_KorisnikID",
                table: "KlijentiPravnoLice");

            migrationBuilder.DropIndex(
                name: "IX_KlijentiFizickoLice_KorisnikID",
                table: "KlijentiFizickoLice");

            migrationBuilder.DropColumn(
                name: "KlijentPravnoLiceID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UposlenikID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpravnoOsobljeID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isKlijentFizickoLice",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isKlijentPravnoLice",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isUposlenik",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isUpravnoOsoblje",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_UpravnoOsoblje_KorisnikID",
                table: "UpravnoOsoblje",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_KorisnikID",
                table: "Uposlenici",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentiPravnoLice_KorisnikID",
                table: "KlijentiPravnoLice",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentiFizickoLice_KorisnikID",
                table: "KlijentiFizickoLice",
                column: "KorisnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UpravnoOsoblje_KorisnikID",
                table: "UpravnoOsoblje");

            migrationBuilder.DropIndex(
                name: "IX_Uposlenici_KorisnikID",
                table: "Uposlenici");

            migrationBuilder.DropIndex(
                name: "IX_KlijentiPravnoLice_KorisnikID",
                table: "KlijentiPravnoLice");

            migrationBuilder.DropIndex(
                name: "IX_KlijentiFizickoLice_KorisnikID",
                table: "KlijentiFizickoLice");

            migrationBuilder.AddColumn<int>(
                name: "KlijentFizickoLiceID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KlijentPravnoLiceID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UposlenikID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpravnoOsobljeID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isKlijentFizickoLice",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isKlijentPravnoLice",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isUposlenik",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isUpravnoOsoblje",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UpravnoOsoblje_KorisnikID",
                table: "UpravnoOsoblje",
                column: "KorisnikID",
                unique: true,
                filter: "[KorisnikID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_KorisnikID",
                table: "Uposlenici",
                column: "KorisnikID",
                unique: true,
                filter: "[KorisnikID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentiPravnoLice_KorisnikID",
                table: "KlijentiPravnoLice",
                column: "KorisnikID",
                unique: true,
                filter: "[KorisnikID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentiFizickoLice_KorisnikID",
                table: "KlijentiFizickoLice",
                column: "KorisnikID",
                unique: true,
                filter: "[KorisnikID] IS NOT NULL");
        }
    }
}
