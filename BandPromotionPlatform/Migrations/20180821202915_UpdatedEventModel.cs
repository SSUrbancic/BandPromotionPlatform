using Microsoft.EntityFrameworkCore.Migrations;

namespace BandPromotionPlatform.Migrations
{
    public partial class UpdatedEventModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddessLine2",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Event",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddessLine2",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Event");
        }
    }
}
