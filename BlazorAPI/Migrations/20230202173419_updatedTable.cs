using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "descrText",
                table: "Currency",
                newName: "cardText");

            migrationBuilder.AddColumn<string>(
                name: "artFilename",
                table: "Currency",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "artFilename",
                table: "Currency");

            migrationBuilder.RenameColumn(
                name: "cardText",
                table: "Currency",
                newName: "descrText");
        }
    }
}
