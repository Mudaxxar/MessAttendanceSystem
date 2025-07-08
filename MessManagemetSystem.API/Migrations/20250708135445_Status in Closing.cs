using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class StatusinClosing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "MonthlyClosings",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e2d8e17a-df94-4c11-af4e-db21ef21b37b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5bc66523-f3dc-463e-a34b-d3c4007dbbf3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "31304a6c-8c3c-406b-bafb-1a91a2d17c3f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "a125b3b7-c7bb-4f87-92da-425dfc537559", new DateTime(2025, 7, 8, 18, 54, 44, 460, DateTimeKind.Local).AddTicks(2919), "AQAAAAIAAYagAAAAEDcTE6VU65khXjTwJP8zfRwtVsVCw5zov2JNQIVg8ygV/p7wJEFgWtWP1UZfii4lUg==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 8, 18, 54, 44, 460, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 8, 18, 54, 44, 460, DateTimeKind.Local).AddTicks(2586));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 8, 18, 54, 44, 460, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 8, 18, 54, 44, 460, DateTimeKind.Local).AddTicks(2831));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "MonthlyClosings");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4bf51b7a-e60d-4597-898e-38ad64981c4c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9dffb7fc-c3c7-481b-90a1-cb532eb7bff2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7612ff17-9c79-4433-b3a1-a410f7b58b36");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "28baff0b-a0bd-47eb-80fa-2f859953d177", new DateTime(2025, 7, 7, 3, 44, 25, 542, DateTimeKind.Local).AddTicks(5138), "AQAAAAIAAYagAAAAEOkf5dRSXefzuv0OMfUk4QqVlh0N5LIQo1qF3Kab1RhLjNDfSW0m+InHnb9JFvUmEA==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 7, 3, 44, 25, 542, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 7, 3, 44, 25, 542, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 7, 3, 44, 25, 542, DateTimeKind.Local).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 7, 3, 44, 25, 542, DateTimeKind.Local).AddTicks(5035));
        }
    }
}
