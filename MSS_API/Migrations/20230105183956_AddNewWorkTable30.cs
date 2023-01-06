using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSSAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNewWorkTable30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KanBanTasks_ProductionBatches_ProductionBatchId",
                table: "KanBanTasks");

            migrationBuilder.RenameColumn(
                name: "ProductionBatchId",
                table: "KanBanTasks",
                newName: "LabourerId");

            migrationBuilder.RenameIndex(
                name: "IX_KanBanTasks_ProductionBatchId",
                table: "KanBanTasks",
                newName: "IX_KanBanTasks_LabourerId");

            migrationBuilder.CreateIndex(
                name: "IX_KanBanTasks_BatchId",
                table: "KanBanTasks",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_KanBanTasks_EmployeeUsers_LabourerId",
                table: "KanBanTasks",
                column: "LabourerId",
                principalTable: "EmployeeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KanBanTasks_ProductionBatches_BatchId",
                table: "KanBanTasks",
                column: "BatchId",
                principalTable: "ProductionBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KanBanTasks_EmployeeUsers_LabourerId",
                table: "KanBanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_KanBanTasks_ProductionBatches_BatchId",
                table: "KanBanTasks");

            migrationBuilder.DropIndex(
                name: "IX_KanBanTasks_BatchId",
                table: "KanBanTasks");

            migrationBuilder.RenameColumn(
                name: "LabourerId",
                table: "KanBanTasks",
                newName: "ProductionBatchId");

            migrationBuilder.RenameIndex(
                name: "IX_KanBanTasks_LabourerId",
                table: "KanBanTasks",
                newName: "IX_KanBanTasks_ProductionBatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_KanBanTasks_ProductionBatches_ProductionBatchId",
                table: "KanBanTasks",
                column: "ProductionBatchId",
                principalTable: "ProductionBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
