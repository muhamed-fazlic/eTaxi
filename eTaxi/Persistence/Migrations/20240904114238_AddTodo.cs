using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KrajnjiRok = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDo_AspNetUsers_UserId",
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
                values: new object[] { "04f9bec8-1415-4855-9844-a2d2533897fa", "AQAAAAIAAYagAAAAEPHg/3Z5sEe9lLl9DIjSPzOQG/8svsLphQNv5jwJtQ+dOax+ahoQqJ6Vf0YhTK5/3w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "13d58b71-3bf7-47ed-a350-1f9c27c1d224", "AQAAAAIAAYagAAAAEFgDse2ShcXAy1dzPbaBIeqgeqBhbZkrwlJVY00Y3KHsIlX2y6OVkNWiIrY8oTfO1Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ccaf6b2e-8404-4bd1-9007-76ea3dd8fdbc", "AQAAAAIAAYagAAAAEK7Iwiat4VXpwLe1vUE7U90c4qRpK2OzJGE5faw5vVP//DXD8A9QhnctFRKK/VPh3A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ba86916-0f64-4207-9b94-a58e36e58eb8", "AQAAAAIAAYagAAAAEELFzxjBGmM1eABGH3901UjXlOcIwFf8R9fHFbE34fAUlnUGz/G9nzFGB3Zv+Ji+xA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f3e609c1-ca92-4d1a-9a57-a09a452e4811", "AQAAAAIAAYagAAAAEGVO0G9wLvA2gvCGk+dAsyufAgXFFR4/K1fLJviOib7bmFyjuQo1fSC6dhMvOrtduQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a1f2550c-866f-44f7-9dcb-f21502703696", "AQAAAAIAAYagAAAAEGMQizkFTJBn3G5uZmdytKxu31oTJU2dFcEHOSPFlh1CeCWRpVGzGBUy7o9nZKKeDw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ddc8565c-f8f0-48cd-90de-fba77ae8585f", "AQAAAAIAAYagAAAAEGvkQFUuo7yXyg1WPsk4wCYa58yTCDsUmW0CIBQmxUf5YMd6T2axhLa/ZYpH2Jp+cg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "839f48eb-b662-454a-a330-f6b1b9522553", "AQAAAAIAAYagAAAAEEy/JaDLugtmefKqQm7VeUMIqEW+eJmZGGdjM2I+ad/+MYTVyhq/TMaI0VHWXGE4CA==" });

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 4, 13, 42, 38, 328, DateTimeKind.Local).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 4, 13, 42, 38, 328, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5147), new DateTime(2024, 9, 4, 15, 42, 38, 649, DateTimeKind.Local).AddTicks(5158), new DateTime(2024, 9, 4, 14, 42, 38, 649, DateTimeKind.Local).AddTicks(5151) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5177), new DateTime(2024, 9, 4, 17, 42, 38, 649, DateTimeKind.Local).AddTicks(5181), new DateTime(2024, 9, 4, 15, 42, 38, 649, DateTimeKind.Local).AddTicks(5180) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5182), new DateTime(2024, 9, 4, 12, 42, 38, 649, DateTimeKind.Local).AddTicks(5186), new DateTime(2024, 9, 4, 11, 42, 38, 649, DateTimeKind.Local).AddTicks(5185) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5187), new DateTime(2024, 9, 3, 11, 42, 38, 649, DateTimeKind.Local).AddTicks(5192), new DateTime(2024, 9, 3, 9, 42, 38, 649, DateTimeKind.Local).AddTicks(5190) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5193), new DateTime(2024, 9, 1, 9, 42, 38, 649, DateTimeKind.Local).AddTicks(5197), new DateTime(2024, 9, 1, 7, 42, 38, 649, DateTimeKind.Local).AddTicks(5196) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5198), new DateTime(2024, 9, 4, 14, 2, 38, 649, DateTimeKind.Local).AddTicks(5202), new DateTime(2024, 9, 4, 13, 44, 38, 649, DateTimeKind.Local).AddTicks(5200) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5203), new DateTime(2024, 9, 4, 4, 42, 38, 649, DateTimeKind.Local).AddTicks(5206), new DateTime(2024, 9, 4, 2, 42, 38, 649, DateTimeKind.Local).AddTicks(5205) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5207), new DateTime(2024, 9, 3, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5210), new DateTime(2024, 9, 3, 12, 42, 38, 649, DateTimeKind.Local).AddTicks(5209) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5211), new DateTime(2024, 9, 5, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5214), new DateTime(2024, 9, 5, 12, 42, 38, 649, DateTimeKind.Local).AddTicks(5213) });

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5250));

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "Id", "DateCreated", "DateModified", "KrajnjiRok", "Naziv", "Opis", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2024, 9, 5, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5304), "Polozit rs2", "Izac na ispit i polozit", "U toku", 1 },
                    { 2, null, null, new DateTime(2024, 9, 25, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5312), "Zavrsit fax", "Zavrsiti sve ispite", "U toku", 3 },
                    { 3, null, null, new DateTime(2024, 9, 6, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5314), "Stici na voz", "Stici na voz u 5", "U toku", 2 },
                    { 4, null, null, new DateTime(2024, 8, 31, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5316), "Zavrsiti seminarski iz rs2", "Da seminarski bude prihvacen", "Realizovana", 4 },
                    { 5, null, null, new DateTime(2024, 3, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5317), "Zavrsiti fax u roku", "Ne cekati puno i zavrisit fax na vrijeme", "Istekla", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 9, 4, 13, 42, 38, 649, DateTimeKind.Local).AddTicks(5112));

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_UserId",
                table: "ToDo",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo");

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
