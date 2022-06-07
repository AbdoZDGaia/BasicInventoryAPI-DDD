using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductStatusId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductStatuses_ProductStatusId",
                        column: x => x.ProductStatusId,
                        principalTable: "ProductStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "Category 1", false },
                    { 2, "Category 2", false },
                    { 3, "Category 3", false }
                });

            migrationBuilder.InsertData(
                table: "ProductStatuses",
                columns: new[] { "Id", "IsDeleted", "StatusDescription", "StatusName" },
                values: new object[,]
                {
                    { 1, false, null, "Sold" },
                    { 2, false, null, "InStock" },
                    { 3, false, null, "Damaged" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "ProductName", "ProductStatusId", "UpdatedBy", "UpdatedDate", "Weight" },
                values: new object[,]
                {
                    { 1, "Barcode 1", 1, "Admin", new DateTime(2022, 6, 7, 19, 43, 18, 660, DateTimeKind.Local).AddTicks(8186), "Description 1", false, "Product 1", 1, null, null, 4.1m },
                    { 2, "Barcode 2", 2, "Admin", new DateTime(2022, 6, 7, 19, 43, 18, 660, DateTimeKind.Local).AddTicks(8199), "Description 2", false, "Product 2", 2, null, null, 4.2m },
                    { 3, "Barcode 3", 3, "Admin", new DateTime(2022, 6, 7, 19, 43, 18, 660, DateTimeKind.Local).AddTicks(8201), "Description 3", false, "Product 3", 3, null, null, 4.3m },
                    { 4, "Barcode 4", 3, "Admin", new DateTime(2022, 6, 7, 19, 43, 18, 660, DateTimeKind.Local).AddTicks(8202), "Description 4", false, "Product 4", 3, null, null, 4.4m },
                    { 5, "Barcode 5", 2, "Admin", new DateTime(2022, 6, 7, 19, 43, 18, 660, DateTimeKind.Local).AddTicks(8204), "Description 5", false, "Product 5", 2, null, null, 4.5m },
                    { 6, "Barcode 6", 2, "Admin", new DateTime(2022, 6, 7, 19, 43, 18, 660, DateTimeKind.Local).AddTicks(8205), "Description 6", false, "Product 6", 2, null, null, 4.6m },
                    { 7, "Barcode 7", 1, "Admin", new DateTime(2022, 6, 7, 19, 43, 18, 660, DateTimeKind.Local).AddTicks(8207), "Description 7", false, "Product 7", 1, null, null, 4.7m },
                    { 8, "Barcode 8", 1, "Admin", new DateTime(2022, 6, 7, 19, 43, 18, 660, DateTimeKind.Local).AddTicks(8208), "Description 8", false, "Product 8", 1, null, null, 4.8m },
                    { 9, "Barcode 9", 1, "Admin", new DateTime(2022, 6, 7, 19, 43, 18, 660, DateTimeKind.Local).AddTicks(8210), "Description 9", false, "Product 9", 1, null, null, 4.9m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStatusId",
                table: "Products",
                column: "ProductStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProductStatuses");
        }
    }
}
