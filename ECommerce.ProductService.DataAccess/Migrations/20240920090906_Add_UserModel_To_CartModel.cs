using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.ProductService.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_UserModel_To_CartModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Shoppingcarts",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Shoppingcarts",
                newName: "UserId");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 9, 20, 17, 9, 6, 419, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 9, 20, 17, 9, 6, 419, DateTimeKind.Local).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 9, 20, 17, 9, 6, 419, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 9, 20, 17, 9, 6, 419, DateTimeKind.Local).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 9, 20, 17, 9, 6, 419, DateTimeKind.Local).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 9, 20, 17, 9, 6, 419, DateTimeKind.Local).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 9, 20, 17, 9, 6, 419, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 9, 20, 17, 9, 6, 419, DateTimeKind.Local).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 9, 20, 17, 9, 6, 419, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 9, 20, 17, 9, 6, 419, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2024, 9, 20, 17, 9, 6, 419, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.CreateIndex(
                name: "IX_Shoppingcarts_UserId1",
                table: "Shoppingcarts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoppingcarts_Users_UserId1",
                table: "Shoppingcarts",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoppingcarts_Users_UserId1",
                table: "Shoppingcarts");

            migrationBuilder.DropIndex(
                name: "IX_Shoppingcarts_UserId1",
                table: "Shoppingcarts");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Shoppingcarts",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Shoppingcarts",
                newName: "ApplicationUserId");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 9, 18, 19, 7, 53, 979, DateTimeKind.Local).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 9, 18, 19, 7, 53, 979, DateTimeKind.Local).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 9, 18, 19, 7, 53, 979, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 9, 18, 19, 7, 53, 979, DateTimeKind.Local).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 9, 18, 19, 7, 53, 979, DateTimeKind.Local).AddTicks(9078));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 9, 18, 19, 7, 53, 979, DateTimeKind.Local).AddTicks(9704));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 9, 18, 19, 7, 53, 979, DateTimeKind.Local).AddTicks(9712));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 9, 18, 19, 7, 53, 979, DateTimeKind.Local).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 9, 18, 19, 7, 53, 979, DateTimeKind.Local).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 9, 18, 19, 7, 53, 979, DateTimeKind.Local).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2024, 9, 18, 19, 7, 53, 979, DateTimeKind.Local).AddTicks(9731));
        }
    }
}
