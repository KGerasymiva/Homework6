using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Models;

namespace DAL.UnitOfWork
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);

        void Create(TEntity entity, string createdBy = null);

        void Update(TEntity entity, string modifiedBy = null);

        void Delete(object id);

        void Delete(TEntity entity);
    }
}