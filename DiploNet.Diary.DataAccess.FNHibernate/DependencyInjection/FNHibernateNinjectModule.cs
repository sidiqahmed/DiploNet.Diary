using DiploNet.Diary.BusinessObject;
using DiploNet.Diary.DataAccess.Facade;
using NHibernate;
using Ninject;

namespace DiploNet.Diary.DataAccess.FNHibernate.DependencyInjection
{
    public class FNHibernateNinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<IDiaryPage>>().To<DiaryPageRepository>();
            Bind<IDiaryPageRepository>().To<DiaryPageRepository>();

            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<ISessionFactory>()
                .ToProvider<FNHibernate.Configuration.FNHibernateConfiguration>()
                .InSingletonScope();

            Bind<ISession>()
                .ToMethod(context => 
                    context.Kernel.Get<ISessionFactory>().OpenSession());
        }
    }
}
