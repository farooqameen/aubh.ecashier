using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCashier.Data.Migrations
{
    /// <inheritdoc />
    public partial class CheckoutUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheckoutUrl",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckoutUrl",
                table: "Orders");
        }
    }
}
