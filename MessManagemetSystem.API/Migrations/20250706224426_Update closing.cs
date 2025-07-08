using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class Updateclosing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Expenses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5bd3cc5e-577f-4e0d-a119-8230dea4ae9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8b3a7625-7a26-4025-967a-def8b757572c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "d6c73c8c-8dab-4add-8a24-b518802ecd2b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "c81ff5ab-c9b8-466f-8b11-06b564031d30", new DateTime(2025, 7, 7, 3, 39, 11, 249, DateTimeKind.Local).AddTicks(8080), "AQAAAAIAAYagAAAAEHlKqI9XdtgjT/xnyIwC5dBDHZCqLdII/B+tXITfgkWm4WU4edAydzxy5PlD6elwPg==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 7, 3, 39, 11, 249, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 7, 3, 39, 11, 249, DateTimeKind.Local).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 7, 3, 39, 11, 249, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 7, 3, 39, 11, 249, DateTimeKind.Local).AddTicks(7988));
        }
    }
}
