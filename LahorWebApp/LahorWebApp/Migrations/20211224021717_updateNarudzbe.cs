using Microsoft.EntityFrameworkCore.Migrations;

namespace LahorWebApp.Migrations
{
    public partial class updateNarudzbe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NazivKlijenta",
                table: "Narudzbe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isGuest",
                table: "Narudzbe",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isNarudzbaAutor",
                table: "Narudzbe",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isOnline",
                table: "Narudzbe",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NazivKlijenta",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "isGuest",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "isNarudzbaAutor",
                table: "Narudzbe");

            migrationBuilder.DropColumn(
                name: "isOnline",
                table: "Narudzbe");
        }
    }
}
