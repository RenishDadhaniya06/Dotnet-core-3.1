using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorywithDI.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
    }
}
