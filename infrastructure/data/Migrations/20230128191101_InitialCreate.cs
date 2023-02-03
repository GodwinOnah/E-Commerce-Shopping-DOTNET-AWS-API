using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductBrand",
                columns: table => new
                {
                    productId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrand", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    productId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    prodName = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    prodPicture = table.Column<string>(type: "TEXT", nullable: false),
                    prodDescription = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    prodPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    productBrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    productTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrand_productBrandId",
                        column: x => x.productBrandId,
                        principalTable: "ProductBrand",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductType_productTypeId",
                        column: x => x.productTypeId,
                        principalTable: "ProductType",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_productBrandId",
                table: "Products",
                column: "productBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_productTypeId",
                table: "Products",
                column: "productTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductBrand");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
