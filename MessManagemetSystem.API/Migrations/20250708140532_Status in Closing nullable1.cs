using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class StatusinClosingnullable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Expenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a4264f15-ed16-4770-9010-c343aaef7705");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4c92eae9-c6d4-4881-a7a2-74ec79fe2255");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a7b4779c-2064-4ef3-a7e0-4fb17330ccac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "42b747cc-3ec8-4879-b5dc-b1f3c8868ecb", new DateTime(2025, 7, 8, 19, 5, 31, 645, DateTimeKind.Local).AddTicks(7415), "AQAAAAIAAYagAAAAEKGU3vgj86QSTdWJOQKnsxb8nHAyh7T4L/sq1hb8nSlgX2SWbBvnsTUds3rTYDHcMg==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 8, 19, 5, 31, 645, DateTimeKind.Local).AddTicks(6908));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 8, 19, 5, 31, 645, DateTimeKind.Local).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 8, 19, 5, 31, 645, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 8, 19, 5, 31, 645, DateTimeKind.Local).AddTicks(7326));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
