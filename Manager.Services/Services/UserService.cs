using AutoMapper;
using Manager.Core;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {


        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<UserOutputDTO> Create(UserCreateDTO entity)
        {
            var userExist = await _repository.GetByEmailAsync(entity.Email);

            if(userExist != null) {
                throw new DomainException("Já existe um usuário cadastrado com email informado");
            }

            var user = _mapper.Map<User>(entity);
            user.Validate();

            var userCreate = await _repository.CreateAsync(user);

            return _mapper.Map<UserOutputDTO>(userCreate);


        }

        public async Task Delete(Guid id)
        {
            var userExist = await _repository.GetByIdAsync(id);

            if (userExist == null)
            {
                throw new DomainException("Já existe um usuário cadastrado com email informado");
            }

            await _repository.DeleteAsync(id);
        }

        public async Task<UserOutputDTO> Get(Guid id)
        {
            var userExist = await _repository.GetByIdAsync(id);

            if (userExist == null)
            {
                throw new DomainException("Usuário não cadastrado");
            }

            return _mapper.Map<UserOutputDTO>(userExist);
        }

        public async Task<IEnumerable<UserOutputDTO>> GetAll()
        {
            var allUser = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserOutputDTO>>(allUser);
        }

        public async Task<UserOutputDTO> GetByEmail(string email)
        {
            var userExist = await _repository.GetByEmailAsync(email);

            if (userExist == null)
            {
                throw new DomainException("Usuário não cadastrado");
            }

            return _mapper.Map<UserOutputDTO>(userExist);
        }

        public async Task<IList<UserOutputDTO>> SearchByEmail(string email)
        {
            var userExist = await _repository.SearchByEmail(email);

            return _mapper.Map<IList<UserOutputDTO>>(userExist);
        }

        public async Task<IList<UserOutputDTO>> SearchByName(string name)
        {
            var userExist = await _repository.SearchByName(name);

            return _mapper.Map<IList<UserOutputDTO>>(userExist);
        }

        public async Task<UserOutputDTO> Update(UserOutputDTO entity)
        {
            var userExist = await _repository.GetByEmailAsync(entity.Email);

            if (userExist != null)
            {
                throw new DomainException("Não existe um usuário cadastrado com o Email informado!");
            }

            var user = _mapper.Map<User>(entity);
            user.Validate();

            var userUpdate = await _repository.UpdateAsync(user);

            return _mapper.Map<UserOutputDTO>(userUpdate);
        }
    }
}
