using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorywithDI.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public bool IsDelete { get; set; }
        public bool IsSuperAdmin { get; set; }
        public Guid RoleId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
