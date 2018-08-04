using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySneakerWishList.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shoes_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoeMenus",
                columns: table => new
                {
                    MenuID = table.Column<int>(nullable: false),
                    ShoeID = table.Column<int>(nullable: false),
                    ShoeMenuMenuID = table.Column<int>(nullable: true),
                    ShoeMenuShoeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeMenus", x => new { x.ShoeID, x.MenuID });
                    table.ForeignKey(
                        name: "FK_ShoeMenus_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeMenus_Shoes_ShoeID",
                        column: x => x.ShoeID,
                        principalTable: "Shoes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeMenus_ShoeMenus_ShoeMenuShoeID_ShoeMenuMenuID",
                        columns: x => new { x.ShoeMenuShoeID, x.ShoeMenuMenuID },
                        principalTable: "ShoeMenus",
                        principalColumns: new[] { "ShoeID", "MenuID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeMenus_MenuID",
                table: "ShoeMenus",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeMenus_ShoeMenuShoeID_ShoeMenuMenuID",
                table: "ShoeMenus",
                columns: new[] { "ShoeMenuShoeID", "ShoeMenuMenuID" });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_CategoryID",
                table: "Shoes",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoeMenus");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
