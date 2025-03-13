using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagementSystemApi {
    public class DataContextDapper {

        private readonly IConfiguration _configuration;

        public DataContextDapper(IConfiguration configuration) {
            _configuration = configuration;
        }

        public IEnumerable<T> LoadData<T>(string sql) {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return connection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(string sql) {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return connection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql(string sql) {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return connection.Execute(sql) > 0;
        }
    }
}
