using Microsoft.EntityFrameworkCore.Migrations;

namespace PierreSweets.Migrations
{
    public partial class AddOrderTreatToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treats_Orders_OrderId",
                table: "Treats");

            migrationBuilder.DropIndex(
                name: "IX_Treats_OrderId",
                table: "Treats");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Treats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Treats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treats_OrderId",
                table: "Treats",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treats_Orders_OrderId",
                table: "Treats",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
