using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddNamedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdGroupUser_HouseholdGroups_HouseholdsId",
                table: "HouseholdGroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdGroupUser_Users_MembersId",
                table: "HouseholdGroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdTask_HouseholdGroups_HouseholdGroupId",
                table: "HouseholdTask");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdTask_Users_ExecutorId",
                table: "HouseholdTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_HouseholdGroups_HouseholdGroupId",
                table: "ShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListItem_Users_RecipientId",
                table: "ShoppingListItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseholdGroups",
                table: "HouseholdGroups");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "HouseholdGroups",
                newName: "HouseholdGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseholdGroup",
                table: "HouseholdGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdGroupUser_HouseholdGroup_HouseholdsId",
                table: "HouseholdGroupUser",
                column: "HouseholdsId",
                principalTable: "HouseholdGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdGroupUser_User_MembersId",
                table: "HouseholdGroupUser",
                column: "MembersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdTask_HouseholdGroup_HouseholdGroupId",
                table: "HouseholdTask",
                column: "HouseholdGroupId",
                principalTable: "HouseholdGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdTask_User_ExecutorId",
                table: "HouseholdTask",
                column: "ExecutorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_HouseholdGroup_HouseholdGroupId",
                table: "ShoppingList",
                column: "HouseholdGroupId",
                principalTable: "HouseholdGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListItem_User_RecipientId",
                table: "ShoppingListItem",
                column: "RecipientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdGroupUser_HouseholdGroup_HouseholdsId",
                table: "HouseholdGroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdGroupUser_User_MembersId",
                table: "HouseholdGroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdTask_HouseholdGroup_HouseholdGroupId",
                table: "HouseholdTask");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdTask_User_ExecutorId",
                table: "HouseholdTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_HouseholdGroup_HouseholdGroupId",
                table: "ShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListItem_User_RecipientId",
                table: "ShoppingListItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseholdGroup",
                table: "HouseholdGroup");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "HouseholdGroup",
                newName: "HouseholdGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseholdGroups",
                table: "HouseholdGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdGroupUser_HouseholdGroups_HouseholdsId",
                table: "HouseholdGroupUser",
                column: "HouseholdsId",
                principalTable: "HouseholdGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdGroupUser_Users_MembersId",
                table: "HouseholdGroupUser",
                column: "MembersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdTask_HouseholdGroups_HouseholdGroupId",
                table: "HouseholdTask",
                column: "HouseholdGroupId",
                principalTable: "HouseholdGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdTask_Users_ExecutorId",
                table: "HouseholdTask",
                column: "ExecutorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_HouseholdGroups_HouseholdGroupId",
                table: "ShoppingList",
                column: "HouseholdGroupId",
                principalTable: "HouseholdGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListItem_Users_RecipientId",
                table: "ShoppingListItem",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
