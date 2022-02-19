using System.ComponentModel.DataAnnotations;

namespace AuthStoreBook.Models
{
    public class UserDto
    {
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string? Email { get; set; }
        public int RoleId { get; set; }
    }
}
