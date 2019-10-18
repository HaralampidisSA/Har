using Har.Domain.Entities;
using Har.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleMvcApp.Data.Repos
{
    public class InMemoryRepository<TEntity, TPrimaryKey> : BaseRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IDictionary<TPrimaryKey, TEntity> _database;

        public InMemoryRepository()
        {
            _database = new Dictionary<TPrimaryKey, TEntity>();
        }

        public override TEntity Add(TEntity entity, bool persist = true)
        {
            _database.Add(entity.Id, entity);
            return entity;
        }

        public override int AddRange(IEnumerable<TEntity> entities, bool persist = true)
        {
            return 0;
        }

        public override void Delete(TEntity entity, bool persist = true)
        {
            _database.Remove(entity.Id);
        }

        public override void Delete(TPrimaryKey id, byte[] timeStamp, bool persist = true)
        {
            _database.Remove(id);
        }

        public override void DeleteRange(IEnumerable<TEntity> entities, bool persist = true)
        {

        }

        public override void Dispose()
        {
            var test = "message";
        }

        public override IQueryable<TEntity> GetAll()
        {
            return _database.Values.AsQueryable();
        }

        public override IQueryable<TEntity> GetAll<TIncludeField>(System.Linq.Expressions.Expression<Func<TEntity, TIncludeField>> include)
        {
            return _database.Values.AsQueryable();
        }

        public override int SaveChanges()
        {
            return 0;
        }

        public override TEntity Update(TEntity entity, bool persist = true)
        {
            return entity;
        }

        public override int UpdateRange(IEnumerable<TEntity> entities, bool persist = true)
        {
            return 0;
        }
    }
}
