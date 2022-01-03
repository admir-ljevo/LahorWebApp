using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LahorWebApp.Migrations
{
    public partial class NovamigracijaSve : Migration
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
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumDodavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Klijenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false),
                    ClanskaKartica = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NivoIzvrsenjaUsluge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivoIzvrsenjaUsluge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pozicije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozicije", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false),
                    NazivKlijenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdBrojFirme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikID = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_KlijentiPravnoLice_Klijenti_Id",
                        column: x => x.Id,
                        principalTable: "Klijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KlijentiFizickoLice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpolID = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        name: "FK_KlijentiFizickoLice_Klijenti_Id",
                        column: x => x.Id,
                        principalTable: "Klijenti",
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
                name: "Radnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadnoIskustvo = table.Column<bool>(type: "bit", nullable: false),
                    Biografija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PozicijaId = table.Column<int>(type: "int", nullable: false),
                    VoazckaDozvolaKategorijaID = table.Column<int>(type: "int", nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IznosPlate = table.Column<float>(type: "real", nullable: false),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radnici_BracniStatusi_BracniStatusID",
                        column: x => x.BracniStatusID,
                        principalTable: "BracniStatusi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Radnici_Pozicije_PozicijaId",
                        column: x => x.PozicijaId,
                        principalTable: "Pozicije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Radnici_Spolovi_SpolID",
                        column: x => x.SpolID,
                        principalTable: "Spolovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Radnici_VozackaDozvolaKategorija_VoazckaDozvolaKategorijaID",
                        column: x => x.VoazckaDozvolaKategorijaID,
                        principalTable: "VozackaDozvolaKategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usluge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivUsluge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumModifikovanja = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Uposlenici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Zanimanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikID = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        name: "FK_Uposlenici_Radnici_Id",
                        column: x => x.Id,
                        principalTable: "Radnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UpravnoOsoblje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Titula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikID = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        name: "FK_UpravnoOsoblje_Radnici_Id",
                        column: x => x.Id,
                        principalTable: "Radnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UslugeNivoIzvrsenja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UslugaId = table.Column<int>(type: "int", nullable: false),
                    NivoIzvrsenjaId = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UslugeNivoIzvrsenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UslugeNivoIzvrsenja_NivoIzvrsenjaUsluge_NivoIzvrsenjaId",
                        column: x => x.NivoIzvrsenjaId,
                        principalTable: "NivoIzvrsenjaUsluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UslugeNivoIzvrsenja_Usluge_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Narudzbe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumNarudzbe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIsporuke = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isporucena = table.Column<bool>(type: "bit", nullable: false),
                    UkupnaCijena = table.Column<float>(type: "real", nullable: false),
                    Kolicina = table.Column<float>(type: "real", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NazivKlijenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutorUpravnoId = table.Column<int>(type: "int", nullable: true),
                    AutorUposlenikId = table.Column<int>(type: "int", nullable: true),
                    KlijentFizickoLiceId = table.Column<int>(type: "int", nullable: true),
                    KlijentPravnoLiceId = table.Column<int>(type: "int", nullable: true),
                    isOnline = table.Column<bool>(type: "bit", nullable: false),
                    isGuest = table.Column<bool>(type: "bit", nullable: false),
                    isNarudzbaAutor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzbe_KlijentiFizickoLice_KlijentFizickoLiceId",
                        column: x => x.KlijentFizickoLiceId,
                        principalTable: "KlijentiFizickoLice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbe_KlijentiPravnoLice_KlijentPravnoLiceId",
                        column: x => x.KlijentPravnoLiceId,
                        principalTable: "KlijentiPravnoLice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbe_Uposlenici_AutorUposlenikId",
                        column: x => x.AutorUposlenikId,
                        principalTable: "Uposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbe_UpravnoOsoblje_AutorUpravnoId",
                        column: x => x.AutorUpravnoId,
                        principalTable: "UpravnoOsoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obavještenja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    SlikaObavještenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JavnaObavijest = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavještenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obavještenja_UpravnoOsoblje_AutorId",
                        column: x => x.AutorId,
                        principalTable: "UpravnoOsoblje",
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

            migrationBuilder.CreateTable(
                name: "NarudzbeUslugeNivoIzvrsenja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarudzbaId = table.Column<int>(type: "int", nullable: false),
                    UslugaId = table.Column<int>(type: "int", nullable: false),
                    NivoIzvrsenjaId = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    Kolicina = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbeUslugeNivoIzvrsenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NarudzbeUslugeNivoIzvrsenja_Narudzbe_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NarudzbeUslugeNivoIzvrsenja_NivoIzvrsenjaUsluge_NivoIzvrsenjaId",
                        column: x => x.NivoIzvrsenjaId,
                        principalTable: "NivoIzvrsenjaUsluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NarudzbeUslugeNivoIzvrsenja_Usluge_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluge",
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

            migrationBuilder.CreateIndex(
                name: "IX_KlijentiFizickoLice_KorisnikID",
                table: "KlijentiFizickoLice",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentiFizickoLice_SpolID",
                table: "KlijentiFizickoLice",
                column: "SpolID");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentiPravnoLice_KorisnikID",
                table: "KlijentiPravnoLice",
                column: "KorisnikID");

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

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbeUslugeNivoIzvrsenja_NarudzbaId",
                table: "NarudzbeUslugeNivoIzvrsenja",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbeUslugeNivoIzvrsenja_NivoIzvrsenjaId",
                table: "NarudzbeUslugeNivoIzvrsenja",
                column: "NivoIzvrsenjaId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbeUslugeNivoIzvrsenja_UslugaId",
                table: "NarudzbeUslugeNivoIzvrsenja",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavještenja_AutorId",
                table: "Obavještenja",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Radnici_BracniStatusID",
                table: "Radnici",
                column: "BracniStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Radnici_PozicijaId",
                table: "Radnici",
                column: "PozicijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Radnici_SpolID",
                table: "Radnici",
                column: "SpolID");

            migrationBuilder.CreateIndex(
                name: "IX_Radnici_VoazckaDozvolaKategorijaID",
                table: "Radnici",
                column: "VoazckaDozvolaKategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_KorisnikID",
                table: "Uposlenici",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_UpravnoOsoblje_KorisnikID",
                table: "UpravnoOsoblje",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_VrstaUslugeId",
                table: "Usluge",
                column: "VrstaUslugeId");

            migrationBuilder.CreateIndex(
                name: "IX_UslugeNivoIzvrsenja_NivoIzvrsenjaId",
                table: "UslugeNivoIzvrsenja",
                column: "NivoIzvrsenjaId");

            migrationBuilder.CreateIndex(
                name: "IX_UslugeNivoIzvrsenja_UslugaId",
                table: "UslugeNivoIzvrsenja",
                column: "UslugaId");
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
                name: "IzvjestajiNarudzbe");

            migrationBuilder.DropTable(
                name: "NarudzbeUslugeNivoIzvrsenja");

            migrationBuilder.DropTable(
                name: "Obavještenja");

            migrationBuilder.DropTable(
                name: "UslugeNivoIzvrsenja");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Izvjestaji");

            migrationBuilder.DropTable(
                name: "Narudzbe");

            migrationBuilder.DropTable(
                name: "NivoIzvrsenjaUsluge");

            migrationBuilder.DropTable(
                name: "Usluge");

            migrationBuilder.DropTable(
                name: "VrstaIzvjestaja");

            migrationBuilder.DropTable(
                name: "KlijentiFizickoLice");

            migrationBuilder.DropTable(
                name: "KlijentiPravnoLice");

            migrationBuilder.DropTable(
                name: "Uposlenici");

            migrationBuilder.DropTable(
                name: "UpravnoOsoblje");

            migrationBuilder.DropTable(
                name: "VrsteUsluga");

            migrationBuilder.DropTable(
                name: "Klijenti");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Radnici");

            migrationBuilder.DropTable(
                name: "BracniStatusi");

            migrationBuilder.DropTable(
                name: "Pozicije");

            migrationBuilder.DropTable(
                name: "Spolovi");

            migrationBuilder.DropTable(
                name: "VozackaDozvolaKategorija");
        }
    }
}
