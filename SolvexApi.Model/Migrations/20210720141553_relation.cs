using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolvexApi.Model.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkShopMembers",
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
                    Role = table.Column<int>(nullable: false),
                    WorkShopId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShopMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShopMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkShopMembers_WorkShops_WorkShopId",
                        column: x => x.WorkShopId,
                        principalTable: "WorkShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkShopMembers_MemberId",
                table: "WorkShopMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShopMembers_WorkShopId",
                table: "WorkShopMembers",
                column: "WorkShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkShopMembers");
        }
    }
}
