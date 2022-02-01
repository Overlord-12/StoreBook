using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreBookWebApi.Models.Employee
{
    public class EmployeeDto
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int RoleId { get; set; }
        public RoleDto? Role { get; set; }
    }
}
