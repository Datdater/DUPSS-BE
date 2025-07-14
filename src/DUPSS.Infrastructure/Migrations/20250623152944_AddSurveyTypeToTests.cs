using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DUPSS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSurveyTypeToTests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SurveyType",
                table: "Tests",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkshopId",
                table: "Tests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_WorkshopId",
                table: "Tests",
                column: "WorkshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Workshops_WorkshopId",
                table: "Tests",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Workshops_WorkshopId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_WorkshopId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "SurveyType",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "WorkshopId",
                table: "Tests");
        }
    }
}
