using FluentNHibernate.Mapping;
using NHibernateDemo.Infrastructure.Entities;

namespace NHibernateDemo.Infrastructure.Maps
{
    public class BaseEntityWithKeyMap<TKey, TEntity> : ClassMap<TEntity> where TEntity : BaseEntityWithKey<TKey>
    {
        public BaseEntityWithKeyMap()
        {
            if(typeof(TKey) == typeof(string)) {
                Id(x => x.Id).Length(3);
            }
            else
            {
                Id(x => x.Id);
            }
            
            Map(x => x.Created);
            Map(x => x.Updated);
        }
    }
}
