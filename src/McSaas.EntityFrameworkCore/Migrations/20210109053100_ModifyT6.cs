using Microsoft.EntityFrameworkCore.Migrations;

namespace McSaas.Migrations
{
    public partial class ModifyT6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Community_Building_BuildingId",
                table: "Community");

            migrationBuilder.DropIndex(
                name: "IX_Community_BuildingId",
                table: "Community");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Community");

            migrationBuilder.AddColumn<int>(
                name: "CommunityId",
                table: "Building",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Building_CommunityId",
                table: "Building",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Community_CommunityId",
                table: "Building",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Community_CommunityId",
                table: "Building");

            migrationBuilder.DropIndex(
                name: "IX_Building_CommunityId",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "CommunityId",
                table: "Building");

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Community",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Community_BuildingId",
                table: "Community",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Community_Building_BuildingId",
                table: "Community",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
