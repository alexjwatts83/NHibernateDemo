using FluentNHibernate.Mapping;
using NHibernateDemo.Infrastructure.Entities;

namespace NHibernateDemo.Infrastructure.Maps
{
    public class BaseEntityMap<T> : ClassMap<T> where T : BaseEntity
    {
        public BaseEntityMap()
        {
            Map(x => x.Created);
            Map(x => x.Updated);
        }
    }
}
