using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeLineApi.Migrations
{
    /// <inheritdoc />
    public partial class TableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FriendshipStartDate",
                table: "Friends",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 8, 9, 16, 9, 309, DateTimeKind.Utc).AddTicks(6693),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 8, 9, 10, 21, 507, DateTimeKind.Utc).AddTicks(629));

            migrationBuilder.AlterColumn<string>(
                name: "FriendId",
                table: "Friends",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendId",
                table: "Friends",
                column: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_FriendId",
                table: "Friends",
                column: "FriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_FriendId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_FriendId",
                table: "Friends");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FriendshipStartDate",
                table: "Friends",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 8, 9, 10, 21, 507, DateTimeKind.Utc).AddTicks(629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 8, 9, 16, 9, 309, DateTimeKind.Utc).AddTicks(6693));

            migrationBuilder.AlterColumn<string>(
                name: "FriendId",
                table: "Friends",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
