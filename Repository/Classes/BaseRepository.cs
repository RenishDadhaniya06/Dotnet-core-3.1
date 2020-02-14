
namespace RepositorywithDI.Repository.Classes
{

    #region Using
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using RepositorywithDI.DBContext;
    using RepositorywithDI.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    #endregion


    /// <summary>
    /// BaseRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="RepositorywithDI.Repository.Interfaces.IBaseRepository{T}" />
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Properties
        private readonly DatabaseContext dbcontext;
        private readonly DbSet<T> entity;
        #endregion


        public BaseRepository(DatabaseContext databaseContext)
        {
            dbcontext = databaseContext;
            entity = dbcontext.Set<T>();
        }

        public async Task Save()
        {
            try
            {
                await dbcontext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                return await entity.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetbyId(Guid id)
        {
            try
            {
                return await entity.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var data = await entity.Where(predicate).ToListAsync();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> FindOne(Expression<Func<T, bool>> predicate)
         {
            try
            {
                var data = await entity.FirstOrDefaultAsync(predicate);
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> Post(T model)
        {
            try
            {
                entity.Add(model);
                await Save();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> InsertRange(List<T> obj)
        {
            try
            {
                entity.AddRange(obj);
                await Save();
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> Put(T model)
        {
            try
            {
                dbcontext.Entry(model).State = EntityState.Modified;
                await Save();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> Delete(Guid id)
        {
            try
            {
                var entityOne = await entity.FindAsync(id);
                entity.Remove(entityOne);
                await Save();
                return entityOne;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteRange(List<T> obj)
        {
            try
            {
                entity.RemoveRange(obj);
                await Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var data = entity.Where(predicate);
                entity.RemoveRange(data);
                await Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> ExecStoreProcedureList(string execCommand, SqlParameter[] sqlParameters = null)
        {
            if(sqlParameters == null)
            {
                return await entity.FromSqlRaw(execCommand).ToListAsync();
            }
            else
            {
                return await entity.FromSqlRaw(execCommand, sqlParameters).ToListAsync();
            }
        }

        public async Task<T> ExecStoreProcedureFirstOrDefault(string execCommand, SqlParameter[] sqlParameters = null)
        {
            if (sqlParameters == null)
            {
                return await entity.FromSqlRaw(execCommand).FirstOrDefaultAsync();
            }
            else
            {
                return await entity.FromSqlRaw(execCommand, sqlParameters).FirstOrDefaultAsync();
            }
        }

    }
}
