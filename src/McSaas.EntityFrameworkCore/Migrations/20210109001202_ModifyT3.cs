using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace McSaas.Migrations
{
    public partial class ModifyT3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Community_CommunityId",
                table: "House");

            migrationBuilder.DropIndex(
                name: "IX_House_CommunityId",
                table: "House");

            migrationBuilder.DropColumn(
                name: "CommunityId",
                table: "House");

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "House",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "Community",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CommunityId = table.Column<int>(nullable: true),
                    HouseNumber = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Building_Community_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Community",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_House_BuildingId",
                table: "House",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_CommunityId",
                table: "Building",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_House_Building_BuildingId",
                table: "House",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Building_BuildingId",
                table: "House");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropIndex(
                name: "IX_House_BuildingId",
                table: "House");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "House");

            migrationBuilder.AddColumn<int>(
                name: "CommunityId",
                table: "House",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "Community",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_House_CommunityId",
                table: "House",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_House_Community_CommunityId",
                table: "House",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
