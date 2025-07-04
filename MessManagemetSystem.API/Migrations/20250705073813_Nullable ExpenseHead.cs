using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class NullableExpenseHead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_ExpenseHead_ExpenseHeadId",
                table: "Expense");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "Expense",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseHeadId",
                table: "Expense",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "24fed959-a71e-43bc-b1ba-add6870c437f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "90a81827-ac8c-4ac7-8224-010125633d8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "4207af14-1783-43f7-8336-bc473fb8e59b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "869b2310-3604-4011-925e-4773b5fc2664", new DateTime(2025, 7, 5, 12, 38, 12, 723, DateTimeKind.Local).AddTicks(6511), "AQAAAAIAAYagAAAAEAqenE7Q9Jf7OBSk9Uun6bf5t9+h9o5i3+7RXeeirkh6J8qLAl+Pb2y3zTzNdCsEdg==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 5, 12, 38, 12, 723, DateTimeKind.Local).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 5, 12, 38, 12, 723, DateTimeKind.Local).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 5, 12, 38, 12, 723, DateTimeKind.Local).AddTicks(6158));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 5, 12, 38, 12, 723, DateTimeKind.Local).AddTicks(6428));

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_ExpenseHead_ExpenseHeadId",
                table: "Expense",
                column: "ExpenseHeadId",
                principalTable: "ExpenseHead",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_ExpenseHead_ExpenseHeadId",
                table: "Expense");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Expense",
                newName: "Remarks");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseHeadId",
                table: "Expense",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "AspNetUsers",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "47448594-71a1-486f-8fd8-d9c87178516c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "22c66276-6338-45d9-8c55-1b81f8313e57");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "00bd84e6-4d30-4832-81ae-27717abbce75");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "ce9759c9-85cd-47c0-b657-7258740298d4", new DateTime(2025, 7, 4, 23, 9, 22, 18, DateTimeKind.Local).AddTicks(2385), "AQAAAAIAAYagAAAAEJwIxeXamfyQA2LIpd6VjrJFasCEQkhgrDwyMHLML7g4Jj+jrHJA2TTmN4XiKStr6w==" });

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 4, 23, 9, 22, 18, DateTimeKind.Local).AddTicks(1715));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 4, 23, 9, 22, 18, DateTimeKind.Local).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "PermissionEntity",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 7, 4, 23, 9, 22, 18, DateTimeKind.Local).AddTicks(1891));

            migrationBuilder.UpdateData(
                table: "RolePermissionEntity",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedOn",
                value: new DateTime(2025, 7, 4, 23, 9, 22, 18, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_ExpenseHead_ExpenseHeadId",
                table: "Expense",
                column: "ExpenseHeadId",
                principalTable: "ExpenseHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
