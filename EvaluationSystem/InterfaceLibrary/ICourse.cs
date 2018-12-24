using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface ICourse
    {
        int AddCourse(CourseObject course);
        int DeleteCourse(CourseObject course);
        int UpdateCourse(CourseObject course);
        CourseObject ViewCourse(int courseId);
    }
}
