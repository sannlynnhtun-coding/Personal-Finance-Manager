using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Query.Budget
{
    public class SqlQuery
    {
        public static string AddExpenditureBudget { get; } = @"EXEC AddExpenditureBudget 
        @month = @FormattedDate ,@amount =  @Amount ,
        @insertedId = @InsertedId OUTPUT";

        public static string GetExpenditureBudget { get; } = @"SELECT Month, Amount 
         FROM expenditure_budgets WHERE id = @InsertedId";

    }
}
