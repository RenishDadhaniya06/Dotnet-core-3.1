using RepositorywithDI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorywithDI.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> Get(int take, int skip);

        Task<List<Employee>> Get();

        Task<Employee> Get(Guid id);
        Task<int> GetCount();

        Task<Employee> Insert(Employee model);

        Task<Employee> Update(Employee model);

        Task<Employee> Delete(Guid id);
    }
}
