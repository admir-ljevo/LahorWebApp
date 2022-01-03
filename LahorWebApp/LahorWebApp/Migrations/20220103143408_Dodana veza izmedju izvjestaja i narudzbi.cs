using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LahorWebApp.Migrations
{
    public partial class Dodanavezaizmedjuizvjestajainarudzbi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VrstaIzvjestaja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaIzvjestaja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Izvjestaji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oznaka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VrstaIzvjestajaId = table.Column<int>(type: "int", nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorUposlenikId = table.Column<int>(type: "int", nullable: true),
                    AutorUpravnoOsobljeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvjestaji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Izvjestaji_Uposlenici_AutorUposlenikId",
                        column: x => x.AutorUposlenikId,
                        principalTable: "Uposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Izvjestaji_UpravnoOsoblje_AutorUpravnoOsobljeId",
                        column: x => x.AutorUpravnoOsobljeId,
                        principalTable: "UpravnoOsoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Izvjestaji_VrstaIzvjestaja_VrstaIzvjestajaId",
                        column: x => x.VrstaIzvjestajaId,
                        principalTable: "VrstaIzvjestaja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IzvjestajiNarudzbe",
                columns: table => new
                {
                    NarudzbaId = table.Column<int>(type: "int", nullable: false),
                    IzvjestajId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzvjestajiNarudzbe", x => new { x.NarudzbaId, x.IzvjestajId });
                    table.ForeignKey(
                        name: "FK_IzvjestajiNarudzbe_Izvjestaji_IzvjestajId",
                        column: x => x.IzvjestajId,
                        principalTable: "Izvjestaji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IzvjestajiNarudzbe_Narudzbe_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Izvjestaji_AutorUposlenikId",
                table: "Izvjestaji",
                column: "AutorUposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Izvjestaji_AutorUpravnoOsobljeId",
                table: "Izvjestaji",
                column: "AutorUpravnoOsobljeId");

            migrationBuilder.CreateIndex(
                name: "IX_Izvjestaji_VrstaIzvjestajaId",
                table: "Izvjestaji",
                column: "VrstaIzvjestajaId");

            migrationBuilder.CreateIndex(
                name: "IX_IzvjestajiNarudzbe_IzvjestajId",
                table: "IzvjestajiNarudzbe",
                column: "IzvjestajId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzvjestajiNarudzbe");

            migrationBuilder.DropTable(
                name: "Izvjestaji");

            migrationBuilder.DropTable(
                name: "VrstaIzvjestaja");
        }
    }
}
