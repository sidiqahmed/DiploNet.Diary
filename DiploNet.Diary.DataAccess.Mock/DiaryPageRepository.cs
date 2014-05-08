using System;
using System.Linq;
using System.Linq.Expressions;
using DiploNet.Diary.BusinessObject;
using DiploNet.Diary.DataAccess.Facade;

namespace DiploNet.Diary.DataAccess.Mock
{
    public class DiaryPageRepository : IDiaryPageRepository
    {
        private DbMock _db;

        public DiaryPageRepository()
        {
            _db = new DbMock();
        }

        public IQueryable<IDiaryPage> GetAll()
        {
            return _db.ReadAll().AsQueryable();
        }

        public IQueryable<IDiaryPage> Get(Expression<Func<IDiaryPage, bool>> wherePredicate)
        {
            return _db.ReadAll().AsQueryable().Where(wherePredicate);
        }
        
        public void Save(IDiaryPage entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IDiaryPage entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IDiaryPage entity)
        {
            throw new NotImplementedException();
        }
    }
}
