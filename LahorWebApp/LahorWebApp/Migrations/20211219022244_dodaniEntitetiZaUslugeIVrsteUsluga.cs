using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class dodaniEntitetiZaUslugeIVrsteUsluga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PozicijaID",
                table: "UpravnoOsoblje");

            migrationBuilder.DropColumn(
                name: "PozicijaID",
                table: "Uposlenici");

            migrationBuilder.CreateTable(
                name: "VrsteUsluga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrsteUsluga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usluge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivUsluge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CijenaPranje = table.Column<float>(type: "real", nullable: false),
                    CijenaSusenje = table.Column<float>(type: "real", nullable: false),
                    CijenaPeglanje = table.Column<float>(type: "real", nullable: false),
                    CijenaPranjeSusenje = table.Column<float>(type: "real", nullable: false),
                    CijenaSusenjePeglanje = table.Column<float>(type: "real", nullable: false),
                    CijenaPranjeSusenjePeglanje = table.Column<float>(type: "real", nullable: false),
                    VrstaUslugeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usluge_VrsteUsluga_VrstaUslugeId",
                        column: x => x.VrstaUslugeId,
                        principalTable: "VrsteUsluga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_VrstaUslugeId",
                table: "Usluge",
                column: "VrstaUslugeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usluge");

            migrationBuilder.DropTable(
                name: "VrsteUsluga");

            migrationBuilder.AddColumn<int>(
                name: "PozicijaID",
                table: "UpravnoOsoblje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PozicijaID",
                table: "Uposlenici",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
