
namespace RepositorywithDI.Repository.Interfaces
{
    using Microsoft.Data.SqlClient;
    #region using
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    #endregion


    /// <summary>
    /// IBaseRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : class
    {
        Task Save();

        Task<List<T>> GetAll();

        Task<T> GetbyId(Guid id);

        Task<List<T>> FindBy(Expression<Func<T, bool>> predicate);
        Task<T> FindOne(Expression<Func<T, bool>> predicate);

        Task<T> Post(T model);

        Task<List<T>> InsertRange(List<T> obj);

        Task<T> Put(T model);

        Task<T> Delete(Guid id);

        Task DeleteRange(List<T> obj);

        Task DeleteWhere(Expression<Func<T, bool>> predicate);

        Task<List<T>> ExecStoreProcedureList(string execCommand, SqlParameter[] sqlParameters = null);

        Task<T> ExecStoreProcedureFirstOrDefault(string execCommand, SqlParameter[] sqlParameters = null);
    }
}
