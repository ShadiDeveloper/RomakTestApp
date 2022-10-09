using AuthProject.Repositories;
using AuthProject.Services.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AuthProject.Services.UserServices
{
    public interface IUserService
    {
        Task<TokenDTO> LoginAsync(LoginDTO model);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _config;

        public UserService(
            IUserRepository repository,
            IConfiguration config)
        {
            this._repository = repository;
            this._config = config;
        }
        public async Task<TokenDTO> LoginAsync(LoginDTO model)
        {
            var user = await _repository.CheckUserAsync(model.UserName, model.Password);
            if(user is false)
            {
                throw new Exception("User not found !!!");
            }

            return new TokenDTO
            {
                Token = GenerateToken()
            };
        }

        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            DateTime expireTime = DateTime.Now.AddMinutes(Convert.ToInt32( _config["Jwt:TokenExpireMinutes"]));

            var token = new JwtSecurityToken(
               issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            expires: expireTime,
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
