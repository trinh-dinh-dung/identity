using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class ActionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JobTitleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "jobTitles",
                columns: table => new
                {
                    JobTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobTitles", x => x.JobTitleId);
                });

            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuType = table.Column<int>(type: "int", nullable: false),
                    Parent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionApi = table.Column<int>(type: "int", nullable: false),
                    ActionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    PermissionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermissionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.PermissionsId);
                });

            migrationBuilder.CreateTable(
                name: "ActionMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionCodeApi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionMenu_menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionMenus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionMenus_menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_permissionMenus_permissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "permissions",
                        principalColumn: "PermissionsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PermissionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userPermissions_permissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "permissions",
                        principalColumn: "PermissionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_JobTitleId",
                table: "Users",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionMenu_MenuId",
                table: "ActionMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_permissionMenus_MenuId",
                table: "permissionMenus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_permissionMenus_PermissionsId",
                table: "permissionMenus",
                column: "PermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_userPermissions_PermissionsId",
                table: "userPermissions",
                column: "PermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_userPermissions_UserId",
                table: "userPermissions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_jobTitles_JobTitleId",
                table: "Users",
                column: "JobTitleId",
                principalTable: "jobTitles",
                principalColumn: "JobTitleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_departments_DepartmentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_jobTitles_JobTitleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ActionMenu");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "jobTitles");

            migrationBuilder.DropTable(
                name: "permissionMenus");

            migrationBuilder.DropTable(
                name: "userPermissions");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropIndex(
                name: "IX_Users_DepartmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_JobTitleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JobTitleId",
                table: "Users");
        }
    }
}
