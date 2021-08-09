namespace NHibernateDemo.Infrastructure.Entities
{
    public class Subject : BaseEntityWithKey<string>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
