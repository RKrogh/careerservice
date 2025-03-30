using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class LocationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "CareerEntries",
                type: "text",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                }
            );

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Country" },
                values: new object[,]
                {
                    { 1, "Stockholm", "Sweden" },
                }
            );

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "CareerEntries",
                type: "integer",
                nullable: false,
                defaultValue: 1
            );

            migrationBuilder.CreateIndex(
                name: "IX_CareerEntries_LocationId",
                table: "CareerEntries",
                column: "LocationId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_CareerEntries_Locations_LocationId",
                table: "CareerEntries",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerEntries_Locations_LocationId",
                table: "CareerEntries"
            );

            migrationBuilder.DropTable(name: "Locations");

            migrationBuilder.DropIndex(name: "IX_CareerEntries_LocationId", table: "CareerEntries");

            migrationBuilder.DropColumn(name: "CompanyName", table: "CareerEntries");

            migrationBuilder.DropColumn(name: "LocationId", table: "CareerEntries");
        }
    }
}
