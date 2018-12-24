using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public interface IDataAccess
    {
        void OpenConnection();
        void CloseConnection();
        int ExecuteCommand(string query, CommandType cmdType, List<SqlParameter> parameters = null);
        Task<int> ExecuteCommandAsync(string query, CommandType cmdType, List<SqlParameter> parameters = null);
        DataTable GetData(string sqlSelect, List<ParameterList> keyValuePairs = null);
        Task<DataTable> GetDataAsync(string sqlSelect, List<ParameterList> keyValuePairs = null);
        object ExecuteScalar(string sqlSelect, List<ParameterList> keyValuePairs = null);
        Task<object> ExecuteScalarAsync(string sqlSelect, List<ParameterList> keyValuePairs = null);
    }
}
