using System;
using System.Collections.Generic;

namespace BuisnessObjects
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Roleid { get; set; }

        public virtual Role Role { get; set; } = null!;
    }
}
