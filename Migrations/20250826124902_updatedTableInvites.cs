using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestrurantPG.Migrations
{
    /// <inheritdoc />
    public partial class updatedTableInvites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Admins",
                type: "nvarchar(254)",
                maxLength: 254,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AdminInvites",
                columns: table => new
                {
                    AdminInvite_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InviteCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    AdminId_Fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminInvites", x => x.AdminInvite_Id);
                    table.ForeignKey(
                        name: "FK_AdminInvites_Admins_AdminId_Fk",
                        column: x => x.AdminId_Fk,
                        principalTable: "Admins",
                        principalColumn: "Admin_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Email",
                table: "Admins",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminInvites_AdminId_Fk",
                table: "AdminInvites",
                column: "AdminId_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_AdminInvites_InviteCode",
                table: "AdminInvites",
                column: "InviteCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminInvites");

            migrationBuilder.DropIndex(
                name: "IX_Admins_Email",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Admins");
        }
    }
}
