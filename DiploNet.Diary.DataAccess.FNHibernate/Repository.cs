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

        public T Get(object id)
        {
            return _session.Get<T>(id);
        }

        public void Save(T entity)
        {
            _session.Save(entity);
        }

        public void Update(T entity)
        {
            _session.Update(entity);
        }

        public void Delete(T entity)
        {
            _session.Delete(entity);
        }
    }
}
