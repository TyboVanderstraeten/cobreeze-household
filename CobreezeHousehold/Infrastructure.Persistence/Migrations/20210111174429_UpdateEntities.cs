using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdGroupUser_Households_HouseholdsId",
                table: "HouseholdGroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdTask_Households_HouseholdGroupId",
                table: "HouseholdTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_Households_HouseholdGroupId",
                table: "ShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListItem_ShoppingList_ShoppingListId",
                table: "ShoppingListItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Households",
                table: "Households");

            migrationBuilder.RenameTable(
                name: "Households",
                newName: "HouseholdGroups");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingListId",
                table: "ShoppingListItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HouseholdGroupId",
                table: "ShoppingList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_HouseholdTask_HouseholdGroups_HouseholdGroupId",
                table: "HouseholdTask",
                column: "HouseholdGroupId",
                principalTable: "HouseholdGroups",
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
                name: "FK_ShoppingListItem_ShoppingList_ShoppingListId",
                table: "ShoppingListItem",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdGroupUser_HouseholdGroups_HouseholdsId",
                table: "HouseholdGroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdTask_HouseholdGroups_HouseholdGroupId",
                table: "HouseholdTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_HouseholdGroups_HouseholdGroupId",
                table: "ShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListItem_ShoppingList_ShoppingListId",
                table: "ShoppingListItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseholdGroups",
                table: "HouseholdGroups");

            migrationBuilder.RenameTable(
                name: "HouseholdGroups",
                newName: "Households");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingListId",
                table: "ShoppingListItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HouseholdGroupId",
                table: "ShoppingList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Households",
                table: "Households",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdGroupUser_Households_HouseholdsId",
                table: "HouseholdGroupUser",
                column: "HouseholdsId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdTask_Households_HouseholdGroupId",
                table: "HouseholdTask",
                column: "HouseholdGroupId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_Households_HouseholdGroupId",
                table: "ShoppingList",
                column: "HouseholdGroupId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListItem_ShoppingList_ShoppingListId",
                table: "ShoppingListItem",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
