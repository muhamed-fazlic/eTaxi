using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedCompanyClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancelReason",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Order",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyId", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { null, "1d6ac2aa-a224-4651-9c33-b59dd6c771f7", "AQAAAAIAAYagAAAAEKyzN53WJo5/Nh8pTP9u6Nrua0SPya2hXoExW5pdVt+SXxJh/YmkadqiqEy05LzjsQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompanyId", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { null, "4f7cdce2-d19f-40c6-9e31-fa12b667520a", "AQAAAAIAAYagAAAAEOkvcrO3FZeRL7TV5JOyeSwlatcnxAuC8yk5grIXUE4tPf03lWInCoDqst/uSM+KgA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompanyId", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { null, "63bb5db3-2192-43ca-9974-a9878da8eef1", "AQAAAAIAAYagAAAAEIfApJMY2WsNsdSVltjPIIu6DYJUIr034NVpIG4tJa8YzdfEsJ5d1HT+Q/PUH4sRYw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CompanyId",
                table: "Vehicle",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_CompanyId",
                table: "Favorite",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Company_CompanyId",
                table: "Favorite",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Company_CompanyId",
                table: "Vehicle",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_Company_CompanyId",
                table: "Favorite");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Company_CompanyId",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_CompanyId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Favorite_CompanyId",
                table: "Favorite");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CancelReason",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6f59bd05-e37f-4a2e-8ea9-65a030a5c1b0", "AQAAAAIAAYagAAAAEJLQMH38UhDhMwCZ0Ij1nG3qVtwvJ2YmZh+g1seFocUg3h7+PMyZRGVRDWICO5bl0g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b290b7de-1a4b-4253-be98-2e6b77154d58", "AQAAAAIAAYagAAAAEDKaJrPWl5sBLqp9mfQF2W8RPoavNQPCddgYbJdMngXd+pfPg1v9C5Anm4lDVBKtxw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fc9b991a-b998-4e41-a8d9-49b668ee6a0c", "AQAAAAIAAYagAAAAEJjt0HdBw4PwukC355M54jOymQ6RIQ6bLF4ZxMQkSbUVbVBdQ3ggeYMM1VQ1yAsxNQ==" });
        }
    }
}
