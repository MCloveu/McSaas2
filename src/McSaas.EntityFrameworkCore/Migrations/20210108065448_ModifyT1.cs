using Microsoft.EntityFrameworkCore.Migrations;

namespace McSaas.Migrations
{
    public partial class ModifyT1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Resident",
                schema: "dbo",
                newName: "Owner");

            migrationBuilder.RenameTable(
                name: "House",
                schema: "dbo",
                newName: "House");

            migrationBuilder.RenameTable(
                name: "Community",
                schema: "dbo",
                newName: "Community");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Owner",
                newName: "Resident",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "House",
                newName: "House",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Community",
                newName: "Community",
                newSchema: "dbo");
        }
    }
}
