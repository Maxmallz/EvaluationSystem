using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface IUser
    {
        UserObject.UserRole Login(string userId, string password, out string errorMsg);
        void Logout(UserObject user);
    }
}
