using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DiploNet.Diary.DataAccess.FNHibernate")]

namespace DiploNet.Diary.BusinessObject.Impl
{
    internal abstract class BaseEntity<T, TId> : IBaseEntity<T, TId>
    {
        public virtual TId Id { get; set; }

        public virtual bool IsTransient {
            get {
                return Id.Equals(default(TId));
            }
        }
    }
}
