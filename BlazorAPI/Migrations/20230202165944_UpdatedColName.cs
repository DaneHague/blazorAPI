using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedColName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "explText",
                table: "Currency",
                newName: "rewardText");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rewardText",
                table: "Currency",
                newName: "explText");
        }
    }
}
