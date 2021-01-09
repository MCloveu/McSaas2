using Microsoft.EntityFrameworkCore.Migrations;

namespace McSaas.Migrations
{
    public partial class ModifyTenantid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                schema: "dbo",
                table: "Owner",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommunityId",
                schema: "dbo",
                table: "House",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                schema: "dbo",
                table: "House",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                schema: "dbo",
                table: "Community",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_House_CommunityId",
                schema: "dbo",
                table: "House",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_House_Community_CommunityId",
                schema: "dbo",
                table: "House",
                column: "CommunityId",
                principalSchema: "dbo",
                principalTable: "Community",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Community_CommunityId",
                schema: "dbo",
                table: "House");

            migrationBuilder.DropIndex(
                name: "IX_House_CommunityId",
                schema: "dbo",
                table: "House");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "dbo",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "CommunityId",
                schema: "dbo",
                table: "House");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "dbo",
                table: "House");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "dbo",
                table: "Community");
        }
    }
}
