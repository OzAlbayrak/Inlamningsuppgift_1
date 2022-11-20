using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift1WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedOrdarRowtableUPDATEDwithEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Products_ProductId",
                table: "OrderRows");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderRows",
                newName: "ProductEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_ProductId",
                table: "OrderRows",
                newName: "IX_OrderRows_ProductEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Products_ProductEntityId",
                table: "OrderRows",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Products_ProductId",
                table: "OrderRows",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
