using System.Configuration;
using System.Runtime.CompilerServices;
using DiploNet.Diary.DataAccess.FNHibernate.Mapping;
using FluentNHibernate.Cfg;
using NHibernate;
using Ninject.Activation;

[assembly: InternalsVisibleTo("DiploNet.Diary.DataAccess.FNHibernate.Test")]

namespace DiploNet.Diary.DataAccess.FNHibernate.Configuration
{
    internal class FNHibernateConfiguration : Provider<ISessionFactory>
    {
        const string ConnectionStringName = "DiaryDb";

        private static ISessionFactory _sessionFactory;
        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = CreateSessionFactory();
                }
                return _sessionFactory;
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => c.FromConnectionStringWithKey(ConnectionStringName))
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DiaryPageMap>())
                .BuildSessionFactory();
        }

        protected override ISessionFactory CreateInstance(IContext context)
        {
            return FNHibernateConfiguration.SessionFactory;
        }
    }
}
