using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedLocationAndVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KmTraveled = table.Column<double>(type: "float", nullable: false),
                    LicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    AirCondition = table.Column<bool>(type: "bit", nullable: false),
                    AirBag = table.Column<bool>(type: "bit", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentLocationId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerKm = table.Column<int>(type: "int", nullable: false),
                    UserDriverId = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_AspNetUsers_UserDriverId",
                        column: x => x.UserDriverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicle_Location_CurrentLocationId",
                        column: x => x.CurrentLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "79123e59-e8ee-412f-8d76-82be19e1ff8e", "AQAAAAIAAYagAAAAEJLbD0gp2/MFmJSFfvXWfAmxJ/yuLoGdTp3ZPL2a1z7fprQlFFIYaMiuXGrNueW0+A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4b85e896-2153-4307-9884-aec70dfab35e", "AQAAAAIAAYagAAAAEKRhYlxJ+xWy5OZp2t2GBAmNXNlbwAlaRBS8OdJQn+I2w0EUSnttgbjC0JRrPKEV+Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b2625ec5-361c-4c24-bc23-732db5617795", "AQAAAAIAAYagAAAAEIAHyjGiuEE4HJgDvx2cjQhJaMRHMr96cQxGMEVg0wgfRe8mkRT9mAMqJXy58hXmiQ==" });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "ImageUrl", "NumberOfSeats", "Type" },
                values: new object[,]
                {
                    { 1, "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/car_l5aypi.png", 4, "malo auto" },
                    { 2, "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/sedan_j0oo9s.png", 5, "limuzina" },
                    { 3, "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/SUV_hjqwbi.png", 5, "SUV" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CurrentLocationId",
                table: "Vehicle",
                column: "CurrentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TypeId",
                table: "Vehicle",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_UserDriverId",
                table: "Vehicle",
                column: "UserDriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "963ae747-6256-43ce-9ef1-c0ad8ba49d25", "AQAAAAIAAYagAAAAEJ5OBA0gXmE5+CuzOvotRaapevPsmV/fSyh4d/mjB+h9y2WML7KRDWo6zHkTh6mpHg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2bfdc7e0-db2d-446e-8df3-b7bd3cc7651a", "AQAAAAIAAYagAAAAEKsqNwKSJAeB+ICPL4EbFlF4gJbgTxDB9qE54fkhdUKfKvQzzuJpNz7OYjaGgtuBEA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee1be750-0ee6-46e9-b150-0c1053255c26", "AQAAAAIAAYagAAAAEKSK1NlEMPXrQnxI72Q1mC9kK/YJtaq1Pg0vUO/6rJKhHwfidDZM7y+9ohuYzkDX6w==" });
        }
    }
}
