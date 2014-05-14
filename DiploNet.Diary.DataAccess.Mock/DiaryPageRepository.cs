using System;
using System.Linq;
using System.Linq.Expressions;
using DiploNet.Diary.BusinessObject;
using DiploNet.Diary.DataAccess.Facade;

namespace DiploNet.Diary.DataAccess.Mock
{
    public class DiaryPageRepository : IDiaryPageRepository
    {
        public IQueryable<IDiaryPage> GetAll()
        {
            return DbMock.GetDb().AsQueryable();
        }

        public IQueryable<IDiaryPage> Get(Expression<Func<IDiaryPage, bool>> wherePredicate)
        {
            return DbMock.GetDb().AsQueryable().Where(wherePredicate);
        }
        
        public void Save(IDiaryPage entity)
        {
            DbMock.GetDb()
                .ToList()
                .Add(entity);
        }

        public void Update(IDiaryPage entity)
        {
            DbMock.GetDb().ToList().Remove(entity);
            DbMock.GetDb().ToList().Add(entity);
        }

        public void Delete(IDiaryPage entity)
        {
            DbMock.GetDb().ToList().Remove(entity);
        }

        public IDiaryPage Get(object id)
        {
            return DbMock.GetDb().Single(s => s.Id == (long)id);
        }
    }
}
