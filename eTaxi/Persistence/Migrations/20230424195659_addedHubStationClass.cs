using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedHubStationClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HubStation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubStation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HubStation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b0f01e13-b388-4460-b3b0-a2478df8cfc2", "AQAAAAIAAYagAAAAENxrSurOrPtFAZ6NAN+4jzPwDp1ghkE9oTIhIaGSrkR9+g3Adu3HE9cV+8ldQS3p9g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0939c84-60cb-4a13-a5c6-7360df5c3dbf", "AQAAAAIAAYagAAAAECTZPw/P+3IMwjW/0bQZUYLFTYnYTCsL30263xMRpHi/YLoAXp+OITRQbJo9HFGltw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "752743da-24b7-42a5-8077-314fc7ab7c9a", "AQAAAAIAAYagAAAAEBNONddWPL1bi7NS4zn+fayXM4Yu8oUFSKOvIuR5VHTE7O+hEZQMzzaMt9eL07ptUg==" });

            migrationBuilder.CreateIndex(
                name: "IX_HubStation_LocationId",
                table: "HubStation",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HubStation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f68aae51-e390-4dd3-b22f-84cdb2773f1f", "AQAAAAIAAYagAAAAEJl8+ZxHONSi3/3VC6Q+nAI1CIoauVTYTeXqSuH1NaYY2nrzdMpdmv+RR6vPgkfA/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a204ffb-def3-4159-a715-e1bee80d5228", "AQAAAAIAAYagAAAAEEaXKM7h7MHx01p+inmswWHnsOzBL3T/0E/FMbcimAPD3ocVQh4SbMBd91MSSPVWFg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "83289843-6fcf-443f-86b6-c859ebeaeb18", "AQAAAAIAAYagAAAAEK3Iol0tu8Q3GL1kadIkKGrR6D+7zYGjs1ffvR9/ZBYiwSLQKIZoI6X0Evfjb862lg==" });
        }
    }
}
