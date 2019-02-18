using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InterfaceLibrary;
using Models.Objects;
using System.Data.SqlClient;
using System.Data;
using DataAccessLibrary;

namespace IntermediateLibrary
{
    class InstructorConnect : IInstructor
    {
        DataAccess instructorDataAccess;
        List<SqlParameter> sqlParameters;
        List<ParameterList> parameters;
        public int AddCriterion(CriterionObject criterion)
        {
            try
            {
                string insQuery = "INSERT INTO [dbo].[criteria_tbl] ([criteriaName] ,[Description], [rubricId]) VALUES(@CriteriaName, @Description, @RubricId);";

                SqlParameter param1, param2, param3;

                param1 = new SqlParameter("@CriteriaName",SqlDbType.NVarChar, 50, "criteriaName");
                param1.Value = criterion.CriteriaName;

                param2 = new SqlParameter("@Description", SqlDbType.NVarChar, 200, "Description");
                param2.Value = criterion.Description;

                param3 = new SqlParameter("@RubricId", SqlDbType.Int, int.MaxValue, "rubricId");
                param3.Value = criterion.Rubric.RubricId;

                if(criterion == null) { throw new NullReferenceException(); }
                else
                {
                    sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(param1);
                    sqlParameters.Add(param2);
                    sqlParameters.Add(param3);

                    instructorDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => instructorDataAccess.ExecuteCommandAsync(insQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public int AddTeam(TeamObject team)
        {
            try
            {
                string Query = "INSERT INTO [dbo].[team_tbl] ([teamName] ,[classId] ,[minMember] ,[maxMember] ,[createdBy]) VALUES(@TeamName, @ClassId, @MinMember, @MaxMember, @CreatedBy)";

                SqlParameter param1, param2, param3, param4, param5;

                param1 = new SqlParameter("@TeamName", SqlDbType.NVarChar, 50, "teamName");
                param1.Value = team.TeamName;

                param2 = new SqlParameter("@ClassId", SqlDbType.Int, int.MaxValue, "classId");
                param2.Value = team._Class.ClassId;

                param3 = new SqlParameter("@MinMember", SqlDbType.Int, int.MaxValue, "minMember");
                param3.Value = team.MinMember;

                param4 = new SqlParameter("@MaxMember", SqlDbType.Int, int.MaxValue, "maxMember");
                param4.Value = team.MaxMember;

                param5 = new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 10, "createdBy");
                param5.Value = team.CreatedBy;

                if(team == null) { throw new NullReferenceException(); }
                else
                {
                    instructorDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => instructorDataAccess.ExecuteCommandAsync(Query, CommandType.Text, sqlParameters));

                    return task.Result; 
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public int AddStudentToTeam(string studentId, int teamId)
        {
            try
            {
                string insQuery = "INSERT INTO [dbo].[studentTeam] ([studentId], [teamId]) VALUES(@StudentId, @TeamId);";

                SqlParameter param1, param2;

                param1 = new SqlParameter("@StudentId", SqlDbType.NVarChar, 10, "studentId");
                param1.Value = studentId;

                param2 = new SqlParameter("@TeamId", SqlDbType.Int, int.MaxValue, "teamId");
                param2.Value = teamId;

                if (param1.Value == null || param2.Value == null) { throw new NullReferenceException(); }
                else
                {
                    instructorDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => instructorDataAccess.ExecuteCommandAsync(insQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public int DeleteCriterion(int criteriaId)
        {
            try
            {
                string Query = "DELETE FROM [criteria_tbl] WHERE criteriaId = @CriteriaId";

                SqlParameter param1;

                param1 = new SqlParameter("@CriteriaId", SqlDbType.Int, int.MaxValue, "criteriaId");
                param1.Value = criteriaId;

                if (param1.Value == null) { throw new NullReferenceException(); }
                else
                {
                    instructorDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => instructorDataAccess.ExecuteCommandAsync(Query, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public int DeleteTeam(int teamId)
        {
            try
            {
                string Query = "DELETE FROM [team_tbl] WHERE [teamId] = @TeamId";

                SqlParameter param1;

                param1 = new SqlParameter("@TeamId", SqlDbType.Int, int.MaxValue, "teamID");
                param1.Value = teamId;

                if (param1.Value == null) { throw new NullReferenceException(); }
                else
                {
                    instructorDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => instructorDataAccess.ExecuteCommandAsync(Query, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public int UpdateCriterion(CriterionObject criterion)
        {
            try
            {
                string insQuery = "UPDATE [dbo].[criteria_tbl] SET [criteriaName] = @CriteriaName,[Description] = @Description, [rubricId] = @RubricId WHERE  [criteriaId] = @CriteriaId";

                SqlParameter param1, param2, param3, param4;

                param1 = new SqlParameter("@CriteriaName", SqlDbType.NVarChar, 50, "criteriaName");
                param1.Value = criterion.CriteriaName;

                param2 = new SqlParameter("@Description", SqlDbType.NVarChar, 200, "Description");
                param2.Value = criterion.Description;

                param3 = new SqlParameter("@RubricId", SqlDbType.Int, int.MaxValue, "rubricId");
                param3.Value = criterion.Rubric.RubricId;

                param4 = new SqlParameter("@CriteriaId", SqlDbType.Int, int.MaxValue, "criteriaId");
                param3.Value = criterion.CriteriaId;

                if (criterion == null) { throw new NullReferenceException(); }
                else
                {
                    sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(param1);
                    sqlParameters.Add(param2);
                    sqlParameters.Add(param3);
                    sqlParameters.Add(param4);

                    instructorDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => instructorDataAccess.ExecuteCommandAsync(insQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public int UpdateTeam(TeamObject team)
        {
            try
            {
                string Query = "UPDATE [dbo].[team_tbl] SET [teamName] = @TeamName, [classId] = @ClassId ,[minMember] = @MinMember,[maxMember] = @MaxMember, [createdBy] = @CreatedBy WHERE [teamId] = @TeamId";

                SqlParameter param1, param2, param3, param4, param5;

                param1 = new SqlParameter("@TeamName", SqlDbType.NVarChar, 50, "teamName");
                param1.Value = team.TeamName;

                param2 = new SqlParameter("@ClassId", SqlDbType.Int, int.MaxValue, "classId");
                param2.Value = team._Class.ClassId;

                param3 = new SqlParameter("@MinMember", SqlDbType.Int, int.MaxValue, "minMember");
                param3.Value = team.MinMember;

                param4 = new SqlParameter("@MaxMember", SqlDbType.Int, int.MaxValue, "maxMember");
                param4.Value = team.MaxMember;

                param5 = new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 10, "createdBy");
                param5.Value = team.CreatedBy;

                param5 = new SqlParameter("@TeamId", SqlDbType.Int, int.MaxValue, "teamId");
                param5.Value = team.TeamId;

                if (team == null) { throw new NullReferenceException(); }
                else
                {
                    sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(param1);
                    sqlParameters.Add(param2);
                    sqlParameters.Add(param3);
                    sqlParameters.Add(param4);
                    sqlParameters.Add(param5);

                    instructorDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => instructorDataAccess.ExecuteCommandAsync(Query, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public AssessmentObject ViewAssessment(int assessmentId)
        {
            throw new NotImplementedException();
        }
        public ReportObject ViewClassReport(ClassObject classId)
        {
            throw new NotImplementedException();
        }
        public CriterionObject ViewCriterion(int criterionId)
        {
            try
            {
                string sqlSelect = $"SELECT [criteriaId],[criteriaName],[Description], cr. [rubricId], r.rubricName FROM [criteria_tbl] cr JOIN rubric_tbl r ON r.rubricId = cr.rubricId where criteriaId = @CriteriaId";

                instructorDataAccess = new DataAccess();
                CriterionObject criterionObject = new CriterionObject();
                parameters = new List<ParameterList>();

                parameters.Add(new ParameterList() { Key = "@CriteriaId", Value = criterionId });

                Task<DataTable> task = Task.Run(() => instructorDataAccess.GetDataAsync(sqlSelect, parameters));

                criterionObject.CriteriaId = Convert.ToInt32(task.Result.Columns["criteriaId"]);
                criterionObject.CriteriaName = task.Result.Columns["criteriaName"].ToString();
                criterionObject.Rubric.RubricId = Convert.ToInt32(task.Result.Columns["rubricId"]);
                criterionObject.Rubric.RubricName = task.Result.Columns["rubricName"].ToString();
                criterionObject.Description = task.Result.Columns["criteriaId"].ToString();

                if (criterionObject == null) { throw new NullReferenceException(); }
                else
                {
                    return criterionObject;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public TeamObject ViewTeam(int teamId)
        {
            try
            {
                string sqlSelect = $"SELECT [teamId],[teamName],[classId],[minMember],[maxMember],[createdBy] FROM team_tbl WHERE teamId = @TeamId;";

                instructorDataAccess = new DataAccess();
                TeamObject teamObject = new TeamObject();
                parameters = new List<ParameterList>();

                parameters.Add(new ParameterList() { Key = "@TeamId", Value = teamId });

                Task<DataTable> task = Task.Run(() => instructorDataAccess.GetDataAsync(sqlSelect, parameters));

                teamObject.TeamId = Convert.ToInt32(task.Result.Columns["teamId"]);
                teamObject.TeamName = task.Result.Columns["teamName"].ToString();
                teamObject.MinMember = Convert.ToInt32(task.Result.Columns["minMember"]);
                teamObject.MaxMember = Convert.ToInt32(task.Result.Columns["maxMember"]);
                teamObject._Class.ClassId = Convert.ToInt32(task.Result.Columns["classId"]);
                teamObject.CreatedBy.UserId = task.Result.Columns["createdBy"].ToString();

                if (teamObject == null) { throw new NullReferenceException(); }
                else
                {
                    return teamObject;
                }
            }
            catch(Exception ex)
            {
                
                throw;
            }
        }
        public ReportObject ViewTeamMemberReport(StudentObject studentId)
        {
            throw new NotImplementedException();
        }
        public ReportObject ViewTeamReport(TeamObject teamId)
        {
            throw new NotImplementedException();
        }
        public int RemoveStudentFromTeam(string studentId, int teamId)
        {
            try
            {
                string Query = "DELETE FROM [studentTeam] WHERE [teamId] = @TeamId AND [studentId] = @StudentId;";

                SqlParameter param1, param2;

                param1 = new SqlParameter("@TeamId", SqlDbType.Int, int.MaxValue, "teamID");
                param1.Value = teamId;

                param2 = new SqlParameter("@StudentId", SqlDbType.NVarChar, 10, "studentId");
                param2.Value = studentId;

                if (param1.Value == null || param2.Value == null) { throw new NullReferenceException(); }
                else
                {
                    instructorDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => instructorDataAccess.ExecuteCommandAsync(Query, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public int AddStudentToClass(string studentId, int classId)
        {
            try
            {
                string insQuery = "INSERT INTO [dbo].[studentClass] ([studentId], [classId]) VALUES(@StudentId, @ClassId);";

                SqlParameter param1, param2;

                param1 = new SqlParameter("@StudentId", SqlDbType.NVarChar, 10, "studentId");
                param1.Value = studentId;

                param2 = new SqlParameter("@ClassId", SqlDbType.Int, int.MaxValue, "teamId");
                param2.Value = classId;

                if (param1.Value == null || param2.Value == null) { throw new NullReferenceException(); }
                else
                {
                    instructorDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => instructorDataAccess.ExecuteCommandAsync(insQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public int RemoveStudentFromClass(string studentId, int classId)
        {
            try
            {
                string Query = "DELETE FROM [studentClass] WHERE [classId] = @ClassId AND [studentId] = @StudentId;";

                SqlParameter param1, param2;

                param1 = new SqlParameter("@ClassId", SqlDbType.Int, int.MaxValue, "classId");
                param1.Value = classId;

                param2 = new SqlParameter("@StudentId", SqlDbType.NVarChar, 10, "studentId");
                param2.Value = studentId;

                if (param1.Value == null || param2.Value == null) { throw new NullReferenceException(); }
                else
                {
                    instructorDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => instructorDataAccess.ExecuteCommandAsync(Query, CommandType.Text, sqlParameters));

                    return task.Result;
                }
            }
            catch(Exception ex)
            {
                
                throw;
            }
        }
        public DataTable GetTeam()
        {
            throw new NotImplementedException();
        }
        public DataTable GetCriterion()
        {
            throw new NotImplementedException();
        }
    }
}
