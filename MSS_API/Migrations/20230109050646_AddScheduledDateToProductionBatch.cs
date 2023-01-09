using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSSAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddScheduledDateToProductionBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedScheduledDate",
                table: "ProductionBatches",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedScheduledDate",
                table: "ProductionBatches");
        }
    }
}
