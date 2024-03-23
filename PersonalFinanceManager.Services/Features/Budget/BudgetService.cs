using PersonalFinanceManager.Dtos.Budget;
using PersonalFinanceManager.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Services.Features.Budget
{
    public class BudgetService
    {
        private readonly DapperService _dapperService;
        public BudgetService()
        {
            _dapperService = new DapperService();
        }

        public List<BudgetReportModel> LoadAllBudgets()
        {
            var budgets = new List<BudgetReportModel>();
            try
            {
                budgets = _dapperService
                .Query<BudgetReportModel>
                (SqlQuery.BudgetQuery.LoadAllBudgets,
                commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return budgets;
        }

        public List<BudgetReportModel> GetBudgetByYear(string year)
        {
            var budgetLst = new List<BudgetReportModel>();
            try
            {
                var obj = new
                {
                    YearPattern = year
                };
                budgetLst = _dapperService
                    .Query<BudgetReportModel>
                    (SqlQuery.BudgetQuery.GetBudgetByYear, obj,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return budgetLst;
        }

        public List<BudgetReportModel> GetBudgetByMonthOfCurrentYear(string month)
        {
            var budgetLst = new List<BudgetReportModel>();
            try
            {
                var obj = new
                {
                    Month = month
                };
                budgetLst = _dapperService
                    .Query<BudgetReportModel>
                    (SqlQuery.BudgetQuery.GetBudgetByMonthOfCurrentYear, obj,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return budgetLst;
        }

        public List<ExpenditureBudgetModel> GetExpenditureBudget(int insertedId)
        {
            var budgetLst = new List<ExpenditureBudgetModel>();
            try
            {
                var getBudgetParam = new
                {
                    InsertedId = insertedId
                };
                budgetLst = _dapperService
                   .Query<ExpenditureBudgetModel>
                   (SqlQuery.BudgetQuery.GetExpenditureBudget, getBudgetParam);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return budgetLst;
        }

        public int AddExpenditureBudget(string formattedDate, decimal amount)
        {
            int result = 0;
            try
            {
                var budgetParam = new
                {
                    FormattedDate = formattedDate,
                    Amount = amount,
                };
                 result = _dapperService
                    .Execute(SqlQuery.BudgetQuery.AddExpenditureBudget,
                    budgetParam, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
    }
}
