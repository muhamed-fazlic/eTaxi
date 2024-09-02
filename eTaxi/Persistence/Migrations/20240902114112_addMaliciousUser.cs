using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addMaliciousUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaliciousUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsSuspicious = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaliciousUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaliciousUser_AspNetUsers_UserId",
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
                values: new object[] { "f8357616-c863-4bdf-a0ec-87794417f870", "AQAAAAIAAYagAAAAEOpCF6bo88Rl1fuGkm3bIoNTgm2/ExeKifXaM1qa/uqI+DJX7nmSbzOqqNnZUVgZvQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "803407fd-bcc1-4694-8f84-3b565f1156e6", "AQAAAAIAAYagAAAAEGiDf85KEV10Kp84MWmD3JU1y01VakM15GSkOf/xoDkydvZEzctFcyCQ5Dx+dSm7ww==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "45e395d9-19d5-4e63-a2f8-3d136c4fb56c", "AQAAAAIAAYagAAAAEKQXH+V2jiNv/3vtkLNCwwq+Koj2kcwqVC4b8cWRyR6ZrTMbyTGow9eCb/uZfcBwmA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0b241fe-ebd1-4f96-b458-a4c2212d9e1a", "AQAAAAIAAYagAAAAECAcMQbKi0m4w6t+Kqcs5ciP20ZyIQVxUzp2It4qLtwTDwKMKCFyzlk9unCdlDdOBA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e98660cb-5a86-49eb-8043-55f9ab4ad622", "AQAAAAIAAYagAAAAEI6vg9wq+suuedQ1sPYStKc9sloSzYqGyJtiIIZPniC/p01dQqBriVDgd4NKUuNLag==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fc8469f9-86f2-4ca5-b232-1d0b29241f64", "AQAAAAIAAYagAAAAEClbD7iO4XYZntCb7e8VFpzT13SDOZF6L4qgx+J4wxlKzU2NSLu63H/+EDnNZLs2wg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7902f334-3f99-4756-9540-c099c1b1c292", "AQAAAAIAAYagAAAAEP2IATAqiTaxfuXDFpV1X2N3E/I0Ud8qCBzI1NY+Sg20GE3fexmlRl7NbnUlwUPMRQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2633224a-5418-4855-8b4c-32eaac770585", "AQAAAAIAAYagAAAAEH8o8S5+x2wsrgRt9vbAklDxpCKU/Qv/Up4MCciWnjOj70Kc41xgCBS3Fadj2P4IgQ==" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 41, 12, 313, DateTimeKind.Local).AddTicks(198));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 41, 12, 313, DateTimeKind.Local).AddTicks(253));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6826), new DateTime(2024, 9, 2, 15, 41, 12, 663, DateTimeKind.Local).AddTicks(6835), new DateTime(2024, 9, 2, 14, 41, 12, 663, DateTimeKind.Local).AddTicks(6830) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6842), new DateTime(2024, 9, 2, 17, 41, 12, 663, DateTimeKind.Local).AddTicks(6846), new DateTime(2024, 9, 2, 15, 41, 12, 663, DateTimeKind.Local).AddTicks(6845) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6847), new DateTime(2024, 9, 2, 12, 41, 12, 663, DateTimeKind.Local).AddTicks(6851), new DateTime(2024, 9, 2, 11, 41, 12, 663, DateTimeKind.Local).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6852), new DateTime(2024, 9, 1, 11, 41, 12, 663, DateTimeKind.Local).AddTicks(6857), new DateTime(2024, 9, 1, 9, 41, 12, 663, DateTimeKind.Local).AddTicks(6854) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6858), new DateTime(2024, 8, 30, 9, 41, 12, 663, DateTimeKind.Local).AddTicks(6861), new DateTime(2024, 8, 30, 7, 41, 12, 663, DateTimeKind.Local).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6863), new DateTime(2024, 9, 2, 14, 1, 12, 663, DateTimeKind.Local).AddTicks(6866), new DateTime(2024, 9, 2, 13, 43, 12, 663, DateTimeKind.Local).AddTicks(6865) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6867), new DateTime(2024, 9, 2, 4, 41, 12, 663, DateTimeKind.Local).AddTicks(6870), new DateTime(2024, 9, 2, 2, 41, 12, 663, DateTimeKind.Local).AddTicks(6869) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6871), new DateTime(2024, 9, 1, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6874), new DateTime(2024, 9, 1, 12, 41, 12, 663, DateTimeKind.Local).AddTicks(6873) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6876), new DateTime(2024, 9, 3, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6879), new DateTime(2024, 9, 3, 12, 41, 12, 663, DateTimeKind.Local).AddTicks(6878) });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6788));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 9, 2, 13, 41, 12, 663, DateTimeKind.Local).AddTicks(6791));

            migrationBuilder.CreateIndex(
                name: "IX_MaliciousUser_UserId",
                table: "MaliciousUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaliciousUser");

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
