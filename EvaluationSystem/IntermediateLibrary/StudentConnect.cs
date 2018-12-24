using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary;
using Models.Objects;

namespace IntermediateLibrary
{
    class StudentConnect : IStudent
    {
        public int AddFeedback(FeedbackObject feedback)
        {
            throw new NotImplementedException();
        }

        public int MakeAssessment(AssessmentObject assessment)
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
