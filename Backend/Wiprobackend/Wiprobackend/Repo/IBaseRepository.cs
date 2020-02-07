using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Wiprobackend.Repo
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

    }
}