using CapstoneWEB.CORE.DTOs;
using CapstoneWEB.CORE.Interfaces;
using CapstoneWEB.CORE.Entities;
using CapstoneWEB.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace CapstoneWEB.INFRASTRUCTURE.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CapstoneDbContext _dbContext;

        public UserRepository(CapstoneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> SignIn(UserLoginDTO usersLoginDTO)
        {
            var result = await _dbContext
                .User
                .Where(z => z.Email == usersLoginDTO.Email
                        && z.Password == usersLoginDTO.Password)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> SignUp(User user)
        {
            await _dbContext.User.AddAsync(user);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.User.FindAsync(id);
        }

        public async Task<bool> ExistsEmail(string email)
        {
            return await _dbContext.User.Where(x => x.Email == email).AnyAsync();
        }
    }
}
