using System;
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
            // migrationBuilder.CreateTable(
            //     name: "Adverts",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         advert = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         time = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Adverts", x => x.id);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Delivery",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         delName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         delTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         delDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         delPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Delivery", x => x.id);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "ProductBrand",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_ProductBrand", x => x.id);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "ProductType",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_ProductType", x => x.id);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "AdminOrder",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         adminOrderId = table.Column<int>(type: "int", nullable: false),
            //         Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_street = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_city = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_country = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         orderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //         deliveryid = table.Column<int>(type: "int", nullable: true),
            //         confirmation = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AdminOrder", x => x.id);
            //         table.ForeignKey(
            //             name: "FK_AdminOrder_Delivery_deliveryid",
            //             column: x => x.deliveryid,
            //             principalTable: "Delivery",
            //             principalColumn: "id");
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Order",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         deliveryid = table.Column<int>(type: "int", nullable: true),
            //         address_firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_street = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_city = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_country = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         address_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         orderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //         subTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //         paymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         confirmation = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Order", x => x.id);
            //         table.ForeignKey(
            //             name: "FK_Order_Delivery_deliveryid",
            //             column: x => x.deliveryid,
            //             principalTable: "Delivery",
            //             principalColumn: "id");
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Products",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         prodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //         prodPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         prodDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
            //     });

            // migrationBuilder.CreateTable(
            //     name: "ItemOrdered",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         productOrdered_id = table.Column<int>(type: "int", nullable: true),
            //         productOrdered_prodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         productOrdered_prodPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
            //     });

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
