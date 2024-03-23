using PersonalFinanceManager.Dtos.AddNewData;
using PersonalFinanceManager.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Services.Features.AddNewData
{
    public class AddNewDataService
    {
        private readonly DapperService _dapperService;

        public AddNewDataService()
        {
            _dapperService = new DapperService();
        }

        public int AddDescription(string description)
        {
            int result = 0;
            try
            {
                var descParam = new
                {
                    Name = description
                };
                result = _dapperService.Execute(SqlQuery.AddNewDataQuery.AddDescription,
                   descParam, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        public List<FlowToFormModel> FlowToFromComboBox(string description)
        {
            var flowToFormLst = new List<FlowToFormModel>();
            try
            {
                var descParam = new
                {
                    Name = description
                };
                var result = _dapperService.Execute(SqlQuery.AddNewDataQuery.AddFromToFlow, descParam, CommandType.StoredProcedure);
                flowToFormLst = _dapperService
                   .Query<FlowToFormModel>(SqlQuery.AddNewDataQuery.GetFromToFlow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return flowToFormLst;
        }

        public List<DescriptionModel> IncomeTitleComboBox()
        {
            var descriptionLst = new List<DescriptionModel>();
            try
            {
                descriptionLst = _dapperService
                        .Query<DescriptionModel>
                        (SqlQuery.AddNewDataQuery.GetDescription);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return descriptionLst;
        }

        public List<CashFlowModel> CashFlowComboBox(string description)
        {
            var cashFlowLst = new List<CashFlowModel>();
            try
            {
                var descParam = new
                {
                    Name = description
                };
                var result = _dapperService
                    .Execute(SqlQuery.AddNewDataQuery.AddCashFlow, 
                    descParam, CommandType.StoredProcedure);
                 cashFlowLst = _dapperService
                    .Query<CashFlowModel>(SqlQuery.AddNewDataQuery.GetCashFlow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return cashFlowLst;
        }
    }
}
