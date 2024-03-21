using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace PersonalFinanceManager.Services
{
    public class DapperService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public DapperService(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
        }

        public async Task<T> QueryFirstOrDefault<T>(string query, object param = null)
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                var item = await db.QueryFirstOrDefaultAsync<T>(query, param);
                return item;
            }
        }

        public async Task<List<T>> Query<T>(string query, object param = null)
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                var lst = await db.QueryAsync<T>(query, param);
                return lst.ToList();
            }
        }

        public async Task<int> Execute(string query, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                var result = await db.ExecuteAsync(query, param, commandType: commandType);
                return result;
            }
        }
    }
}
