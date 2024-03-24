using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Dtos.Income
{
    public class IncomeFormLoadingModel
    {
        public List<IncomeDescriptionModel> DescriptionLst { get; set; } = new List<IncomeDescriptionModel>();
        public List<IncomeFromModel> FromLst { get; set; } = new List<IncomeFromModel>();
        public List<IncomeTypeModel> PaymentLst { get; set; } = new List<IncomeTypeModel>();
    }
    public class IncomeDescriptionModel
    {
        public string Description { get; set; }
    }
    public class IncomeFromModel
    {
        public string From { get; set; }
    }
    public class IncomeTypeModel
    {
        public string IncomeType { get; set; }
    }
}
