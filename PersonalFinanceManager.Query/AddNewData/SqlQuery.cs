using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Query.AddNewData
{
    public class SqlQuery
    {
        public static string AddDescription { get; } = @"InsertDescription @name = @description";
        public static string GetDescription { get; } = @"SELECT Description FROM descriptions;";
        public static string AddFromToFlow { get; } = @"InsertFromToFlow @name = @description";
        public static string GetFromToFlow { get; } = @"SELECT Text FROM from_to_flow;";
        public static string AddCashFlow { get; } = @"InsertCashFlow @name = @description;";
        public static string GetCashFlow { get; } = @"SELECT Text FROM cash_flow;";
    }
}
