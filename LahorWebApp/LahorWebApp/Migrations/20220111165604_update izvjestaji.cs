using Microsoft.EntityFrameworkCore.Migrations;

namespace LahorWebApp.Migrations
{
    public partial class updateizvjestaji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izvjestaji_Uposlenici_AutorUposlenikId",
                table: "Izvjestaji");

            migrationBuilder.DropForeignKey(
                name: "FK_Izvjestaji_UpravnoOsoblje_AutorUpravnoOsobljeId",
                table: "Izvjestaji");

            migrationBuilder.DropIndex(
                name: "IX_Izvjestaji_AutorUposlenikId",
                table: "Izvjestaji");

            migrationBuilder.DropColumn(
                name: "AutorUposlenikId",
                table: "Izvjestaji");

            migrationBuilder.RenameColumn(
                name: "AutorUpravnoOsobljeId",
                table: "Izvjestaji",
                newName: "AutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Izvjestaji_AutorUpravnoOsobljeId",
                table: "Izvjestaji",
                newName: "IX_Izvjestaji_AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Izvjestaji_Radnici_AutorId",
                table: "Izvjestaji",
                column: "AutorId",
                principalTable: "Radnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izvjestaji_Radnici_AutorId",
                table: "Izvjestaji");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Izvjestaji",
                newName: "AutorUpravnoOsobljeId");

            migrationBuilder.RenameIndex(
                name: "IX_Izvjestaji_AutorId",
                table: "Izvjestaji",
                newName: "IX_Izvjestaji_AutorUpravnoOsobljeId");

            migrationBuilder.AddColumn<int>(
                name: "AutorUposlenikId",
                table: "Izvjestaji",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Izvjestaji_AutorUposlenikId",
                table: "Izvjestaji",
                column: "AutorUposlenikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Izvjestaji_Uposlenici_AutorUposlenikId",
                table: "Izvjestaji",
                column: "AutorUposlenikId",
                principalTable: "Uposlenici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Izvjestaji_UpravnoOsoblje_AutorUpravnoOsobljeId",
                table: "Izvjestaji",
                column: "AutorUpravnoOsobljeId",
                principalTable: "UpravnoOsoblje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
