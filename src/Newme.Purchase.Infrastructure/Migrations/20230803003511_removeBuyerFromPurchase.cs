using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Newme.Purchase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeBuyerFromPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PurchaseOrderItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("21ba27ae-e50a-4dd7-b2b6-1900e7e55669"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("6142f754-363f-48f3-a028-f54551e65c7e"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("825a3b7a-5bb3-4658-90d0-39eb8173662d"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("8f815c58-9cff-4a47-b57b-69dc5519f6a6"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("074fcaa5-3e0e-4e01-82a9-deeeb11e9f3d"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("5550bfb3-293e-4f53-ae42-9526ba0d99c7"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("5f2f5c6b-88e3-4b19-bf17-7debc787f83a"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("644652b9-d960-4dfe-ac5a-4f90131f59bb"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("eaceb864-7480-4c0b-9768-01c20a949357"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("ee54407f-032e-4f12-9b88-c34f2a76b8ca"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("f49e1709-a1c9-4310-a4d2-f9103350386a"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PurchaseOrderItemStatus",
                columns: new[] { "Id", "Description", "Status" },
                values: new object[,]
                {
                    { new Guid("21ba27ae-e50a-4dd7-b2b6-1900e7e55669"), "item de compra parcialmente aprovado", 3 },
                    { new Guid("6142f754-363f-48f3-a028-f54551e65c7e"), "item de compra aprovado", 1 },
                    { new Guid("825a3b7a-5bb3-4658-90d0-39eb8173662d"), "item de compra não aprovado porque o produto estava fora de estoque", 2 },
                    { new Guid("8f815c58-9cff-4a47-b57b-69dc5519f6a6"), "item de compra criado", 0 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseOrderStatus",
                columns: new[] { "Id", "Description", "Status" },
                values: new object[,]
                {
                    { new Guid("074fcaa5-3e0e-4e01-82a9-deeeb11e9f3d"), "compra aprovada", 6 },
                    { new Guid("5550bfb3-293e-4f53-ae42-9526ba0d99c7"), "validação do pagamento", 1 },
                    { new Guid("5f2f5c6b-88e3-4b19-bf17-7debc787f83a"), "compra aprovada com itens faltantes", 5 },
                    { new Guid("644652b9-d960-4dfe-ac5a-4f90131f59bb"), "inicial", 0 },
                    { new Guid("eaceb864-7480-4c0b-9768-01c20a949357"), "pagamento autorizado", 2 },
                    { new Guid("ee54407f-032e-4f12-9b88-c34f2a76b8ca"), "pagamento não autorizado", 3 },
                    { new Guid("f49e1709-a1c9-4310-a4d2-f9103350386a"), "compra não aprovada porque o produto estava fora de estoque", 4 }
                });
        }
    }
}
