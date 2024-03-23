using PersonalFinanceManager.Dtos.Expense;
using PersonalFinanceManager.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Services.Features.Expense
{
    public class ExpenseService
    {
        private readonly DapperService _dapperService;
        public ExpenseService()
        {
            _dapperService = new DapperService();
        }

        public List<ExpenseFormLoadingModel> ExpenseFormLoading()
        {
            var lst = new List<ExpenseFormLoadingModel>();
            try
            {
                lst = _dapperService
                    .Query<ExpenseFormLoadingModel>
                    (SqlQuery.ExpenseQuery.ExpenseFormLoading,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }

        public List<ExpenseReportModel> GetExpenseByMonth
            (int year,int month)
        {
            var lst = new List<ExpenseReportModel>();
            try
            {
                var param = new
                {
                    Year = year,
                    Month = month
                };
                lst = _dapperService
                    .Query<ExpenseReportModel>
                    (SqlQuery.ExpenseQuery.GetExpenseByMonth, param,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }

        public List<ExpenseReportModel> GetExpenseByUser
            (string userName)
        {
            var lst = new List<ExpenseReportModel>();
            try
            {
                var param = new
                {
                    UserName = userName
                };
                lst = _dapperService
                    .Query<ExpenseReportModel>
                    (SqlQuery.ExpenseQuery.GetExpenseByUser, param,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }

        public CheckBudgetAndBalanceModel CheckBudgetAndBalance
            (CheckBudgetAndBalanceRequestModel requestModel)
        {
            var item = new CheckBudgetAndBalanceModel();
            try
            {
                item = _dapperService
                    .QueryFirstOrDefault<CheckBudgetAndBalanceModel>
                    (SqlQuery.ExpenseQuery.CheckBudgetAndBalance, requestModel,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return item;
        }

        public AddNewExpenseModel AddNewExpense
            (AddeNewExpenseRequestModel requestModel)
        {
            var item = new AddNewExpenseModel();
            try
            {
                item = _dapperService
                    .QueryFirstOrDefault<AddNewExpenseModel>
                    (SqlQuery.ExpenseQuery.AddNewExpense, requestModel,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return item;
        }

        public List<ExpenseReportModel> GetExpenseData(int insertId)
        {
            var lst = new List<ExpenseReportModel>();
            try
            {
                var param = new
                {
                    InsertedId = insertId,
                };
                lst = _dapperService
                    .Query<ExpenseReportModel>
                    (SqlQuery.ExpenseQuery.GetExpenseData, param,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }
    }
}
