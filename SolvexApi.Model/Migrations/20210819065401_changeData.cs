using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericApi.Model.Migrations
{
    public partial class changeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkShopDays_WorkShops_WorkShopId",
                table: "WorkShopDays");

            migrationBuilder.AlterColumn<int>(
                name: "WorkShopId",
                table: "WorkShopDays",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "StartHour",
                table: "WorkShopDays",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EndHour",
                table: "WorkShopDays",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Dob" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 19, 6, 53, 58, 864, DateTimeKind.Unspecified).AddTicks(1096), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 8, 19, 1, 53, 58, 864, DateTimeKind.Local).AddTicks(4230) });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShopDays_WorkShops_WorkShopId",
                table: "WorkShopDays",
                column: "WorkShopId",
                principalTable: "WorkShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkShopDays_WorkShops_WorkShopId",
                table: "WorkShopDays");

            migrationBuilder.AlterColumn<int>(
                name: "WorkShopId",
                table: "WorkShopDays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartHour",
                table: "WorkShopDays",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndHour",
                table: "WorkShopDays",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Dob" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 15, 15, 27, 19, 226, DateTimeKind.Unspecified).AddTicks(2988), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2021, 8, 15, 10, 27, 19, 226, DateTimeKind.Local).AddTicks(4890) });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShopDays_WorkShops_WorkShopId",
                table: "WorkShopDays",
                column: "WorkShopId",
                principalTable: "WorkShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
