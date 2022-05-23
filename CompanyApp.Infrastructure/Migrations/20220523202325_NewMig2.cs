using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NewsDateGroupId",
                table: "MainTitle",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MainTitle_NewsDateGroupId",
                table: "MainTitle",
                column: "NewsDateGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainTitle_NewsDateGroups_NewsDateGroupId",
                table: "MainTitle",
                column: "NewsDateGroupId",
                principalTable: "NewsDateGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainTitle_NewsDateGroups_NewsDateGroupId",
                table: "MainTitle");

            migrationBuilder.DropIndex(
                name: "IX_MainTitle_NewsDateGroupId",
                table: "MainTitle");

            migrationBuilder.DropColumn(
                name: "NewsDateGroupId",
                table: "MainTitle");
        }
    }
}
