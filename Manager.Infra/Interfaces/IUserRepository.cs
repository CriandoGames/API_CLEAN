using Manager.Domain.Entities;
namespace Manager.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<IList<User>> SearchByEmail(string email);
        Task<IList<User>> SearchByName(string name);
    }
}
