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
                name: "PurchaseOrderState",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderState", x => x.Id);
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
                    State = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
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
                    Quantity = table.Column<int>(type: "int", nullable: false)
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
                table: "PurchaseOrderState",
                columns: new[] { "Id", "Description", "State" },
                values: new object[,]
                {
                    { new Guid("21bb4140-62e7-4471-acb0-9d16914a7ae3"), "inicial", 0 },
                    { new Guid("25b66b8b-70c0-468e-9c08-3af7417b1c31"), "compra aprovada com itens faltantes", 5 },
                    { new Guid("5350a9b1-d7da-4609-b14b-3b7dcdf5e4dd"), "pagamento não autorizado", 3 },
                    { new Guid("911c3da3-707c-4572-a603-0213fcea3944"), "validação do pagamento", 1 },
                    { new Guid("a919b49f-c760-46e2-9655-587d999e87c5"), "pagamento autorizado", 2 },
                    { new Guid("cfbdac27-0ea4-4ffe-92b5-7115efc7052a"), "compra aprovada", 6 },
                    { new Guid("f137d268-b9f6-4d2e-9a25-7db78a2c86c0"), "compra não aprovada porque o produto estava fora de estoque", 4 }
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
                name: "IX_PurchaseOrderState_State",
                table: "PurchaseOrderState",
                column: "State");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderItem");

            migrationBuilder.DropTable(
                name: "PurchaseOrderState");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Buyers");
        }
    }
}
