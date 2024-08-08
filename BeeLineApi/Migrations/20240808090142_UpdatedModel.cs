using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeLineApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FriendshipStartDate",
                table: "Friends",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 8, 9, 1, 42, 120, DateTimeKind.Utc).AddTicks(3006),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 7, 17, 7, 35, 791, DateTimeKind.Utc).AddTicks(3807));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FriendshipStartDate",
                table: "Friends",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 7, 17, 7, 35, 791, DateTimeKind.Utc).AddTicks(3807),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 8, 9, 1, 42, 120, DateTimeKind.Utc).AddTicks(3006));
        }
    }
}
