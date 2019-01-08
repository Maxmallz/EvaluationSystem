using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InterfaceLibrary;
using Models.Objects;
using CommonLibrary;
using System.Data.SqlClient;
using System.Data;
using DataAccessLibrary;

namespace IntermediateLibrary
{
    class StudentConnect : IStudent
    {
        DataAccess studentDataAccess;
        List<SqlParameter> sqlParameters;
        List<ParameterList> parameters;

        public int MakeAssessment(AssessmentObject assessment)
        {
            try
            {
                string insQuery = "INSERT INTO [dbo].[teamMemberAssessment_tbl] ([doneBy],[doneFor],[totalValue], [teamId],[classId],[feedback],[feedbackStatus]) VALUES (@DoneBy, @DoneFor, @TotalValue, @TeamId, @ClassId, @Feedback,         @FeedbackStatus)";

                SqlParameter param1, param2, param3, param4, param5, param6, param7;

                param1 = new SqlParameter("@DoneBy", SqlDbType.NVarChar, 10, "doneBy");
                param1.Value = assessment.DoneBy.UserId;

                param2 = new SqlParameter("@DoneFor", SqlDbType.NVarChar, 10, "doneFor");
                param2.Value = assessment.DoneFor.UserId;

                param3 = new SqlParameter("@TotalValue", SqlDbType.Int, int.MaxValue, "totalValue");
                param3.Value = assessment.TotalValue;

                param4 = new SqlParameter("@TeamId", SqlDbType.Int, int.MaxValue, "teamId");
                param4.Value = assessment.Team.TeamId;

                param5 = new SqlParameter("@ClassId", SqlDbType.Int, int.MaxValue, "classId");
                param5.Value = assessment._Class.ClassId;

                param6 = new SqlParameter("@Feedback", SqlDbType.NVarChar, 200, "feedback");
                param6.Value = assessment.Feedback;

                param7 = new SqlParameter("FeedbackStatus", SqlDbType.Int, int.MaxValue, "feedbackStatus");
                if(assessment.Feedback != null){param7.Value = 0;}//No Feedback Enum
                else { param7.Value = 1; }//No Action Taken

                if(assessment == null) { throw new NullReferenceException(); }
                else
                {
                    sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(param1);
                    sqlParameters.Add(param2);
                    sqlParameters.Add(param3);
                    sqlParameters.Add(param4);
                    sqlParameters.Add(param5);
                    sqlParameters.Add(param6);
                    sqlParameters.Add(param7);

                    studentDataAccess = new DataAccess();

                    Task<int> task = Task.Run(() => studentDataAccess.ExecuteCommandAsync(insQuery, CommandType.Text, sqlParameters));

                    return task.Result;
                }

            }
            catch (Exception ex)
            {
                MyException.Log(ex);
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
        public ReportObject ViewTeamMemberReport(StudentObject studentId)
        {
            throw new NotImplementedException();
        }
        public ReportObject ViewTeamReport(TeamObject teamId)
        {
            throw new NotImplementedException();
        }
    }
}
