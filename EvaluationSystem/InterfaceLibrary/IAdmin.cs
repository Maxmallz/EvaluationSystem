using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface IAdmin:IClass, ICourse, IRubric
    {
        int AddUser<T>(T user)where T: UserObject;
        int DeleteUser<T>(T user) where T : UserObject;
        int UpdateUser<T>(T user) where T : UserObject;
        UserObject ViewUser(string userId, UserObject.UserRole userRole);
        DataTable GetStudents();
        DataTable GetInstructors();
    }
}
