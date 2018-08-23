using Microsoft.EntityFrameworkCore.Migrations;

namespace BandPromotionPlatform.Migrations
{
    public partial class UpdateCusomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillingState",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingState",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingState",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ShippingState",
                table: "Customer");
        }
    }
}
