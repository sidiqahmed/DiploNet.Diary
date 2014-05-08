namespace DiploNet.Diary.BusinessObject.DependencyInjection
{
    public class BusinessObjectNinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IDiaryPage>().To<Impl.DiaryPage>();
        }
    }
}
