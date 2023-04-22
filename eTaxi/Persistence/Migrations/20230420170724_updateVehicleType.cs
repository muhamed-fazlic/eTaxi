using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateVehicleType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                table: "VehicleType",
                newName: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VehicleType",
                newName: "VehicleTypeId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88f812a9-1d1b-40c3-a3ba-e391214b65ac", "AQAAAAIAAYagAAAAENhymgBRMZ8CH+KgLEVHPRufjvn3ujXi0CzSONVw+qT5S1uPHSXWfGxIq5Qaelodzw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b07d52f-e485-42eb-a672-e61f9c97fa44", "AQAAAAIAAYagAAAAEGpkDLVbeEf5luOwdmt41SG6uuWOQIvMMAPUYgp4Z+6r+gLd0tiZ9ttBYVMN0S2ghQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44310c5c-8677-43d1-9c0b-203fbf604b4d", "AQAAAAIAAYagAAAAEPmWiOG5qPMsCYsqLsCaJ6b2CanVxL3X38FG0F00k28aAeZlhO3jb3kNPDL8iEJgNQ==" });
        }
    }
}
