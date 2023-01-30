using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lahor.Infrastructure.Migrations
{
    public partial class updateUserAndPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_MarriageStatus_MarriageStatusId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "MarriageStatus");

            migrationBuilder.DropIndex(
                name: "IX_Persons_MarriageStatusId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "MarriageStatusId",
                table: "Persons",
                newName: "MarriageStatus");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "MarriageStatus",
                table: "Persons",
                newName: "MarriageStatusId");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MarriageStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarriageStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MarriageStatusId",
                table: "Persons",
                column: "MarriageStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_MarriageStatus_MarriageStatusId",
                table: "Persons",
                column: "MarriageStatusId",
                principalTable: "MarriageStatus",
                principalColumn: "Id");
        }
    }
}
