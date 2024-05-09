using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Utitlities
{
    public static class Roles
    {
        public enum RoleType
        {
            SuperAdmin,
            Admin,
            Employee,
            Individual,
            Company
        }

        public static List<RoleType> GetAllRoles { get; set; } = new List<RoleType>
        {
            RoleType.SuperAdmin,
            RoleType.Admin,
            RoleType.Employee,
            RoleType.Individual,
            RoleType.Company
        };
    }
}
