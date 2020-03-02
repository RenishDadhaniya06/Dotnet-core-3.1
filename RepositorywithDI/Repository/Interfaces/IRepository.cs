using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositorywithDI.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        IList<TEntity>
        SearchFor(Expression<Func<TEntity, bool>> predicate);
        IList<TEntity> GetAll();
        TEntity GetById(Guid id);
    }

    /// <summary>  
    /// A non-instantiable base entity which defines   
    /// members available across all entities.  
    /// </summary>  
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
    }
}
