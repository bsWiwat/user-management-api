using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserPermissions_UserId",
                table: "UserPermissions");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "dateUpdate",
                table: "Users",
                newName: "DateUpdate");

            migrationBuilder.RenameColumn(
                name: "dateDelete",
                table: "Users",
                newName: "DateDelete");

            migrationBuilder.RenameColumn(
                name: "dateCreate",
                table: "Users",
                newName: "DateCreate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_username",
                table: "Users",
                newName: "IX_Users_Username");

            migrationBuilder.RenameIndex(
                name: "IX_Users_roleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameColumn(
                name: "isWritable",
                table: "UserPermissions",
                newName: "IsWritable");

            migrationBuilder.RenameColumn(
                name: "isReadable",
                table: "UserPermissions",
                newName: "IsReadable");

            migrationBuilder.RenameColumn(
                name: "isDeletable",
                table: "UserPermissions",
                newName: "IsDeletable");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserPermissions",
                newName: "UserPermissionId");

            migrationBuilder.RenameColumn(
                name: "roleName",
                table: "Roles",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Roles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "permissionName",
                table: "Permissions",
                newName: "PermissionName");

            migrationBuilder.RenameColumn(
                name: "permissionId",
                table: "Permissions",
                newName: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UserId_PermissionId",
                table: "UserPermissions",
                columns: new[] { "UserId", "PermissionId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserPermissions_UserId_PermissionId",
                table: "UserPermissions");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "roleId");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "Users",
                newName: "dateUpdate");

            migrationBuilder.RenameColumn(
                name: "DateDelete",
                table: "Users",
                newName: "dateDelete");

            migrationBuilder.RenameColumn(
                name: "DateCreate",
                table: "Users",
                newName: "dateCreate");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Username",
                table: "Users",
                newName: "IX_Users_username");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                newName: "IX_Users_roleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "Users",
                newName: "IX_Users_email");

            migrationBuilder.RenameColumn(
                name: "IsWritable",
                table: "UserPermissions",
                newName: "isWritable");

            migrationBuilder.RenameColumn(
                name: "IsReadable",
                table: "UserPermissions",
                newName: "isReadable");

            migrationBuilder.RenameColumn(
                name: "IsDeletable",
                table: "UserPermissions",
                newName: "isDeletable");

            migrationBuilder.RenameColumn(
                name: "UserPermissionId",
                table: "UserPermissions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "Roles",
                newName: "roleName");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roles",
                newName: "roleId");

            migrationBuilder.RenameColumn(
                name: "PermissionName",
                table: "Permissions",
                newName: "permissionName");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "Permissions",
                newName: "permissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UserId",
                table: "UserPermissions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users",
                column: "roleId",
                principalTable: "Roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
