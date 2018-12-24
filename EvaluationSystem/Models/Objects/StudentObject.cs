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
        public StudentObject():base(_studentRole)
        {

        }
    }
}
