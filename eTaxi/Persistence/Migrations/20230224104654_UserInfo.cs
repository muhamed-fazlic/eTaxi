using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "6d09071f-7fa9-454e-86ce-412ef51e28ca", "Admin", "eTaxi", "AQAAAAIAAYagAAAAEACqrannKDzz5M6naRuo6FDAAVFL+txa4WWIHJnuHJL6KwE8ARmK4GhIwUfTzW7OpA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "674f04c2-e800-4982-808f-e100a4b610f2", "Muhamed", "Fazlic", "AQAAAAIAAYagAAAAEA5CgYPlrTjL7nsHh7P1oPt/iWutxq8QhGsTMgPzzaxHvsCsGoIEuenITtjx0o608Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "7e9ed811-ff51-4549-9f81-6cd0eee1731e", "Bilal", "Hodzic", "AQAAAAIAAYagAAAAEDspEamEnrp6WnMYaR29Y7Zyf0Fdt22FTuI+lBcahcBqpQJEVmWpDH1tG/YdIkbM6w==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "567f6820-bfc4-4399-af98-9c709f771ce5", "", "", "AQAAAAIAAYagAAAAEOD1NNmr0Pyaxkj2EMhl9AEghG3+QcD20smz+bSXFojNb6sasJFfsnWQkTxRDT1jNw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "6b41218a-b9b3-4a13-83b8-68e5ce90709d", "", "", "AQAAAAIAAYagAAAAEIQLyh8wUYa0QgEkxnOTH9a/NGbDvBIRH8BLZwqngkGl2Ux/qXn1+LdudYqWn2Loog==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "17efc502-987b-405e-8662-70d244beb4c8", "", "", "AQAAAAIAAYagAAAAEFXSnCC5a4nqZ2qndK4V2RlBVppQfEFdFNa3ciZt1t0wwtEQyjpkeo8IOZf8+OkVew==" });
        }
    }
}
