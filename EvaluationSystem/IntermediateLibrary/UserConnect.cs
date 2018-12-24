using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary;
using Models.Objects;

namespace IntermediateLibrary
{
    public class UserConnect : IUser
    {
        public int Login(string userId, string password)
        {
            throw new NotImplementedException();
        }
        public void Logout(UserObject user)
        {
            throw new NotImplementedException();
        }
    }
}
