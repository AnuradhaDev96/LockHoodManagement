using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSSAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTestingResultToBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PassedAmount",
                table: "ProductionBatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TestedAmount",
                table: "ProductionBatches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassedAmount",
                table: "ProductionBatches");

            migrationBuilder.DropColumn(
                name: "TestedAmount",
                table: "ProductionBatches");
        }
    }
}
