using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models.Objects;
using InterfaceLibrary;
using CommonLibrary;
using DataAccessLibrary;

namespace IntermediateLibrary
{
    public class AdminConnect : IAdmin
    {
        DataAccess adminDataAccess;
        List<SqlParameter> sqlParameters;
        List<ParameterList> parameters;
        int i = 0;
        
        public int AddClass(ClassObject _class)
        {
            try
            {
                string insQuery = $"INSERT INTO [dbo].[class_tbl] (className, courseId, instructorId) VALUES (@ClassName, @CourseId, @InstructorId);";

                SqlParameter param1, param2, param3;

                param1 = new SqlParameter("@ClassName", SqlDbType.NVarChar, 50, "className");
                param1.Value = _class.ClassName;

                param2 = new SqlParameter("@CourseId", SqlDbType.NVarChar, 8, "courseId");
                param2.Value = _class.Course.CourseId;

                param3 = new SqlParameter("InstructorId", SqlDbType.NVarChar, 10, "instructorId");
                param3.Value = _class.Instructor.UserId;

                sqlParameters.Add(param1);
                sqlParameters.Add(param2);
                sqlParameters.Add(param3);

                sqlParameters = new List<SqlParameter>(3);
                adminDataAccess = new DataAccess();

                Task<int> task =  Task.Run(() => adminDataAccess.ExecuteCommandAsync(insQuery, CommandType.Text, sqlParameters));

                return task.Result;
            }
            catch (Exception ex) 
            {
                MyException.Log(ex);
                throw;
            }
        }
        public int AddCourse(CourseObject course)
        {
            try
            {
                string insQuery = "INSERT INTO [dbo].[course_tbl] (courseId, courseName) VALUES (@CourseId, @CourseName);";

                SqlParameter param1, param2;

                param1 = new SqlParameter("@CourseId", SqlDbType.NVarChar, 8, "courseId");
                param1.Value = course.CourseId;

                param2 = new SqlParameter("@CourseName", SqlDbType.NVarChar, 100, "courseName");
                param2.Value = course.CourseName;

                sqlParameters = new List<SqlParameter>(2);

                sqlParameters.Add(param1);
                sqlParameters.Add(param2);

                adminDataAccess = new DataAccess();

                Task<int> task = Task.Run(() =>adminDataAccess.ExecuteCommandAsync(insQuery, CommandType.Text, sqlParameters));

                return task.Result;
            }
            catch (Exception ex) 
            {
                MyException.Log(ex);
                throw;
            }
        }
        public int AddRubric(RubricObject rubric)
        {
            try
            {
                string insQuery = $"INSERT INTO [dbo].[rubric_tbl] (rubricName, minGrade, maxGrade, averageGrade, maxCriteria, classId) VALUES(@RubricName, @MinGrade, @MaxGrade, @AverageGrade,@MaxCriteria, @ClassId)";

                SqlParameter param1, param2, param3, param4, param5, param6;

                param1 = new SqlParameter("@RubricName", SqlDbType.NVarChar, 50, "rubricName");
                param1.Value = rubric.RubricName;

                param2 = new SqlParameter("@MinGrade", SqlDbType.Int, 50, "minGrade");
                param2.Value = rubric.MinGrade;

                param3 = new SqlParameter("@MaxGrade", SqlDbType.Int, 50, "maxGrade");
                param3.Value = rubric.MaxGrade;

                param4 = new SqlParameter("@AverageGrade", SqlDbType.Int, 50, "averageGrade");
                param4.Value = rubric.AverageGrade;

                param5 = new SqlParameter("@MaxCriteria", SqlDbType.Int, 50, "maxCriteria");
                param5.Value = rubric.MaxCriteria;

                param6 = new SqlParameter("@ClassId", SqlDbType.Int, int.MaxValue, "classId");
                param6.Value = rubric.Class.ClassId;

                sqlParameters = new List<SqlParameter>();

                sqlParameters.Add(param1);
                sqlParameters.Add(param2);
                sqlParameters.Add(param3);
                sqlParameters.Add(param4);
                sqlParameters.Add(param5);
                sqlParameters.Add(param6);

                adminDataAccess = new DataAccess();

                Task<int> task = Task.Run(() => adminDataAccess.ExecuteCommandAsync(insQuery, CommandType.Text, sqlParameters));

                return task.Result;
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public int AddUser<T>(T user) where T : UserObject
        {
            try
            {
                if(typeof(StudentObject) != user.GetType() || typeof(InstructorObject) != user.GetType()) { throw new InvalidCastException(); }
                else
                {
                    string insQuery = $"INSERT INTO [dbo].[user_tbl] (userId, password, roleId, fName, lName, email, phone) VALUES(@UserId, @Password, @RoleId, @Fname, @Lname, @Email, @Phone); ";

                    SqlParameter param1, param2, param3, param4, param5, param6, param7;

                    param1 = new SqlParameter("@UserId", SqlDbType.NVarChar, 10, "userId");
                    param1.Value = user.UserId;


                    param2 = new SqlParameter("@Password", SqlDbType.NVarChar, 50, "password");
                    param2.Value = user.Password;

                    param3 = new SqlParameter("@RoleId", SqlDbType.Int, int.MaxValue, "roleId");
                    param3.Value = (int)user.userRole;

                    param4 = new SqlParameter("@Fname", SqlDbType.NVarChar, 50, "fName");
                    param4.Value = user.FirstName;

                    param5 = new SqlParameter("@Lname", SqlDbType.NVarChar, 50, "lName");
                    param5.Value = user.LastName;

                    param6 = new SqlParameter("@Email", SqlDbType.NVarChar, 50, "email");
                    param6.Value = user.Email;

                    param7 = new SqlParameter("@Phone", SqlDbType.NVarChar, 50, "phone");
                    param7.Value = user.Phone;

                    sqlParameters = new List<SqlParameter>(7);

                    sqlParameters.Add(param1);
                    sqlParameters.Add(param2);
                    sqlParameters.Add(param3);
                    sqlParameters.Add(param4);
                    sqlParameters.Add(param5);
                    sqlParameters.Add(param6);
                    sqlParameters.Add(param7);

                    adminDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => adminDataAccess.ExecuteCommandAsync(insQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }

            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public int DeleteClass(ClassObject _class)
        {
            throw new NotImplementedException();
        }
        public int DeleteCourse(CourseObject course)
        {
            throw new NotImplementedException();
        }
        public int DeleteRubric(RubricObject rubric)
        {
            throw new NotImplementedException();
        }
        public int UpdateClass(ClassObject _class)
        {
            throw new NotImplementedException();
        }
        public int UpdateCourse(CourseObject course)
        {
            throw new NotImplementedException();
        }
        public int UpdateRubric(RubricObject rubric)
        {
            throw new NotImplementedException();
        }
        public ClassObject ViewClass(int classId)
        {
            throw new NotImplementedException();
        }
        public CourseObject ViewCourse(int courseId)
        {
            throw new NotImplementedException();
        }
        public RubricObject ViewRubric(int rubricId)
        {
            throw new NotImplementedException();
        }
    }
}
