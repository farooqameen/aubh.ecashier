using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCashier.Data.Migrations
{
    /// <inheritdoc />
    public partial class ItemOrderJoin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ItemOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitPrice",
                table: "ItemOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ItemOrder");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "ItemOrder");
        }
    }
}
