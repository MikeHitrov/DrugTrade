using Microsoft.EntityFrameworkCore.Migrations;

namespace DrugTrade.Data.Migrations
{
    public partial class ProductFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Мanufacturer",
                table: "Products",
                newName: "Мanifacturer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Мanifacturer",
                table: "Products",
                newName: "Мanufacturer");
        }
    }
}
