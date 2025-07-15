using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DUPSS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQueuingCourseV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QueuingCourses_Categories_CateId",
                table: "QueuingCourses");

            migrationBuilder.RenameColumn(
                name: "CateId",
                table: "QueuingCourses",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_QueuingCourses_CateId",
                table: "QueuingCourses",
                newName: "IX_QueuingCourses_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_QueuingCourses_Categories_CategoryId",
                table: "QueuingCourses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QueuingCourses_Categories_CategoryId",
                table: "QueuingCourses");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "QueuingCourses",
                newName: "CateId");

            migrationBuilder.RenameIndex(
                name: "IX_QueuingCourses_CategoryId",
                table: "QueuingCourses",
                newName: "IX_QueuingCourses_CateId");

            migrationBuilder.AddForeignKey(
                name: "FK_QueuingCourses_Categories_CateId",
                table: "QueuingCourses",
                column: "CateId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
