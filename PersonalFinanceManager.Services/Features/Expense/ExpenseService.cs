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

        public ExpenseFormLoadingModel ExpenseFormLoading()
        {
            var item = new ExpenseFormLoadingModel();
            try
            {
                //var result = _dapperService
                //    .QueryMultiple
                //    (SqlQuery.ExpenseQuery.ExpenseFormLoading,
                //    commandType: CommandType.StoredProcedure);
                //item.DescriptionLst = result.Read<ExpenseDescriptionModel>().ToList();
                //item.ToLst = result.Read<ExpenseToModel>().ToList();
                //item.PaymentLst = result.Read<ExpensePaymentModel>().ToList();
                var result = _dapperService
                    .QueryDataSet(SqlQuery.ExpenseQuery.ExpenseFormLoading);
                var dt1 = result.Tables[0];
                var dt2 = result.Tables[1];
                var dt3 = result.Tables[2];
                item.DescriptionLst = dt1.ToJson().ToObject<List<ExpenseDescriptionModel>>();
                item.ToLst = dt2.ToJson().ToObject<List<ExpenseToModel>>();
                item.PaymentLst = dt3.ToJson().ToObject<List<ExpensePaymentModel>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return item;
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
                    (SqlQuery.ExpenseQuery.GetExpenseData, param);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }
    }
}
