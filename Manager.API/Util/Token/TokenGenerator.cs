using Manager.Domain.Entities;
using Manager.Services.DTO;
using Manager.Services.Extension;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Manager.API.Util.Token
{
    public class TokenGenerator : ITokenGenerator
    {

        private readonly IConfiguration _configuration;
        private User _user;
        private readonly SymmetricSecurityKey _key;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

        }

        public void SetUser(User user)
        {
            _user = user;
        }

        public string GenerateToken()
        {
            var tokemHandle = new JwtSecurityTokenHandler();
            var claims = _user.GetClaims();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"])),

                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokemHandle.CreateToken(tokenDescriptor);

            return tokemHandle.WriteToken(token);
            
        }
    }
}
