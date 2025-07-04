using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class Feedbackupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "FeedbackEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FeedbackEntities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "FeedbackEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "FeedbackEntities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FeedbackEntities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "FeedbackEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "FeedbackEntities",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FeedbackEntities");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FeedbackEntities");

            migrationBuilder.DropColumn(
                name: "IP",
                table: "FeedbackEntities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "FeedbackEntities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FeedbackEntities");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "FeedbackEntities");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "FeedbackEntities");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "10e89173-f6a0-45ab-a299-bc94bcf218b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5505a1a8-6bbb-461a-82dd-2bee7e09a942");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "3b6a016d-39cd-4e80-81b7-a298cc755915");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "dd761c03-ff52-4521-93ba-8c836ef5900c", new DateTime(2025, 6, 30, 18, 7, 19, 161, DateTimeKind.Local).AddTicks(4804), "AQAAAAIAAYagAAAAEGHCFo38C7o3TNeGmFEd0kFn5arVhUjO/0BgtzIqGW+VcxF9Q6idL0mHgzYf8HlPyw==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 18, 7, 19, 161, DateTimeKind.Local).AddTicks(4467));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 18, 7, 19, 161, DateTimeKind.Local).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 18, 7, 19, 161, DateTimeKind.Local).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 6, 30, 18, 7, 19, 161, DateTimeKind.Local).AddTicks(4711));
        }
    }
}
