using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifyVehicleClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Location_CurrentLocationId",
                table: "Vehicle");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.AlterColumn<int>(
                name: "CurrentLocationId",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
               table: "Company",
               columns: new[] { "Id", "DateCreated", "DateModified", "Name" },
               values: new object[,]
               {
                    { 1, new DateTime(2023, 6, 14, 21, 33, 56, 595, DateTimeKind.Local).AddTicks(6301), null, "Sarajevo Taxi" },
                    { 2, new DateTime(2023, 6, 14, 21, 33, 56, 595, DateTimeKind.Local).AddTicks(6370), null, "Mostar Taxi" }
               });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 3, null, "CompanyAdmin", "COMPANYADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e01c1309-e7bd-4a94-89d6-3599df2ee919", "AQAAAAIAAYagAAAAEFm1llryNtRoGMAGz6unHbW72X14k0cHVmVzSjoMBtrNQG5VhOjEkMM7T8Juvrx+Dg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompanyId", "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { 1, "a30d8da3-d8ec-474d-b116-c3a0da5a3fd6", "kompanija@admin.com", "Sarajevo", "Taxi", "KOMPANIJA@ADMIN.COM", "KOMPANIJA SARAJEVO", "AQAAAAIAAYagAAAAEPbN7+WL5Oj4SbOP6p7khPfozEun8GcHeGPyRV0UjOdWRQuuff7aQ15Vjh+KDw2S4g==", "kompanija Sarajevo" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "a0353b73-d344-4f8c-bf88-b57520937870", "user1@taxi.com", "User", "br1", "USER1@TAXI.COM", "USER BR1", "AQAAAAIAAYagAAAAEJdzgp/b47fgZOAtfJoL2mZyS4U0JCIdn0+aWanei97K8LY6IsC/+a9jX6orm1eTlg==", "user br1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pin", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 4, 0, null, "ba069794-d86b-492c-a79a-6ac520c8009f", null, null, "user2@taxi.com", true, "User", "br2", false, null, "USER2@TAXI.COM", "USER BR2", "AQAAAAIAAYagAAAAEAkyyXiBO86HXZjZJHDKZaf8RRaUeYB6K16UKvhU2A12WvPjIle/sJQ2O3l4MAUHKQ==", null, false, null, "", false, "user br2" },
                    { 5, 0, null, "1b8c330a-8e1f-4096-82a4-010f71f25c7e", null, null, "user3@taxi.com", true, "User", "br3", false, null, "USER3@TAXI.COM", "USER BR3", "AQAAAAIAAYagAAAAEKMdOiAklLtT/txSzXnJxnyrt8GdCe+cDinUKGNyIQxmhy9Suri9pcOs7GdG45iRMw==", null, false, null, "", false, "user br3" },
                    { 6, 0, null, "d8d473dc-d974-4923-affa-bf11f9057285", null, null, "user4@taxi.com", true, "User", "br4", false, null, "USER4@TAXI.COM", "USER BR4", "AQAAAAIAAYagAAAAEHQpiJy+9iWg0LJO8XZf/r6ohGEz5zOKmkqP58fBkjwkOiu4fhZfSiB1zdP/dYY3Bg==", null, false, null, "", false, "user br4" },
                    { 7, 0, null, "65efeb98-9726-4de8-9067-2486eba401ac", null, null, "user5@taxi.com", true, "User", "br5", false, null, "USER5@TAXI.COM", "USER BR5", "AQAAAAIAAYagAAAAENfv1pSkZala88ogUyLHIkmjIdgX4+ixKTMlKW/JtjHDKhOOb7W0XHo5IDqeg6ts5Q==", null, false, null, "", false, "user br5" },
                    { 8, 0, null, "f042bdbc-34ca-49c3-bfa2-4b6e102684c2", null, null, "user6@taxi.com", true, "User", "br6", false, null, "USER6@TAXI.COM", "USER BR6", "AQAAAAIAAYagAAAAEMRhPVAt6OfuXILuglppjJAl6mvDnZ+fOSYfD5d8oG7BXwVhm4leiznkuNG711IrtA==", null, false, null, "", false, "user br6" }
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

            migrationBuilder.UpdateData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Malo auto");

            migrationBuilder.UpdateData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Limuzina");

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "ImageUrl", "NumberOfSeats", "Type" },
                values: new object[] { 4, "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/Bus_ogtv6k.png", 9, "MiniVan" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, 2 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 }
                });

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
                    { 1, true, true, "Audi", "Siva", 1, null, new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3768), null, "Benzin", "https://res.cloudinary.com/doswamdah/image/upload/v1656523883/rs2/audia8_gckbfh.png", 50000.0, "ABC123", "Audi A8", 6, "Automatic", 2, 3, 2019 },
                    { 2, true, true, "Volkswagen", "Siva", 1, null, new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3824), null, "Dizel", "https://res.cloudinary.com/doswamdah/image/upload/v1656523879/rs2/golf_7_didjje.jpg", 80000.0, "XYZ789", "Volkswagen Golf 7", 3, "Manual", 1, 4, 2017 },
                    { 3, true, true, "BMW", "Plava", 1, null, new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3831), null, "Dizel", "https://res.cloudinary.com/doswamdah/image/upload/v1686762738/bmw-x5_qbbvec.jpg", 60000.0, "DEF456", "BMW X5", 9, "Automatic", 3, 5, 2020 },
                    { 4, true, true, "Mercedes", "White", 2, null, new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3835), null, "Benzin", "https://res.cloudinary.com/doswamdah/image/upload/v1686765411/benz-c-class_msuspq.jpg", 40000.0, "GHI789", "Mercedes-Benz C-Class", 10, "Automatic", 2, 6, 2021 },
                    { 5, true, false, "Audi", "Red", null, null, new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3838), null, "Dizel", "https://res.cloudinary.com/doswamdah/image/upload/v1686765730/Audi_A3_snaxht.webp", 55000.0, "JKL012", "Audi A3", 4, "Automatic", 1, 7, 2016 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CancelReason", "DateCreated", "DateModified", "EndLocationId", "EndTime", "IsActive", "IsCanceled", "IsSelfDrive", "PaymentMethod", "Price", "StartLocationId", "StartTime", "UserDriverId", "UserId", "VehicleId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3884), null, 2, new DateTime(2023, 6, 14, 23, 33, 57, 321, DateTimeKind.Local).AddTicks(3895), true, false, false, "Online", 36.0, 1, new DateTime(2023, 6, 14, 22, 33, 57, 321, DateTimeKind.Local).AddTicks(3888), 3, 8, 1 },
                    { 2, null, new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3902), null, 3, new DateTime(2023, 6, 15, 1, 33, 57, 321, DateTimeKind.Local).AddTicks(3908), true, false, false, "Gotovina", 357.0, 2, new DateTime(2023, 6, 14, 23, 33, 57, 321, DateTimeKind.Local).AddTicks(3906), 4, 7, 2 },
                    { 3, null, new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3910), null, 6, new DateTime(2023, 6, 14, 20, 33, 57, 321, DateTimeKind.Local).AddTicks(3915), false, false, false, "Gotovina", 83.700000000000003, 4, new DateTime(2023, 6, 14, 19, 33, 57, 321, DateTimeKind.Local).AddTicks(3913), 5, 8, 3 },
                    { 4, null, new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3917), null, 1, new DateTime(2023, 6, 13, 19, 33, 57, 321, DateTimeKind.Local).AddTicks(3924), false, false, false, "Online", 1210.0, 5, new DateTime(2023, 6, 13, 17, 33, 57, 321, DateTimeKind.Local).AddTicks(3921), 6, 4, 4 },
                    { 5, null, new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3926), null, 1, new DateTime(2023, 6, 11, 17, 33, 57, 321, DateTimeKind.Local).AddTicks(3931), true, false, false, "Gotovina", 500.0, 3, new DateTime(2023, 6, 11, 15, 33, 57, 321, DateTimeKind.Local).AddTicks(3929), 7, 8, 5 },
                    { 6, null, new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3934), null, 1, new DateTime(2023, 6, 14, 21, 53, 57, 321, DateTimeKind.Local).AddTicks(3942), true, false, false, "Online", 32.299999999999997, 6, new DateTime(2023, 6, 14, 21, 35, 57, 321, DateTimeKind.Local).AddTicks(3939), 3, 6, 1 },
                    { 7, "Pokvareno vozilo", new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3944), null, 1, new DateTime(2023, 6, 14, 12, 33, 57, 321, DateTimeKind.Local).AddTicks(3948), false, true, false, "Gotovina", 36.0, 2, new DateTime(2023, 6, 14, 10, 33, 57, 321, DateTimeKind.Local).AddTicks(3946), 3, 5, 1 },
                    { 8, null, new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3950), null, 4, new DateTime(2023, 6, 13, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(3954), false, false, false, "Gotovina", 78.0, 1, new DateTime(2023, 6, 13, 20, 33, 57, 321, DateTimeKind.Local).AddTicks(3953), 6, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Comment", "DateCreated", "DateModified", "Grade", "OrderId", "UserDriverId", "UserId" },
                values: new object[,]
                {
                    { 1, "Odlična vožnja, vozač je bio veoma ljubazan i profesionalan.", new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(4089), null, 5, 6, 3, 6 },
                    { 2, "Sjajno iskustvo, vozač je bio veoma pristojan i vozilo je bilo čisto i udobno.", new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(4098), null, 5, 4, 6, 4 },
                    { 3, "taxi nikad nije ni dosao. Navodno se pokvarilo vozilo", new DateTime(2023, 6, 14, 21, 33, 57, 321, DateTimeKind.Local).AddTicks(4101), null, 2, 7, 3, 5 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Location_CurrentLocationId",
                table: "Vehicle",
                column: "CurrentLocationId",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Location_CurrentLocationId",
                table: "Vehicle");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "HubStation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HubStation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HubStation",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentLocationId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1d6ac2aa-a224-4651-9c33-b59dd6c771f7", "AQAAAAIAAYagAAAAEKyzN53WJo5/Nh8pTP9u6Nrua0SPya2hXoExW5pdVt+SXxJh/YmkadqiqEy05LzjsQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompanyId", "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { null, "4f7cdce2-d19f-40c6-9e31-fa12b667520a", "fazla@admin.com", "Muhamed", "Fazlic", "FAZLA@ADMIN.COM", "FAZLA", "AQAAAAIAAYagAAAAEOkvcrO3FZeRL7TV5JOyeSwlatcnxAuC8yk5grIXUE4tPf03lWInCoDqst/uSM+KgA==", "fazla" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "63bb5db3-2192-43ca-9974-a9878da8eef1", "billy@admin.com", "Bilal", "Hodzic", "BILLY@ADMIN.COM", "BILLY", "AQAAAAIAAYagAAAAEIfApJMY2WsNsdSVltjPIIu6DYJUIr034NVpIG4tJa8YzdfEsJ5d1HT+Q/PUH4sRYw==", "billy" });

            migrationBuilder.UpdateData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "malo auto");

            migrationBuilder.UpdateData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "limuzina");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Location_CurrentLocationId",
                table: "Vehicle",
                column: "CurrentLocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
