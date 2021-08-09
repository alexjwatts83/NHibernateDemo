using NHibernateDemo.Infrastructure.Entities;

namespace NHibernateDemo.Infrastructure.Maps
{
    public class SubjectMap : BaseEntityWithKeyMap<string, Subject>
    {
        public SubjectMap()
        {
            Map(x => x.Name).Length(255);
            Map(x => x.Description);
            Table("Subjects");
        }
    }
}
