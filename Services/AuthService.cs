using Microsoft.IdentityModel.Tokens;
using MyBussSiteAPIs.Context;
using MyBussSiteAPIs.Interfaces;
using MyBussSiteAPIs.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyBussSiteAPIs.Services
{
    public class AuthService : IAuthService
    {
        private readonly dbContext _dbContext;
        private readonly IConfiguration _configuration;
        public AuthService(dbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public Register AddUser(Register register)
        {
            var addUser = _dbContext.Add(register);
            _dbContext.SaveChanges();
            return addUser.Entity;
        }

        public Register GetAllUserById(int id)
        {
            var getUser = _dbContext.registers.SingleOrDefault(s => s.Id == id);
            return getUser;
        }

        public List<Register> GetAllUsers()
        {
            var list = _dbContext.registers.ToList();
            return list;
        }

        public string Login(LoginRequest loginRequest)
        {
            if(loginRequest.Email != null && loginRequest.Password != null)
            {
                var user = _dbContext.registers.SingleOrDefault(s => s.Email == loginRequest.Email && s.Password == loginRequest.Password);
                if(user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.Name),
                        new Claim("Email", user.Email),
                        new Claim(ClaimTypes.Role, user.Role) // Add role claim 
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(20),
                        signingCredentials: signIn);

                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                    // File Logs of successful login users
                    LogUserLogin(user.Name,user.Email,user.Password,user.Role);

                    return jwtToken;
                }
                else
                {
                    throw new Exception("User is not valid!");
                }
            }
            else
            {
                throw new Exception("Credientials are not valid!");
            }

        }

        public Register UpdateUser(Register register)
        {
            var updateUser = _dbContext.registers.Update(register);
            _dbContext.SaveChanges();
            return updateUser.Entity;
        }

        private void LogUserLogin(string name, string email, string password, string role)
        {
            var loginInfo = new UserLoginInfo
            {
                Name = name,
                Email = email,
                Password = password,
                Role = role,
                LoginTime = DateTime.UtcNow
            };

            _dbContext.userLoginInfos.Add(loginInfo);
            _dbContext.SaveChanges();
        }
    }
}
