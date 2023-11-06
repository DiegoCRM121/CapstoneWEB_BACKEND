using CapstoneWEB.CORE.DTOs;
using CapstoneWEB.CORE.Interfaces;
using CapstoneWEB.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneWEB.CORE.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jwtService;

        public UserService(IUserRepository userRepository, IJWTService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<UserAuthenticationDTO> SignIn(UserLoginDTO usersLoginDTO)
        {
            var user = await _userRepository.SignIn(usersLoginDTO);

            if (user == null)
                return null;

            var token = _jwtService.GenerateJWToken(user);

            var userDTO = new UserAuthenticationDTO();
            userDTO.IdUser = user.IdUser;
            userDTO.FirstName = user.FirstName;
            userDTO.SecondName = user.SecondName;
            userDTO.Email = user.Email;
            userDTO.Address = user.Address;
            userDTO.Country = user.Country;
            userDTO.BirthDate = user.BirthDate;
            userDTO.Token = token;

            return userDTO;

        }

        public async Task<bool> SignUp(UserRegisterDTO userRegisterDTO)
        {
            var exists = await _userRepository.ExistsEmail(userRegisterDTO.Email);
            if (exists) return false;

            var user = new User()
            {
                FirstName = userRegisterDTO.FirstName,
                SecondName = userRegisterDTO.SecondName,
                Email = userRegisterDTO.Email,
                Address = userRegisterDTO.Address,
                Country = userRegisterDTO.Country,
                Password = userRegisterDTO.Password,
                BirthDate = userRegisterDTO.BirthDate,
                IsActive = 1,
            };


            var result = await _userRepository.SignUp(user);
            return result;
        }
    }
}
