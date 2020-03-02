
namespace RepositorywithDI.Repository.Classes
{
    using Microsoft.Data.SqlClient;
    #region Using
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
        private DatabaseContext dbcontext;
        private DbSet<T> entity;
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                entity.Remove(await entity.FindAsync(id));
                await Save();
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
