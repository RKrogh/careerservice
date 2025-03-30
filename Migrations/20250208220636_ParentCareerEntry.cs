using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ParentCareerEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartingDate",
                table: "CareerEntries",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndingDate",
                table: "CareerEntries",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "CareerEntries",
                type: "integer",
                nullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_CareerEntries_ParentId",
                table: "CareerEntries",
                column: "ParentId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_CareerEntries_CareerEntries_ParentId",
                table: "CareerEntries",
                column: "ParentId",
                principalTable: "CareerEntries",
                principalColumn: "Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerEntries_CareerEntries_ParentId",
                table: "CareerEntries"
            );

            migrationBuilder.DropIndex(name: "IX_CareerEntries_ParentId", table: "CareerEntries");

            migrationBuilder.DropColumn(name: "ParentId", table: "CareerEntries");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartingDate",
                table: "CareerEntries",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndingDate",
                table: "CareerEntries",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true
            );
        }
    }
}
