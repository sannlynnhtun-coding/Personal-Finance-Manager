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
    }
}
