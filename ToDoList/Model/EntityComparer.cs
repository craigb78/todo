using System.Collections.Generic;

namespace CraigToDoList.Model
{
    public class EntityComparer : IComparer<IEntity>
    {
        public int Compare(IEntity x, IEntity y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
}