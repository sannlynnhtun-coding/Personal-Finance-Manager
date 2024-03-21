using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Query.Budget
{
    public class SqlQuery
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
}
