using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class Menu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MealType = table.Column<int>(type: "int", nullable: false),
                    MenuItems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

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
                columns: new[] { "Active", "ConcurrencyStamp", "CreatedOn", "PasswordHash", "RoleId" },
                values: new object[] { "1", "7021b8a2-d560-4c85-94c4-85f281b78048", new DateTime(2025, 6, 28, 10, 15, 46, 342, DateTimeKind.Local).AddTicks(1538), "AQAAAAIAAYagAAAAEDen3nrYtwSPtOG+QZBkNfGiFhYs5JQ7QYCp10RB675oqSmRovJri2l0od4mtwXhQw==", 1 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0db58322-6a76-4d43-8033-92daeb6682f7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "ConcurrencyStamp", "CreatedOn", "PasswordHash", "RoleId" },
                values: new object[] { null, "97af0bd7-31bb-4ecb-8596-0d019d560644", new DateTime(2025, 6, 27, 8, 57, 50, 420, DateTimeKind.Local).AddTicks(4952), "AQAAAAIAAYagAAAAEN9NkaWNneiG+yiExVNL4w9FskuBWQQSL6/8WqiWgN9afOC6ysJdIiyF9wJdwbdFrw==", null });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 27, 8, 57, 50, 420, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 27, 8, 57, 50, 420, DateTimeKind.Local).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 27, 8, 57, 50, 420, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 6, 27, 8, 57, 50, 420, DateTimeKind.Local).AddTicks(4850));
        }
    }
}
