using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Objects
{
    public class StudentObject:UserObject
    {
        const UserRole _studentRole = UserRole.Student;
        public StudentObject()
        {
            base.userRole = _studentRole;
        }
        public List<ClassObject> _Class { get; set; }
        public List<TeamObject> Team { get; set; }
        public List<AssessmentObject> Assessment { get; set; }
        public List<CourseObject> Course { get; set; }
        public List<FeedbackObject> Feedback { get; set; }
    }
}
