using System.Collections.Generic;
using DiploNet.Diary.BusinessObject;
using DiploNet.Diary.BusinessObject.Impl;

namespace DiploNet.Diary.DataAccess.Mock
{
    public static class DbMock
    {
        public static IEnumerable<IDiaryPage> GetDb()
        {
            yield return new DiaryPage
            {
                Id = 1,
                Title = "Title_1",
                Description = "Description_1",
                Text = "Text_1"
            };

            yield return new DiaryPage
            {
                Id = 2,
                Title = "Title_2",
                Description = "Description_2",
                Text = "Text_2"
            };

            yield return new DiaryPage
            {
                Id = 3,
                Title = "Title_3",
                Description = "Description_3",
                Text = "Text_3"
            };

            yield return new DiaryPage
            {
                Id = 4,
                Title = "Title_4",
                Description = "Description_4",
                Text = "Text_4"
            };

        }
    }
}
