using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreBookWebApi.Models.Employee
{
    public class UserDto
    {
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }
    }
}
