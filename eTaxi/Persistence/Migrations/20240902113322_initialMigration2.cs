using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f6b03aca-d2ea-4aeb-ae11-a5f65a55686c", "AQAAAAIAAYagAAAAEBSwBmlmBboBMvpVstYe1TUcZJEtMAYc5HPO85WS8E62e6miHJ5ULrhOgaJuh9hTog==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9dbb7e65-5ed1-49e7-9f33-a27f822f6f0a", "AQAAAAIAAYagAAAAEDw1eoicKn2vnLSpQzzNnWuIfRk0dn6MYVHRU9tjLfm+kY94gYtBhPNtlr2Xwjqf7A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3be1d490-19f8-4ebe-b0b6-0f19ce18488f", "AQAAAAIAAYagAAAAEBrp3z4yw6/+KTlLQ9J+UPAV82fF8MUvpmAAr9Sq1642ZI9dy/BZ0c+d0moJ+BqZuQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2897cb7-4aa4-405d-9798-8c844a9f1206", "AQAAAAIAAYagAAAAEG+4YCnFnR1OFbrxzJoQPrLvm9s19XP6r97oTtXoGxAWZEWJXjF/cnkZMq9oO3Ur/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "05119eaa-deec-4f2e-8039-f7b1aaafff7c", "AQAAAAIAAYagAAAAELtYmIwnsx2eFl0+KRHzzzLeb6OFtWE1nB//qX2kG7h9Kb2oyQXnAZc1Jglrks42lg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "89fdb7d4-f99d-44de-bcbd-dd3ee62248e1", "AQAAAAIAAYagAAAAELJbS7T8+peQEXY9nM1jO+4a+kaz08glFSwuqasp1tXqdwejhGKWefDyzyaaZoyrkA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "69cc2b9d-cc14-479a-9822-acf8c8217a16", "AQAAAAIAAYagAAAAEIejA6DfxjncB0G9OWxZ1A9/lMSScIJ3afcwX992WSZPhzTg8oxet/VRMtpVMuxTbw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91b5b62e-6461-4127-9774-942290b51eb5", "AQAAAAIAAYagAAAAEPGPSfwbJA0Yu6z34APs8TRGl/82jAoAPe6dVqhne6k1SgJr0rUrmrpDKomovlYSpw==" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 33, 21, 853, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 33, 21, 853, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Address", "City", "Country", "DateCreated", "DateModified", "District", "Latitude", "Longitude", "PostalCode", "StreetName", "StreetNumber" },
                values: new object[] { 7, "Hasana Brkića 30, Sarajevo 71000", "Sarajevo", "BiH", null, null, "Centar", 43.851064899999997, 18.3907597, "71000", "Hasan Brkica", "30" });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4362), new DateTime(2024, 9, 2, 15, 33, 22, 207, DateTimeKind.Local).AddTicks(4371), new DateTime(2024, 9, 2, 14, 33, 22, 207, DateTimeKind.Local).AddTicks(4365) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4377), new DateTime(2024, 9, 2, 17, 33, 22, 207, DateTimeKind.Local).AddTicks(4381), new DateTime(2024, 9, 2, 15, 33, 22, 207, DateTimeKind.Local).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4382), new DateTime(2024, 9, 2, 12, 33, 22, 207, DateTimeKind.Local).AddTicks(4385), new DateTime(2024, 9, 2, 11, 33, 22, 207, DateTimeKind.Local).AddTicks(4384) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4386), new DateTime(2024, 9, 1, 11, 33, 22, 207, DateTimeKind.Local).AddTicks(4391), new DateTime(2024, 9, 1, 9, 33, 22, 207, DateTimeKind.Local).AddTicks(4389) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4392), new DateTime(2024, 8, 30, 9, 33, 22, 207, DateTimeKind.Local).AddTicks(4395), new DateTime(2024, 8, 30, 7, 33, 22, 207, DateTimeKind.Local).AddTicks(4394) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4415), new DateTime(2024, 9, 2, 13, 53, 22, 207, DateTimeKind.Local).AddTicks(4419), new DateTime(2024, 9, 2, 13, 35, 22, 207, DateTimeKind.Local).AddTicks(4417) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4420), new DateTime(2024, 9, 2, 4, 33, 22, 207, DateTimeKind.Local).AddTicks(4423), new DateTime(2024, 9, 2, 2, 33, 22, 207, DateTimeKind.Local).AddTicks(4422) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4424), new DateTime(2024, 9, 1, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4426), new DateTime(2024, 9, 1, 12, 33, 22, 207, DateTimeKind.Local).AddTicks(4425) });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4270));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CancelReason", "DateCreated", "DateModified", "EndLocationId", "EndTime", "IsActive", "IsCanceled", "IsSelfDrive", "PaymentMethod", "Price", "StartLocationId", "StartTime", "UserDriverId", "UserId", "VehicleId" },
                values: new object[] { 9, null, new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4428), null, 1, new DateTime(2024, 9, 3, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4431), true, false, false, "Gotovina", 25.0, 7, new DateTime(2024, 9, 3, 12, 33, 22, 207, DateTimeKind.Local).AddTicks(4430), 6, 5, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
