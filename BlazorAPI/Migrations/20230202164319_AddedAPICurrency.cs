using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedAPICurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    verified = table.Column<bool>(type: "bit", nullable: false),
                    w = table.Column<int>(type: "int", nullable: false),
                    h = table.Column<int>(type: "int", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stackSize = table.Column<int>(type: "int", nullable: false),
                    maxStackSize = table.Column<int>(type: "int", nullable: false),
                    league = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typeLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    baseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    identified = table.Column<bool>(type: "bit", nullable: false),
                    ilvl = table.Column<int>(type: "int", nullable: false),
                    explText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descrText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    frameType = table.Column<int>(type: "int", nullable: false),
                    x = table.Column<int>(type: "int", nullable: false),
                    y = table.Column<int>(type: "int", nullable: false),
                    inventoryId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
