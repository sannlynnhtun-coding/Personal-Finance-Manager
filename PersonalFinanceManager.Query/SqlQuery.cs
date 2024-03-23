using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonalFinanceManager.Query
{
    public class SqlQuery
    {
        public static class LoginQuery
        {
            public static string Login { get; } = "Login";
        }

        public static class DashboardQuery
        {
            public static string Balance { get; } = "LoadBalance";
        }

        public static class AddNewDataQuery
        {
            public static string AddDescription { get; } = @"InsertDescription";
            public static string GetDescription { get; } = @"SELECT Description FROM descriptions;";
            public static string AddFromToFlow { get; } = @"InsertFromToFlow";
            public static string GetFromToFlow { get; } = @"SELECT Text FROM from_to_flow;";
            public static string AddCashFlow { get; } = @"InsertCashFlow";
            public static string GetCashFlow { get; } = @"SELECT Text FROM cash_flow;";
        }

        public static class BudgetQuery
        {
            public static string AddExpenditureBudget { get; } = @"AddExpenditureBudget";

            public static string GetExpenditureBudget { get; } = @"SELECT Month, Amount 
         FROM expenditure_budgets WHERE id = @InsertedId";

            public static string GetBudgetByYear { get; } = @"GetBudgetByYear";

            public static string GetBudgetByMonthOfCurrentYear { get; } = @"GetBudgetByMonthOfCurrentYear";

            public static string LoadAllBudgets { get; } = @"LoadAllBudgets";
        }

        public static class ExpenseQuery
        {
            public static string ExpenseFormLoading { get; } = @"ExpenseFormLoading";
            public static string GetExpenseByMonth { get; } = @"GetExpenseByMonth";
            public static string GetExpenseByUser { get; } = @"GetExpenseByUser";
            public static string CheckBudgetAndBalance { get; } = @"CheckBudgetAndBalance";
            public static string AddNewExpense { get; } = @"AddNewExpense";
            public static string GetExpenseData { get; } = @"SELECT descriptions.description AS Description,
                    from_to_flow.text AS [To], cash_flow.text AS Payment,
                    expenses.amount AS Amount, expenses.date AS Date FROM expenses 
                    INNER JOIN descriptions ON expenses.description_id = descriptions.id 
                    INNER JOIN from_to_flow ON expenses.from_to_flow_id = from_to_flow.id 
                    INNER JOIN users ON expenses.user_id = users.id 
                    INNER JOIN cash_flow ON expenses.cash_flow_id = cash_flow.id 
                    WHERE expenses.id = @InsertedId";
        }

        public static class IncomeQuery
        {
            public static string IncomeFormLoading { get; } = @"IncomeFormLoading";
            public static string GetIncomeByMonth { get; } = @"GetIncomeByMonth";
            public static string GetIncomeByUser { get; } = @"GetIncomeByUser";
            public static string AddNewIncome { get; } = @"AddNewIncome";
            public static string GetIncomeData { get; } = @"SELECT descriptions.description AS Description,
                          from_to_flow.text AS [From],
                          users.name AS Name,
                          cash_flow.text AS Payment,
                          incomes.amount AS Amount,
                          incomes.date AS Date
                        FROM incomes
                        INNER JOIN descriptions ON incomes.description_id = descriptions.id
                        INNER JOIN from_to_flow ON incomes.from_to_flow_id = from_to_flow.id
                        INNER JOIN users ON incomes.user_id = users.id
                        INNER JOIN cash_flow ON incomes.cash_flow_id = cash_flow.id
                        WHERE incomes.id = @InsertedId";
        }

        public static class SavingQuery
        {
            public static string AddNewSaving { get; } = @"AddNewSaving";
            public static string GetSavingByInsertedId { get; } = @"GetSavingByInsertedID";
            public static string GetTotalSaving { get; } = @"GetTotalSaving";
            public static string SavingLoad { get; } = @"SavingLoad";
            public static string GetSavingByYearly { get; } = @"GetSavingByYearly";
            public static string GetSavingByMonthsOfCurrentYear { get; } = @"GetSavingByMonthsOfCurrentYear";
            public static string GetWithdrawSavingByUser { get; } = @"GetwithdrawSavingByUser";
            public static string GetWithdrawByYearly { get; } = @"GetwithdrawByYearly";
            public static string GetWithdrawByCurrentYear { get; } = @"GetWithdrawByCurrentYear";
            public static string AddNewWithdrawSaving { get; } = @"AddNewWithdrawSaving";
            public static string WithdrawSaving { get; } = @"SELECT users.name AS [User], 
                date AS WithdrawDate,
                amount AS Amount FROM withdraw_saving 
                INNER JOIN users ON withdraw_saving.user_id = users.id 
                WHERE withdraw_saving.id =@InsertedId";
        }
    }
}
