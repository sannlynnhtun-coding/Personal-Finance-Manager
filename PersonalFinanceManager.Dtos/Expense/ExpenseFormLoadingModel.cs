using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Dtos.Expense
{
    public class ExpenseFormLoadingModel
    {
        public List<ExpenseDescriptionModel> DescriptionLst { get; set; } = new List<ExpenseDescriptionModel>();
        public List<ExpenseToModel> ToLst { get; set; } = new List<ExpenseToModel>();
        public List<ExpensePaymentModel> PaymentLst { get; set; } = new List<ExpensePaymentModel>();
    }
    public class ExpenseDescriptionModel
    {
        public string Description { get; set; }
    }
    public class ExpenseToModel
    {
        public string To { get; set; }
    }
    public class ExpensePaymentModel
    {
        public string Payment { get; set; }
    }
}
