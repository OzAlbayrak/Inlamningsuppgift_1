using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift1WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedOrdarRowtableUPDATEDwithProduct5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEntityOrderRowEntity");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows");

            migrationBuilder.DropIndex(
                name: "IX_OrderRows_OrderId",
                table: "OrderRows");

            migrationBuilder.CreateTable(
                name: "OrderEntityOrderRowEntity",
                columns: table => new
                {
                    OrderRowsId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntityOrderRowEntity", x => new { x.OrderRowsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrderEntityOrderRowEntity_OrderRows_OrderRowsId",
                        column: x => x.OrderRowsId,
                        principalTable: "OrderRows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEntityOrderRowEntity_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntityOrderRowEntity_OrdersId",
                table: "OrderEntityOrderRowEntity",
                column: "OrdersId");
        }
    }
}
