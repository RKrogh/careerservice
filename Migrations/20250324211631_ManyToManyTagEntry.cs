using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyTagEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerTags_CareerEntries_CareerEntryId",
                table: "CareerTags"
            );

            migrationBuilder.DropIndex(name: "IX_CareerTags_CareerEntryId", table: "CareerTags");

            migrationBuilder.DropColumn(name: "CareerEntryId", table: "CareerTags");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "StartingDate",
                table: "CareerEntries",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date"
            );

            migrationBuilder.AlterColumn<DateOnly>(
                name: "EndingDate",
                table: "CareerEntries",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true
            );

            migrationBuilder.CreateTable(
                name: "CareerEntryCareerTag",
                columns: table => new
                {
                    CareerEntriesId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_CareerEntryCareerTag",
                        x => new { x.CareerEntriesId, x.TagsId }
                    );
                    table.ForeignKey(
                        name: "FK_CareerEntryCareerTag_CareerEntries_CareerEntriesId",
                        column: x => x.CareerEntriesId,
                        principalTable: "CareerEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_CareerEntryCareerTag_CareerTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "CareerTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_CareerEntryCareerTag_TagsId",
                table: "CareerEntryCareerTag",
                column: "TagsId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "CareerEntryCareerTag");

            migrationBuilder.AddColumn<int>(
                name: "CareerEntryId",
                table: "CareerTags",
                type: "integer",
                nullable: true
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartingDate",
                table: "CareerEntries",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndingDate",
                table: "CareerEntries",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_CareerTags_CareerEntryId",
                table: "CareerTags",
                column: "CareerEntryId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_CareerTags_CareerEntries_CareerEntryId",
                table: "CareerTags",
                column: "CareerEntryId",
                principalTable: "CareerEntries",
                principalColumn: "Id"
            );
        }
    }
}
