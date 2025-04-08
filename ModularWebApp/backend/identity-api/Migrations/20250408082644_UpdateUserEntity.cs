using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace identity_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "Users",
                newName: "RolesRaw");

            migrationBuilder.RenameColumn(
                name: "Permissions",
                table: "Users",
                newName: "PermissionsRaw");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RolesRaw",
                table: "Users",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "PermissionsRaw",
                table: "Users",
                newName: "Permissions");
        }
    }
}
