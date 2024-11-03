using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCashier.Data.Migrations
{
    /// <inheritdoc />
    public partial class ItemOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Items_ItemsId",
                table: "ItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Orders_OrdersId",
                table: "ItemOrder");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "ItemOrder",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "ItemsId",
                table: "ItemOrder",
                newName: "ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrder_OrdersId",
                table: "ItemOrder",
                newName: "IX_ItemOrder_OrderID");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ItemOrder",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Items_ItemID",
                table: "ItemOrder",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Orders_OrderID",
                table: "ItemOrder",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Items_ItemID",
                table: "ItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Orders_OrderID",
                table: "ItemOrder");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ItemOrder");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "ItemOrder",
                newName: "OrdersId");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "ItemOrder",
                newName: "ItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrder_OrderID",
                table: "ItemOrder",
                newName: "IX_ItemOrder_OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Items_ItemsId",
                table: "ItemOrder",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Orders_OrdersId",
                table: "ItemOrder",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
