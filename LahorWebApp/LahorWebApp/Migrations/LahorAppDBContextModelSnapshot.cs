﻿// <auto-generated />
using System;
using LahorWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LahorWebApp.Migrations
{
    [DbContext(typeof(LahorAppDBContext))]
    partial class LahorAppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LahorWebApp.Models.BracniStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BracniStatusi");
                });

            modelBuilder.Entity("LahorWebApp.Models.KlijentFizickoLice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktivan")
                        .HasColumnType("bit");

                    b.Property<bool>("ClanskaKartica")
                        .HasColumnType("bit");

                    b.Property<string>("DatumRodjenja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnikID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpolID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikID")
                        .IsUnique()
                        .HasFilter("[KorisnikID] IS NOT NULL");

                    b.HasIndex("SpolID");

                    b.ToTable("KlijentiFizickoLice");
                });

            modelBuilder.Entity("LahorWebApp.Models.KlijentPravnoLice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktivan")
                        .HasColumnType("bit");

                    b.Property<bool>("ClanskaKartica")
                        .HasColumnType("bit");

                    b.Property<string>("IdBrojFirme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnikID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NazivKlijenta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikID")
                        .IsUnique()
                        .HasFilter("[KorisnikID] IS NOT NULL");

                    b.ToTable("KlijentiPravnoLice");
                });

            modelBuilder.Entity("LahorWebApp.Models.Korisnik", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumDodavanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("EmailAdresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("KlijentFizickoLiceID")
                        .HasColumnType("int");

                    b.Property<int>("KlijentPravnoLiceID")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("UposlenikID")
                        .HasColumnType("int");

                    b.Property<int>("UpravnoOsobljeID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("isKlijentFizickoLice")
                        .HasColumnType("bit");

                    b.Property<bool>("isKlijentPravnoLice")
                        .HasColumnType("bit");

                    b.Property<bool>("isUposlenik")
                        .HasColumnType("bit");

                    b.Property<bool>("isUpravnoOsoblje")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("LahorWebApp.Models.Pozicija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pozicija");
                });

            modelBuilder.Entity("LahorWebApp.Models.Spol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Spolovi");
                });

            modelBuilder.Entity("LahorWebApp.Models.Uposlenik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktivan")
                        .HasColumnType("bit");

                    b.Property<string>("Biografija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BracniStatusID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Drzavljanstvo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IznosPlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnikID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MjestoPrebivalista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MjestoRodjenja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PozicijaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RadnoIskustvo")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("SpolID")
                        .HasColumnType("int");

                    b.Property<string>("StrucnaSprema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VoazckaDozvolaKategorijaID")
                        .HasColumnType("int");

                    b.Property<string>("Zanimanje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BracniStatusID");

                    b.HasIndex("KorisnikID")
                        .IsUnique()
                        .HasFilter("[KorisnikID] IS NOT NULL");

                    b.HasIndex("PozicijaID");

                    b.HasIndex("SpolID");

                    b.HasIndex("VoazckaDozvolaKategorijaID");

                    b.ToTable("Uposlenici");
                });

            modelBuilder.Entity("LahorWebApp.Models.UpravnoOsoblje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktivan")
                        .HasColumnType("bit");

                    b.Property<string>("Biografija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BracniStatusID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Drzavljanstvo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IznosPlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnikID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MjestoPrebivalista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MjestoRodjenja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PozicijaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RadnoIskustvo")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("SpolID")
                        .HasColumnType("int");

                    b.Property<string>("StrucnaSprema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VoazckaDozvolaKategorijaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BracniStatusID");

                    b.HasIndex("KorisnikID")
                        .IsUnique()
                        .HasFilter("[KorisnikID] IS NOT NULL");

                    b.HasIndex("PozicijaID");

                    b.HasIndex("SpolID");

                    b.HasIndex("VoazckaDozvolaKategorijaID");

                    b.ToTable("UpravnoOsoblje");
                });

            modelBuilder.Entity("LahorWebApp.Models.VoazckaDozvolaKategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VozackaDozvolaKategorija");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LahorWebApp.Models.KlijentFizickoLice", b =>
                {
                    b.HasOne("LahorWebApp.Models.Korisnik", "Korisnik")
                        .WithOne("KlijentFizickoLice")
                        .HasForeignKey("LahorWebApp.Models.KlijentFizickoLice", "KorisnikID");

                    b.HasOne("LahorWebApp.Models.Spol", "Spol")
                        .WithMany()
                        .HasForeignKey("SpolID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Spol");
                });

            modelBuilder.Entity("LahorWebApp.Models.KlijentPravnoLice", b =>
                {
                    b.HasOne("LahorWebApp.Models.Korisnik", "Korisnik")
                        .WithOne("KlijentPravnoLice")
                        .HasForeignKey("LahorWebApp.Models.KlijentPravnoLice", "KorisnikID");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("LahorWebApp.Models.Uposlenik", b =>
                {
                    b.HasOne("LahorWebApp.Models.BracniStatus", "BracniStatus")
                        .WithMany()
                        .HasForeignKey("BracniStatusID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LahorWebApp.Models.Korisnik", "Korisnik")
                        .WithOne("Uposlenik")
                        .HasForeignKey("LahorWebApp.Models.Uposlenik", "KorisnikID");

                    b.HasOne("LahorWebApp.Models.Pozicija", "Pozicija")
                        .WithMany()
                        .HasForeignKey("PozicijaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LahorWebApp.Models.Spol", "Spol")
                        .WithMany()
                        .HasForeignKey("SpolID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LahorWebApp.Models.VoazckaDozvolaKategorija", "VoazckaDozvolaKategorija")
                        .WithMany()
                        .HasForeignKey("VoazckaDozvolaKategorijaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BracniStatus");

                    b.Navigation("Korisnik");

                    b.Navigation("Pozicija");

                    b.Navigation("Spol");

                    b.Navigation("VoazckaDozvolaKategorija");
                });

            modelBuilder.Entity("LahorWebApp.Models.UpravnoOsoblje", b =>
                {
                    b.HasOne("LahorWebApp.Models.BracniStatus", "BracniStatus")
                        .WithMany()
                        .HasForeignKey("BracniStatusID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LahorWebApp.Models.Korisnik", "Korisnik")
                        .WithOne("UpravnoOsoblje")
                        .HasForeignKey("LahorWebApp.Models.UpravnoOsoblje", "KorisnikID");

                    b.HasOne("LahorWebApp.Models.Pozicija", "Pozicija")
                        .WithMany()
                        .HasForeignKey("PozicijaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LahorWebApp.Models.Spol", "Spol")
                        .WithMany()
                        .HasForeignKey("SpolID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LahorWebApp.Models.VoazckaDozvolaKategorija", "VoazckaDozvolaKategorija")
                        .WithMany()
                        .HasForeignKey("VoazckaDozvolaKategorijaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BracniStatus");

                    b.Navigation("Korisnik");

                    b.Navigation("Pozicija");

                    b.Navigation("Spol");

                    b.Navigation("VoazckaDozvolaKategorija");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LahorWebApp.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LahorWebApp.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LahorWebApp.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LahorWebApp.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LahorWebApp.Models.Korisnik", b =>
                {
                    b.Navigation("KlijentFizickoLice");

                    b.Navigation("KlijentPravnoLice");

                    b.Navigation("Uposlenik");

                    b.Navigation("UpravnoOsoblje");
                });
#pragma warning restore 612, 618
        }
    }
}
