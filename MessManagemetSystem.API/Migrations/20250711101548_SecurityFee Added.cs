using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class SecurityFeeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SecurityFees",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityFees" },
                values: new object[] { "6e1b37f8-4f22-44c9-a26c-f2139303e260", new DateTime(2025, 7, 11, 15, 15, 48, 129, DateTimeKind.Local).AddTicks(8215), "AQAAAAIAAYagAAAAEMRHNpuQigpnlO2oCqDy8eKJbP0yF7aoZOoYzQuDbESHpdg3hr+Rnn7apArGt2OH0A==", 0.0 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecurityFees",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4dac25e7-ebd5-4bdf-a0b1-81b05a7bbb82");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "68081603-b60a-41f0-811b-abf5afa1e31a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "66a8ae3c-3a3a-462b-9910-d9932396f9c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "d766722a-84e0-4977-9e51-733698720895", new DateTime(2025, 7, 10, 18, 34, 39, 268, DateTimeKind.Local).AddTicks(1976), "AQAAAAIAAYagAAAAEFqE0tc8yI3NywCaAGUYHnbjvqlX7FkoiZIBiXaOUHCxM6NVmXoPKkujB2npBKDoxQ==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 10, 18, 34, 39, 268, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 10, 18, 34, 39, 268, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 10, 18, 34, 39, 268, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 10, 18, 34, 39, 268, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 10, 18, 34, 39, 268, DateTimeKind.Local).AddTicks(1844));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 10, 18, 34, 39, 268, DateTimeKind.Local).AddTicks(1845));
        }
    }
}
