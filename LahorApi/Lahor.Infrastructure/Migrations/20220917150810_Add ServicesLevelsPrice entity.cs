using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lahor.Infrastructure.Migrations
{
    public partial class AddServicesLevelsPriceentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicesLevelsPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    LevelOfServiceExecutionId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesLevelsPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesLevelsPrice_LevelOfServiceExecution_LevelOfServiceExecutionId",
                        column: x => x.LevelOfServiceExecutionId,
                        principalTable: "LevelOfServiceExecution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesLevelsPrice_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicesLevelsPrice_LevelOfServiceExecutionId",
                table: "ServicesLevelsPrice",
                column: "LevelOfServiceExecutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesLevelsPrice_ServiceId",
                table: "ServicesLevelsPrice",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicesLevelsPrice");
        }
    }
}
