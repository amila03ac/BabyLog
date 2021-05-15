using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyLog.Data.Migrations
{
    public partial class UpdateAuditFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "EventTypes",
                newName: "LastUpdatedByUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedAtUtc",
                table: "EventTypes",
                newName: "LastUpdatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "Events",
                newName: "LastUpdatedByUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedAtUtc",
                table: "Events",
                newName: "LastUpdatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "Babies",
                newName: "LastUpdatedByUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedAtUtc",
                table: "Babies",
                newName: "LastUpdatedAtUtc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdatedByUserId",
                table: "EventTypes",
                newName: "ModifiedByUserId");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedAtUtc",
                table: "EventTypes",
                newName: "ModifiedAtUtc");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedByUserId",
                table: "Events",
                newName: "ModifiedByUserId");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedAtUtc",
                table: "Events",
                newName: "ModifiedAtUtc");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedByUserId",
                table: "Babies",
                newName: "ModifiedByUserId");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedAtUtc",
                table: "Babies",
                newName: "ModifiedAtUtc");
        }
    }
}
