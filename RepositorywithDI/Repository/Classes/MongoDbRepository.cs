using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using RepositorywithDI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositorywithDI.Repository.Classes
{
    public class MongoDbRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private MongoDatabase database;
        private MongoCollection<TEntity> collection;
        public MongoDbRepository()
        {
            GetDatabase();
            GetCollection();
        }

        public bool Insert(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            return collection.Insert(entity).DocumentsAffected > 0;
        }

        public bool Update(TEntity entity)
        {
            if (entity.Id == null)
                return Insert(entity);

            return collection
            .Save(entity)
            .DocumentsAffected > 0;
        }

        public bool Delete(TEntity entity)
        {
            return collection
            .Remove(Query.EQ("_id", entity.Id))
            .DocumentsAffected > 0;
        }

        public IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return collection
            .AsQueryable<TEntity>()
            .Where(predicate.Compile())
            .ToList();
        }

        public IList<TEntity> GetAll()
        {
            return collection.FindAllAs<TEntity>().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return collection.FindOneByIdAs<TEntity>(id);
        }

        #region Private Helper Methods  
        private void GetDatabase()
        {
            var client = new MongoClient(GetConnectionString());
            var server = client.GetServer();

            database = server.GetDatabase(GetDatabaseName());
        }

        private string GetConnectionString()
        {
            return "";
        }

        private string GetDatabaseName()
        {
            return "PMS";
        }

        private void GetCollection()
        {
            collection = database
            .GetCollection<TEntity>(typeof(TEntity).Name);
        }
        #endregion
    }
}
