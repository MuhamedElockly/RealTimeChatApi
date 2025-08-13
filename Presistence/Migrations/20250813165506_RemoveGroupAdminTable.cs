using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveGroupAdminTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupAdmins_ChatUsers_UserID",
                table: "GroupAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupAdmins_Groups_GroupID",
                table: "GroupAdmins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupAdmins",
                table: "GroupAdmins");

            migrationBuilder.DropIndex(
                name: "IX_GroupAdmins_GroupID",
                table: "GroupAdmins");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GroupAdmins");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "GroupAdmins",
                newName: "AdminsId");

            migrationBuilder.RenameColumn(
                name: "GroupID",
                table: "GroupAdmins",
                newName: "AdminOfGroupsId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupAdmins_UserID",
                table: "GroupAdmins",
                newName: "IX_GroupAdmins_AdminsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupAdmins",
                table: "GroupAdmins",
                columns: new[] { "AdminOfGroupsId", "AdminsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAdmins_ChatUsers_AdminsId",
                table: "GroupAdmins",
                column: "AdminsId",
                principalTable: "ChatUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAdmins_Groups_AdminOfGroupsId",
                table: "GroupAdmins",
                column: "AdminOfGroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupAdmins_ChatUsers_AdminsId",
                table: "GroupAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupAdmins_Groups_AdminOfGroupsId",
                table: "GroupAdmins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupAdmins",
                table: "GroupAdmins");

            migrationBuilder.RenameColumn(
                name: "AdminsId",
                table: "GroupAdmins",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "AdminOfGroupsId",
                table: "GroupAdmins",
                newName: "GroupID");

            migrationBuilder.RenameIndex(
                name: "IX_GroupAdmins_AdminsId",
                table: "GroupAdmins",
                newName: "IX_GroupAdmins_UserID");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GroupAdmins",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupAdmins",
                table: "GroupAdmins",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAdmins_GroupID",
                table: "GroupAdmins",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAdmins_ChatUsers_UserID",
                table: "GroupAdmins",
                column: "UserID",
                principalTable: "ChatUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAdmins_Groups_GroupID",
                table: "GroupAdmins",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
