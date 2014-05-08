using System;
using System.Linq;
using System.Collections.Generic;
using DiploNet.Diary.DataAccess.Facade;

namespace DiploNet.Diary.Domains.Impl
{
    internal abstract class EntityDomain<T> : IEntityDomain<T>
    {
        protected IRepository<T> Repository { get; set; }

        public EntityDomain(IRepository<T> repository)
        {
            Repository = repository;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Repository.GetAll()
                .ToList();
        }

        public virtual void Save(T entity)
        {
            Repository.Save(entity);
        }

        public virtual void Update(T entity)
        {
            Repository.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            Repository.Delete(entity);
        }
    }
}
