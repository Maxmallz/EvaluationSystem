using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary;
using Models.Objects;

namespace IntermediateLibrary
{
    class InstructorConnect : IInstructor
    {
        public int AddCriterion(CriterionObject criterion)
        {
            throw new NotImplementedException();
        }

        public int AddTeam(TeamObject team)
        {
            throw new NotImplementedException();
        }

        public int AssignStudentToTeam(List<StudentObject> students, TeamObject team)
        {
            throw new NotImplementedException();
        }

        public int DeleteCriterion(CriterionObject criterion)
        {
            throw new NotImplementedException();
        }

        public int DeleteTeam(TeamObject team)
        {
            throw new NotImplementedException();
        }

        public int MakeAssessment(AssessmentObject assessment)
        {
            throw new NotImplementedException();
        }

        public int UpdateCriterion(CriterionObject criterion)
        {
            throw new NotImplementedException();
        }

        public int UpdateTeam(TeamObject team)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public TeamObject ViewTeam(int teamId)
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
