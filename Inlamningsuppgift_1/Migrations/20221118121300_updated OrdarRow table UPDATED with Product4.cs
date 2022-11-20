using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift1WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedOrdarRowtableUPDATEDwithProduct4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "OrderRowId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEntityOrderRowEntity");

            migrationBuilder.DropColumn(
                name: "OrderRowId",
                table: "Orders");

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
    }
}
