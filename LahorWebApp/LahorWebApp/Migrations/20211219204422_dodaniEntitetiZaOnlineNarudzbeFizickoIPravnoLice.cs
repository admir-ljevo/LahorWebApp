using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class dodaniEntitetiZaOnlineNarudzbeFizickoIPravnoLice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnlineNarduzbeKlijentiFizickoLice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlijentFizickoLiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineNarduzbeKlijentiFizickoLice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineNarduzbeKlijentiFizickoLice_KlijentiFizickoLice_KlijentFizickoLiceId",
                        column: x => x.KlijentFizickoLiceId,
                        principalTable: "KlijentiFizickoLice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineNarduzbeKlijentiPravnoLice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlijentPravnoLiceId = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumNarudzbe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIsporuke = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isporucena = table.Column<bool>(type: "bit", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    Kolicina = table.Column<float>(type: "real", nullable: false),
                    KolicinaVrsteUsluge = table.Column<float>(type: "real", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineNarduzbeKlijentiPravnoLice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineNarduzbeKlijentiPravnoLice_KlijentiPravnoLice_KlijentPravnoLiceId",
                        column: x => x.KlijentPravnoLiceId,
                        principalTable: "KlijentiPravnoLice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineNarduzbeKlijentiFizickoLice_KlijentFizickoLiceId",
                table: "OnlineNarduzbeKlijentiFizickoLice",
                column: "KlijentFizickoLiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineNarduzbeKlijentiPravnoLice_KlijentPravnoLiceId",
                table: "OnlineNarduzbeKlijentiPravnoLice",
                column: "KlijentPravnoLiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineNarduzbeKlijentiFizickoLice");

            migrationBuilder.DropTable(
                name: "OnlineNarduzbeKlijentiPravnoLice");
        }
    }
}
