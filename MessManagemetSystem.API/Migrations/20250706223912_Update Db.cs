using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessManagemetSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_ExpenseHead_ExpenseHeadId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedbackEntities_AspNetUsers_ApplicationUserId",
                table: "FeedbackEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentMealSummary_AspNetUsers_ApplicationUserId",
                table: "StudentMealSummary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentMealSummary",
                table: "StudentMealSummary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedbackEntities",
                table: "FeedbackEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.RenameTable(
                name: "StudentMealSummary",
                newName: "StudentMealSummarys");

            migrationBuilder.RenameTable(
                name: "FeedbackEntities",
                newName: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentMealSummary_ApplicationUserId",
                table: "StudentMealSummarys",
                newName: "IX_StudentMealSummarys_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_FeedbackEntities_ApplicationUserId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_ExpenseHeadId",
                table: "Expenses",
                newName: "IX_Expenses_ExpenseHeadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentMealSummarys",
                table: "StudentMealSummarys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MonthlyClosings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAttendance = table.Column<int>(type: "int", nullable: true),
                    TotalMeals = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_MonthlyClosings", x => x.Id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseHead_ExpenseHeadId",
                table: "Expenses",
                column: "ExpenseHeadId",
                principalTable: "ExpenseHead",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_ApplicationUserId",
                table: "Feedbacks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMealSummarys_AspNetUsers_ApplicationUserId",
                table: "StudentMealSummarys",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseHead_ExpenseHeadId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_ApplicationUserId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentMealSummarys_AspNetUsers_ApplicationUserId",
                table: "StudentMealSummarys");

            migrationBuilder.DropTable(
                name: "MonthlyClosings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentMealSummarys",
                table: "StudentMealSummarys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "StudentMealSummarys",
                newName: "StudentMealSummary");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "FeedbackEntities");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameIndex(
                name: "IX_StudentMealSummarys_ApplicationUserId",
                table: "StudentMealSummary",
                newName: "IX_StudentMealSummary_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_ApplicationUserId",
                table: "FeedbackEntities",
                newName: "IX_FeedbackEntities_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_ExpenseHeadId",
                table: "Expense",
                newName: "IX_Expense_ExpenseHeadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentMealSummary",
                table: "StudentMealSummary",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedbackEntities",
                table: "FeedbackEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_FeedbackEntities_AspNetUsers_ApplicationUserId",
                table: "FeedbackEntities",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMealSummary_AspNetUsers_ApplicationUserId",
                table: "StudentMealSummary",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
