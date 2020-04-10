using ComplaintApp.API.Model;
using ComplaintApp.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApp.API.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UserService(IUserRepository userRepository
            , IAuthService authService
           )
        {
            _userRepository = userRepository;
            _authService = authService;
    }

        public DataTransfer<List<User>> GetAllUser()
        {
            var userList = new List<User>();
            try
            {
                userList = _userRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return Response.GetFailedResponse(userList, ex.Message);
            }

            if (userList.Count > 0)
            {
                return Response.GetSuccessResponse(userList, "Success.");
            }
            else
            {
                return Response.GetNotFoundResponse(userList, "Error.");
            }



        }

        public DataTransfer<User> UserLogin(string userName, string password)
        {

            var user = new User();

            try
            {
                user = _userRepository.GetLoginCredentials(userName, password);
            }
            catch (Exception ex)
            {
                return Response.GetFailedResponse(user, ex.Message);
            }

            if (user?.UserId > 0)
            {
                return Response.GetSuccessResponse(user, "Success.",_authService.CreateToken(user));
            }
            else
            {
                return Response.GetNotFoundResponse(user, "Error.");
            }
        }
    }
}
