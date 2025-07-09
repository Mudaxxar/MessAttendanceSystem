using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class Updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_ApplicationUserId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseHead_ExpenseHeadId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentMealSummarys_AspNetUsers_ApplicationUserId",
                table: "StudentMealSummarys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentMealSummarys",
                table: "StudentMealSummarys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonthlyClosings",
                table: "MonthlyClosings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseHead",
                table: "ExpenseHead");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "StudentMealSummarys",
                newName: "StudentMealSummary");

            migrationBuilder.RenameTable(
                name: "MonthlyClosings",
                newName: "MonthlyClosing");

            migrationBuilder.RenameTable(
                name: "ExpenseHead",
                newName: "ExpenseHeads");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameColumn(
                name: "TotalDebit",
                table: "Accounts",
                newName: "Debit");

            migrationBuilder.RenameColumn(
                name: "TotalCredit",
                table: "Accounts",
                newName: "Credit");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "Accounts",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_StudentMealSummarys_ApplicationUserId",
                table: "StudentMealSummary",
                newName: "IX_StudentMealSummary_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_ApplicationUserId",
                table: "Attendance",
                newName: "IX_Attendance_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentMealSummary",
                table: "StudentMealSummary",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonthlyClosing",
                table: "MonthlyClosing",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseHeads",
                table: "ExpenseHeads",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AspNetUsers_ApplicationUserId",
                table: "Attendance",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseHeads_ExpenseHeadId",
                table: "Expenses",
                column: "ExpenseHeadId",
                principalTable: "ExpenseHeads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMealSummary_AspNetUsers_ApplicationUserId",
                table: "StudentMealSummary",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AspNetUsers_ApplicationUserId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseHeads_ExpenseHeadId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentMealSummary_AspNetUsers_ApplicationUserId",
                table: "StudentMealSummary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentMealSummary",
                table: "StudentMealSummary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonthlyClosing",
                table: "MonthlyClosing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseHeads",
                table: "ExpenseHeads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.RenameTable(
                name: "StudentMealSummary",
                newName: "StudentMealSummarys");

            migrationBuilder.RenameTable(
                name: "MonthlyClosing",
                newName: "MonthlyClosings");

            migrationBuilder.RenameTable(
                name: "ExpenseHeads",
                newName: "ExpenseHead");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Accounts",
                newName: "Remarks");

            migrationBuilder.RenameColumn(
                name: "Debit",
                table: "Accounts",
                newName: "TotalDebit");

            migrationBuilder.RenameColumn(
                name: "Credit",
                table: "Accounts",
                newName: "TotalCredit");

            migrationBuilder.RenameIndex(
                name: "IX_StudentMealSummary_ApplicationUserId",
                table: "StudentMealSummarys",
                newName: "IX_StudentMealSummarys_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_ApplicationUserId",
                table: "Attendances",
                newName: "IX_Attendances_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentMealSummarys",
                table: "StudentMealSummarys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonthlyClosings",
                table: "MonthlyClosings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseHead",
                table: "ExpenseHead",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_ApplicationUserId",
                table: "Attendances",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseHead_ExpenseHeadId",
                table: "Expenses",
                column: "ExpenseHeadId",
                principalTable: "ExpenseHead",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMealSummarys_AspNetUsers_ApplicationUserId",
                table: "StudentMealSummarys",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
