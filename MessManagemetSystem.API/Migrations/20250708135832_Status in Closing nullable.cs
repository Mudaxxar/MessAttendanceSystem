using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class StatusinClosingnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4b31469a-0154-4fea-95b9-3a6ffb90d7f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "bd45bde8-6833-48cd-a30f-ac74313bb219");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "5bb5f012-a342-4fe2-a68d-7d7a4d7c8f80");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "b86ac8fe-e6b2-42d8-803f-8ef99c9aa7a4", new DateTime(2025, 7, 8, 18, 58, 31, 915, DateTimeKind.Local).AddTicks(6598), "AQAAAAIAAYagAAAAEMpuMaShH1S2e5zPt9icSMdPfOHXGyzBKd2XWZk3xaVQ3/L4MvwGa35CjyvU2r1fdg==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 8, 18, 58, 31, 915, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 8, 18, 58, 31, 915, DateTimeKind.Local).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 8, 18, 58, 31, 915, DateTimeKind.Local).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 8, 18, 58, 31, 915, DateTimeKind.Local).AddTicks(6511));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
