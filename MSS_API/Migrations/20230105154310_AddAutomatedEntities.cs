using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSSAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAutomatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutomatedWarehouseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomatedWarehouseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutomatedWarehouseRequests_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseItems",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableQuantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseItems", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "AutomatedWarehouseRequestItems",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomatedWarehouseRequestItems", x => new { x.RequestId, x.ProductCode });
                    table.ForeignKey(
                        name: "FK_AutomatedWarehouseRequestItems_AutomatedWarehouseRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "AutomatedWarehouseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutomatedWarehouseRequestItems_WarehouseItems_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "WarehouseItems",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutomatedWarehouseRequestItems_ProductCode",
                table: "AutomatedWarehouseRequestItems",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_AutomatedWarehouseRequests_InventoryId",
                table: "AutomatedWarehouseRequests",
                column: "InventoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutomatedWarehouseRequestItems");

            migrationBuilder.DropTable(
                name: "Factories");

            migrationBuilder.DropTable(
                name: "AutomatedWarehouseRequests");

            migrationBuilder.DropTable(
                name: "WarehouseItems");
        }
    }
}
