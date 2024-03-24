using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Dtos.Saving
{
    public class SavingLoadModel
    {
        public string User { get; set; }
        public DateTime SavingMonth { get; set; }
        public decimal Amount { get; set; }
    }
    public class TotalSavingModel
    {
        public decimal TotalSaving { get; set; }
    }
    public class SavingLoadResponseModel
    {
        public List<SavingLoadModel> SavingLoadModel { get; set; }
        public TotalSavingModel TotalSavingModel { get; set; }
    }
}
