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
        //private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        //public DapperService(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        //{
        //    _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
        //}

        private readonly string _connectionString  = "Data Source=.;Initial Catalog=housewife;User ID=sa;Password=sasa@123;";

        public T QueryFirstOrDefault<T>(string query, object param = null)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var item =  db.QueryFirstOrDefault<T>(query, param);
                return item;
            }
        }

        public List<T> Query<T>(string query, object param = null)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var lst =  db.Query<T>(query, param);
                return lst.ToList();
            }
        }

        public int Execute(string query, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var result =  db.Execute(query, param, commandType: commandType);
                return result;
            }
        }
    }
}
