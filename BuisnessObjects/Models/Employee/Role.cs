using BuisnessObjects.Models;
using System;
using System.Collections.Generic;

namespace BuisnessObjects
{
    public partial class Role: SqlEntityBase
    {
        public string? Rolename { get; set; }
    }
}
