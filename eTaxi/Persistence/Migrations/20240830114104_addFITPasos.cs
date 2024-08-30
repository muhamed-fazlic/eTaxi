using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addFITPasos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FitPasos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIzdavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumVazenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitPasos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitPasos_AspNetUsers_UserId",
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
                values: new object[] { "3dbcd15f-cf70-498b-8a70-0230abad8e89", "AQAAAAIAAYagAAAAEEg+UMUMzq7DymPtNuWJbDVJIrQlB1qz8BMqGgId7StHpWn6IWzh+uZuAoD/GJGkTA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "76cbad5b-2c4d-412c-9335-1d26ae1247d6", "AQAAAAIAAYagAAAAEDeXzWrsBQzZLRsSicHhzpXkqhEUDsusum/QsJkjcfWgu6PyBRAL8gAaikGFgwUTyw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3478d2b2-9772-4620-8c24-ee916304915f", "AQAAAAIAAYagAAAAEIm3SCPnSqkG8h35+JAu7aPnGt6oGYtFeJx8NFilj86AzQu7vcUAlG/wu4wSs7qciA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a7f58fe-d3a5-4f39-8c4d-26e5db4afcf5", "AQAAAAIAAYagAAAAEIsigX2wsEBbS1kEW/8yBUK1+234HqgWTsb3MwXVhmHj50xNgJvkALIHuZ2mAcMrsg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ffef288b-cacf-4621-9ee5-b0762f560f8f", "AQAAAAIAAYagAAAAEIMiVbzoHhgNEioqig2HwYEkqUb2RV7jd+oxWHt61scWllLKJWOHhugkgpxWd8Aj3Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "055c70d6-7999-48ef-95b7-1ea94b6db7a7", "AQAAAAIAAYagAAAAEOSQ4rn5I0CNRzBQ+4XUsQ1zzeXx8BMzlDDIDevUJji9bHS2VPnr4hwUD/YiSf7sig==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "303dbcdf-9510-4b08-9905-e3e018f4c721", "AQAAAAIAAYagAAAAEGyOqsQ3ymIj3iI151nZhtf3HOkQ08sh8A/VK9ap1ZWTTXdCHkjVI50StPWqp9xYkg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1e91332e-dfe1-4f42-96bd-2fe3c97503f9", "AQAAAAIAAYagAAAAEMgEUPi80D7HEZzFKObjpQ9d4AvA49V7cvjDRs+cKJiy+1a3+dKvFImjY449ajPTig==" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 8, 30, 13, 41, 3, 848, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 30, 13, 41, 3, 848, DateTimeKind.Local).AddTicks(2161));

            migrationBuilder.InsertData(
                table: "FitPasos",
                columns: new[] { "Id", "DateCreated", "DateModified", "DatumIzdavanja", "DatumVazenja", "IsValid", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2034, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { 2, null, null, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2034, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4 },
                    { 3, null, null, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5 },
                    { 4, null, null, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2028, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6 }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Address", "City", "Country", "DateCreated", "DateModified", "District", "Latitude", "Longitude", "PostalCode", "StreetName", "StreetNumber" },
                values: new object[] { 7, "Hasana Brkića 30, Sarajevo 71000", "Sarajevo", "BiH", null, null, "Centar", 43.851064899999997, 18.3907597, "71000", "Hasan Brkica", "30" });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1156), new DateTime(2024, 8, 30, 15, 41, 4, 304, DateTimeKind.Local).AddTicks(1173), new DateTime(2024, 8, 30, 14, 41, 4, 304, DateTimeKind.Local).AddTicks(1163) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1189), new DateTime(2024, 8, 30, 17, 41, 4, 304, DateTimeKind.Local).AddTicks(1212), new DateTime(2024, 8, 30, 15, 41, 4, 304, DateTimeKind.Local).AddTicks(1193) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1214), new DateTime(2024, 8, 30, 12, 41, 4, 304, DateTimeKind.Local).AddTicks(1218), new DateTime(2024, 8, 30, 11, 41, 4, 304, DateTimeKind.Local).AddTicks(1217) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1220), new DateTime(2024, 8, 29, 11, 41, 4, 304, DateTimeKind.Local).AddTicks(1242), new DateTime(2024, 8, 29, 9, 41, 4, 304, DateTimeKind.Local).AddTicks(1223) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1246), new DateTime(2024, 8, 27, 9, 41, 4, 304, DateTimeKind.Local).AddTicks(1259), new DateTime(2024, 8, 27, 7, 41, 4, 304, DateTimeKind.Local).AddTicks(1258) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1262), new DateTime(2024, 8, 30, 14, 1, 4, 304, DateTimeKind.Local).AddTicks(1275), new DateTime(2024, 8, 30, 13, 43, 4, 304, DateTimeKind.Local).AddTicks(1264) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1277), new DateTime(2024, 8, 30, 4, 41, 4, 304, DateTimeKind.Local).AddTicks(1281), new DateTime(2024, 8, 30, 2, 41, 4, 304, DateTimeKind.Local).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1283), new DateTime(2024, 8, 29, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1303), new DateTime(2024, 8, 29, 12, 41, 4, 304, DateTimeKind.Local).AddTicks(1301) });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(931));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1025));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1029));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1034));

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CancelReason", "DateCreated", "DateModified", "EndLocationId", "EndTime", "IsActive", "IsCanceled", "IsSelfDrive", "PaymentMethod", "Price", "StartLocationId", "StartTime", "UserDriverId", "UserId", "VehicleId" },
                values: new object[] { 9, null, new DateTime(2024, 8, 30, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1305), null, 1, new DateTime(2024, 8, 31, 13, 41, 4, 304, DateTimeKind.Local).AddTicks(1321), true, false, false, "Gotovina", 25.0, 7, new DateTime(2024, 8, 31, 12, 41, 4, 304, DateTimeKind.Local).AddTicks(1319), 6, 5, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_FitPasos_UserId",
                table: "FitPasos",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitPasos");

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "775531be-b8d0-42aa-9847-5c8237054161", "AQAAAAIAAYagAAAAEH1LP7SYcHyzFBt5pio9QesUb0ONSy92NmwNgfw0hF2rhBCVZ9bKFSsqdqnSlaHrLg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ea9926a-9d18-42c6-9634-dfebca8663fc", "AQAAAAIAAYagAAAAEPmT95zRgxFQlorMTEFjcUi9Cl3s00abXKbWnswoYeI0S1m4zGzB0eit76nVLweCnQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b7d0e08-81f6-4321-afa7-52acc888142e", "AQAAAAIAAYagAAAAEPNh4Nsj2+6w9plxGlfoZ0c5LjBmalLHqljL6NhgEryvOLcY6+gemgJFgLhn8LTItg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af517832-f922-402c-be08-db07f81d4647", "AQAAAAIAAYagAAAAEEoFLIEsPiSu0D5Gm3FaCINTUc8mQ1Jhc/X+Bqa6IjnHWhzGAIkfnGfdmcC64vUI5Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7f60017c-cd51-42e5-b072-57eb09f9a1b7", "AQAAAAIAAYagAAAAEMT6/A+Gj4xhePby4HADEG241XXlltiEPwNnYBpwAtXq3YOy7nPWYGXcYfsVQotoPA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ce9413e3-8cf0-4774-bb84-e96fb073f091", "AQAAAAIAAYagAAAAEOULswAjxjXTTEi45XPdTh3LmvKJZV8b0LessaPAkfHcAfIGaQi2CGbkzISg1cA7zw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b130c48-cf24-4395-b2f6-2a6b5539d3a8", "AQAAAAIAAYagAAAAEFyTRpZubz9nQLH61/jlU0v1Isvlw131HOtU/tGD46r+VFg57y9PCJw9CvNXVW1v+w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f5585649-78ea-493a-93ea-0a9208fee9ad", "AQAAAAIAAYagAAAAEOydW1pUBZh67a6GHNOaDSMjiiLW9ndX8AtGdyxkn8cStCL14TP1X7oAVr+aeLg0Lg==" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 14, 23, 43, 49, 73, DateTimeKind.Local).AddTicks(5721));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 14, 23, 43, 49, 73, DateTimeKind.Local).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9525), new DateTime(2023, 6, 15, 1, 43, 50, 100, DateTimeKind.Local).AddTicks(9541), new DateTime(2023, 6, 15, 0, 43, 50, 100, DateTimeKind.Local).AddTicks(9532) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9554), new DateTime(2023, 6, 15, 3, 43, 50, 100, DateTimeKind.Local).AddTicks(9561), new DateTime(2023, 6, 15, 1, 43, 50, 100, DateTimeKind.Local).AddTicks(9559) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9565), new DateTime(2023, 6, 14, 22, 43, 50, 100, DateTimeKind.Local).AddTicks(9571), new DateTime(2023, 6, 14, 21, 43, 50, 100, DateTimeKind.Local).AddTicks(9569) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9574), new DateTime(2023, 6, 13, 21, 43, 50, 100, DateTimeKind.Local).AddTicks(9581), new DateTime(2023, 6, 13, 19, 43, 50, 100, DateTimeKind.Local).AddTicks(9577) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9583), new DateTime(2023, 6, 11, 19, 43, 50, 100, DateTimeKind.Local).AddTicks(9589), new DateTime(2023, 6, 11, 17, 43, 50, 100, DateTimeKind.Local).AddTicks(9587) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9593), new DateTime(2023, 6, 15, 0, 3, 50, 100, DateTimeKind.Local).AddTicks(9702), new DateTime(2023, 6, 14, 23, 45, 50, 100, DateTimeKind.Local).AddTicks(9698) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9706), new DateTime(2023, 6, 14, 14, 43, 50, 100, DateTimeKind.Local).AddTicks(9713), new DateTime(2023, 6, 14, 12, 43, 50, 100, DateTimeKind.Local).AddTicks(9711) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9716), new DateTime(2023, 6, 13, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9721), new DateTime(2023, 6, 13, 22, 43, 50, 100, DateTimeKind.Local).AddTicks(9719) });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9778));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9461));
        }
    }
}
