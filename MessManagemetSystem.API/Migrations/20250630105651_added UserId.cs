using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class addedUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "063c5711-a442-4c86-8b78-a22ce64585b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d7e00b52-8ca8-4759-a7ad-6a1bcc54a48a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "fe339ffb-99d8-4e86-841f-b22e236b40f7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "9c629f62-fc66-433a-a934-e07bd0d67ad1", new DateTime(2025, 6, 30, 15, 56, 51, 368, DateTimeKind.Local).AddTicks(2811), "AQAAAAIAAYagAAAAEMqgdI76DKggwPRqpV9gmlRKONOBH4MIfFQlw93BjRMYEqOQIfMEfIpsrHlEk8sfIA==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 15, 56, 51, 368, DateTimeKind.Local).AddTicks(2496));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 15, 56, 51, 368, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 15, 56, 51, 368, DateTimeKind.Local).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 15, 56, 51, 368, DateTimeKind.Local).AddTicks(2728));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b149be8b-13cb-4ebb-b4dd-c35ad618a2a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4eea70e1-2f14-44c9-a784-00070e5f36c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "367bd6a4-8daa-4a4a-86c6-56f45c6ae828");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "cb5d7ad9-2829-4a3e-8869-d929614ab5ba", new DateTime(2025, 6, 30, 15, 26, 7, 320, DateTimeKind.Local).AddTicks(8317), "AQAAAAIAAYagAAAAEJZYIlo3jVppmvpY5RjMMIFyimZoF6/sL/qhneHVCafFDpoJdSjfMaJG2+gDT9keBQ==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 15, 26, 7, 320, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 15, 26, 7, 320, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 15, 26, 7, 320, DateTimeKind.Local).AddTicks(8092));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 15, 26, 7, 320, DateTimeKind.Local).AddTicks(8218));
        }
    }
}
