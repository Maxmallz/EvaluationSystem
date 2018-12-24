using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Objects
{
    
    public class InstructorObject: UserObject
    {
        const UserRole _InstructorRole = UserRole.Instructor;
        public InstructorObject():base(_InstructorRole)
        {

        }
    }
}
