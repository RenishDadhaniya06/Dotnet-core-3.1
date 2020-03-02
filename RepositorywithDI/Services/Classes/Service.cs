
namespace RepositorywithDI.Services
{
    #region using
    using RepositorywithDI.Extension;
    using RepositorywithDI.Models;
    using RepositorywithDI.Repository.Interfaces;
    using RepositorywithDI.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    #endregion


    /// <summary>
    /// UserService
    /// </summary>
    /// <seealso cref="RepositorywithDI.Services.IUserService" />
    public class Service<T> : IService<T> where T : class
    {
        #region Properties
        private readonly IBaseRepository<T> _userrepository;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userrepository">The userrepository.</param>
        /// <param name="spSerevice">The sp serevice.</param>
        public Service(IBaseRepository<T> userrepository)
        {
            _userrepository = userrepository;
          
        }

        /// <summary>
        /// Gets the Employee.
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> Get(int take, int skip)
        {
            try
            {
                var employee = await _userrepository.GetAll();
                return employee.Skip(skip).Take(take).ToList();
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
        public async Task<List<T>> Get()
        {
            try
            {
                var employee = await _userrepository.GetAll();
                return employee.ToList();
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
        public async Task<T> Get(Guid id)
        {
            try
            {
                var employee = await _userrepository.GetbyId(id);
                return employee;
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
        public async Task<T> Insert(T model)
        {
            try
            {

         
                var employee = await _userrepository.Post(model);
                return employee;

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
        public async Task<T> Update(T model)
        {
            try
            {
                var employee = await _userrepository.Put(model);
                return employee;
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
        public async Task<T> Delete(Guid id)
        {
            try
            {
                var employee = await _userrepository.Delete(id);
                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
