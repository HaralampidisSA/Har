using Har.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Har.Domain.Repositories
{
    public interface IRepository : IDisposable
    {
    }

    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    {

    }

    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : class, IEntity<TPrimaryKey>
    {
        int Count { get; }

        bool Any();

        bool Any(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll<TIncludeField>(Expression<Func<TEntity, TIncludeField>> include);

        IQueryable<TEntity> GetAll<TSortField>(Expression<Func<TEntity, TSortField>> orderBy, bool ascending);

        IQueryable<TEntity> GetAll<TIncludeField, TSortField>(
            Expression<Func<TEntity, TIncludeField>> include,
            Expression<Func<TEntity, TSortField>> orderBy, bool ascending);

        IQueryable<TEntity> GetSome(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> GetSome<TIncludeField>(
            Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TIncludeField>> include);

        IQueryable<TEntity> GetSome<TSortField>(
            Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TSortField>> orderBy, bool ascending);

        IQueryable<TEntity> GetSome<TIncludeField, TSortField>(
            Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TIncludeField>> include,
            Expression<Func<TEntity, TSortField>> orderBy, bool ascending = true);

        IQueryable<TEntity> GetRange(int skip, int take);

        IQueryable<TEntity> GetRange(IQueryable<TEntity> query, int skip, int take);

        TEntity FirstOrDefault();

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where);

        TEntity FirstOrDefault<TIncludeField>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TIncludeField>> include);

        TEntity Find(TPrimaryKey id);

        TEntity Find(Expression<Func<TEntity, bool>> where);

        TEntity Find<TIncludeField>(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TIncludeField>> include);

        TEntity Add(TEntity entity, bool persist = true);

        TPrimaryKey AddAndGetId(TEntity entity, bool persist = true);

        int AddRange(IEnumerable<TEntity> entities, bool persist = true);

        TEntity Update(TEntity entity, bool persist = true);

        TPrimaryKey UpdateAndGetId(TEntity entity, bool persist = true);

        int UpdateRange(IEnumerable<TEntity> entities, bool persist = true);

        void Delete(TEntity entity, bool persist = true);

        void DeleteRange(IEnumerable<TEntity> entities, bool persist = true);

        void Delete(TPrimaryKey id, byte[] timeStamp, bool persist = true);

        int SaveChanges();
    }
}
