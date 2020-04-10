using ComplaintApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApp.API.Service
{
    public interface IUserService
    {
        DataTransfer<List<User>> GetAllUser();
        DataTransfer<User> UserLogin(string userName, string password);
    }
}
