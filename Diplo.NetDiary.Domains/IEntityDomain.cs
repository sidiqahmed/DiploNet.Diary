using System.Collections.Generic;

namespace DiploNet.Diary.Domains
{
    public interface IEntityDomain<T>
    {
        IEnumerable<T> GetAll();
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
