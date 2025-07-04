using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "Menus",
                newName: "Date");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7304fa79-5862-4768-932a-ca876bc12785");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "6e1307cc-a2c9-4acd-8231-d77945130445", new DateTime(2025, 6, 28, 13, 17, 11, 17, DateTimeKind.Local).AddTicks(2483), "AQAAAAIAAYagAAAAEHgj/a1FJ+KlF+JFntb+U1TiMQpjJPWTe/YmzNgoOsvvD0hcwxuyfmOr/g6xvLXpXw==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 13, 17, 11, 17, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 13, 17, 11, 17, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 13, 17, 11, 17, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 13, 17, 11, 17, DateTimeKind.Local).AddTicks(2405));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Menus",
                newName: "ToDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7912d8e0-9c43-4df4-8128-fc47bfc4379e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "7021b8a2-d560-4c85-94c4-85f281b78048", new DateTime(2025, 6, 28, 10, 15, 46, 342, DateTimeKind.Local).AddTicks(1538), "AQAAAAIAAYagAAAAEDen3nrYtwSPtOG+QZBkNfGiFhYs5JQ7QYCp10RB675oqSmRovJri2l0od4mtwXhQw==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 10, 15, 46, 342, DateTimeKind.Local).AddTicks(1266));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 10, 15, 46, 342, DateTimeKind.Local).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 10, 15, 46, 342, DateTimeKind.Local).AddTicks(1305));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 6, 28, 10, 15, 46, 342, DateTimeKind.Local).AddTicks(1434));
        }
    }
}
