using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DiploNet.Diary.DataAccess.FNHibernate")]
[assembly: InternalsVisibleTo("DiploNet.Diary.DataAccess.Mock")]

namespace DiploNet.Diary.BusinessObject.Impl
{
    internal abstract class BaseEntity<T, TId> : IBaseEntity<T, TId>
        where T : IBaseEntity<T, TId>
    {
        private int _transientHashCode; 

        public virtual TId Id { get; set; }

        public virtual bool IsTransient {
            get {
                return Id.Equals(default(TId));
            }
        }

        public override int GetHashCode()
        {
            if (_transientHashCode != default(int))
                return _transientHashCode;
            else if (IsTransient)
            {
                _transientHashCode = base.GetHashCode();
                return _transientHashCode;
            }
            else
                return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj)) 
                return false;
            
            if(!Equals(typeof(T), obj.GetType())) 
                return false;
            
            T o = (T)obj;
            if(this.IsTransient && o.IsTransient)
                return ReferenceEquals(this, o);
            if(!this.IsTransient && !o.IsTransient)
                return Equals(this.Id, o.Id);
            
            return false;
        }

        public override string ToString()
        {
            return typeof(T).Name + " : " + (IsTransient ? "Transient" : Id.ToString());
        }
    }
}
