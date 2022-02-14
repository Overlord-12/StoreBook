using BusinessObjects.Models;
using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class User: SqlEntityBase
    {
        public string? Name { get; set; }
        public int Roleid { get; set; }
        public string Password { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
    }
}
