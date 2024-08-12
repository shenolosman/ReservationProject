using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DataAccessLayer.Migrations
{
    public partial class addContactMessageCategoryFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactMessageCategoryId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactMessageCategoryId",
                table: "Contacts",
                column: "ContactMessageCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactMessageCategories_ContactMessageCategoryId",
                table: "Contacts",
                column: "ContactMessageCategoryId",
                principalTable: "ContactMessageCategories",
                principalColumn: "ContactMessageCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactMessageCategories_ContactMessageCategoryId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactMessageCategoryId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactMessageCategoryId",
                table: "Contacts");
        }
    }
}
