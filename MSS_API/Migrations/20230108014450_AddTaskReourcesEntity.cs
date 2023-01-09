using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSSAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskReourcesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskAllocatedResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllocatedAmount = table.Column<double>(type: "float", nullable: false),
                    InventoryItemId = table.Column<int>(type: "int", nullable: false),
                    KanBanTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAllocatedResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskAllocatedResources_InventoryItems_InventoryItemId",
                        column: x => x.InventoryItemId,
                        principalTable: "InventoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskAllocatedResources_KanBanTasks_KanBanTaskId",
                        column: x => x.KanBanTaskId,
                        principalTable: "KanBanTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskAllocatedResources_InventoryItemId",
                table: "TaskAllocatedResources",
                column: "InventoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAllocatedResources_KanBanTaskId",
                table: "TaskAllocatedResources",
                column: "KanBanTaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskAllocatedResources");
        }
    }
}
