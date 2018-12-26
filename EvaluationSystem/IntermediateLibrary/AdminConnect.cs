using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models.Objects;
using InterfaceLibrary;
using CommonLibrary;
using DataAccessLibrary;
using System.Transactions;

namespace IntermediateLibrary
{
    public class AdminConnect : IAdmin
    {
        DataAccess adminDataAccess;
        List<SqlParameter> sqlParameters;
        List<ParameterList> parameters;
        DataTable table;

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
            try
            {
                string delQuery = "DELETE FROM [dbo].[class_tbl] WHERE classId = (@ClassId);";

                SqlParameter param1 = new SqlParameter("@ClassId", SqlDbType.Int, int.MaxValue, "classId");
                param1.Value = _class.ClassId;

                sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(param1);

                adminDataAccess = new DataAccess();

                if (param1.Value == null){ throw new MyException(); }
                else
                {
                    Task<int> task = Task.Run(() => adminDataAccess.ExecuteCommandAsync(delQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public int DeleteCourse(CourseObject course)
        {
            try
            {
                string delQuery = "DELETE FROM [dbo].[course_tbl] WHERE [courseId] = (@CourseId);";

                SqlParameter param1 = new SqlParameter("@CourseId", SqlDbType.NVarChar, 8, "courseId");
                param1.Value = course.CourseId;

                sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(param1);

                adminDataAccess = new DataAccess();

                if (param1.Value == null) { throw new MyException(); }
                else
                {
                    Task<int> task = Task.Run(() => adminDataAccess.ExecuteCommandAsync(delQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public int DeleteRubric(RubricObject rubric)
        {
            try
            {
                string delQuery = "DELETE FROM [dbo].[rubric_tbl] WHERE rubricId = (@RubricId);";

                sqlParameters = new List<SqlParameter>();
                SqlParameter param1 = new SqlParameter("@RubricId", SqlDbType.Int, int.MaxValue, "rubricId");
                param1.Value = rubric.RubricId;

                sqlParameters.Add(param1);

                if(param1.Value == null) { throw new MyException(); }
                else
                {
                    adminDataAccess = new DataAccess();
                    Task<int> task = Task.Run(() => adminDataAccess.ExecuteCommandAsync(delQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }


            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public int DeleteUser<T>(T user) where T : UserObject
        {
            if (typeof(StudentObject) != user.GetType() || typeof(InstructorObject) != user.GetType()) { throw new InvalidCastException(); }
            else
            {
                string delQuery = "DELETE FROM [dbo].[user_tbl] WHERE userId = (@UserId) and roleId = (@RoleId);";

                SqlParameter param1, param2;

                param1 = new SqlParameter("@UserId", SqlDbType.NVarChar, 10, "userId");
                param1.Value = user.UserId;

                param2 = new SqlParameter("@RoleId", SqlDbType.Int, int.MaxValue, "roleId");
                param2.Value = user.userRole;

                if (param1.Value == null || param2.Value == null) { throw new MyException(); }
                else
                {
                    sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(param1);
                    sqlParameters.Add(param2);

                    adminDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => adminDataAccess.ExecuteCommandAsync(delQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
        }
        public int UpdateClass(ClassObject _class)
        {
            try
            {
                string updQuery = "$UPDATE [dbo].[class_tbl] SET className = @ClassName, courseId = @CourseId, instructorId = @InstructorId where classId = @ClassId";

                SqlParameter param1, param2, param3, param4;

                param1 = new SqlParameter("@ClassName", SqlDbType.NVarChar, 50, "className");
                param1.Value = _class.ClassId;

                param2 = new SqlParameter("@CourseId", SqlDbType.Int, int.MaxValue, "courseId");
                param2.Value = _class.Course.CourseId;

                param3 = new SqlParameter("@InstructorId", SqlDbType.NVarChar, 10, "instructorId");
                param3.Value = _class.Instructor.UserId;

                param4 = new SqlParameter("@ClassId", SqlDbType.Int, int.MaxValue, "classId");
                param4.Value = _class.ClassId;

                if(param4.Value == null) { throw new NullReferenceException(); }
                else
                {
                    sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(param1);
                    sqlParameters.Add(param2);
                    sqlParameters.Add(param3);
                    sqlParameters.Add(param4);

                    adminDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => adminDataAccess.ExecuteCommandAsync(updQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public int UpdateCourse(CourseObject course)
        {
            try
            {
                string updQuery = "$UPDATE [dbo].[course_tbl] SET courseName = @CourseName where courseId = @CourseId";

                SqlParameter param1, param2;

                param1 = new SqlParameter("@CourseName", SqlDbType.NVarChar, 50, "courseName");
                param1.Value = course.CourseName;

                param2 = new SqlParameter("@CourseId", SqlDbType.NVarChar, 8, "courseId");
                param2.Value = course.CourseId;

                if(param2.Value == null) { throw new NullReferenceException(); }
                else
                {
                    sqlParameters = new List<SqlParameter>();

                    sqlParameters.Add(param1);
                    sqlParameters.Add(param2);

                    adminDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => adminDataAccess.ExecuteCommandAsync(updQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public int UpdateRubric(RubricObject rubric)
        {
            try
            {
                string updQuery = "$UPDATE [dbo].[rubric_tbl] SET rubricName = @RubricName, minGrade = @MinGrade, maxCriteria = @MaxGrade, averageGrade = @AverageGrade, maxCriteria = @MaxCriteria, classId = @Class where rubricId = @RubricId";

                SqlParameter param1, param2, param3, param4, param5, param6;

                param1 = new SqlParameter("@RubricName", SqlDbType.NVarChar, 50, "rubricName");
                param1.Value = rubric.RubricName;

                param2 = new SqlParameter("@MinGrade", SqlDbType.Int, int.MaxValue, "maxCriteria");
                param2.Value = rubric.MinGrade;

                param3 = new SqlParameter("@MaxGrade", SqlDbType.Int, int.MaxValue, "maxCriteria");
                param3.Value = rubric.MaxGrade;

                param4 = new SqlParameter("@MaxCriteria", SqlDbType.Int, int.MaxValue, "maxCriteria");
                param4.Value = rubric.MaxCriteria;

                param5 = new SqlParameter("@Class", SqlDbType.Int, int.MaxValue, "classId");
                param5.Value = rubric.Class.ClassId;

                param6 = new SqlParameter("@RubricId", SqlDbType.Int, int.MaxValue, "rubricId");
                param6.Value = rubric.RubricId;

                if(param6.Value == null) { throw new NullReferenceException(); }
                else
                {
                    sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(param1);
                    sqlParameters.Add(param2);
                    sqlParameters.Add(param3);
                    sqlParameters.Add(param4);
                    sqlParameters.Add(param5);
                    sqlParameters.Add(param6);

                    adminDataAccess = new DataAccess();

                    Task<int> task = Task.Run(()=> adminDataAccess.ExecuteCommandAsync(updQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public int UpdateUser<T>(T user) where T : UserObject
        {
            try
            {
                if (typeof(StudentObject) != user.GetType() || typeof(InstructorObject) != user.GetType()) { throw new InvalidCastException(); }
                else
                {
                    string updQuery = $"UPDATE [dbo].[user_tbl] SET password = @Password, fName = @Fname, lName = @Lname, email = @Email, phone = @Phone where userId = @UserId;";

                    SqlParameter param1, param2, param3, param4, param5, param6;

                    param1 = new SqlParameter("@Password", SqlDbType.NVarChar, 50, "password");
                    param1.Value = user.Password;

                    param2 = new SqlParameter("@Fname", SqlDbType.NVarChar, 50, "fName");
                    param2.Value = user.FirstName;

                    param3 = new SqlParameter("@Lname", SqlDbType.NVarChar, 50, "lName");
                    param3.Value = user.LastName;

                    param4 = new SqlParameter("@Email", SqlDbType.NVarChar, 50, "email");
                    param4.Value = user.Email;

                    param5 = new SqlParameter("@Phone", SqlDbType.NVarChar, 50, "phone");
                    param5.Value = user.Phone;

                    param6 = new SqlParameter("@UserId", SqlDbType.NVarChar, 10, "userId");
                    param6.Value = user.UserId;

                    if(param6.Value == null) { throw new NullReferenceException(); }
                    else
                    {
                        sqlParameters = new List<SqlParameter>();
                        sqlParameters.Add(param1);
                        sqlParameters.Add(param2);
                        sqlParameters.Add(param3);
                        sqlParameters.Add(param4);
                        sqlParameters.Add(param5);
                        sqlParameters.Add(param6);

                        adminDataAccess = new DataAccess();

                        Task<int> task = Task.Run(() => adminDataAccess.ExecuteCommandAsync(updQuery, CommandType.Text, sqlParameters));

                        return task.Result;
                    }
                }
            }

            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public ClassObject ViewClass(int classId)
        {
            try
            {
                string sqlSelect = $"SELECT cl.classId, cl.className, cl.courseId, cl.InstructorId, co.courseName,  us.fName from(class_tbl cl join course_tbl co on cl.courseId = co.courseId) join user_tbl us on cl.instructorId = us.userId where cl.classId = @ClassId ";

                adminDataAccess = new DataAccess();
                ClassObject classObj = new ClassObject();
                parameters = new List<ParameterList>();

                parameters.Add(new ParameterList() { Key = "@ClassId", Value = classId });

                Task<DataTable> task = Task.Run(() => adminDataAccess.GetDataAsync(sqlSelect, parameters));

                classObj.ClassId = Convert.ToInt32(task.Result.Columns["classId"]);
                classObj.ClassName = task.Result.Columns["courseName"].ToString();
                classObj.Course.CourseId = Convert.ToInt32(task.Result.Columns["courseId"]);
                classObj.Course.CourseName = task.Result.Columns["courseName"].ToString();
                classObj.Instructor.UserId = task.Result.Columns["userId"].ToString();
                classObj.Instructor.FirstName = task.Result.Columns["fName"].ToString();

                if(classObj == null) { throw new NullReferenceException(); }
                else
                {
                    return classObj;
                }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public CourseObject ViewCourse(int courseId)
        {
            try
            {
                string sqlSelect = $"SELECT [courseId], [courseName] FROM [dbo].[course_tbl] WHERE courseiD = @CourseID";

                parameters = new List<ParameterList>();

                parameters.Add(new ParameterList() { Key = "@CourseID", Value = courseId });
                adminDataAccess = new DataAccess();
                CourseObject courseObj = new CourseObject();

                Task<DataTable> task = Task.Run(() => adminDataAccess.GetDataAsync(sqlSelect, parameters));

                courseObj.CourseId = Convert.ToInt32(task.Result.Columns["courseId"]);
                courseObj.CourseName = task.Result.Columns["courseName"].ToString();

                if(courseObj == null) { throw new NullReferenceException(); }
                else { return courseObj; }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public RubricObject ViewRubric(int rubricId)
        {
            try
            {
                string sqlSelect = $"SELECT [rubricId] ,[rubricName] ,[minGrade] ,[maxGrade] ,[averageGrade] ,[maxCriteria] , r.[classId], cl.className FROM[dbo].[rubric_tbl] r join class_tbl cl on r.classId = cl.classId where rubricId = @RubricId;";

                parameters = new List<ParameterList>();
                parameters.Add(new ParameterList() { Key = "@RubricId", Value = rubricId });

                RubricObject rubricObj = new RubricObject();
                adminDataAccess = new DataAccess();

                Task<DataTable> task = Task.Run(() => adminDataAccess.GetDataAsync(sqlSelect, parameters));

                rubricObj.RubricId = Convert.ToInt32(task.Result.Columns["rubricId"]);
                rubricObj.RubricName = task.Result.Columns["rubricName"].ToString();
                rubricObj.MinGrade = Convert.ToInt32(task.Result.Columns["minGrade"]);
                rubricObj.MaxGrade = Convert.ToInt32(task.Result.Columns["maxGrade"]);
                rubricObj.MaxCriteria = Convert.ToInt32(task.Result.Columns["maxCriteria"]);
                rubricObj.Class.ClassId = Convert.ToInt32(task.Result.Columns["classId"]);
                rubricObj.Class.ClassName = task.Result.Columns["className"].ToString();

                if(rubricObj == null) { throw new NullReferenceException(); }
                else { return rubricObj; }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
        public UserObject ViewUser(string userId, UserObject.UserRole userRole)
        {
            try
            {
                string sqlSelect = $"SELECT u.[userId], u.[password], u.[roleId], u.[fName], u.[lName], u.[email], u.[phone] FROM user_tbl u WHERE userId = @UserId";

                if(userRole != UserObject.UserRole.Instructor || userRole != UserObject.UserRole.Student) { throw new NullReferenceException(); }

                    parameters = new List<ParameterList>();
                    UserObject user = null;

                    switch (userRole)
                    {
                        case UserObject.UserRole.Instructor:
                            user = new InstructorObject();
                            break;
                        case UserObject.UserRole.Student:
                            user = new StudentObject();
                            break;
                        default:
                            break;
                    }

                    parameters.Add(new ParameterList() { Key = "@UserId", Value = userId });
                    adminDataAccess = new DataAccess();

                    Task<DataTable> task = Task.Run(() => adminDataAccess.GetDataAsync(sqlSelect, parameters));

                    user.UserId = task.Result.Columns["userId"].ToString();
                    user.Password = task.Result.Columns["password"].ToString();
                    user.userRole = (UserObject.UserRole)Convert.ToInt32(task.Result.Columns["roleId"]);
                    user.FirstName = task.Result.Columns["fName"].ToString();
                    user.LastName = task.Result.Columns["lName"].ToString();
                    user.Email = task.Result.Columns["email"].ToString();
                    user.Phone = task.Result.Columns["phone"].ToString();

                    if(user == null) { throw new NullReferenceException(); }
                    else { return user; }
            }
            catch (Exception ex)
            {
                MyException.Log(ex);
                throw;
            }
        }
    }
}
