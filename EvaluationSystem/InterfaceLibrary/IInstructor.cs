using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface IInstructor:ITeam, IAssessment, IReport,ICriterion
    {
        int AssignStudentToTeam(List<StudentObject> students, TeamObject team);
    }
}
