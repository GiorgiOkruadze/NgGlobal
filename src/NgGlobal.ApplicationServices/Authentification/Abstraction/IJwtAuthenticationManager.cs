﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Authentication.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(bool status,int userId, string email, string userName,List<string> roles);
    }
}
