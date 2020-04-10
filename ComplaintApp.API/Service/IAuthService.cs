using ComplaintApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApp.API.Service
{
    public interface IAuthService
    {
        string CreateToken(User model);
    }
}
