using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestrurantPG.Migrations
{
    /// <inheritdoc />
    public partial class updatedAppDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Guests_Guest_Id",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tables_Table_Id",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_Guest_Id",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_Table_Id",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Guest_Id",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Table_Id",
                table: "Bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Guest_Id",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Table_Id",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Guest_Id",
                table: "Bookings",
                column: "Guest_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Table_Id",
                table: "Bookings",
                column: "Table_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Guests_Guest_Id",
                table: "Bookings",
                column: "Guest_Id",
                principalTable: "Guests",
                principalColumn: "Guest_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tables_Table_Id",
                table: "Bookings",
                column: "Table_Id",
                principalTable: "Tables",
                principalColumn: "Table_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
