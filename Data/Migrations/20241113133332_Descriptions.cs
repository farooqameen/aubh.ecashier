using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCashier.Data.Migrations
{
    /// <inheritdoc />
    public partial class Descriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Items",
                newName: "InternalDescription");

            migrationBuilder.AddColumn<string>(
                name: "ExternalDescription",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalDescription",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "InternalDescription",
                table: "Items",
                newName: "Description");
        }
    }
}
