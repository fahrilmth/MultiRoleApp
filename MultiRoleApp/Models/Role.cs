﻿using System;
using System.Collections.Generic;

namespace MultiRoleApp.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
