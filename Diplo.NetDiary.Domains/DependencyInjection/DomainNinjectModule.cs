
namespace DiploNet.Diary.Domains.DependencyInjection
{
    public class DomainNinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IDiaryPageDomain>().To<Impl.DiaryPageDomain>();
        }
    }
}
