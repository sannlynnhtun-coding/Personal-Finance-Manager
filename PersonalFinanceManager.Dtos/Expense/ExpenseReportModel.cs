using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Dtos.Expense
{
    public class ExpenseReportModel
    {
        public string Description { get; set; }
        public string To { get; set; }
        public string Name { get; set; }
        public string Payment { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
