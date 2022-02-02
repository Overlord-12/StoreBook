using BuisnessObjects.Models;
using System;
using System.Collections.Generic;

namespace BuisnessObjects
{
    public partial class Employee: SqlEntityBase
    {
        public string? Name { get; set; }
        public int Roleid { get; set; }

        public virtual Role Role { get; set; } = null!;
    }
}
