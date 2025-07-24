using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedAttendanceSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendanceSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
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
                    table.PrimaryKey("PK_AttendanceSettings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9ed49f23-9446-4d73-9431-14e89e1bc07f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "12e6f4ec-9348-48f8-9263-70e3f3848b1d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "81894c7f-0a29-4b82-9d01-d2524b208fdd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "3a83ffbb-48f4-4096-a491-eafe4b5882b1", new DateTime(2025, 7, 22, 16, 2, 17, 69, DateTimeKind.Local).AddTicks(7114), "AQAAAAIAAYagAAAAEBLMSVm7ZBkoO3WiY71jsMiWTfsKp+dpIjJQZUWLCcaDe2aJbZezD+xMAstDKAJEIw==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 22, 16, 2, 17, 69, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 22, 16, 2, 17, 69, DateTimeKind.Local).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 22, 16, 2, 17, 69, DateTimeKind.Local).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 22, 16, 2, 17, 69, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 22, 16, 2, 17, 69, DateTimeKind.Local).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 22, 16, 2, 17, 69, DateTimeKind.Local).AddTicks(7019));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceSettings");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8f56c335-0ae1-4edb-bdd3-7ce60c3b5159");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "19fa81e6-ebbb-4e01-9cce-f296cf0ffc02");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "8180f6eb-5ba7-4719-b280-b413414d8d5c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "e667c339-d907-4115-8bed-a23c92ce830e", new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(1083), "AQAAAAIAAYagAAAAECZSLq+SwKbfbwzMRoEaOlm4rDzCZYN+fRx3iaD285KSdVPPiht7Sp3JqqaehxOCCQ==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(958));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(962));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 17, 17, 44, 14, 841, DateTimeKind.Local).AddTicks(963));
        }
    }
}
