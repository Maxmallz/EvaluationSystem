using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;
using Models.Objects;

namespace Models.Objects
{
    public class UserObject
    {
        public enum UserRole { Admin, Instructor, Student}
        public UserObject()
        {
            
        }
        
        public string UserId { get; set; }
        public string Password { get; set; }
        public UserRole userRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
