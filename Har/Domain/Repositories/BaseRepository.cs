using Har.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Har.Domain.Repositories
{
    public abstract class BaseRepository<TEntity> : BaseRepository<TEntity, int> where TEntity : class, IEntity<int>
    {
    }

    public abstract class BaseRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        public virtual int Count => GetAll().Count();

        public virtual bool Any()
        {
            return GetAll().Any();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> where)
        {
            return GetAll().Any(where);
        }

        public virtual TEntity Find(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Find<TIncludeField>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TIncludeField>> include)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity FirstOrDefault()
        {
            return GetAll().FirstOrDefault();
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where)
        {
            return GetAll().FirstOrDefault(where);
        }

        public virtual TEntity FirstOrDefault<TIncludeField>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TIncludeField>> include)
        {
            return GetAll(include).Where(where).FirstOrDefault();
        }

        public abstract IQueryable<TEntity> GetAll();

        public abstract IQueryable<TEntity> GetAll<TIncludeField>(Expression<Func<TEntity, TIncludeField>> include);

        public virtual IQueryable<TEntity> GetAll<TSortField>(Expression<Func<TEntity, TSortField>> orderBy, bool ascending)
        {
            return ascending ? GetAll().OrderBy(orderBy) : GetAll().OrderByDescending(orderBy);
        }

        public virtual IQueryable<TEntity> GetAll<TIncludeField, TSortField>(Expression<Func<TEntity, TIncludeField>> include, Expression<Func<TEntity, TSortField>> orderBy, bool ascending)
        {
            return ascending ? GetAll(include).OrderBy(orderBy) : GetAll(include).OrderByDescending(orderBy);
        }

        public virtual IQueryable<TEntity> GetRange(int skip, int take)
        {
            return GetRange(GetAll(), skip, take);
        }

        public virtual IQueryable<TEntity> GetRange(IQueryable<TEntity> query, int skip, int take)
        {
            return query.Skip(skip).Take(take);
        }

        public virtual IQueryable<TEntity> GetSome(Expression<Func<TEntity, bool>> where)
        {
            return GetAll().Where(where);
        }

        public virtual IQueryable<TEntity> GetSome<TIncludeField>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TIncludeField>> include)
        {
            return GetAll(include).Where(where);
        }

        public virtual IQueryable<TEntity> GetSome<TSortField>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TSortField>> orderBy, bool ascending)
        {
            return GetAll(orderBy, ascending).Where(where);
        }

        public virtual IQueryable<TEntity> GetSome<TIncludeField, TSortField>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TIncludeField>> include, Expression<Func<TEntity, TSortField>> orderBy, bool ascending = true)
        {
            return GetAll(include, orderBy, ascending).Where(where);
        }

        public abstract TEntity Add(TEntity entity, bool persist = true);

        public virtual TPrimaryKey AddAndGetId(TEntity entity, bool persist = true)
        {
            return Add(entity).Id;
        }

        public abstract int AddRange(IEnumerable<TEntity> entities, bool persist = true);

        public abstract TEntity Update(TEntity entity, bool persist = true);

        public virtual TPrimaryKey UpdateAndGetId(TEntity entity, bool persist = true)
        {
            return Update(entity).Id;
        }

        public abstract int UpdateRange(IEnumerable<TEntity> entities, bool persist = true);

        public abstract void Delete(TEntity entity, bool persist = true);

        public abstract void DeleteRange(IEnumerable<TEntity> entities, bool persist = true);

        public abstract void Delete(TPrimaryKey id, byte[] timeStamp, bool persist = true);

        public abstract int SaveChanges();
        public abstract void Dispose();
    }
}