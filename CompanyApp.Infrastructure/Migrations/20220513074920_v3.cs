using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prediction",
                table: "MusEvent",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Probability",
                table: "MusEvent",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Prediction",
                table: "EventPlace",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Probability",
                table: "EventPlace",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prediction",
                table: "MusEvent");

            migrationBuilder.DropColumn(
                name: "Probability",
                table: "MusEvent");

            migrationBuilder.DropColumn(
                name: "Prediction",
                table: "EventPlace");

            migrationBuilder.DropColumn(
                name: "Probability",
                table: "EventPlace");
        }
    }
}
