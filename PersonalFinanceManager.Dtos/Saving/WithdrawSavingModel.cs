using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Dtos.Saving
{
    public class WithdrawSavingModel
    {
        public string User { get; set; }
        public DateTime WithdrawDate { get; set; }
        public decimal Amount { get; set; }
    }
}
