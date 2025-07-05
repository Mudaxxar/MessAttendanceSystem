namespace MessManagementSystem.MVC.EndPoints
{
    public static class ApiEndPoint
    {
        //Account + Student
        public const string LoginUser = "Account/Login";
        public const string RegisterUser = "Account/Register";
        public const string GetUsers = "Account/get-users";
        public const string UserStatus = "Account/user-status";
        public const string UsersCount = "Account/users-count";
        public const string GetStudent = "Account/user";



		//Roles
		public const string GetAllRoles = "Roles/get-all-roles";
        public const string GetRoles = "Roles/get-roles";
        public const string GetRole = "Roles/getById";
        public const string AddRoles = "Roles/Create";
        public const string Delete_Role = "Roles/delete-role";
        public const string Update_Role = "Roles/update-Role";
        public const string AddPermission = "Roles/add-permission";

        //Permission

        public const string Add_Permission = "Permission/add-permission";
        public const string Update_Permission = "Permission/update-permission";
        public const string Delete_Permission = "Permission/delete-permission";
        public const string Get_Permissions = "Permission/get-permissions";
        public const string Get_All_Permissions = "Permission/get-all-permissions";
        public const string Get_PermissionById = "Permission/getById";


		//Menu

		public const string Add_Menu = "Menu/add-Menu";
		public const string Update_Menu = "Menu/update-Menu";
		public const string Delete_Menu = "Menu/delete-Menu";
		public const string Get_Menus = "Menu/get-Menus";
		public const string Get_All_Menus = "Menu/get-all-Menus";
		public const string Get_Menu = "Menu/getById";
        public const string Get_Weekly_Menu = "Menu/weekly";


        //Attendance
        public const string MarkAttendance = "attendance/mark-attendance";

        //Summary
        public const string GetSummary = "summary/summary";

		//Feedback
		public const string AddFeedBack = "Feedback/add-feedback";
		public const string GetFeedbacks = "Feedback/get-feedbacks";


		//ExpenseHead
		public const string AddExpenseHead = "ExpenseHeads/add";
        public const string UpdateExpenseHead = "ExpenseHeads/update";
		public const string DeleteExpenseHead = "ExpenseHeads/delete";
		public const string GetExpenseHeads = "ExpenseHeads/get";
		public const string GetExpenseHeadsAll = "ExpenseHeads/get-all";
		public const string GetExpenseHead = "ExpenseHeads/getbyId";

        //Expense
        public const string AddExpense = "Expense/add";
        public const string UpdateExpense = "Expense/update";
        public const string DeleteExpense = "Expense/delete";
        public const string GetExpenses = "Expense/get-expenses";
        public const string GetMonthlyExpenses = "Expense/get-monthly-expenses";
        public const string GetExpense = "Expense/getbyId";



    }
}
