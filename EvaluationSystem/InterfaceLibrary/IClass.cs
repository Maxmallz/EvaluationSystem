using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface IClass
    {
        int AddClass(ClassObject _class);
        int DeleteClass(ClassObject _class);
        int UpdateClass(ClassObject _class);
        ClassObject ViewClass(int classId);
    }
}
