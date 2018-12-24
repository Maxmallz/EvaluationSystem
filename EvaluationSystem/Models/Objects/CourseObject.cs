using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Objects
{
    public class CourseObject
    {
        private string _courseName;
        private int _courseId;

        public int CourseId { get => _courseId; set => _courseId = value; }
        public string CourseName { get => _courseName; set => _courseName = value; }
    }
}
