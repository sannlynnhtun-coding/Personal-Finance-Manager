using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Dtos.Saving
{
    public class AddSavingRequestModel
    {
        public string UserName { get; set; }
        public decimal Amount { get; set; }
        public string FormattedDate { get; set; }
    }
}
