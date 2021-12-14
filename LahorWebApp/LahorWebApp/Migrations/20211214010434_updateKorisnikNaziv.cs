using Microsoft.EntityFrameworkCore.Migrations;

namespace LahorWebApp.Migrations
{
    public partial class updateKorisnikNaziv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "AspNetUsers");
        }
    }
}
