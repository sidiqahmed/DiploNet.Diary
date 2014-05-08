using System;

namespace DiploNet.Diary.DataAccess.Facade
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();

        IRepository<T> CreateRepository<T>();
    }
}
