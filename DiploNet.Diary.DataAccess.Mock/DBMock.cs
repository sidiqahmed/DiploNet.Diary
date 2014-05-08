using System.Collections.Generic;
using DiploNet.Diary.BusinessObject;

namespace DiploNet.Diary.DataAccess.Mock
{
    public class DbMock
    {
        public IEnumerable<IDiaryPage> ReadAll()
        {
            yield return Moq.Mock.Of<IDiaryPage>();
            yield return Moq.Mock.Of<IDiaryPage>();
            yield return Moq.Mock.Of<IDiaryPage>();
            yield return Moq.Mock.Of<IDiaryPage>();
        }
    }
}
