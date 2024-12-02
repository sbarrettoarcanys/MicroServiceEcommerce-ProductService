using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.ProductService.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserModel_ForeignKey_Correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoppingcarts_Users_UserId1",
                table: "Shoppingcarts");

            migrationBuilder.DropIndex(
                name: "IX_Shoppingcarts_UserId1",
                table: "Shoppingcarts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Shoppingcarts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Shoppingcarts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 9, 23, 14, 50, 39, 266, DateTimeKind.Local).AddTicks(6941));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 9, 23, 14, 50, 39, 266, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 9, 23, 14, 50, 39, 266, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 9, 23, 14, 50, 39, 266, DateTimeKind.Local).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 9, 23, 14, 50, 39, 266, DateTimeKind.Local).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 9, 23, 14, 50, 39, 266, DateTimeKind.Local).AddTicks(7448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 9, 23, 14, 50, 39, 266, DateTimeKind.Local).AddTicks(7459));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 9, 23, 14, 50, 39, 266, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 9, 23, 14, 50, 39, 266, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 9, 23, 14, 50, 39, 266, DateTimeKind.Local).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2024, 9, 23, 14, 50, 39, 266, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.CreateIndex(
                name: "IX_Shoppingcarts_UserId",
                table: "Shoppingcarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoppingcarts_Users_UserId",
                table: "Shoppingcarts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoppingcarts_Users_UserId",
                table: "Shoppingcarts");

            migrationBuilder.DropIndex(
                name: "IX_Shoppingcarts_UserId",
                table: "Shoppingcarts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Shoppingcarts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Shoppingcarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
