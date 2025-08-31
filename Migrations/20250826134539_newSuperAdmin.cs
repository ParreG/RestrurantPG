using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestrurantPG.Migrations
{
    /// <inheritdoc />
    public partial class newSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Admin_Id", "Email", "PasswordHash", "Role", "UserName" },
                values: new object[] { 1, "Parman.gitijah@yahoo.com", "$2a$11$VA0.5ZyTnOGfuSBhoJjYyO0FBlZpE8T8d5GN0QORxl4vJSVBci1ke", "SuperAdmin", "ParGit99" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Admin_Id",
                keyValue: 1);
        }
    }
}
