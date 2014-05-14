using System.Collections.Generic;
using DiploNet.Diary.BusinessObject;
using DiploNet.Diary.Domains;

namespace DiploNet.Diary.Web.MVCSite.Models
{
    public class DiaryModel
    {
        public IEnumerable<IDiaryPage> DiaryPages { get; set; }
    }
}