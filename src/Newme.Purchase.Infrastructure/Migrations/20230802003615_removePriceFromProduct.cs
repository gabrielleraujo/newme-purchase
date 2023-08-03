using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Newme.Purchase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removePriceFromProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PurchaseOrderItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("03ff1480-c28f-4623-ad38-81e309a1af92"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("29b9f3d0-bf01-4a2b-9158-eab7a3459cef"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("32e7c7a8-9dd7-4876-be2c-0458898ffdc3"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("db86646d-3df0-45fc-aef3-5eec6c6066a6"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("2a648e98-1d49-4046-bc26-14b66abc12ba"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("5454ae22-79c4-4503-a0f8-70660f1c420c"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("62035222-000c-46e0-9d95-4b714c705b9c"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("87db6fb7-cd83-4344-8c70-7d26088a99dd"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("b6b7750a-b072-467a-a8ce-00a125dbdcd6"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("c63ca995-baa7-4bb0-b769-a1f60e539c60"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("f203118e-ba12-48dd-a516-7b7036dfd140"));

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.InsertData(
                table: "PurchaseOrderItemStatus",
                columns: new[] { "Id", "Description", "Status" },
                values: new object[,]
                {
                    { new Guid("016793a3-dd06-4533-87a5-d5d44251b418"), "item de compra parcialmente aprovado", 3 },
                    { new Guid("648ee8d4-e16e-4b06-b20d-de77f13b29c9"), "item de compra não aprovado porque o produto estava fora de estoque", 2 },
                    { new Guid("c070b697-8ea1-4ae3-98b0-a1e6d10b117b"), "item de compra criado", 0 },
                    { new Guid("c7bee533-19e9-457e-9bab-bd1038ef486b"), "item de compra aprovado", 1 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseOrderStatus",
                columns: new[] { "Id", "Description", "Status" },
                values: new object[,]
                {
                    { new Guid("0b779177-2467-48d9-980f-6f64cbe3b828"), "pagamento não autorizado", 3 },
                    { new Guid("43e8604b-064d-47a0-a8d6-34148d6cf23b"), "compra aprovada com itens faltantes", 5 },
                    { new Guid("5be51086-a19c-4dab-9ec1-4dd2996cfe41"), "pagamento autorizado", 2 },
                    { new Guid("9377149a-77a4-4849-b4fd-14520e096737"), "compra não aprovada porque o produto estava fora de estoque", 4 },
                    { new Guid("b159c09c-a785-4a8c-91be-f95b6bb0f6cf"), "compra aprovada", 6 },
                    { new Guid("e016e397-0371-46cd-abf9-32c3862ff33e"), "validação do pagamento", 1 },
                    { new Guid("ffc43c28-2a5d-471b-b70c-49d42fbf6d5d"), "inicial", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PurchaseOrderItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("016793a3-dd06-4533-87a5-d5d44251b418"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("648ee8d4-e16e-4b06-b20d-de77f13b29c9"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("c070b697-8ea1-4ae3-98b0-a1e6d10b117b"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderItemStatus",
                keyColumn: "Id",
                keyValue: new Guid("c7bee533-19e9-457e-9bab-bd1038ef486b"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("0b779177-2467-48d9-980f-6f64cbe3b828"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("43e8604b-064d-47a0-a8d6-34148d6cf23b"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("5be51086-a19c-4dab-9ec1-4dd2996cfe41"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("9377149a-77a4-4849-b4fd-14520e096737"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("b159c09c-a785-4a8c-91be-f95b6bb0f6cf"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("e016e397-0371-46cd-abf9-32c3862ff33e"));

            migrationBuilder.DeleteData(
                table: "PurchaseOrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("ffc43c28-2a5d-471b-b70c-49d42fbf6d5d"));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "PurchaseOrderItemStatus",
                columns: new[] { "Id", "Description", "Status" },
                values: new object[,]
                {
                    { new Guid("03ff1480-c28f-4623-ad38-81e309a1af92"), "item de compra parcialmente aprovado", 3 },
                    { new Guid("29b9f3d0-bf01-4a2b-9158-eab7a3459cef"), "item de compra aprovado", 1 },
                    { new Guid("32e7c7a8-9dd7-4876-be2c-0458898ffdc3"), "item de compra criado", 0 },
                    { new Guid("db86646d-3df0-45fc-aef3-5eec6c6066a6"), "item de compra não aprovado porque o produto estava fora de estoque", 2 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseOrderStatus",
                columns: new[] { "Id", "Description", "Status" },
                values: new object[,]
                {
                    { new Guid("2a648e98-1d49-4046-bc26-14b66abc12ba"), "pagamento autorizado", 2 },
                    { new Guid("5454ae22-79c4-4503-a0f8-70660f1c420c"), "compra não aprovada porque o produto estava fora de estoque", 4 },
                    { new Guid("62035222-000c-46e0-9d95-4b714c705b9c"), "validação do pagamento", 1 },
                    { new Guid("87db6fb7-cd83-4344-8c70-7d26088a99dd"), "compra aprovada", 6 },
                    { new Guid("b6b7750a-b072-467a-a8ce-00a125dbdcd6"), "inicial", 0 },
                    { new Guid("c63ca995-baa7-4bb0-b769-a1f60e539c60"), "pagamento não autorizado", 3 },
                    { new Guid("f203118e-ba12-48dd-a516-7b7036dfd140"), "compra aprovada com itens faltantes", 5 }
                });
        }
    }
}
