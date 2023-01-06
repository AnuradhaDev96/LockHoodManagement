using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSSAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNewWorkTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeePerformances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KPI = table.Column<double>(type: "float", nullable: false),
                    TaskCount = table.Column<int>(type: "int", nullable: false),
                    TimeLogged = table.Column<int>(type: "int", nullable: false),
                    EmployeeUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePerformances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePerformances_EmployeeUsers_EmployeeUserId",
                        column: x => x.EmployeeUserId,
                        principalTable: "EmployeeUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementDecisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Decision = table.Column<long>(type: "bigint", nullable: false),
                    ManagementType = table.Column<byte>(type: "tinyint", nullable: false),
                    SituationType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementDecisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionBatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    CreatedManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionBatches_EmployeeUsers_CreatedManagerId",
                        column: x => x.CreatedManagerId,
                        principalTable: "EmployeeUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionBatches_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KanBanTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpectedAmount = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    ProductionBatchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanBanTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KanBanTasks_ProductionBatches_ProductionBatchId",
                        column: x => x.ProductionBatchId,
                        principalTable: "ProductionBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePerformances_EmployeeUserId",
                table: "EmployeePerformances",
                column: "EmployeeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_KanBanTasks_ProductionBatchId",
                table: "KanBanTasks",
                column: "ProductionBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionBatches_CreatedManagerId",
                table: "ProductionBatches",
                column: "CreatedManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionBatches_WorkshopId",
                table: "ProductionBatches",
                column: "WorkshopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePerformances");

            migrationBuilder.DropTable(
                name: "KanBanTasks");

            migrationBuilder.DropTable(
                name: "ManagementDecisions");

            migrationBuilder.DropTable(
                name: "ProductionBatches");
        }
    }
}
