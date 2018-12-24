using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InterfaceLibrary;
using CommonLibrary;
using System.Transactions;

namespace DataAccessLibrary
{
    public class DataAccess:ParameterList, IDataAccess
    {
        private string conStr;
        private DataTable table;
        private SqlCommand sqlCmd;
        private SqlDataAdapter adp;
        private SqlDataReader rdr;
        private DataSet dataSet;
        private SqlConnection sqlCon;

        public DataAccess()
        {
            conStr = ConfigurationManager.ConnectionStrings["MainProgram.Properties.Settings.schCS"].ConnectionString;
        }
        public void OpenConnection()
        {
            try
            {
                if (this.sqlCon.State != ConnectionState.Open)
                {
                    sqlCon = new SqlConnection(conStr);
                    sqlCon.Open();
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public void CloseConnection()
        {
            try
            {
                if (this.sqlCon.State != ConnectionState.Closed)
                {
                    sqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public int ExecuteCommand(string query, CommandType cmdType, List<SqlParameter> parameters = null)
        {
            int i = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    using (sqlCon = new SqlConnection())
                    {
                        sqlCmd = new SqlCommand(query, sqlCon);
                        cmdType = CommandType.Text;

                        if (parameters != null)
                            {
                                foreach (SqlParameter parameter in parameters)
                                {
                                    sqlCmd.Parameters.Add(parameter);
                                }
                            }//add parameters
                        OpenConnection();

                        i = sqlCmd.ExecuteNonQuery();
                        scope.Complete();
                        return i;
                    }
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
            finally
            {
                sqlCmd.Dispose();
                CloseConnection();
            }
        }
        public async Task<int> ExecuteCommandAsync(string query, CommandType cmdType, List<SqlParameter> parameters = null)
        {
            int i = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    using (sqlCon = new SqlConnection())
                    {
                        sqlCmd = new SqlCommand(query, sqlCon);
                        cmdType = CommandType.Text;

                        if (parameters != null)
                        {
                            foreach (SqlParameter parameter in parameters)
                            {
                                sqlCmd.Parameters.Add(parameter);
                            }
                        }//add parameters
                        OpenConnection();

                        i = await sqlCmd.ExecuteNonQueryAsync();
                        scope.Complete();
                        return i;
                    }
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
            finally
            {
                sqlCmd.Dispose();
                CloseConnection();
            }
        }
        public object ExecuteScalar(string sqlSelect, List<ParameterList> keyValuePairs = null)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    using (sqlCon = new SqlConnection())
                    {
                        sqlCmd = new SqlCommand(sqlSelect, sqlCon);

                        if (keyValuePairs != null)
                        {
                            foreach (var keyValuePair in keyValuePairs)
                            {
                                sqlCmd.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                            }
                        }
                        OpenConnection();

                        scope.Complete();
                        return sqlCmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex) 
            {
                MyException.Log(ex);
                throw;
            }
            finally
            {
                sqlCmd.Dispose();
                CloseConnection();
            }
        }
        public async Task<object> ExecuteScalarAsync(string sqlSelect, List<ParameterList> keyValuePairs = null)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    using (sqlCon = new SqlConnection())
                    {
                        sqlCmd = new SqlCommand(sqlSelect, sqlCon);

                        if (keyValuePairs != null)
                        {
                            foreach (var keyValuePair in keyValuePairs)
                            {
                                sqlCmd.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                            }
                        }
                        OpenConnection();

                        scope.Complete();
                        return await sqlCmd.ExecuteScalarAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
            finally
            {
                sqlCmd.Dispose();
                CloseConnection();
            }
        }
        public DataTable GetData(string sqlSelect, List<ParameterList> keyValuePairs = null)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    using (sqlCon = new SqlConnection())
                    {
                        sqlCmd = new SqlCommand(sqlSelect, sqlCon);
                        table = new DataTable();
                        adp = new SqlDataAdapter(sqlCmd);

                        if (keyValuePairs != null)
                        {
                            foreach (var keyValuePair in keyValuePairs)
                            {
                                sqlCmd.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                            }
                        }
                        OpenConnection();

                        adp.Fill(table);

                        scope.Complete();
                        return table;
                    }
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
            finally
            {
                sqlCmd.Dispose();
                CloseConnection();
            }
        }
        public async Task<DataTable> GetDataAsync(string sqlSelect, List<ParameterList> keyValuePairs = null)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    using (sqlCon = new SqlConnection())
                    {
                        sqlCmd = new SqlCommand(sqlSelect, sqlCon);
                        table = new DataTable();
                        adp = new SqlDataAdapter(sqlCmd);

                        if (keyValuePairs != null)
                        {
                            foreach (var keyValuePair in keyValuePairs)
                            {
                                sqlCmd.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                            }
                        }
                        OpenConnection();

                        int i;
                        adp.Fill(table);

                        Task task = Task.Run(()=> adp.Fill(table));

                        await (task);

                        scope.Complete();
                        return table;
                    }
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
            finally
            {
                sqlCmd.Dispose();
                CloseConnection();
            }
        }
        private SqlDataReader GetDataReader()
        {
            throw new NotImplementedException();
        }
    }
}
