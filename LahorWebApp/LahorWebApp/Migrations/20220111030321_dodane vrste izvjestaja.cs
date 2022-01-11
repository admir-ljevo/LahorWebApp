using Microsoft.EntityFrameworkCore.Migrations;

namespace LahorWebApp.Migrations
{
    public partial class dodanevrsteizvjestaja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izvjestaji_VrstaIzvjestaja_VrstaIzvjestajaId",
                table: "Izvjestaji");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VrstaIzvjestaja",
                table: "VrstaIzvjestaja");

            migrationBuilder.RenameTable(
                name: "VrstaIzvjestaja",
                newName: "VrsteIzvjestaja");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VrsteIzvjestaja",
                table: "VrsteIzvjestaja",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Izvjestaji_VrsteIzvjestaja_VrstaIzvjestajaId",
                table: "Izvjestaji",
                column: "VrstaIzvjestajaId",
                principalTable: "VrsteIzvjestaja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izvjestaji_VrsteIzvjestaja_VrstaIzvjestajaId",
                table: "Izvjestaji");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VrsteIzvjestaja",
                table: "VrsteIzvjestaja");

            migrationBuilder.RenameTable(
                name: "VrsteIzvjestaja",
                newName: "VrstaIzvjestaja");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VrstaIzvjestaja",
                table: "VrstaIzvjestaja",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Izvjestaji_VrstaIzvjestaja_VrstaIzvjestajaId",
                table: "Izvjestaji",
                column: "VrstaIzvjestajaId",
                principalTable: "VrstaIzvjestaja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
