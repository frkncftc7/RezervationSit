using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public class Enums
    {
        public enum PostState
        {
            Draft = 0,
            Published = 1,
            Deleted = 2
        }
        public enum UserRole
        {
            User = 1,
            Admin = 2
        }
    }
}
