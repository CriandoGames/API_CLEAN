using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Manager.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        private readonly ManagerContext _context;

        public UserRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
           var user = await _context.Users.
                           Where(x => x.Email.ToLower() == email.ToLower()).AsNoTracking().ToListAsync();

            return user.FirstOrDefault();
        }

        public async Task<IList<User>> SearchByEmail(string email)
        {
            
            var allUser = await _context.Users
                        .Where(
                                x => x.Email.ToLower() == email.ToLower()
                        ).AsNoTracking().ToListAsync();

            return allUser;

        }

        public async Task<IList<User>> SearchByName(string name)
        {
            var allUser = await _context.Users
                       .Where(
                               x => x.Name.ToLower() == name.ToLower()
                       ).AsNoTracking().ToListAsync();

            return allUser;
        }
    }
}
