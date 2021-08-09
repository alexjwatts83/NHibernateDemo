namespace NHibernateDemo.Infrastructure.Entities
{
    public class BaseEntityWithKey<TKey> : BaseEntity
    {
        public virtual TKey Id { get; set; }
    }
}
