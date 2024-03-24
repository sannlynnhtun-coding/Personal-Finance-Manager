using PersonalFinanceManager.Dtos.Expense;
using PersonalFinanceManager.Dtos.Income;
using PersonalFinanceManager.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Services.Features.Income
{
    public class IncomeService
    {
        private readonly DapperService _dapperService;

        public IncomeService()
        {
            _dapperService = new DapperService();
        }

        public IncomeFormLoadingModel IncomeFormLoading()
        {
            var item = new IncomeFormLoadingModel();
            try
            {
                //var result = _dapperService
                //    .QueryMultiple
                //    (SqlQuery.IncomeQuery.IncomeFormLoading);
                //item.DescriptionLst = result.Read<IncomeDescriptionModel>().ToList();
                //item.FromLst = result.Read<IncomeFromModel>().ToList();
                //item.PaymentLst = result.Read<IncomePaymentModel>().ToList();
                var result = _dapperService
                    .QueryDataSet(SqlQuery.IncomeQuery.IncomeFormLoading);
                var dt1 = result.Tables[0];
                var dt2 = result.Tables[1];
                var dt3 = result.Tables[2];
                item.DescriptionLst = dt1.ToJson().ToObject<List<IncomeDescriptionModel>>();
                item.FromLst = dt2.ToJson().ToObject<List<IncomeFromModel>>();
                item.PaymentLst = dt3.ToJson().ToObject<List<IncomeTypeModel>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return item;
        }

        public List<IncomeReportModel> GetIncomeByMonth
            (int year,int month)
        {
            var lst = new List<IncomeReportModel>();
            try
            {
                var param = new
                {
                    Year = year,
                    Month = month
                };
                lst = _dapperService
                    .Query<IncomeReportModel>
                    (SqlQuery.IncomeQuery.GetIncomeByMonth, param,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }
        public List<IncomeReportModel> GetIncomeByUser
            (string user)
        {
            var lst = new List<IncomeReportModel>();
            try
            {
                var param = new
                {
                    UserName = user
                };
                lst = _dapperService
                    .Query<IncomeReportModel>
                    (SqlQuery.IncomeQuery.GetIncomeByUser, param,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }

        public AddIncomeExpenseModel AddNewIncome
            (AddeNewIncomeRequestModel requestModel)
        {
            var item = new AddIncomeExpenseModel();
            try
            {
                item = _dapperService
                    .QueryFirstOrDefault<AddIncomeExpenseModel>
                    (SqlQuery.IncomeQuery.AddNewIncome, requestModel,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return item;
        }

        public List<IncomeReportModel> GetNewIncome
           (int insertedId)
        {
            var lst = new List<IncomeReportModel>();
            try
            {
                var param = new
                {
                    InsertedId = insertedId
                };
                lst = _dapperService
                    .Query<IncomeReportModel>
                    (SqlQuery.IncomeQuery.GetIncomeData, param);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }
    }
}
