using Manager.Domain.Entities;

namespace Manager.API.Util.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken();
        public void SetUser(User user);
    }
}
