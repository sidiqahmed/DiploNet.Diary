
namespace DiploNet.Diary.BusinessObject.Impl
{
    internal class DiaryPage : BaseEntity<DiaryPage, long>, IDiaryPage
    {
        public virtual string Title { get; set; }

        public virtual string ShortDescription { get; set; }

        public virtual string Description { get; set; }

        public virtual string Text { get; set; }
    }
}
