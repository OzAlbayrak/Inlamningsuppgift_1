using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift1WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedOrdarRowtableUPDATED : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderEntityId",
                table: "OrderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Products_ProductEntityId",
                table: "OrderRows");

            migrationBuilder.RenameColumn(
                name: "ProductEntityId",
                table: "OrderRows",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_ProductEntityId",
                table: "OrderRows",
                newName: "IX_OrderRows_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderEntityId",
                table: "OrderRows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderRows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderEntityId",
                table: "OrderRows",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Products_ProductId",
                table: "OrderRows",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderEntityId",
                table: "OrderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Products_ProductId",
                table: "OrderRows");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderRows");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderRows",
                newName: "ProductEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_ProductId",
                table: "OrderRows",
                newName: "IX_OrderRows_ProductEntityId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderEntityId",
                table: "OrderRows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderEntityId",
                table: "OrderRows",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Products_ProductEntityId",
                table: "OrderRows",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
