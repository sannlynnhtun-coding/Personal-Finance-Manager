using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Dtos.Income
{
    public class AddeNewIncomeRequestModel
    {
        public string Description { get; set; }
        public string User { get; set; }
        public string CashFlow { get; set; }
        public decimal Amount { get; set; }
        public string FromToFlow { get; set; }
        public string FormattedDate { get; set; }
    }
}
