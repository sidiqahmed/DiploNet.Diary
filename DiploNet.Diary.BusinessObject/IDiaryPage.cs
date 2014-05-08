
namespace DiploNet.Diary.BusinessObject
{
    public interface IDiaryPage : IBaseEntity<IDiaryPage, long>
    {
        string Title { get; set; }
        string ShortDescription { get; set; }
        string Description { get; set; }
        string Text { get; set; }
    }
}
