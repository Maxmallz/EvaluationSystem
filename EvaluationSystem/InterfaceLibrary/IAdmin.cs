﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface IAdmin:IClass, ICourse, IRubric
    {
        int AddUser<T>(UserObject user)where T: UserObject;
    }
}
