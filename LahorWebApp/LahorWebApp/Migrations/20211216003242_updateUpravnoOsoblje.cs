using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateUpravnoOsoblje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uposlenici_Pozicija_PozicijaID",
                table: "Uposlenici");

            migrationBuilder.DropForeignKey(
                name: "FK_UpravnoOsoblje_Pozicija_PozicijaID",
                table: "UpravnoOsoblje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pozicija",
                table: "Pozicija");

            migrationBuilder.RenameTable(
                name: "Pozicija",
                newName: "Pozicije");

            migrationBuilder.RenameColumn(
                name: "PozicijaID",
                table: "UpravnoOsoblje",
                newName: "PozicijaId");

            migrationBuilder.RenameIndex(
                name: "IX_UpravnoOsoblje_PozicijaID",
                table: "UpravnoOsoblje",
                newName: "IX_UpravnoOsoblje_PozicijaId");

            migrationBuilder.RenameColumn(
                name: "PozicijaID",
                table: "Uposlenici",
                newName: "PozicijaId");

            migrationBuilder.RenameIndex(
                name: "IX_Uposlenici_PozicijaID",
                table: "Uposlenici",
                newName: "IX_Uposlenici_PozicijaId");

            migrationBuilder.AlterColumn<string>(
                name: "Slika",
                table: "UpravnoOsoblje",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "IznosPlate",
                table: "UpravnoOsoblje",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PozicijaID",
                table: "UpravnoOsoblje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Slika",
                table: "Uposlenici",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "IznosPlate",
                table: "Uposlenici",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PozicijaID",
                table: "Uposlenici",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pozicije",
                table: "Pozicije",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Uposlenici_Pozicije_PozicijaId",
                table: "Uposlenici",
                column: "PozicijaId",
                principalTable: "Pozicije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpravnoOsoblje_Pozicije_PozicijaId",
                table: "UpravnoOsoblje",
                column: "PozicijaId",
                principalTable: "Pozicije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uposlenici_Pozicije_PozicijaId",
                table: "Uposlenici");

            migrationBuilder.DropForeignKey(
                name: "FK_UpravnoOsoblje_Pozicije_PozicijaId",
                table: "UpravnoOsoblje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pozicije",
                table: "Pozicije");

            migrationBuilder.DropColumn(
                name: "PozicijaID",
                table: "UpravnoOsoblje");

            migrationBuilder.DropColumn(
                name: "PozicijaID",
                table: "Uposlenici");

            migrationBuilder.RenameTable(
                name: "Pozicije",
                newName: "Pozicija");

            migrationBuilder.RenameColumn(
                name: "PozicijaId",
                table: "UpravnoOsoblje",
                newName: "PozicijaID");

            migrationBuilder.RenameIndex(
                name: "IX_UpravnoOsoblje_PozicijaId",
                table: "UpravnoOsoblje",
                newName: "IX_UpravnoOsoblje_PozicijaID");

            migrationBuilder.RenameColumn(
                name: "PozicijaId",
                table: "Uposlenici",
                newName: "PozicijaID");

            migrationBuilder.RenameIndex(
                name: "IX_Uposlenici_PozicijaId",
                table: "Uposlenici",
                newName: "IX_Uposlenici_PozicijaID");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Slika",
                table: "UpravnoOsoblje",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IznosPlate",
                table: "UpravnoOsoblje",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Slika",
                table: "Uposlenici",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IznosPlate",
                table: "Uposlenici",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pozicija",
                table: "Pozicija",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Uposlenici_Pozicija_PozicijaID",
                table: "Uposlenici",
                column: "PozicijaID",
                principalTable: "Pozicija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpravnoOsoblje_Pozicija_PozicijaID",
                table: "UpravnoOsoblje",
                column: "PozicijaID",
                principalTable: "Pozicija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
