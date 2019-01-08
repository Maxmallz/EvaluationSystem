using System.Data;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface ICourse
    {
        int AddCourse(CourseObject course);
        int DeleteCourse(CourseObject course);
        int UpdateCourse(CourseObject course);
        CourseObject ViewCourse(int courseId);
        DataTable GetCourse();
    }
}
