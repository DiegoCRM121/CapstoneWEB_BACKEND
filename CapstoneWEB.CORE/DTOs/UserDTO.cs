using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneWEB.CORE.DTOs
{
    public class UserDTO
    {
        public int IdUser { get; set; }

        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Country { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public int? IsActive { get; set; }
    }

    public class UserLoginDTO
    {
        public string? Email { get; set; }

        public string? Password { get; set; }
    }

    public class UserRegisterDTO
    {
        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Country { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }

    public class UserAuthenticationDTO 
    {
        public int IdUser { get; set; }

        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Country { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Token { get; set; }
    }
}
