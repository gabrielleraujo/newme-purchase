using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Newme.Purchase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItemStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderItemStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    HasSummary = table.Column<bool>(type: "bit", nullable: false),
                    HasDiscountCoupon = table.Column<bool>(type: "bit", nullable: false),
                    DiscountCouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchseDiscountValue = table.Column<double>(type: "float", nullable: false),
                    FreightValue = table.Column<double>(type: "float", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Refund = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItem_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PurchaseOrderItemStatus",
                columns: new[] { "Id", "Description", "Status" },
                values: new object[,]
                {
                    { new Guid("1263d8ed-c935-443c-98b6-47c9a1a795b1"), "item de compra não aprovado porque o produto estava fora de estoque", 2 },
                    { new Guid("459ee5f1-f1f9-4820-be9c-5628e7a201c7"), "item de compra aprovado", 1 },
                    { new Guid("9566dea4-7c7e-41b1-97e4-1c7bef79adf8"), "item de compra criado", 0 },
                    { new Guid("e965659f-bd46-4483-b4a3-3647c2654246"), "item de compra parcialmente aprovado", 3 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseOrderStatus",
                columns: new[] { "Id", "Description", "Status" },
                values: new object[,]
                {
                    { new Guid("5d7b0f59-a59f-4766-926d-34786d4c0f5c"), "compra aprovada", 6 },
                    { new Guid("6e09a39b-3d6a-43d2-af97-196fc03fda77"), "pagamento autorizado", 2 },
                    { new Guid("a175401c-16e8-4bd2-a47e-5aa42282fad0"), "pagamento não autorizado", 3 },
                    { new Guid("b5a17818-693d-4b6a-af68-e525e88a3d23"), "validação do pagamento", 1 },
                    { new Guid("b7f9f558-8556-4b85-a516-6a92db138def"), "inicial", 0 },
                    { new Guid("cae60eb5-4217-4a8f-b200-f89ebd4e951f"), "compra não aprovada porque o produto estava fora de estoque", 4 },
                    { new Guid("ce5d3651-7b88-4ee0-8fbb-1b02f840a27b"), "compra aprovada com itens faltantes", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_BuyerId",
                table: "PurchaseOrder",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItem_ProductId",
                table: "PurchaseOrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItem_PurchaseOrderId",
                table: "PurchaseOrderItem",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItemStatus_Status",
                table: "PurchaseOrderItemStatus",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderStatus_Status",
                table: "PurchaseOrderStatus",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderItem");

            migrationBuilder.DropTable(
                name: "PurchaseOrderItemStatus");

            migrationBuilder.DropTable(
                name: "PurchaseOrderStatus");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Buyers");
        }
    }
}
