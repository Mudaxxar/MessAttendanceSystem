using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class addedmeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MealPerHead",
                table: "MonthlyClosing",
                type: "decimal(18,2)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealPerHead",
                table: "MonthlyClosing");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "de702ce7-6f34-41d6-b612-ad2d8fc58d6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9cc55f32-4fee-4da5-9035-dffe9c4a512e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7e7a3be9-d815-4626-8801-4fee1be36118");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "a233542e-a92c-42d3-bb43-076430b41684", new DateTime(2025, 7, 9, 1, 34, 30, 968, DateTimeKind.Local).AddTicks(9844), "AQAAAAIAAYagAAAAECVaBZE7ImBgC6OsL/9shG0JvjgP0QI4Z2xvhx8GbI+bAYStNWQM6Ro2ciK+dt7cLA==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 9, 1, 34, 30, 968, DateTimeKind.Local).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 9, 1, 34, 30, 968, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 9, 1, 34, 30, 968, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 9, 1, 34, 30, 968, DateTimeKind.Local).AddTicks(9729));
        }
    }
}
