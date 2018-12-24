using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Objects
{
    public class ClassObject
    {
        public ClassObject()
        {
            this.Course = new CourseObject();
            this.Instructor = new InstructorObject();
        }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public CourseObject Course { get; set; }
        public InstructorObject Instructor { get; set; }
    }
}
