using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorywithDI.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string OtherContact { get; set; }
        public string CurrentSalary { get; set; }
        public string LeaveBalance { get; set; }
        public bool IsDelete { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid RoleId { get; set; }
    }
}
