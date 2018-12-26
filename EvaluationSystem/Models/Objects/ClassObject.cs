using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Objects
{
    public class ClassObject
    {
        private int _classId;
        private InstructorObject _instructor;
        private CourseObject _course;
        private string _className;

        public ClassObject()
        {
            this.Course = new CourseObject();
            this.Instructor = new InstructorObject();
        }
        public int ClassId { get => _classId; set => _classId = value; }
        public string ClassName { get => _className; set => _className = value; }
        public CourseObject Course { get => _course; set => _course = value; }
        public InstructorObject Instructor { get => _instructor; set => _instructor = value; }
    }
}
