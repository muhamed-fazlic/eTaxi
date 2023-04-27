using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addFeedbackWithFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Order",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "FeedbackId",
                table: "File",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Feedback_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb20ab16-a05f-43bb-9265-418d72122c2e", "AQAAAAIAAYagAAAAEJq7Mgpf2FAxeFPlyUMt4B6VIz01GkHFwgFq6u553aoOTTIcUCuvr/QMm/7gfQhT2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "734e1f16-6a93-4d98-bb6b-8a7c2ecaf40e", "AQAAAAIAAYagAAAAEBawG8xEJnkcCGroRisDeXR5Q+CD3hc1JDGVCe2x3iwpUClhf5uI5aSY/vccOF/+yg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f85d4bd4-7c40-44c0-be0f-3f197b416a74", "AQAAAAIAAYagAAAAENCJKFpnBHF0Tz3QQG7FmVexhfkdQsKu7rWGEqMRxGyAs0G0tGyen2hmtAZvKQ2DmQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_File_FeedbackId",
                table: "File",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_OrderId",
                table: "Feedback",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserId",
                table: "Feedback",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_VehicleId",
                table: "Feedback",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Feedback_FeedbackId",
                table: "File",
                column: "FeedbackId",
                principalTable: "Feedback",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Feedback_FeedbackId",
                table: "File");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_File_FeedbackId",
                table: "File");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "File");

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
        }
    }
}
