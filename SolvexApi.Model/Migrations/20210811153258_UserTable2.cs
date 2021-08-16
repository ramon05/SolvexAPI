using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericApi.Model.Migrations
{
    public partial class UserTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Deleted", "DeletedBy", "DeletedDate", "Dob", "DocumentType", "DocumentTypeValue", "Gender", "LastName", "MiddleName", "Name", "Password", "PhotoId", "SecondLastName", "UpdatedBy", "UpdatedDate", "UserName" },
                values: new object[] { 1, null, new DateTimeOffset(new DateTime(2021, 8, 11, 15, 32, 56, 137, DateTimeKind.Unspecified).AddTicks(6232), new TimeSpan(0, 0, 0, 0, 0)), false, null, null, new DateTime(2021, 8, 11, 10, 32, 56, 137, DateTimeKind.Local).AddTicks(8277), 0, "00000000000", 0, "Admin", "Admin", "Admin", "Hola123,", null, "Admin", null, null, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
