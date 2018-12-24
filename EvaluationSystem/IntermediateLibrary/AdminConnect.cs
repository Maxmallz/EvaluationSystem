using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Objects;
using InterfaceLibrary;

namespace IntermediateLibrary
{
    public class AdminConnect : IAdmin
    {
        public int AddClass(ClassObject _class)
        {
            throw new NotImplementedException();
        }
        public int AddCourse(CourseObject course)
        {
            throw new NotImplementedException();
        }
        public int AddRubric(RubricObject rubric)
        {
            throw new NotImplementedException();
        }
        public int AddUser<T>(UserObject user) where T : UserObject
        {
            throw new NotImplementedException();
        }
        public int DeleteClass(ClassObject _class)
        {
            throw new NotImplementedException();
        }
        public int DeleteCourse(CourseObject course)
        {
            throw new NotImplementedException();
        }
        public int DeleteRubric(RubricObject rubric)
        {
            throw new NotImplementedException();
        }
        public int UpdateClass(ClassObject _class)
        {
            throw new NotImplementedException();
        }
        public int UpdateCourse(CourseObject course)
        {
            throw new NotImplementedException();
        }
        public int UpdateRubric(RubricObject rubric)
        {
            throw new NotImplementedException();
        }
        public ClassObject ViewClass(int classId)
        {
            throw new NotImplementedException();
        }
        public CourseObject ViewCourse(int courseId)
        {
            throw new NotImplementedException();
        }
        public RubricObject ViewRubric(int rubricId)
        {
            throw new NotImplementedException();
        }
    }
}
