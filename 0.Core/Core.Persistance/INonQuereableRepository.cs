using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace Core.Persistance
{
    /// <summary>
    /// This repository is suitable for wrapping connectors of non-relational databases, which may not offer the IQueryable collection.
    /// </summary>
    /// <typeparam name="TEntity">Type of the Entity</typeparam>
    public interface INonQuereableRepository<TEntity>: IRepository where TEntity : IEntity
    {
        #region Query

        IQueryable<TEntity> Query();
        IQueryable<TEntity> Query(int page, int count);
        IQueryable<TEntity> Query(Ordering<TEntity> ordering, int page, int count);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> searchExpression);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> searchExpression,int page, int count);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> searchExpression,
            Ordering<TEntity> ordering,
            int page, 
            int count);

        #endregion Query

        TEntity Get<TKey>(TKey id) where TKey: IComparable, IFormattable;

        Task<TEntity> GetAsync<TKey>(TKey id) where TKey : IComparable, IFormattable;

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        int Count();
    }
}
