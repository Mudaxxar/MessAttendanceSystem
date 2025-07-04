using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class OnlineDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "91c414b5-b5b3-49f2-87ba-4cc48a4ad77f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "82006700-f553-49dc-8821-e1c2c68f0d34");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0be30f3f-d02e-42d2-8263-04124b3b0b42");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "fbb2ef1f-112c-44a2-96e0-414be83ed689", new DateTime(2025, 7, 1, 15, 20, 38, 8, DateTimeKind.Local).AddTicks(3323), "AQAAAAIAAYagAAAAEGIfnN36HtEIqlomExz4Z5U1zLp+thLFh/6jvsrQMJcM5bN+qCxMnscQHdEX88tJFA==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 1, 15, 20, 38, 8, DateTimeKind.Local).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 1, 15, 20, 38, 8, DateTimeKind.Local).AddTicks(2827));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 1, 15, 20, 38, 8, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 1, 15, 20, 38, 8, DateTimeKind.Local).AddTicks(3210));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "cfc29155-4d81-49ce-9a9e-f921c441e7b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "74fd6287-c113-449c-b9df-38ba9a88eaf8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f373ffb4-0638-45b6-8e30-e3d4598aa1c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "9ac0418a-7126-4974-b5fb-b92ebb7edb47", new DateTime(2025, 6, 30, 18, 54, 30, 841, DateTimeKind.Local).AddTicks(6912), "AQAAAAIAAYagAAAAEIuvyj7r0WKAH38Ap5awTMPuh+rIt6viX/0PFndxwPfPsGAjMQVr3YwSiOkMkWyWRA==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 18, 54, 30, 841, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 18, 54, 30, 841, DateTimeKind.Local).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 18, 54, 30, 841, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 18, 54, 30, 841, DateTimeKind.Local).AddTicks(6815));
        }
    }
}
