using PersonalFinanceManager.Dtos.Saving;
using PersonalFinanceManager.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Services.Features.Saving
{
    public class SavingService
    {
        private readonly DapperService _dapperService;

        public SavingService()
        {
            _dapperService = new DapperService();
        }

        public AddSavingResponseModel AddNewSaving
            (AddSavingRequestModel requestModel)
        {
            var result = new AddSavingResponseModel();
            try
            {
                result = _dapperService
                    .QueryFirstOrDefault<AddSavingResponseModel>
                    (SqlQuery.SavingQuery.AddNewSaving,requestModel,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());  
            }
            return result;
        }

        public List<SavingReportModel> GetSavingByInsertedId(int insertId)
        {
            var lst = new List<SavingReportModel>();
            try
            {
                var param = new
                {
                    InsertedId = insertId,
                };
                lst = _dapperService.Query
                    <SavingReportModel>
                    (SqlQuery.SavingQuery.GetSavingByInsertedId, param,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }

        public GetTotalSavingModel GetTotalSaving()
        {
            var item = new GetTotalSavingModel();
            try
            {
                item = _dapperService.
                    QueryFirstOrDefault<GetTotalSavingModel>
                    (SqlQuery.SavingQuery.GetTotalSaving,
                    commandType:CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.ToString());
            }
            return item;
        }

        public SavingLoadResponseModel SavingLoad(string userName)
        {
            var item = new SavingLoadResponseModel();
            try
            {
                var param = new
                {
                    UserName = userName,
                };
                var result = _dapperService.QueryMultiple
                    (SqlQuery.SavingQuery.SavingLoad,param,
                    CommandType.StoredProcedure);
                item.SavingLoadModel = result.Read<SavingLoadModel>().ToList();
                item.TotalSavingModel = result.Read<TotalSavingModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return item;
        }

        public List<WithdrawlAndSavingReportModel> GetSavingByYearly
            (string yearPattern)
        {
            var lst = new List<WithdrawlAndSavingReportModel> ();
            try
            {
                var param = new
                {
                    YearPattern = yearPattern,
                };
                lst = _dapperService.Query<WithdrawlAndSavingReportModel>
                    (SqlQuery.SavingQuery.GetSavingByYearly,
                    param,CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }
        public List<WithdrawlAndSavingReportModel> GetSavingByMonthsOfCurrentYear
            (string month)
        {
            var lst = new List<WithdrawlAndSavingReportModel>();
            try
            {
                var param = new
                {
                    MonthName = month,
                };
                lst = _dapperService.Query<WithdrawlAndSavingReportModel>
                    (SqlQuery.SavingQuery.GetSavingByMonthsOfCurrentYear,
                    param, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }

        public List<WithdrawlAndSavingReportModel> GetWithdrawSavingByUser
            (string name)
        {
            var lst = new List<WithdrawlAndSavingReportModel>();
            try
            {
                var param = new
                {
                    Name = name,
                };
                lst = _dapperService.Query<WithdrawlAndSavingReportModel>
                    (SqlQuery.SavingQuery.GetWithdrawSavingByUser,
                    param, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }

        public List<WithdrawlAndSavingReportModel> GetWithdrawByYearly
            (string withdrawyearPattern)
        {
            var lst = new List<WithdrawlAndSavingReportModel>();
            try
            {
                var param = new
                {
                    WithdrawYearPattern = withdrawyearPattern,
                };
                lst = _dapperService.Query<WithdrawlAndSavingReportModel>
                    (SqlQuery.SavingQuery.GetWithdrawByYearly,
                    param, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }
        public List<WithdrawlAndSavingReportModel> GetWithdrawByCurrentYear
            (string withdrawMonth)
        {
            var lst = new List<WithdrawlAndSavingReportModel>();
            try
            {
                var param = new
                {
                    WithdrawMonth = withdrawMonth,
                };
                lst = _dapperService.Query<WithdrawlAndSavingReportModel>
                    (SqlQuery.SavingQuery.GetWithdrawByCurrentYear,
                    param, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return lst;
        }

        public AddNewWithdrawSavingModel AddNewWithdrawSaving
            (string name,string amount)
        {
            var result = new AddNewWithdrawSavingModel();
            try
            {
                var param = new
                {
                    UserName = name,
                    Amount = amount,
                    InsertedId = 0
                };
                result = _dapperService
                    .QueryFirstOrDefault<AddNewWithdrawSavingModel>
                    (SqlQuery.SavingQuery.AddNewWithdrawSaving,param,
                    CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        public List<WithdrawSavingModel> WithdrawSaving(int insertedId)
        {
            var lst = new List<WithdrawSavingModel>();
            try
            {
                var param = new
                {
                    InsertedId = insertedId
                };
                lst = _dapperService
                    .Query<WithdrawSavingModel>
                    (SqlQuery.SavingQuery.WithdrawSaving, param);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); 
            }
            return lst;
        }
    }
}
