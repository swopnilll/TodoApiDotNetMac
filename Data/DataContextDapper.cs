using System.Data;
using Dapper;

namespace EmployeeManagementSystemApi.Data
{
    public class DataContextDapper
    {
        private readonly IDbConnection _connection;

        public DataContextDapper(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<T> LoadData<T>(string sql)
        {
            return _connection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(string sql)
        {
            return _connection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            return _connection.Execute(sql) > 0;
        }
    }
}
