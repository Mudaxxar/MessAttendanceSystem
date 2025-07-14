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
            migrationBuilder.RenameColumn(
                name: "AttendaneCount",
                table: "Attendance",
                newName: "AttendanceCount");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e45b5a3f-4f63-48f5-9cc4-d6e0428eac42");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "da15697f-d399-4a40-b14f-a946ff2a83f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7b637fc6-5f44-4fea-a34d-8a98cb5bd9ef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "70efcf0a-6eb0-4725-9181-b541e23bfe3e", new DateTime(2025, 7, 11, 16, 8, 42, 928, DateTimeKind.Local).AddTicks(6481), "AQAAAAIAAYagAAAAEC4OZ5kvmTH48SIymnMxrEvfgg7wKjcg06e/sU2xRAA3ndZv8nesVwlhSRspRFoBzw==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 11, 16, 8, 42, 928, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 11, 16, 8, 42, 928, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 11, 16, 8, 42, 928, DateTimeKind.Local).AddTicks(6185));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 11, 16, 8, 42, 928, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 11, 16, 8, 42, 928, DateTimeKind.Local).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 11, 16, 8, 42, 928, DateTimeKind.Local).AddTicks(6395));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AttendanceCount",
                table: "Attendance",
                newName: "AttendaneCount");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d8f857e8-4b18-41db-a302-413f2a5c2c06");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d82b1da4-416e-4839-b6d4-79fa598a7974");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "aad35b1c-7eb5-4e3e-ac3a-8ef8419b7869");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "6e1b37f8-4f22-44c9-a26c-f2139303e260", new DateTime(2025, 7, 11, 15, 15, 48, 129, DateTimeKind.Local).AddTicks(8215), "AQAAAAIAAYagAAAAEMRHNpuQigpnlO2oCqDy8eKJbP0yF7aoZOoYzQuDbESHpdg3hr+Rnn7apArGt2OH0A==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 11, 15, 15, 48, 129, DateTimeKind.Local).AddTicks(7787));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 11, 15, 15, 48, 129, DateTimeKind.Local).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 11, 15, 15, 48, 129, DateTimeKind.Local).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 11, 15, 15, 48, 129, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 11, 15, 15, 48, 129, DateTimeKind.Local).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 11, 15, 15, 48, 129, DateTimeKind.Local).AddTicks(8118));
        }
    }
}
