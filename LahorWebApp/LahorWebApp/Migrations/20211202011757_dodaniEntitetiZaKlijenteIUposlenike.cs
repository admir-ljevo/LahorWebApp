using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LahorWebApp.Migrations
{
    public partial class dodaniEntitetiZaKlijenteIUposlenike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KlijentiFizickoLice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlijentiFizickoLice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KlijentiFizickoLice_Spolovi_SpolId",
                        column: x => x.SpolId,
                        principalTable: "Spolovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KlijentiPravnoLice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKlijenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdBrojFirme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false),
                    ClanskaKartica = table.Column<bool>(type: "bit", nullable: false),
                    DatumDodavanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlijentiPravnoLice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VozackaDozvolaKategorija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VozackaDozvolaKategorija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uposlenici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zanimanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pozicija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrucnaSprema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MjestoRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MjestoPrebivalista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpolId = table.Column<int>(type: "int", nullable: true),
                    BracniStatusId = table.Column<int>(type: "int", nullable: true),
                    Nacionalost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drzavljanstvo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RadnoIskustvo = table.Column<bool>(type: "bit", nullable: false),
                    Biografija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoazckaDozvolaKategorijaId = table.Column<int>(type: "int", nullable: true),
                    DatumZaposlenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IznosPlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uposlenici_BracniStatusi_BracniStatusId",
                        column: x => x.BracniStatusId,
                        principalTable: "BracniStatusi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uposlenici_Spolovi_SpolId",
                        column: x => x.SpolId,
                        principalTable: "Spolovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uposlenici_VozackaDozvolaKategorija_VoazckaDozvolaKategorijaId",
                        column: x => x.VoazckaDozvolaKategorijaId,
                        principalTable: "VozackaDozvolaKategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UpravnoOsoblje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pozicija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrucnaSprema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MjestoRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MjestoPrebivalista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpolId = table.Column<int>(type: "int", nullable: true),
                    BracniStatusId = table.Column<int>(type: "int", nullable: true),
                    Nacionalost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drzavljanstvo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RadnoIskustvo = table.Column<bool>(type: "bit", nullable: false),
                    Biografija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoazckaDozvolaKategorijaId = table.Column<int>(type: "int", nullable: true),
                    DatumZaposlenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IznosPlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpravnoOsoblje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpravnoOsoblje_BracniStatusi_BracniStatusId",
                        column: x => x.BracniStatusId,
                        principalTable: "BracniStatusi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpravnoOsoblje_Spolovi_SpolId",
                        column: x => x.SpolId,
                        principalTable: "Spolovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpravnoOsoblje_VozackaDozvolaKategorija_VoazckaDozvolaKategorijaId",
                        column: x => x.VoazckaDozvolaKategorijaId,
                        principalTable: "VozackaDozvolaKategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KlijentiFizickoLice_SpolId",
                table: "KlijentiFizickoLice",
                column: "SpolId");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_BracniStatusId",
                table: "Uposlenici",
                column: "BracniStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_SpolId",
                table: "Uposlenici",
                column: "SpolId");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_VoazckaDozvolaKategorijaId",
                table: "Uposlenici",
                column: "VoazckaDozvolaKategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_UpravnoOsoblje_BracniStatusId",
                table: "UpravnoOsoblje",
                column: "BracniStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UpravnoOsoblje_SpolId",
                table: "UpravnoOsoblje",
                column: "SpolId");

            migrationBuilder.CreateIndex(
                name: "IX_UpravnoOsoblje_VoazckaDozvolaKategorijaId",
                table: "UpravnoOsoblje",
                column: "VoazckaDozvolaKategorijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KlijentiFizickoLice");

            migrationBuilder.DropTable(
                name: "KlijentiPravnoLice");

            migrationBuilder.DropTable(
                name: "Uposlenici");

            migrationBuilder.DropTable(
                name: "UpravnoOsoblje");

            migrationBuilder.DropTable(
                name: "VozackaDozvolaKategorija");
        }
    }
}
