using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "explicitMods",
                table: "DivinationCard");

            migrationBuilder.DropColumn(
                name: "flavourText",
                table: "DivinationCard");

            migrationBuilder.DropColumn(
                name: "properties",
                table: "DivinationCard");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "explicitMods",
                table: "DivinationCard",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "flavourText",
                table: "DivinationCard",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "properties",
                table: "DivinationCard",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
