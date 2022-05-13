using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prediction",
                table: "MainTitle",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Probability",
                table: "MainTitle",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prediction",
                table: "MainTitle");

            migrationBuilder.DropColumn(
                name: "Probability",
                table: "MainTitle");
        }
    }
}
