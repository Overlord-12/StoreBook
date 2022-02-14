using BusinessObjects.Models;
using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Role: SqlEntityBase
    {
        public string? Rolename { get; set; }
    }
}
