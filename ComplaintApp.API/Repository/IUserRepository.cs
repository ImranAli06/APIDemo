﻿using ComplaintApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApp.API.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
         User GetLoginCredentials(string UserName, string Password);
    }
}
