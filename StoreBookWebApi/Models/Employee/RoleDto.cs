using System.ComponentModel.DataAnnotations;

namespace StoreBookWebApi.Models.Employee
{
    public class RoleDto
    {
        [Key]
        public int Id { get; set; }
        public string? RoleName { get; set; }
    }
}
