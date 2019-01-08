using System.Data;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface IClass
    {
        int AddClass(ClassObject _class);
        int DeleteClass(ClassObject _class);
        int UpdateClass(ClassObject _class);
        ClassObject ViewClass(int classId);
        DataTable GetClasses();
    }
}
