using ComplaintApp.API.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintApp.API.Service
{
    public class AuthService : IAuthService
    {
        private IConfiguration _configuration;
        private readonly string appSettings = "AppSettings";

        public AuthService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string CreateToken(User model)
        {
            var claims = new Claim[]
                   {
                            new Claim("UserId",model.UserId.ToString()) ,
                            new Claim("UserName",model.UserName)
                   };
            var SymetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                      (
                          _configuration["Jwt:Key"]
                      ));

            var SignInCredentials = new SigningCredentials(SymetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var JWTSecurityToken = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["Jwt:Hour"])),
                    signingCredentials: SignInCredentials,
                    claims: claims
                );

            return new JwtSecurityTokenHandler().WriteToken(JWTSecurityToken);
        }
    }
}
