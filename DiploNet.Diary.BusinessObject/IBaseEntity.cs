
namespace DiploNet.Diary.BusinessObject
{
    public interface IBaseEntity<T, TId>
    {
        TId Id { get; set; }
        bool IsTransient { get; }
    }
}
