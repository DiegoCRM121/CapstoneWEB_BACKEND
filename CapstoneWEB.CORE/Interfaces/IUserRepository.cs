using CapstoneWEB.CORE.DTOs;
using CapstoneWEB.CORE.Entities;

namespace CapstoneWEB.CORE.Interfaces
{
    public interface IUserRepository
    {
        Task<User> SignIn(UserLoginDTO usersLoginDTO);
        Task<bool> SignUp(User user);
        Task<User> GetById(int id);
        Task<bool> ExistsEmail(string email);
    }
}
