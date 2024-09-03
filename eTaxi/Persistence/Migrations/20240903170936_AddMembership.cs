using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMembership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Tier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membership_AspNetUsers_UserId",
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
                values: new object[] { "f29dc843-93d6-4769-8c40-28ace1028053", "AQAAAAIAAYagAAAAEOJYMUzoUuPx738WaA7OkvmdOYFLoVy8IzKEsku9gPkB0yLzNretpwAZl8CfZzUQAw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4f3351ab-1401-4e48-82b5-3893a95dddba", "AQAAAAIAAYagAAAAEICt662SdsdSq/SNW6QKHzSIVNCyq0T5GW/EyCRV8FbLhFyJuqEPOcIPVZcSQ3F8xw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c6ba159-ad0f-490a-bfe8-42a40c6c2447", "AQAAAAIAAYagAAAAENFt6ATvBk/WpIA+S83AaCrO/YzGXDg0IHwvWzEVIJYFYFUx1arT4YwCPEaoj2m5eg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "366c3f76-0a91-49f4-b9f3-bf883c950cec", "AQAAAAIAAYagAAAAEH9KFkx7XF9KTcRZAhG4pSqZVWE8KMNALmgmVoE8jio0CSS5zVGRbRx8nbpViozhpQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "64221946-26e8-4a3e-9ef6-e76db80bac2d", "AQAAAAIAAYagAAAAENei5nUpduzsbgO9w2w+PA3GMk6fDdKkIMrpK94kwUwKj7WLvg6A/G3o0wKmoJG6zw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f4fe9a4-5769-4f7f-8cb9-1ce5679546b6", "AQAAAAIAAYagAAAAECuFxmQzotkoTE1EhlVY/n9T1VPSAF850sacbbeOSHsLIx007qq1TFA6C+SQfJ0kNA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cf167753-fce2-4c36-992f-d1d3f5121267", "AQAAAAIAAYagAAAAEEDHzN9OMfGvinwccZQchhw/Ppnneeq8IJ8KfQvxF9aJnHBie8PW10g/OqDDjh6K1g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "42a8cd3b-4816-4787-816e-937f293113ac", "AQAAAAIAAYagAAAAEI6CIjldNA0PAgp3lUq8Qn8cpBc2S14KD3Onft/fH/CemMTBhNxtNOEKV3p0PrDOiw==" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 19, 9, 35, 805, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 19, 9, 35, 805, DateTimeKind.Local).AddTicks(3499));

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "DateCreated", "DateModified", "EndTime", "IsActive", "StartTime", "Tier", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2024, 9, 8, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5921), true, new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5920), "Basic", 1 },
                    { 2, null, null, new DateTime(2024, 9, 12, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5926), true, new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5925), "Basic", 3 },
                    { 3, null, null, new DateTime(2024, 9, 8, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5929), true, new DateTime(2024, 8, 25, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5928), "Premium", 4 },
                    { 4, null, null, new DateTime(2024, 8, 31, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5932), false, new DateTime(2024, 8, 13, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5931), "VIP", 3 },
                    { 5, null, null, new DateTime(2024, 8, 29, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5940), false, new DateTime(2024, 8, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5933), "Basic", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5767), new DateTime(2024, 9, 3, 21, 9, 36, 140, DateTimeKind.Local).AddTicks(5777), new DateTime(2024, 9, 3, 20, 9, 36, 140, DateTimeKind.Local).AddTicks(5772) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5782), new DateTime(2024, 9, 3, 23, 9, 36, 140, DateTimeKind.Local).AddTicks(5786), new DateTime(2024, 9, 3, 21, 9, 36, 140, DateTimeKind.Local).AddTicks(5785) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5788), new DateTime(2024, 9, 3, 18, 9, 36, 140, DateTimeKind.Local).AddTicks(5792), new DateTime(2024, 9, 3, 17, 9, 36, 140, DateTimeKind.Local).AddTicks(5791) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5794), new DateTime(2024, 9, 2, 17, 9, 36, 140, DateTimeKind.Local).AddTicks(5798), new DateTime(2024, 9, 2, 15, 9, 36, 140, DateTimeKind.Local).AddTicks(5796) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5800), new DateTime(2024, 8, 31, 15, 9, 36, 140, DateTimeKind.Local).AddTicks(5803), new DateTime(2024, 8, 31, 13, 9, 36, 140, DateTimeKind.Local).AddTicks(5802) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5805), new DateTime(2024, 9, 3, 19, 29, 36, 140, DateTimeKind.Local).AddTicks(5810), new DateTime(2024, 9, 3, 19, 11, 36, 140, DateTimeKind.Local).AddTicks(5808) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5811), new DateTime(2024, 9, 3, 10, 9, 36, 140, DateTimeKind.Local).AddTicks(5814), new DateTime(2024, 9, 3, 8, 9, 36, 140, DateTimeKind.Local).AddTicks(5813) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5816), new DateTime(2024, 9, 2, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5820), new DateTime(2024, 9, 2, 18, 9, 36, 140, DateTimeKind.Local).AddTicks(5819) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5822), new DateTime(2024, 9, 4, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5825), new DateTime(2024, 9, 4, 18, 9, 36, 140, DateTimeKind.Local).AddTicks(5824) });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5682));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5724));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 9, 3, 19, 9, 36, 140, DateTimeKind.Local).AddTicks(5730));

            migrationBuilder.CreateIndex(
                name: "IX_Membership_UserId",
                table: "Membership",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membership");

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
