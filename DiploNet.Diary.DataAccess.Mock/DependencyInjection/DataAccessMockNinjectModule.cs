
using DiploNet.Diary.DataAccess.Facade;
namespace DiploNet.Diary.DataAccess.Mock.DependencyInjection
{
    public class DataAccessMockNinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IDiaryPageRepository>().To<DiaryPageRepository>();
        }
    }
}
