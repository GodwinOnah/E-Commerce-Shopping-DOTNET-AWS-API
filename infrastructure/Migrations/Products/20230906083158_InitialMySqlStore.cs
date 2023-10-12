using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations.Products
{
    /// <inheritdoc />
    public partial class InitialMySqlStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AlterDatabase()
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "Adverts",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         advert = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         time = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Adverts", x => x.id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "Delivery",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         delName = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         delTime = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         delDescription = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         delPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Delivery", x => x.id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "ProductBrand",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         Name = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_ProductBrand", x => x.id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "ProductType",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         Name = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_ProductType", x => x.id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "AdminOrder",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         adminOrderId = table.Column<int>(type: "int", nullable: false),
            //         Email = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_firstName = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_middleName = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_lastName = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_street = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_city = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_country = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_zipcode = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_phone = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         orderStatus = table.Column<string>(type: "longtext", nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         orderDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //         deliveryid = table.Column<int>(type: "int", nullable: true),
            //         confirmation = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AdminOrder", x => x.id);
            //         table.ForeignKey(
            //             name: "FK_AdminOrder_Delivery_deliveryid",
            //             column: x => x.deliveryid,
            //             principalTable: "Delivery",
            //             principalColumn: "id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "Order",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         Email = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         deliveryid = table.Column<int>(type: "int", nullable: true),
            //         address_firstName = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_middleName = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_lastName = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_street = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_city = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_country = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_zipcode = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         address_phone = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         orderStatus = table.Column<string>(type: "longtext", nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         orderDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //         subTotal = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
            //         paymentIntentId = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         confirmation = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Order", x => x.id);
            //         table.ForeignKey(
            //             name: "FK_Order_Delivery_deliveryid",
            //             column: x => x.deliveryid,
            //             principalTable: "Delivery",
            //             principalColumn: "id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "Products",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         prodName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         prodPicture = table.Column<string>(type: "longtext", nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         prodDescription = table.Column<string>(type: "longtext", nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         prodPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //         productBrandId = table.Column<int>(type: "int", nullable: false),
            //         productTypeId = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Products", x => x.id);
            //         table.ForeignKey(
            //             name: "FK_Products_ProductBrand_productBrandId",
            //             column: x => x.productBrandId,
            //             principalTable: "ProductBrand",
            //             principalColumn: "id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_Products_ProductType_productTypeId",
            //             column: x => x.productTypeId,
            //             principalTable: "ProductType",
            //             principalColumn: "id",
            //             onDelete: ReferentialAction.Cascade);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "ItemOrdered",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         productOrdered_id = table.Column<int>(type: "int", nullable: true),
            //         productOrdered_prodName = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         productOrdered_prodPicture = table.Column<string>(type: "longtext", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         itemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //         quantity = table.Column<int>(type: "int", nullable: false),
            //         AdminOrderid = table.Column<int>(type: "int", nullable: true),
            //         Orderid = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_ItemOrdered", x => x.id);
            //         table.ForeignKey(
            //             name: "FK_ItemOrdered_AdminOrder_AdminOrderid",
            //             column: x => x.AdminOrderid,
            //             principalTable: "AdminOrder",
            //             principalColumn: "id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_ItemOrdered_Order_Orderid",
            //             column: x => x.Orderid,
            //             principalTable: "Order",
            //             principalColumn: "id",
            //             onDelete: ReferentialAction.Cascade);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateIndex(
            //     name: "IX_AdminOrder_deliveryid",
            //     table: "AdminOrder",
            //     column: "deliveryid");

            // migrationBuilder.CreateIndex(
            //     name: "IX_ItemOrdered_AdminOrderid",
            //     table: "ItemOrdered",
            //     column: "AdminOrderid");

            // migrationBuilder.CreateIndex(
            //     name: "IX_ItemOrdered_Orderid",
            //     table: "ItemOrdered",
            //     column: "Orderid");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Order_deliveryid",
            //     table: "Order",
            //     column: "deliveryid");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Products_productBrandId",
            //     table: "Products",
            //     column: "productBrandId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Products_productTypeId",
            //     table: "Products",
            //     column: "productTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "ItemOrdered");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AdminOrder");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProductBrand");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Delivery");
        }
    }
}
