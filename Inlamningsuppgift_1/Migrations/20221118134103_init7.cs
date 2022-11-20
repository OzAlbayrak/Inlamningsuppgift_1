using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift1WebApi.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows");

            migrationBuilder.DropIndex(
                name: "IX_OrderRows_OrderId",
                table: "OrderRows");

            migrationBuilder.AddColumn<int>(
                name: "OrderEntityId",
                table: "OrderRows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderRows_OrderEntityId",
                table: "OrderRows",
                column: "OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderEntityId",
                table: "OrderRows",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderEntityId",
                table: "OrderRows");

            migrationBuilder.DropIndex(
                name: "IX_OrderRows_OrderEntityId",
                table: "OrderRows");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "OrderRows");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRows_OrderId",
                table: "OrderRows",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
