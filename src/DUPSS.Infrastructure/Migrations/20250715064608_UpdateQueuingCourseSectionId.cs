using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DUPSS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQueuingCourseSectionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QueuingCourseSection_QueuingCourses_QueuingCoureseId",
                table: "QueuingCourseSection");

            migrationBuilder.DropForeignKey(
                name: "FK_QueuingSteps_QueuingCourseSection_QueuingCouresSectionId",
                table: "QueuingSteps");

            migrationBuilder.DropIndex(
                name: "IX_QueuingCourseSection_QueuingCoureseId",
                table: "QueuingCourseSection");

            migrationBuilder.DropColumn(
                name: "CourseSectionId",
                table: "QueuingSteps");

            migrationBuilder.DropColumn(
                name: "QueuingCoureseId",
                table: "QueuingCourseSection");

            migrationBuilder.RenameColumn(
                name: "QueuingCouresSectionId",
                table: "QueuingSteps",
                newName: "QueuingCourseSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_QueuingSteps_QueuingCouresSectionId",
                table: "QueuingSteps",
                newName: "IX_QueuingSteps_QueuingCourseSectionId");

            migrationBuilder.AddColumn<string>(
                name: "QueuingCourseId",
                table: "QueuingCourseSection",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QueuingCourseSection_QueuingCourseId",
                table: "QueuingCourseSection",
                column: "QueuingCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_QueuingCourseSection_QueuingCourses_QueuingCourseId",
                table: "QueuingCourseSection",
                column: "QueuingCourseId",
                principalTable: "QueuingCourses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QueuingSteps_QueuingCourseSection_QueuingCourseSectionId",
                table: "QueuingSteps",
                column: "QueuingCourseSectionId",
                principalTable: "QueuingCourseSection",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QueuingCourseSection_QueuingCourses_QueuingCourseId",
                table: "QueuingCourseSection");

            migrationBuilder.DropForeignKey(
                name: "FK_QueuingSteps_QueuingCourseSection_QueuingCourseSectionId",
                table: "QueuingSteps");

            migrationBuilder.DropIndex(
                name: "IX_QueuingCourseSection_QueuingCourseId",
                table: "QueuingCourseSection");

            migrationBuilder.DropColumn(
                name: "QueuingCourseId",
                table: "QueuingCourseSection");

            migrationBuilder.RenameColumn(
                name: "QueuingCourseSectionId",
                table: "QueuingSteps",
                newName: "QueuingCouresSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_QueuingSteps_QueuingCourseSectionId",
                table: "QueuingSteps",
                newName: "IX_QueuingSteps_QueuingCouresSectionId");

            migrationBuilder.AddColumn<string>(
                name: "CourseSectionId",
                table: "QueuingSteps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QueuingCoureseId",
                table: "QueuingCourseSection",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_QueuingCourseSection_QueuingCoureseId",
                table: "QueuingCourseSection",
                column: "QueuingCoureseId");

            migrationBuilder.AddForeignKey(
                name: "FK_QueuingCourseSection_QueuingCourses_QueuingCoureseId",
                table: "QueuingCourseSection",
                column: "QueuingCoureseId",
                principalTable: "QueuingCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QueuingSteps_QueuingCourseSection_QueuingCouresSectionId",
                table: "QueuingSteps",
                column: "QueuingCouresSectionId",
                principalTable: "QueuingCourseSection",
                principalColumn: "Id");
        }
    }
}
