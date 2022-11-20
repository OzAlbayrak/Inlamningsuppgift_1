using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift1WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedOrdarRowtableUPDATEDwithOrderEntitydelited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderEntityId",
                table: "OrderRows");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderEntityId",
                table: "OrderRows");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderRows");

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
        }
    }
}
