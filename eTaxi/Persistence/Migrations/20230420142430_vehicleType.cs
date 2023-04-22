using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class vehicleType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pin",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.VehicleTypeId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Pin" },
                values: new object[] { "88f812a9-1d1b-40c3-a3ba-e391214b65ac", "AQAAAAIAAYagAAAAENhymgBRMZ8CH+KgLEVHPRufjvn3ujXi0CzSONVw+qT5S1uPHSXWfGxIq5Qaelodzw==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Pin" },
                values: new object[] { "8b07d52f-e485-42eb-a672-e61f9c97fa44", "AQAAAAIAAYagAAAAEGpkDLVbeEf5luOwdmt41SG6uuWOQIvMMAPUYgp4Z+6r+gLd0tiZ9ttBYVMN0S2ghQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Pin" },
                values: new object[] { "44310c5c-8677-43d1-9c0b-203fbf604b4d", "AQAAAAIAAYagAAAAEPmWiOG5qPMsCYsqLsCaJ6b2CanVxL3X38FG0F00k28aAeZlhO3jb3kNPDL8iEJgNQ==", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropColumn(
                name: "Pin",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d09071f-7fa9-454e-86ce-412ef51e28ca", "AQAAAAIAAYagAAAAEACqrannKDzz5M6naRuo6FDAAVFL+txa4WWIHJnuHJL6KwE8ARmK4GhIwUfTzW7OpA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "674f04c2-e800-4982-808f-e100a4b610f2", "AQAAAAIAAYagAAAAEA5CgYPlrTjL7nsHh7P1oPt/iWutxq8QhGsTMgPzzaxHvsCsGoIEuenITtjx0o608Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e9ed811-ff51-4549-9f81-6cd0eee1731e", "AQAAAAIAAYagAAAAEDspEamEnrp6WnMYaR29Y7Zyf0Fdt22FTuI+lBcahcBqpQJEVmWpDH1tG/YdIkbM6w==" });
        }
    }
}
