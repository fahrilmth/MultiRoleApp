using MultiRoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRoleApp
{
    public static class Session
    {
        public static User? User { get; set; } = null;
    }
}
