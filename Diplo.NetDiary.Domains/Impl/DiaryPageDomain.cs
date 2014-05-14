using DiploNet.Diary.BusinessObject;
using DiploNet.Diary.DataAccess.Facade;

namespace DiploNet.Diary.Domains.Impl
{
    internal class DiaryPageDomain : EntityDomain<IDiaryPage>, IDiaryPageDomain
    {
        public DiaryPageDomain(IDiaryPageRepository repository)
            : base(repository) { }
    }
}
