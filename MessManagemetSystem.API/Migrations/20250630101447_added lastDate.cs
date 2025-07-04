using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class addedlastDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastStatusChange",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7b2a15fe-96ad-48b2-8fc6-5c086a1d96c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "99da98d5-4236-4a2a-bd58-6e220c96b698");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7e52dd35-8f2d-4676-b513-f1284e44700e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastStatusChange", "PasswordHash" },
                values: new object[] { "c0614f8f-35ad-4d38-adf3-9a834d18e732", new DateTime(2025, 6, 30, 15, 14, 46, 953, DateTimeKind.Local).AddTicks(6330), null, "AQAAAAIAAYagAAAAEL1PQlN7dOG4zl68p/GIpSabh2rYm/Kp0fia27S+VOvfgu41ux0lqn+7kEGNGJ52Ig==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 15, 14, 46, 953, DateTimeKind.Local).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 15, 14, 46, 953, DateTimeKind.Local).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 15, 14, 46, 953, DateTimeKind.Local).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 15, 14, 46, 953, DateTimeKind.Local).AddTicks(6233));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastStatusChange",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5d668cad-332f-4efc-926b-6b60b1b15d9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e62be2f1-cf5c-47e8-9fc5-884e9f5453df");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0b51b2a2-95ba-44f2-8404-80a3ef9e7f62");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "b2562bbb-ffe9-41e3-8f6f-c75504ca4ca9", new DateTime(2025, 6, 30, 9, 51, 53, 523, DateTimeKind.Local).AddTicks(6155), "AQAAAAIAAYagAAAAEFtoEBjRM+ckH8VnXmGb04lFUTu2yJEItRW0zMXazLBpo2t/Ki8rn+x+mdHX1HGYtQ==" });

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
    }
}
