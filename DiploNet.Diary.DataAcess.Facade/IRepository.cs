using System;
using System.Linq;
using System.Linq.Expressions;

namespace DiploNet.Diary.DataAccess.Facade
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> wherePredicate);
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
