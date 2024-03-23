using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public static string AddDescription { get; } = @"InsertDescription @name = @description";
            public static string GetDescription { get; } = @"SELECT Description FROM descriptions;";
            public static string AddFromToFlow { get; } = @"InsertFromToFlow @name = @description";
            public static string GetFromToFlow { get; } = @"SELECT Text FROM from_to_flow;";
            public static string AddCashFlow { get; } = @"InsertCashFlow @name = @description;";
            public static string GetCashFlow { get; } = @"SELECT Text FROM cash_flow;";
        }

        public static class BudgetQuery
        {
            public static string AddExpenditureBudget { get; } = @"AddExpenditureBudget 
        @month = @FormattedDate ,@amount =  @Amount ,
        @insertedId = @InsertedId OUTPUT";

            public static string GetExpenditureBudget { get; } = @"SELECT Month, Amount 
         FROM expenditure_budgets WHERE id = @InsertedId";

            public static string GetBudgetByYear { get; } = @"GetBudgetByYear 
         @yearPattern = @YearPattern";

            public static string GetBudgetByMonthOfCurrentYear { get; } = @"GetBudgetByMonthOfCurrentYear
        @monthName = @Month";

            public static string LoadAllBudgets { get; } = @"LoadAllBudgets";
        }

        public static class ExpenseQuery
        {
            public static string ExpenseFormLoading { get; } = @"ExpenseFormLoading";
            public static string GetExpenseByMonth { get; } = @"GetExpenseByMonth @Year = @Year,@Month =  @Month ;";
            public static string GetExpenseByUser { get; } = @"EXEC GetExpenseByUser @Username = @UserName;";
            public static string CheckBudgetAndBalance { get; } = @"CheckBudgetAndBalance
                    @Description = @Description, @FromToFlow = @FromToFlow,
                    @CashFlow = @CashFlow, @Amount = @Amount, @Date = @FormattedDate , 
                    @StatusCode =@StatusCode OUTPUT";
            public static string AddNewExpense { get; } = @"AddNewExpense
                    @Description = @Description, @FromToFlow = @FromToFlow,@User=@User
                    @CashFlow = @CashFlow, @Amount = @Amount, @Date = @FormattedDate , 
                    @InsertedId =@InsertedId OUTPUT";
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
            public static string GetIncomeByMonth { get; } = @"GetIncomeByMonth @Year = @Year ,@Month = @Month ;";
            public static string GetIncomeByUser { get; } = @"GetIncomeByUser @Username = @UserName;";
            public static string AddNewIncome { get; } = @"EXEC AddNewIncome
                     @Description = @Description, @FromToFlow = @FromToFlow, @User = @User , 
                     @CashFlow = @CashFlow, @Amount = @Amount, @Date = @FormattedDate, 
                     @InsertedId = @InsertedId OUTPUT";
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
            public static string AddNewSaving { get; } = @"AddNewSaving 
            @Username = @UserName ,@Amount = @Amount,
            @SavingMonth = @FormattedDate,@StatusCode = @StatusCode OUTPUT,
            @InsertedId = @InsertedId OUTPUT";
            public static string GetSavingByInsertedId { get; } = @"EXEC GetSavingByInsertedID @InsertedId =  @InsertedId";
            public static string GetTotalSaving { get; } = @"GetTotalSaving";
        }
    }
}
