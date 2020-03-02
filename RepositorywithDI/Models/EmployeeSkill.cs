using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorywithDI.Models
{
    public class EmployeeSkill
    {
        public Guid Id { get; set; }
        public Guid SkillId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
