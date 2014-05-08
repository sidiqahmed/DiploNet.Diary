using System;
using System.Linq;
using System.Linq.Expressions;
using DiploNet.Diary.BusinessObject;
using DiploNet.Diary.DataAccess.Facade;
using NHibernate;
using NHibernate.Linq;

namespace DiploNet.Diary.DataAccess.FNHibernate
{
    internal class Repository<T> : IRepository<T>
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> GetAll()
        {
            return _session.Query<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> wherePredicate)
        {
            return this.GetAll().Where(wherePredicate);
        }

        public void Save(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
