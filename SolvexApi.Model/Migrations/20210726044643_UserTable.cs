using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericApi.Model.Migrations
{
    public partial class UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkShopMembers_Members_MemberId",
                table: "WorkShopMembers");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropIndex(
                name: "IX_WorkShopMembers_MemberId",
                table: "WorkShopMembers");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "WorkShopMembers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WorkShopMembers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SecondLastName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: true),
                    DocumentType = table.Column<int>(nullable: false),
                    DocumentTypeValue = table.Column<string>(nullable: true),
                    PhotoId = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Documents_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkShopMembers_UserId",
                table: "WorkShopMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhotoId",
                table: "Users",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShopMembers_Users_UserId",
                table: "WorkShopMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkShopMembers_Users_UserId",
                table: "WorkShopMembers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_WorkShopMembers_UserId",
                table: "WorkShopMembers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WorkShopMembers");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "WorkShopMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoId = table.Column<int>(type: "int", nullable: true),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Documents_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkShopMembers_MemberId",
                table: "WorkShopMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PhotoId",
                table: "Members",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShopMembers_Members_MemberId",
                table: "WorkShopMembers",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
