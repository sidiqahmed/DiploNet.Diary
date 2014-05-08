using DiploNet.Diary.BusinessObject;
using DiploNet.Diary.DataAccess.Facade;
using NHibernate;

namespace DiploNet.Diary.DataAccess.FNHibernate
{
    internal class DiaryPageRepository : Repository<IDiaryPage>, IDiaryPageRepository
    {
        public DiaryPageRepository(ISession session)
            : base(session) { }
    }
}
