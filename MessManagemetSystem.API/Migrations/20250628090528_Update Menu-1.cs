using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenu1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "DayofWeek",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e138e7eb-3ada-4b6f-93b3-f34f649e97d0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "f82125c1-e9a6-4cf0-81e6-347d6289c8b4", new DateTime(2025, 6, 28, 14, 5, 27, 872, DateTimeKind.Local).AddTicks(6843), "AQAAAAIAAYagAAAAEJSRizRdOrXLqGfNFPKEyiHrWA2dB+GRrGrubioaOtXlfQJTqtTM76liy4x2riFOrA==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 14, 5, 27, 872, DateTimeKind.Local).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 14, 5, 27, 872, DateTimeKind.Local).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 14, 5, 27, 872, DateTimeKind.Local).AddTicks(5852));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 14, 5, 27, 872, DateTimeKind.Local).AddTicks(6593));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayofWeek",
                table: "Menus");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7304fa79-5862-4768-932a-ca876bc12785");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "6e1307cc-a2c9-4acd-8231-d77945130445", new DateTime(2025, 6, 28, 13, 17, 11, 17, DateTimeKind.Local).AddTicks(2483), "AQAAAAIAAYagAAAAEHgj/a1FJ+KlF+JFntb+U1TiMQpjJPWTe/YmzNgoOsvvD0hcwxuyfmOr/g6xvLXpXw==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 13, 17, 11, 17, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 13, 17, 11, 17, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 13, 17, 11, 17, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 13, 17, 11, 17, DateTimeKind.Local).AddTicks(2405));
        }
    }
}
