using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5d668cad-332f-4efc-926b-6b60b1b15d9e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 2, "e62be2f1-cf5c-47e8-9fc5-884e9f5453df", false, "Student", "Student" },
                    { 3, "0b51b2a2-95ba-44f2-8404-80a3ef9e7f62", false, "Operator", "Operator" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "Status" },
                values: new object[] { "b2562bbb-ffe9-41e3-8f6f-c75504ca4ca9", new DateTime(2025, 6, 30, 9, 51, 53, 523, DateTimeKind.Local).AddTicks(6155), "AQAAAAIAAYagAAAAEFtoEBjRM+ckH8VnXmGb04lFUTu2yJEItRW0zMXazLBpo2t/Ki8rn+x+mdHX1HGYtQ==", 2 });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 9, 51, 53, 523, DateTimeKind.Local).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 9, 51, 53, 523, DateTimeKind.Local).AddTicks(5958));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 9, 51, 53, 523, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 9, 51, 53, 523, DateTimeKind.Local).AddTicks(6074));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e138e7eb-3ada-4b6f-93b3-f34f649e97d0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "f82125c1-e9a6-4cf0-81e6-347d6289c8b4", new DateTime(2025, 6, 28, 14, 5, 27, 872, DateTimeKind.Local).AddTicks(6843), "AQAAAAIAAYagAAAAEJSRizRdOrXLqGfNFPKEyiHrWA2dB+GRrGrubioaOtXlfQJTqtTM76liy4x2riFOrA==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 14, 5, 27, 872, DateTimeKind.Local).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 14, 5, 27, 872, DateTimeKind.Local).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 14, 5, 27, 872, DateTimeKind.Local).AddTicks(5852));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 14, 5, 27, 872, DateTimeKind.Local).AddTicks(6593));
        }
    }
}
