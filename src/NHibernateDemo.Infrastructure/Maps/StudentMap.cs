using NHibernateDemo.Infrastructure.Entities;

namespace NHibernateDemo.Infrastructure.Maps
{
    public class StudentMap : BaseEntityMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.ID);
            Map(x => x.LastName);
            Map(x => x.FirstMidName);
            Table("Student");
        }
    }
}
