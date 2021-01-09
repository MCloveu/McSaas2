using Microsoft.EntityFrameworkCore.Migrations;

namespace McSaas.Migrations
{
    public partial class ModifyT4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Community_CommunityId",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_House_Building_BuildingId",
                table: "House");

            migrationBuilder.DropIndex(
                name: "IX_House_BuildingId",
                table: "House");

            migrationBuilder.DropIndex(
                name: "IX_Building_CommunityId",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "House");

            migrationBuilder.DropColumn(
                name: "CommunityId",
                table: "Building");

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Community",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseId",
                table: "Building",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Community_BuildingId",
                table: "Community",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_HouseId",
                table: "Building",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Building_House_HouseId",
                table: "Building",
                column: "HouseId",
                principalTable: "House",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Community_Building_BuildingId",
                table: "Community",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_House_HouseId",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_Community_Building_BuildingId",
                table: "Community");

            migrationBuilder.DropIndex(
                name: "IX_Community_BuildingId",
                table: "Community");

            migrationBuilder.DropIndex(
                name: "IX_Building_HouseId",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Community");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "Building");

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "House",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommunityId",
                table: "Building",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_House_BuildingId",
                table: "House",
                column: "BuildingId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_House_Building_BuildingId",
                table: "House",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
