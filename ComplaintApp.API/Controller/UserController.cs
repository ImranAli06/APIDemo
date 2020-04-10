using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComplaintApp.API.Model;
using ComplaintApp.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("getAllUser")]
        public IActionResult getAllUser()
        {
            if (_userService == null)
                return BadRequest();

            return Ok(_userService.GetAllUser());
        }

        [AllowAnonymous]
        [HttpGet("UserLogin/{userName}/{password}")]
        public IActionResult UserLogin(string userName, string password)
        {
            if (_userService == null)
                return BadRequest();

            return Ok(_userService.UserLogin(userName, password));
        }
    }
}