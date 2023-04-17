using Manager.Domain.Entities;
using Manager.Services.DTO;
using System.Security.Claims;


namespace Manager.Services.Extension
{
    public static class UserClaimsExtension
    {

        public static IEnumerable<Claim> GetClaims (this User user) => new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim (ClaimTypes.Authentication, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),

        };

    }
}
