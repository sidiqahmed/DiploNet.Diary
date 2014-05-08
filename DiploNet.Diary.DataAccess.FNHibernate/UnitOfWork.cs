using System;
using System.Data;
using DiploNet.Diary.DataAccess.Facade;
using NHibernate;
using Ninject;

namespace DiploNet.Diary.DataAccess.FNHibernate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IKernel _kernel;
        private readonly ITransaction _transaction;
        
        private readonly ISession _session;

        public UnitOfWork(ISession session)
        {
            // Kernel
            _kernel = new StandardKernel(new DependencyInjection.FNHibernateNinjectModule());
            
            // Session
            _session = session;
            _session.FlushMode = FlushMode.Auto;
            _transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            if (_transaction.IsActive)
                _transaction.Commit();
            else
                throw new InvalidOperationException(
                    string.Format("Transaction is not active"));
        }

        public void Rollback()
        {
            if (_transaction.IsActive)
                _transaction.Rollback();
        }

        public void Dispose()
        {
            if (_session.IsOpen)
                _session.Close();
        }

        public IRepository<T> CreateRepository<T>()
        {
            var sessionParam = 
                new Ninject.Parameters.ConstructorArgument("session", _session);
            
            return _kernel.Get<IRepository<T>>(sessionParam);
        }
    }
}