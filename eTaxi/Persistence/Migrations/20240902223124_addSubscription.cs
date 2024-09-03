using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_AspNetUsers_UserId",
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
                values: new object[] { "b86d89df-3ae0-4875-a910-565ac03bdda5", "AQAAAAIAAYagAAAAEDWKP6aPqpoEwL5qzecPWE1AvwdkbpungEQw+anBEBn8p9zCwd5fZ79g8QrgFIEhLw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d7bf6d08-4361-4a7b-83f5-127abfe01980", "AQAAAAIAAYagAAAAEIC7YBjQBAUO8zmnERBCW++1N/BZEnGAozYUVyRAlluOPRSBRYqu9ed3sW6EQ5US8w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "da950051-d3e5-47bd-a4b4-8abb74eeb615", "AQAAAAIAAYagAAAAEPjd1daKt1ZRTGUu4NYx04Flb99GGrBtJllf1BQT20lqgKYK5m2xTZ/UPgtcoWaTHQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e0b94291-7d51-4ad6-8e3d-62bbb1833609", "AQAAAAIAAYagAAAAECr+ekJGIBtGHrUEu7HICzERUaBEqTZzrPFxpCyw8D9nleY4TGW7yQRa17V+mTnsEQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bc51c685-fd49-4bda-9e4b-9fe615b62e51", "AQAAAAIAAYagAAAAEPaQ533kU5WR75ucfqwpFoVyeC2Bbgp5KqfDspDIQ62waTWRz0pX3OtHvL+nULEYRw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "29ea65ed-9b51-4c59-be6d-c437bf6f0558", "AQAAAAIAAYagAAAAEICR85sm4P1KJZQUBauD0shiPbTpE0n/jfgSMSZmIijKvEH2CLzGwbStSsJQ4tBDYg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a436bdab-ad7b-46fa-bbba-66c72448d9cf", "AQAAAAIAAYagAAAAEJU1KYg1Tn5GEMdxpttkd72rXsGJHH7/4lknrzOpcwGgxWbm3Iim52GHhnXJvsV5ng==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "64ebab7f-ad52-4276-85c5-923c546ffab1", "AQAAAAIAAYagAAAAEPy+CMx/0vK/yDTaXY58CxcjOrz5V6annHV6oEWoBDY6vtnrc7OCZszGzkuezFuUhA==" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 0, 31, 24, 30, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 0, 31, 24, 30, DateTimeKind.Local).AddTicks(2722));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2205), new DateTime(2024, 9, 3, 2, 31, 24, 486, DateTimeKind.Local).AddTicks(2218), new DateTime(2024, 9, 3, 1, 31, 24, 486, DateTimeKind.Local).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2224), new DateTime(2024, 9, 3, 4, 31, 24, 486, DateTimeKind.Local).AddTicks(2230), new DateTime(2024, 9, 3, 2, 31, 24, 486, DateTimeKind.Local).AddTicks(2228) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2232), new DateTime(2024, 9, 2, 23, 31, 24, 486, DateTimeKind.Local).AddTicks(2236), new DateTime(2024, 9, 2, 22, 31, 24, 486, DateTimeKind.Local).AddTicks(2235) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2238), new DateTime(2024, 9, 1, 22, 31, 24, 486, DateTimeKind.Local).AddTicks(2244), new DateTime(2024, 9, 1, 20, 31, 24, 486, DateTimeKind.Local).AddTicks(2241) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2246), new DateTime(2024, 8, 30, 20, 31, 24, 486, DateTimeKind.Local).AddTicks(2251), new DateTime(2024, 8, 30, 18, 31, 24, 486, DateTimeKind.Local).AddTicks(2249) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2253), new DateTime(2024, 9, 3, 0, 51, 24, 486, DateTimeKind.Local).AddTicks(2258), new DateTime(2024, 9, 3, 0, 33, 24, 486, DateTimeKind.Local).AddTicks(2256) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2260), new DateTime(2024, 9, 2, 15, 31, 24, 486, DateTimeKind.Local).AddTicks(2264), new DateTime(2024, 9, 2, 13, 31, 24, 486, DateTimeKind.Local).AddTicks(2262) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2265), new DateTime(2024, 9, 2, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2270), new DateTime(2024, 9, 1, 23, 31, 24, 486, DateTimeKind.Local).AddTicks(2268) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2271), new DateTime(2024, 9, 4, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2276), new DateTime(2024, 9, 3, 23, 31, 24, 486, DateTimeKind.Local).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.InsertData(
                table: "Subscription",
                columns: new[] { "Id", "DateCreated", "DateModified", "EndTime", "IsActive", "StartTime", "SubscriptionType", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2024, 9, 10, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2356), true, new DateTime(2024, 9, 4, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2354), "mjesecna", 6 },
                    { 2, null, null, new DateTime(2024, 9, 10, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2363), true, new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2362), "mjesecna", 1 },
                    { 3, null, null, new DateTime(2024, 9, 2, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2367), false, new DateTime(2024, 8, 27, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2366), "mjesecna", 3 },
                    { 4, null, null, new DateTime(2024, 9, 21, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2371), false, new DateTime(2024, 9, 10, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2370), "", 4 }
                });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 0, 31, 24, 486, DateTimeKind.Local).AddTicks(2173));

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_UserId",
                table: "Subscription",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscription");

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
                table: "Order",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4428), new DateTime(2024, 9, 3, 13, 33, 22, 207, DateTimeKind.Local).AddTicks(4431), new DateTime(2024, 9, 3, 12, 33, 22, 207, DateTimeKind.Local).AddTicks(4430) });

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
        }
    }
}
