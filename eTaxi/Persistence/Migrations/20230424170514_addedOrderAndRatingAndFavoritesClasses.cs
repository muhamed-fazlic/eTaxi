using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedOrderAndRatingAndFavoritesClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorite_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserDriverId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    StartLocationId = table.Column<int>(type: "int", nullable: false),
                    EndLocationId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    IsSelfDrive = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserDriverId",
                        column: x => x.UserDriverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Location_EndLocationId",
                        column: x => x.EndLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Location_StartLocationId",
                        column: x => x.StartLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Order_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserDriverId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_AspNetUsers_UserDriverId",
                        column: x => x.UserDriverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rating_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f68aae51-e390-4dd3-b22f-84cdb2773f1f", "AQAAAAIAAYagAAAAEJl8+ZxHONSi3/3VC6Q+nAI1CIoauVTYTeXqSuH1NaYY2nrzdMpdmv+RR6vPgkfA/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a204ffb-def3-4159-a715-e1bee80d5228", "AQAAAAIAAYagAAAAEEaXKM7h7MHx01p+inmswWHnsOzBL3T/0E/FMbcimAPD3ocVQh4SbMBd91MSSPVWFg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "83289843-6fcf-443f-86b6-c859ebeaeb18", "AQAAAAIAAYagAAAAEK3Iol0tu8Q3GL1kadIkKGrR6D+7zYGjs1ffvR9/ZBYiwSLQKIZoI6X0Evfjb862lg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_UserId",
                table: "Favorite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EndLocationId",
                table: "Order",
                column: "EndLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StartLocationId",
                table: "Order",
                column: "StartLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserDriverId",
                table: "Order",
                column: "UserDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_VehicleId",
                table: "Order",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_OrderId",
                table: "Rating",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserDriverId",
                table: "Rating",
                column: "UserDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Order");

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
        }
    }
}
