using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreBookWebApi.Models.Employee
{
    public class EmployeeDto
    {
        public string Password { get; set; } = null!;
        public string? Name { get; set; }
        public int RoleId { get; set; }
    }
}
