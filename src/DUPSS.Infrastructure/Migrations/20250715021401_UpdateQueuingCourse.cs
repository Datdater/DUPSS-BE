using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DUPSS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQueuingCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QueuingSteps_QueuingCourseSection_QueuingCoureseId",
                table: "QueuingSteps");

            migrationBuilder.RenameColumn(
                name: "QueuingCoureseId",
                table: "QueuingSteps",
                newName: "QueuingCouresSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_QueuingSteps_QueuingCoureseId",
                table: "QueuingSteps",
                newName: "IX_QueuingSteps_QueuingCouresSectionId");

            migrationBuilder.AddColumn<string>(
                name: "CateId",
                table: "QueuingCourses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "QueuingCourses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "QueuingCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "OldPrice",
                table: "QueuingCourses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "QueuingCourses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "QueuingCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_QueuingCourses_CateId",
                table: "QueuingCourses",
                column: "CateId");

            migrationBuilder.CreateIndex(
                name: "IX_QueuingCourses_CreatedBy",
                table: "QueuingCourses",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_QueuingCourses_AspNetUsers_CreatedBy",
                table: "QueuingCourses",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QueuingCourses_Categories_CateId",
                table: "QueuingCourses",
                column: "CateId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QueuingSteps_QueuingCourseSection_QueuingCouresSectionId",
                table: "QueuingSteps",
                column: "QueuingCouresSectionId",
                principalTable: "QueuingCourseSection",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QueuingCourses_AspNetUsers_CreatedBy",
                table: "QueuingCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_QueuingCourses_Categories_CateId",
                table: "QueuingCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_QueuingSteps_QueuingCourseSection_QueuingCouresSectionId",
                table: "QueuingSteps");

            migrationBuilder.DropIndex(
                name: "IX_QueuingCourses_CateId",
                table: "QueuingCourses");

            migrationBuilder.DropIndex(
                name: "IX_QueuingCourses_CreatedBy",
                table: "QueuingCourses");

            migrationBuilder.DropColumn(
                name: "CateId",
                table: "QueuingCourses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "QueuingCourses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "QueuingCourses");

            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "QueuingCourses");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "QueuingCourses");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "QueuingCourses");

            migrationBuilder.RenameColumn(
                name: "QueuingCouresSectionId",
                table: "QueuingSteps",
                newName: "QueuingCoureseId");

            migrationBuilder.RenameIndex(
                name: "IX_QueuingSteps_QueuingCouresSectionId",
                table: "QueuingSteps",
                newName: "IX_QueuingSteps_QueuingCoureseId");

            migrationBuilder.AddForeignKey(
                name: "FK_QueuingSteps_QueuingCourseSection_QueuingCoureseId",
                table: "QueuingSteps",
                column: "QueuingCoureseId",
                principalTable: "QueuingCourseSection",
                principalColumn: "Id");
        }
    }
}
