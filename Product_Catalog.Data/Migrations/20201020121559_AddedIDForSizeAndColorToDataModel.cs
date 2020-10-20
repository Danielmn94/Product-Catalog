using Microsoft.EntityFrameworkCore.Migrations;

namespace Product_Catalog.Data.Migrations
{
    public partial class AddedIDForSizeAndColorToDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorID",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SizeID",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SizeID",
                table: "Products");
        }
    }
}
