using Microsoft.EntityFrameworkCore.Migrations;

namespace Product_Catalog.Data.Migrations
{
    public partial class ProductModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ColorName = table.Column<string>(nullable: true),
                    SizeName = table.Column<string>(nullable: true),
                    Sustainable = table.Column<bool>(nullable: false),
                    ItemNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
