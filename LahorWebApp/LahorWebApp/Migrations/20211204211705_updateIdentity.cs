using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmailAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumDodavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UposlenikID = table.Column<int>(type: "int", nullable: false),
                    UpravnoOsobljeID = table.Column<int>(type: "int", nullable: false),
                    KlijentPravnoLiceID = table.Column<int>(type: "int", nullable: false),
                    KlijentFizickoLiceID = table.Column<int>(type: "int", nullable: false),
                    isUposlenik = table.Column<bool>(type: "bit", nullable: false),
                    isUpravnoOsoblje = table.Column<bool>(type: "bit", nullable: false),
                    isKlijentPravnoLice = table.Column<bool>(type: "bit", nullable: false),
                    isKlijentFizickoLice = table.Column<bool>(type: "bit", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BracniStatusi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BracniStatusi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pozicija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozicija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spolovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spolovi", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KlijentiPravnoLice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKlijenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdBrojFirme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false),
                    ClanskaKartica = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlijentiPravnoLice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KlijentiPravnoLice_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KlijentiFizickoLice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpolID = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false),
                    ClanskaKartica = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlijentiFizickoLice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KlijentiFizickoLice_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KlijentiFizickoLice_Spolovi_SpolID",
                        column: x => x.SpolID,
                        principalTable: "Spolovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uposlenici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zanimanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrucnaSprema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MjestoRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MjestoPrebivalista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpolID = table.Column<int>(type: "int", nullable: false),
                    BracniStatusID = table.Column<int>(type: "int", nullable: false),
                    Nacionalost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drzavljanstvo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RadnoIskustvo = table.Column<bool>(type: "bit", nullable: false),
                    Biografija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PozicijaID = table.Column<int>(type: "int", nullable: false),
                    VoazckaDozvolaKategorijaID = table.Column<int>(type: "int", nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IznosPlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uposlenici_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uposlenici_BracniStatusi_BracniStatusID",
                        column: x => x.BracniStatusID,
                        principalTable: "BracniStatusi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uposlenici_Pozicija_PozicijaID",
                        column: x => x.PozicijaID,
                        principalTable: "Pozicija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uposlenici_Spolovi_SpolID",
                        column: x => x.SpolID,
                        principalTable: "Spolovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uposlenici_VozackaDozvolaKategorija_VoazckaDozvolaKategorijaID",
                        column: x => x.VoazckaDozvolaKategorijaID,
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
                    KorisnikID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrucnaSprema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MjestoRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MjestoPrebivalista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpolID = table.Column<int>(type: "int", nullable: false),
                    BracniStatusID = table.Column<int>(type: "int", nullable: false),
                    Nacionalost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drzavljanstvo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RadnoIskustvo = table.Column<bool>(type: "bit", nullable: false),
                    Biografija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PozicijaID = table.Column<int>(type: "int", nullable: false),
                    VoazckaDozvolaKategorijaID = table.Column<int>(type: "int", nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IznosPlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpravnoOsoblje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpravnoOsoblje_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpravnoOsoblje_BracniStatusi_BracniStatusID",
                        column: x => x.BracniStatusID,
                        principalTable: "BracniStatusi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpravnoOsoblje_Pozicija_PozicijaID",
                        column: x => x.PozicijaID,
                        principalTable: "Pozicija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpravnoOsoblje_Spolovi_SpolID",
                        column: x => x.SpolID,
                        principalTable: "Spolovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpravnoOsoblje_VozackaDozvolaKategorija_VoazckaDozvolaKategorijaID",
                        column: x => x.VoazckaDozvolaKategorijaID,
                        principalTable: "VozackaDozvolaKategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentiFizickoLice_KorisnikID",
                table: "KlijentiFizickoLice",
                column: "KorisnikID",
                unique: true,
                filter: "[KorisnikID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentiFizickoLice_SpolID",
                table: "KlijentiFizickoLice",
                column: "SpolID");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentiPravnoLice_KorisnikID",
                table: "KlijentiPravnoLice",
                column: "KorisnikID",
                unique: true,
                filter: "[KorisnikID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_BracniStatusID",
                table: "Uposlenici",
                column: "BracniStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_KorisnikID",
                table: "Uposlenici",
                column: "KorisnikID",
                unique: true,
                filter: "[KorisnikID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_PozicijaID",
                table: "Uposlenici",
                column: "PozicijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_SpolID",
                table: "Uposlenici",
                column: "SpolID");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_VoazckaDozvolaKategorijaID",
                table: "Uposlenici",
                column: "VoazckaDozvolaKategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_UpravnoOsoblje_BracniStatusID",
                table: "UpravnoOsoblje",
                column: "BracniStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_UpravnoOsoblje_KorisnikID",
                table: "UpravnoOsoblje",
                column: "KorisnikID",
                unique: true,
                filter: "[KorisnikID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UpravnoOsoblje_PozicijaID",
                table: "UpravnoOsoblje",
                column: "PozicijaID");

            migrationBuilder.CreateIndex(
                name: "IX_UpravnoOsoblje_SpolID",
                table: "UpravnoOsoblje",
                column: "SpolID");

            migrationBuilder.CreateIndex(
                name: "IX_UpravnoOsoblje_VoazckaDozvolaKategorijaID",
                table: "UpravnoOsoblje",
                column: "VoazckaDozvolaKategorijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "KlijentiFizickoLice");

            migrationBuilder.DropTable(
                name: "KlijentiPravnoLice");

            migrationBuilder.DropTable(
                name: "Uposlenici");

            migrationBuilder.DropTable(
                name: "UpravnoOsoblje");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BracniStatusi");

            migrationBuilder.DropTable(
                name: "Pozicija");

            migrationBuilder.DropTable(
                name: "Spolovi");

            migrationBuilder.DropTable(
                name: "VozackaDozvolaKategorija");
        }
    }
}
