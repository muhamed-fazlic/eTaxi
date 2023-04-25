using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3f26dd45-6422-43a7-86c8-664537f786f5", "AQAAAAIAAYagAAAAENY7zolm/KEf6Udau8Q94Wc4vzwBR0YqAdlDwLW1sR3dM/JxLtV1uJH8BWuoej+66w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ace73cef-5c10-45a2-8612-f734ca3fc6b5", "AQAAAAIAAYagAAAAEI6V73mzX0OPhnG7F0ZyYKmBi3Mj2Z1zCRCtuy6I1g5HlRJDzBk9asUP7O+IkhNAXw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa94c257-ad4f-4718-a1a5-f5aef13e48ad", "AQAAAAIAAYagAAAAENwGis8ZHiNqNWZ8UgJL9C7HgCIqtIrOiVvINH6T+XZiQ0TcvKX+k4BUqnm79o/2+g==" });

            migrationBuilder.CreateIndex(
                name: "IX_File_UserId",
                table: "File",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

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
        }
    }
}
