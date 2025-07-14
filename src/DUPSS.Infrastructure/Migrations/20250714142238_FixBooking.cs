using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DUPSS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "BookingRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "BookingRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BookingNote",
                table: "BookingRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "BookingRequests");

            migrationBuilder.DropColumn(
                name: "BookingNote",
                table: "BookingRequests");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "BookingRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
