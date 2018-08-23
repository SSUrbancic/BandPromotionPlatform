using Microsoft.EntityFrameworkCore.Migrations;

namespace BandPromotionPlatform.Migrations
{
    public partial class nullablecustomerid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Customer_CustomerID",
                table: "Cart");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Cart",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Customer_CustomerID",
                table: "Cart",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Customer_CustomerID",
                table: "Cart");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Cart",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Customer_CustomerID",
                table: "Cart",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
