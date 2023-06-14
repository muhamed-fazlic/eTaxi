using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pin = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HubStation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubStation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HubStation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_Favorite_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CurrentLocationId = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerKm = table.Column<int>(type: "int", nullable: false),
                    UserDriverId = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Vehicle_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicle_Location_CurrentLocationId",
                        column: x => x.CurrentLocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VehicleType",
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
                    IsCanceled = table.Column<bool>(type: "bit", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDriverId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    StartLocationId = table.Column<int>(type: "int", nullable: true),
                    EndLocationId = table.Column<int>(type: "int", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    IsSelfDrive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Location_StartLocationId",
                        column: x => x.StartLocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Feedback_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserDriverId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rating_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Feedback_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedback",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "User", "USER" },
                    { 3, null, "CompanyAdmin", "COMPANYADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pin", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, "775531be-b8d0-42aa-9847-5c8237054161", null, null, "admin@admin.com", true, "Admin", "eTaxi", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEH1LP7SYcHyzFBt5pio9QesUb0ONSy92NmwNgfw0hF2rhBCVZ9bKFSsqdqnSlaHrLg==", null, false, null, "", false, "admin" },
                    { 3, 0, null, "6b7d0e08-81f6-4321-afa7-52acc888142e", null, null, "user1@taxi.com", true, "User", "br1", false, null, "USER1@TAXI.COM", "USER BR1", "AQAAAAIAAYagAAAAEPNh4Nsj2+6w9plxGlfoZ0c5LjBmalLHqljL6NhgEryvOLcY6+gemgJFgLhn8LTItg==", null, false, null, "", false, "user br1" },
                    { 4, 0, null, "af517832-f922-402c-be08-db07f81d4647", null, null, "user2@taxi.com", true, "User", "br2", false, null, "USER2@TAXI.COM", "USER BR2", "AQAAAAIAAYagAAAAEEoFLIEsPiSu0D5Gm3FaCINTUc8mQ1Jhc/X+Bqa6IjnHWhzGAIkfnGfdmcC64vUI5Q==", null, false, null, "", false, "user br2" },
                    { 5, 0, null, "7f60017c-cd51-42e5-b072-57eb09f9a1b7", null, null, "user3@taxi.com", true, "User", "br3", false, null, "USER3@TAXI.COM", "USER BR3", "AQAAAAIAAYagAAAAEMT6/A+Gj4xhePby4HADEG241XXlltiEPwNnYBpwAtXq3YOy7nPWYGXcYfsVQotoPA==", null, false, null, "", false, "user br3" },
                    { 6, 0, null, "ce9413e3-8cf0-4774-bb84-e96fb073f091", null, null, "user4@taxi.com", true, "User", "br4", false, null, "USER4@TAXI.COM", "USER BR4", "AQAAAAIAAYagAAAAEOULswAjxjXTTEi45XPdTh3LmvKJZV8b0LessaPAkfHcAfIGaQi2CGbkzISg1cA7zw==", null, false, null, "", false, "user br4" },
                    { 7, 0, null, "7b130c48-cf24-4395-b2f6-2a6b5539d3a8", null, null, "user5@taxi.com", true, "User", "br5", false, null, "USER5@TAXI.COM", "USER BR5", "AQAAAAIAAYagAAAAEFyTRpZubz9nQLH61/jlU0v1Isvlw131HOtU/tGD46r+VFg57y9PCJw9CvNXVW1v+w==", null, false, null, "", false, "user br5" },
                    { 8, 0, null, "f5585649-78ea-493a-93ea-0a9208fee9ad", null, null, "user6@taxi.com", true, "User", "br6", false, null, "USER6@TAXI.COM", "USER BR6", "AQAAAAIAAYagAAAAEOydW1pUBZh67a6GHNOaDSMjiiLW9ndX8AtGdyxkn8cStCL14TP1X7oAVr+aeLg0Lg==", null, false, null, "", false, "user br6" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 14, 23, 43, 49, 73, DateTimeKind.Local).AddTicks(5721), null, "Sarajevo Taxi" },
                    { 2, new DateTime(2023, 6, 14, 23, 43, 49, 73, DateTimeKind.Local).AddTicks(5797), null, "Mostar Taxi" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Address", "City", "Country", "DateCreated", "DateModified", "District", "Latitude", "Longitude", "PostalCode", "StreetName", "StreetNumber" },
                values: new object[,]
                {
                    { 1, "Marsala Tita 12, Centar, Sarajevo, 71000, Bosnia and Herzegovina", "Sarajevo", "BiH", null, null, "Centar", 43.856299999999997, 18.4131, "71000", "Marsala Tita", "12" },
                    { 2, "Dzemala Bijedica St 185, Sarajevo 71000", "Sarajevo", "BiH", null, null, "Sarajevo", 43.844961099999999, 18.337866200000001, "71000", "Dzemala Bijedica", "185" },
                    { 3, "Maršala Tita 8, Stari Grad, Mostar, 88000, Bosnia and Herzegovina", "Mostar", "BiH", null, null, "Stari Grad", 43.342399999999998, 17.808900000000001, "88000", "Maršala Tita", "8" },
                    { 4, "Aleja Bosne Srebrene 15, Novi Grad, Sarajevo, 71000, Bosnia and Herzegovina", "Sarajevo", "BiH", null, null, "Novi Grad", 43.870800000000003, 18.4314, "71000", "Aleja Bosne Srebrene", "15" },
                    { 5, "Titova 3, Centar, Tuzla, 75000, Bosnia and Herzegovina", "Tuzla", "BiH", null, null, "Centar", 44.534999999999997, 18.671399999999998, "75000", "Titova", "3" },
                    { 6, "VCJ7+59H, Patriotske lige 58, Sarajevo 71000", "Sarajevo", "BiH", null, null, "Centar", 43.874206600000001, 18.408753399999998, "71000", "Patriotske lige", "58" }
                });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "ImageUrl", "NumberOfSeats", "Type" },
                values: new object[,]
                {
                    { 1, "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/car_l5aypi.png", 4, "Malo auto" },
                    { 2, "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/sedan_j0oo9s.png", 5, "Limuzina" },
                    { 3, "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/SUV_hjqwbi.png", 5, "SUV" },
                    { 4, "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/Bus_ogtv6k.png", 9, "MiniVan" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pin", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, 1, "2ea9926a-9d18-42c6-9634-dfebca8663fc", null, null, "kompanija@admin.com", true, "Sarajevo", "Taxi", false, null, "KOMPANIJA@ADMIN.COM", "KOMPANIJA SARAJEVO", "AQAAAAIAAYagAAAAEPmT95zRgxFQlorMTEFjcUi9Cl3s00abXKbWnswoYeI0S1m4zGzB0eit76nVLweCnQ==", null, false, null, "", false, "kompanija Sarajevo" });

            migrationBuilder.InsertData(
                table: "HubStation",
                columns: new[] { "Id", "DateCreated", "DateModified", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, null, null, 1, "Sarajevo Hub" },
                    { 2, null, null, 3, "Mostar Hub" },
                    { 3, null, null, 5, "Tuzla Hub" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "AirBag", "AirCondition", "Brand", "Color", "CompanyId", "CurrentLocationId", "DateCreated", "DateModified", "FuelType", "ImageUrl", "KmTraveled", "LicenceNumber", "Name", "PricePerKm", "Transmission", "TypeId", "UserDriverId", "Year" },
                values: new object[,]
                {
                    { 1, true, true, "Audi", "Siva", 1, null, new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9257), null, "Benzin", "https://res.cloudinary.com/doswamdah/image/upload/v1656523883/rs2/audia8_gckbfh.png", 50000.0, "ABC123", "Audi A8", 6, "Automatic", 2, 3, 2019 },
                    { 2, true, true, "Volkswagen", "Siva", 1, null, new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9321), null, "Dizel", "https://res.cloudinary.com/doswamdah/image/upload/v1656523879/rs2/golf_7_didjje.jpg", 80000.0, "XYZ789", "Volkswagen Golf 7", 3, "Manual", 1, 4, 2017 },
                    { 3, true, true, "BMW", "Plava", 1, null, new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9450), null, "Dizel", "https://res.cloudinary.com/doswamdah/image/upload/v1686762738/bmw-x5_qbbvec.jpg", 60000.0, "DEF456", "BMW X5", 9, "Automatic", 3, 5, 2020 },
                    { 4, true, true, "Mercedes", "White", 2, null, new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9457), null, "Benzin", "https://res.cloudinary.com/doswamdah/image/upload/v1686765411/benz-c-class_msuspq.jpg", 40000.0, "GHI789", "Mercedes-Benz C-Class", 10, "Automatic", 2, 6, 2021 },
                    { 5, true, false, "Audi", "Red", null, null, new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9461), null, "Dizel", "https://res.cloudinary.com/doswamdah/image/upload/v1686765730/Audi_A3_snaxht.webp", 55000.0, "JKL012", "Audi A3", 4, "Automatic", 1, 7, 2016 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CancelReason", "DateCreated", "DateModified", "EndLocationId", "EndTime", "IsActive", "IsCanceled", "IsSelfDrive", "PaymentMethod", "Price", "StartLocationId", "StartTime", "UserDriverId", "UserId", "VehicleId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9525), null, 2, new DateTime(2023, 6, 15, 1, 43, 50, 100, DateTimeKind.Local).AddTicks(9541), true, false, false, "Online", 36.0, 1, new DateTime(2023, 6, 15, 0, 43, 50, 100, DateTimeKind.Local).AddTicks(9532), 3, 8, 1 },
                    { 2, null, new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9554), null, 3, new DateTime(2023, 6, 15, 3, 43, 50, 100, DateTimeKind.Local).AddTicks(9561), true, false, false, "Gotovina", 357.0, 2, new DateTime(2023, 6, 15, 1, 43, 50, 100, DateTimeKind.Local).AddTicks(9559), 4, 7, 2 },
                    { 3, null, new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9565), null, 6, new DateTime(2023, 6, 14, 22, 43, 50, 100, DateTimeKind.Local).AddTicks(9571), false, false, false, "Gotovina", 83.700000000000003, 4, new DateTime(2023, 6, 14, 21, 43, 50, 100, DateTimeKind.Local).AddTicks(9569), 5, 8, 3 },
                    { 4, null, new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9574), null, 1, new DateTime(2023, 6, 13, 21, 43, 50, 100, DateTimeKind.Local).AddTicks(9581), false, false, false, "Online", 1210.0, 5, new DateTime(2023, 6, 13, 19, 43, 50, 100, DateTimeKind.Local).AddTicks(9577), 6, 4, 4 },
                    { 5, null, new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9583), null, 1, new DateTime(2023, 6, 11, 19, 43, 50, 100, DateTimeKind.Local).AddTicks(9589), true, false, false, "Gotovina", 500.0, 3, new DateTime(2023, 6, 11, 17, 43, 50, 100, DateTimeKind.Local).AddTicks(9587), 7, 8, 5 },
                    { 6, null, new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9593), null, 1, new DateTime(2023, 6, 15, 0, 3, 50, 100, DateTimeKind.Local).AddTicks(9702), true, false, false, "Online", 32.299999999999997, 6, new DateTime(2023, 6, 14, 23, 45, 50, 100, DateTimeKind.Local).AddTicks(9698), 3, 6, 1 },
                    { 7, "Pokvareno vozilo", new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9706), null, 1, new DateTime(2023, 6, 14, 14, 43, 50, 100, DateTimeKind.Local).AddTicks(9713), false, true, false, "Gotovina", 36.0, 2, new DateTime(2023, 6, 14, 12, 43, 50, 100, DateTimeKind.Local).AddTicks(9711), 3, 5, 1 },
                    { 8, null, new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9716), null, 4, new DateTime(2023, 6, 13, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9721), false, false, false, "Gotovina", 78.0, 1, new DateTime(2023, 6, 13, 22, 43, 50, 100, DateTimeKind.Local).AddTicks(9719), 6, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Comment", "DateCreated", "DateModified", "Grade", "OrderId", "UserDriverId", "UserId" },
                values: new object[,]
                {
                    { 1, "Odlična vožnja, vozač je bio veoma ljubazan i profesionalan.", new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9778), null, 5, 6, 3, 6 },
                    { 2, "Sjajno iskustvo, vozač je bio veoma pristojan i vozilo je bilo čisto i udobno.", new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9795), null, 5, 4, 6, 4 },
                    { 3, "taxi nikad nije ni dosao. Navodno se pokvarilo vozilo", new DateTime(2023, 6, 14, 23, 43, 50, 100, DateTimeKind.Local).AddTicks(9798), null, 2, 7, 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_CompanyId",
                table: "Favorite",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_UserId",
                table: "Favorite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_OrderId",
                table: "Feedback",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserId",
                table: "Feedback",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_VehicleId",
                table: "Feedback",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_File_FeedbackId",
                table: "File",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_File_UserId",
                table: "File",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HubStation_LocationId",
                table: "HubStation",
                column: "LocationId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CompanyId",
                table: "Vehicle",
                column: "CompanyId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "HubStation");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
