using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift1WebApi.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderEntityId",
                table: "OrderRows",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
