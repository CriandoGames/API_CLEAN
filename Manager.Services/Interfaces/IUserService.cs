using Manager.Services.DTO;


namespace Manager.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserOutputDTO> Create(UserCreateDTO entity);
        Task<UserOutputDTO> Update(UserOutputDTO entity);
        Task Delete(Guid id);
        Task<UserOutputDTO> Get(Guid id);
        Task<IEnumerable<UserOutputDTO>> GetAll();
        Task<UserOutputDTO> GetByEmail(string email);
        Task<IList<UserOutputDTO>> SearchByEmail(string email);
        Task<IList<UserOutputDTO>> SearchByName(string name);
    }
}
