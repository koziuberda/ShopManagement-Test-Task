using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "FullName", "RegistrationDate" },
                values: new object[,]
                {
                    { new Guid("8b955699-5414-4a79-839c-75abde655ef4"), new DateTime(1975, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill Johnson", new DateTime(2024, 9, 6, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8680) },
                    { new Guid("8fc409f4-a743-466b-95a3-553d818ae949"), new DateTime(1995, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna Williams", new DateTime(2024, 9, 6, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8681) },
                    { new Guid("b9288f91-0bcd-4835-a1a0-d366d8acacb5"), new DateTime(1990, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith", new DateTime(2024, 9, 6, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8678) },
                    { new Guid("bc9174cb-fdf0-4e6c-be1d-ec71e7c00831"), new DateTime(1980, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Brown", new DateTime(2024, 9, 6, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8683) },
                    { new Guid("be7a13fa-f221-47ae-a5d5-ac0c7fee0287"), new DateTime(1985, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", new DateTime(2024, 9, 6, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8670) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { new Guid("076e214f-d0e6-4390-ba95-cbca4f357bb8"), "Electronics", "Smartphone", 800m, "SPH456" },
                    { new Guid("0c6816a9-f275-48a4-b8a1-15b05b629db5"), "KitchenAppliances", "Microwave", 150m, "MW456" },
                    { new Guid("26e73e23-3208-41b2-a830-8bfcaa96cfd6"), "Sports", "Basketball", 50m, "BB123" },
                    { new Guid("515f2380-8f7f-4a31-8d8d-d2942bf4d51b"), "Sports", "Running Shoes", 80m, "RS789" },
                    { new Guid("b982edb0-6a9f-4d55-9cd8-17849cae91cc"), "Electronics", "Laptop", 1500m, "LPT123" },
                    { new Guid("baee2f86-ca43-4485-aad0-1fa410905c7e"), "Furniture", "Dining Table", 300m, "DT456" },
                    { new Guid("c511d84d-a634-4844-9d12-69fb1f2afc27"), "Electronics", "Tablet", 600m, "TBL789" },
                    { new Guid("d06af2f1-2ef3-422d-903f-17f3cc1b457a"), "HomeAppliances", "Vacuum Cleaner", 200m, "VC123" },
                    { new Guid("e614d34a-4391-4f0d-bc85-3bc65bdc3d91"), "Furniture", "Office Chair", 120m, "CH123" },
                    { new Guid("f4eb1d6e-608c-4d56-969e-90158560c858"), "KitchenAppliances", "Blender", 90m, "BL123" }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CustomerId", "Date", "Number", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("02b432ac-ff22-4ce3-aba5-535e3d34851f"), new Guid("bc9174cb-fdf0-4e6c-be1d-ec71e7c00831"), new DateTime(2024, 7, 8, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8871), "ORD2291", 2400m },
                    { new Guid("121bb3b9-4f9d-42c4-ac97-1b67c754c537"), new Guid("8b955699-5414-4a79-839c-75abde655ef4"), new DateTime(2024, 8, 5, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8841), "ORD3114", 3100m },
                    { new Guid("18e5e266-7b83-4ace-abf3-933443ccbe38"), new Guid("8fc409f4-a743-466b-95a3-553d818ae949"), new DateTime(2024, 6, 29, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8849), "ORD1978", 900m },
                    { new Guid("5b8a66de-3131-4619-adec-06fd4351c7e6"), new Guid("b9288f91-0bcd-4835-a1a0-d366d8acacb5"), new DateTime(2024, 6, 11, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8776), "ORD3049", 6690m },
                    { new Guid("85541de5-7d0c-409a-92bf-d78033473efc"), new Guid("be7a13fa-f221-47ae-a5d5-ac0c7fee0287"), new DateTime(2024, 6, 29, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8767), "ORD4742", 1290m },
                    { new Guid("8f6715f6-f377-413c-93ce-a5f15cee4576"), new Guid("8b955699-5414-4a79-839c-75abde655ef4"), new DateTime(2024, 7, 11, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8832), "ORD6078", 1260m },
                    { new Guid("9f04d3f7-44a5-478d-b51f-a673f926c4ca"), new Guid("8b955699-5414-4a79-839c-75abde655ef4"), new DateTime(2024, 6, 26, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8825), "ORD3605", 3200m },
                    { new Guid("eac094d5-67a5-49e3-815e-7c36fd87c4cd"), new Guid("bc9174cb-fdf0-4e6c-be1d-ec71e7c00831"), new DateTime(2024, 8, 22, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8864), "ORD1990", 4000m },
                    { new Guid("f27e7e8d-d10e-4560-ad16-7120b62a0ef9"), new Guid("be7a13fa-f221-47ae-a5d5-ac0c7fee0287"), new DateTime(2024, 7, 18, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8740), "ORD5714", 400m },
                    { new Guid("faa790fe-059d-4b97-947c-9d0165817678"), new Guid("8fc409f4-a743-466b-95a3-553d818ae949"), new DateTime(2024, 8, 11, 23, 36, 6, 351, DateTimeKind.Local).AddTicks(8859), "ORD6987", 320m }
                });

            migrationBuilder.InsertData(
                table: "PurchaseItems",
                columns: new[] { "Id", "ProductId", "PurchaseId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("02ceb7d8-fd09-410a-82ff-c8c0e43ba5d5"), new Guid("baee2f86-ca43-4485-aad0-1fa410905c7e"), new Guid("8f6715f6-f377-413c-93ce-a5f15cee4576"), 3 },
                    { new Guid("0889c5da-a529-4161-939f-798db4ebca64"), new Guid("26e73e23-3208-41b2-a830-8bfcaa96cfd6"), new Guid("f27e7e8d-d10e-4560-ad16-7120b62a0ef9"), 2 },
                    { new Guid("2ee8a6ff-a994-4621-bd81-6f5fa32b97ac"), new Guid("f4eb1d6e-608c-4d56-969e-90158560c858"), new Guid("18e5e266-7b83-4ace-abf3-933443ccbe38"), 2 },
                    { new Guid("3c4220ac-b9f3-41f8-854f-cd5a10d132ed"), new Guid("0c6816a9-f275-48a4-b8a1-15b05b629db5"), new Guid("121bb3b9-4f9d-42c4-ac97-1b67c754c537"), 2 },
                    { new Guid("46d4ffe9-8afa-4434-a0e0-cff05e42ec3e"), new Guid("c511d84d-a634-4844-9d12-69fb1f2afc27"), new Guid("121bb3b9-4f9d-42c4-ac97-1b67c754c537"), 2 },
                    { new Guid("52fa920b-c75f-42fe-95de-d14f5728aa75"), new Guid("f4eb1d6e-608c-4d56-969e-90158560c858"), new Guid("85541de5-7d0c-409a-92bf-d78033473efc"), 1 },
                    { new Guid("6e9e3c03-d9c9-48bc-a8dd-d23150784a01"), new Guid("d06af2f1-2ef3-422d-903f-17f3cc1b457a"), new Guid("eac094d5-67a5-49e3-815e-7c36fd87c4cd"), 4 },
                    { new Guid("6f70c8d1-03c4-4ea0-83a4-c54cead0e747"), new Guid("515f2380-8f7f-4a31-8d8d-d2942bf4d51b"), new Guid("faa790fe-059d-4b97-947c-9d0165817678"), 4 },
                    { new Guid("6f9fdb48-d8b0-47ee-8d71-f2ad7d391f4f"), new Guid("076e214f-d0e6-4390-ba95-cbca4f357bb8"), new Guid("eac094d5-67a5-49e3-815e-7c36fd87c4cd"), 4 },
                    { new Guid("7abfe1bf-a8d8-463c-adba-534dd15059bf"), new Guid("baee2f86-ca43-4485-aad0-1fa410905c7e"), new Guid("18e5e266-7b83-4ace-abf3-933443ccbe38"), 2 },
                    { new Guid("7bca26cf-4a07-4233-a971-df3650c22643"), new Guid("e614d34a-4391-4f0d-bc85-3bc65bdc3d91"), new Guid("18e5e266-7b83-4ace-abf3-933443ccbe38"), 1 },
                    { new Guid("7ef393f2-e5e2-49e6-b7bc-6cbc6b269483"), new Guid("0c6816a9-f275-48a4-b8a1-15b05b629db5"), new Guid("5b8a66de-3131-4619-adec-06fd4351c7e6"), 3 },
                    { new Guid("87a87833-beb8-4279-a303-41715455465b"), new Guid("d06af2f1-2ef3-422d-903f-17f3cc1b457a"), new Guid("9f04d3f7-44a5-478d-b51f-a673f926c4ca"), 1 },
                    { new Guid("90008a03-f2de-4425-8d93-d0152be7675e"), new Guid("076e214f-d0e6-4390-ba95-cbca4f357bb8"), new Guid("121bb3b9-4f9d-42c4-ac97-1b67c754c537"), 2 },
                    { new Guid("bb575500-0fad-4a72-bc1f-545d09710c40"), new Guid("b982edb0-6a9f-4d55-9cd8-17849cae91cc"), new Guid("9f04d3f7-44a5-478d-b51f-a673f926c4ca"), 2 },
                    { new Guid("c2d85958-e428-4e1a-ae95-8a182cdc3f4d"), new Guid("e614d34a-4391-4f0d-bc85-3bc65bdc3d91"), new Guid("5b8a66de-3131-4619-adec-06fd4351c7e6"), 2 },
                    { new Guid("cd0b3239-7020-40d6-b18b-bb6e28a2f46e"), new Guid("baee2f86-ca43-4485-aad0-1fa410905c7e"), new Guid("85541de5-7d0c-409a-92bf-d78033473efc"), 4 },
                    { new Guid("dd425354-2d99-4cb6-9be5-8b2dd9f5816e"), new Guid("076e214f-d0e6-4390-ba95-cbca4f357bb8"), new Guid("02b432ac-ff22-4ce3-aba5-535e3d34851f"), 3 },
                    { new Guid("e21896d1-d36c-41e6-912b-d413b4c920b5"), new Guid("f4eb1d6e-608c-4d56-969e-90158560c858"), new Guid("8f6715f6-f377-413c-93ce-a5f15cee4576"), 4 },
                    { new Guid("ecc296fb-7a57-47df-9b9c-e22197d8395b"), new Guid("e614d34a-4391-4f0d-bc85-3bc65bdc3d91"), new Guid("f27e7e8d-d10e-4560-ad16-7120b62a0ef9"), 1 },
                    { new Guid("f01792d3-691f-4c50-8281-38a48a23c413"), new Guid("f4eb1d6e-608c-4d56-969e-90158560c858"), new Guid("f27e7e8d-d10e-4560-ad16-7120b62a0ef9"), 2 },
                    { new Guid("f5826f1b-3ce3-4f40-b4af-90d9a8ab90c2"), new Guid("b982edb0-6a9f-4d55-9cd8-17849cae91cc"), new Guid("5b8a66de-3131-4619-adec-06fd4351c7e6"), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ProductId",
                table: "PurchaseItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_PurchaseId",
                table: "PurchaseItems",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CustomerId",
                table: "Purchases",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
