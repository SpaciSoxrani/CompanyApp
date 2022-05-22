using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusEvent");

            migrationBuilder.DropTable(
                name: "EventPlace");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventPlace",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Prediction = table.Column<string>(type: "text", nullable: false),
                    Probability = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusEvent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    eventPlaceId = table.Column<string>(type: "text", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: true),
                    IsComplete = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Prediction = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Probability = table.Column<double>(type: "double precision", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusEvent_EventPlace_eventPlaceId",
                        column: x => x.eventPlaceId,
                        principalTable: "EventPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusEvent_eventPlaceId",
                table: "MusEvent",
                column: "eventPlaceId");
        }
    }
}
