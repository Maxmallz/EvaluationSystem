using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary;
using Models.Objects;
using DataAccessLibrary;
using System.Data;
using CommonLibrary;

namespace IntermediateLibrary
{
    public class UserConnect : IUser
    {
        DataAccess userAccess;
        UserObject.UserRole userRole;
        List<ParameterList> parameterLists;
        public bool isLoginSuccessfull = false;
        public string fullName { get; set; }
        public UserObject.UserRole Login(string userId, string password, out string errorMsg)
        {
            try
            {
                //check if username exists
                //check if password matches
                //get user role
                userAccess = new DataAccess();
                parameterLists = new List<ParameterList>();
                errorMsg = "";

                string usernameSql, passwordSql, roleSql;
                ParameterList usernameParam, roleParam;
                string usernameTask, passwordTask;
                DataTable roleTask;

                usernameSql = "select userId from user_tbl where userId = @UserId";
                usernameParam = new ParameterList() { Key = "@UserId", Value = userId };
                parameterLists.Add(usernameParam);

                passwordSql = "select password from user_tbl where userId = @UserId";

                usernameTask = (string)userAccess.ExecuteScalar(usernameSql, parameterLists);
                
                if (usernameTask != null)//username exists
                {
                    passwordTask = (string)userAccess.ExecuteScalar(passwordSql, parameterLists);

                    if (passwordTask != null && (password.ToUpper().Equals(passwordTask.ToString().ToUpper())))//password exists and is equal
                    {
                        roleSql = "select roleId, fName + ' ' + lName full_Name from user_tbl where userId = @UserId and password = @Password;";

                        roleParam = new ParameterList() { Key = "@Password", Value = password };

                        parameterLists.Add(roleParam);
                        
                        roleTask = userAccess.GetData(roleSql, parameterLists);

                        if(roleTask != null)
                        {
                            isLoginSuccessfull = true;
                            fullName = roleTask.Rows[0].Field<string>("full_Name");
                            userRole = (UserObject.UserRole)roleTask.Rows[0].Field<int>("roleId");
                        }
                        else
                        {
                            errorMsg = "An unknown error has occured";
                            throw new Exception();
                        }
                    }
                    else
                    {
                        errorMsg = "Incorrect Password";
                    }
                }
                else
                {
                    errorMsg = "Username does not exist";   
                }

                return userRole;
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }

        }
        public void Logout(UserObject user)
        {
            throw new NotImplementedException();
        }
    }
}
