
namespace RepositorywithDI.Services
{
    #region Using
    using RepositorywithDI.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion


    /// <summary>
    /// IUserService
    /// </summary>
    public interface IService<T> where T : class
    {
        Task<List<T>> Get(int take, int skip);

        Task<List<T>> Get();

        Task<T> Get(Guid id);

        Task<T> Insert(T model);

        Task<T> Update(T model);

        Task<T> Delete(Guid id);
    }
}
