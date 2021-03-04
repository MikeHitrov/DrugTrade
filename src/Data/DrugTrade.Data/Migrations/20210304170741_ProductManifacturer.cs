using Microsoft.EntityFrameworkCore.Migrations;

namespace DrugTrade.Data.Migrations
{
    public partial class ProductManifacturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Мanufacturer",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Мanufacturer",
                table: "Products");
        }
    }
}
