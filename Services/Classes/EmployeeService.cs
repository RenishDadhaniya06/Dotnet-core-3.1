using RepositorywithDI.Extension;
using RepositorywithDI.Models;
using RepositorywithDI.Repository.Interfaces;
using RepositorywithDI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RepositorywithDI.Services.Classes
{
    public class EmployeeService : IEmployeeService
    {


        #region Properties
        private readonly IBaseRepository<Employee> _repository;
        private readonly IStoreProcedureService _spSerevice;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Employeeervice"/> class.
        /// </summary>
        /// <param name="employeerepository">The employeerepository.</param>
        /// <param name="spSerevice">The sp serevice.</param>
        public EmployeeService(IBaseRepository<Employee> repository, IStoreProcedureService spSerevice)
        {
            _repository = repository;
            _spSerevice = spSerevice;
        }

        /// <summary>
        /// Gets the Employee.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> Get(int take,int skip)
        {
            try
            {
                var employee = await _repository.FindBy(_=>_.IsDelete == false);
                return employee.AsEnumerable().WithoutPasswords().Take(take).Skip(skip).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the Employee.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> Get()
        {
            try
            {
                var employee = await _repository.FindBy(_ => _.IsDelete == false);
                return employee.AsEnumerable().WithoutPasswords().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Employee> Get(Guid id)
        {
            try
            {
                var employee = await _repository.GetbyId(id);
                return employee.WithoutPassword();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserts the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<Employee> Insert(Employee model)
        {
            try
            {

                model.Password = ExtensionMethods.Encrypt(model.Password);
                model.IsDelete = false;
                var employee = await _repository.Post(model);
                return employee.WithoutPassword();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<Employee> Update(Employee model)
        {
            try
            {
                var employee = await _repository.Put(model);
                return employee.WithoutPassword();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task<Employee> Delete(Guid id)
        {
            try
            {
                var employee = await _repository.Delete(id);
                return employee.WithoutPassword();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
