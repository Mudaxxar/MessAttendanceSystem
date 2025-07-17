using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AttendanceCount",
                table: "Attendance",
                newName: "MealsCount");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8f56c335-0ae1-4edb-bdd3-7ce60c3b5159");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "19fa81e6-ebbb-4e01-9cce-f296cf0ffc02");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "8180f6eb-5ba7-4719-b280-b413414d8d5c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "e667c339-d907-4115-8bed-a23c92ce830e", new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(1083), "AQAAAAIAAYagAAAAECZSLq+SwKbfbwzMRoEaOlm4rDzCZYN+fRx3iaD285KSdVPPiht7Sp3JqqaehxOCCQ==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(958));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(962));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(963));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MealsCount",
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
    }
}
