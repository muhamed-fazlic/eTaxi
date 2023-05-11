using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTaxi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateLocationAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Location",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Location",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Location",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Location",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb20ab16-a05f-43bb-9265-418d72122c2e", "AQAAAAIAAYagAAAAEJq7Mgpf2FAxeFPlyUMt4B6VIz01GkHFwgFq6u553aoOTTIcUCuvr/QMm/7gfQhT2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "734e1f16-6a93-4d98-bb6b-8a7c2ecaf40e", "AQAAAAIAAYagAAAAEBawG8xEJnkcCGroRisDeXR5Q+CD3hc1JDGVCe2x3iwpUClhf5uI5aSY/vccOF/+yg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f85d4bd4-7c40-44c0-be0f-3f197b416a74", "AQAAAAIAAYagAAAAENCJKFpnBHF0Tz3QQG7FmVexhfkdQsKu7rWGEqMRxGyAs0G0tGyen2hmtAZvKQ2DmQ==" });
        }
    }
}
