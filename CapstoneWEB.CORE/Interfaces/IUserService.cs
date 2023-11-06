using CapstoneWEB.CORE.DTOs;

namespace CapstoneWEB.CORE.Interfaces
{
    public interface IUserService
    {
        Task<UserAuthenticationDTO> SignIn(UserLoginDTO usersLoginDTO);
        Task<bool> SignUp(UserRegisterDTO userRegisterDTO);
    }
}
