using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AttendanceCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttendaneCount",
                table: "Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3329e5a1-48b3-405c-9daa-a14e56ef411f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f147ca67-5e21-4f8b-961b-a573dd76f580");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "55e80ced-7cfa-41c8-a20a-763bef5dab70");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "10e202c6-f15d-4109-a803-097e74291894", new DateTime(2025, 7, 9, 8, 48, 7, 955, DateTimeKind.Local).AddTicks(9732), "AQAAAAIAAYagAAAAEDuE+KF+Ylpe3maZ6b4h8ZpBGz12b8/le/sF7JP+36mZsiD4briD/zkB2oTzJvUJcw==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 9, 8, 48, 7, 955, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 9, 8, 48, 7, 955, DateTimeKind.Local).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 9, 8, 48, 7, 955, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 9, 8, 48, 7, 955, DateTimeKind.Local).AddTicks(9599));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendaneCount",
                table: "Attendance");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7eb6b321-9c3b-4f19-b9d2-a6ea82ea7cfc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c6829ae0-5acb-48db-bf0c-6c6f22fd6836");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b5929a64-8142-48dc-8f3f-84d414b61d76");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "c0c33066-3f99-4f0d-8fb6-c10916641900", new DateTime(2025, 7, 9, 2, 0, 20, 327, DateTimeKind.Local).AddTicks(7984), "AQAAAAIAAYagAAAAEE4kxtJYOHxqbhG+mpfvl0sTKUX3KUI4deAJVmpAIJL1ucMBw+LIPWJlrPetUazmIg==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 9, 2, 0, 20, 327, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 9, 2, 0, 20, 327, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 9, 2, 0, 20, 327, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 9, 2, 0, 20, 327, DateTimeKind.Local).AddTicks(7892));
        }
    }
}
