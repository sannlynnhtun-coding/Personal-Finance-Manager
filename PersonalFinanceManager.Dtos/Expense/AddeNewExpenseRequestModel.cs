using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Dtos.Expense
{
    public class AddeNewExpenseRequestModel
    {
        public string Description { get; set; }
        public string User { get; set; }
        public string CashFlow { get; set; }
        public decimal Amount { get; set; }
        public string FromToFlow { get; set; }
        public string Date { get; set; }
        public int InsertedId { get; set; }
    }
}
