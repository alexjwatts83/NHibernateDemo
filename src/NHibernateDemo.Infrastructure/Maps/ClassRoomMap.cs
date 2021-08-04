using FluentNHibernate.Mapping;
using NHibernateDemo.Infrastructure.Entities;

namespace NHibernateDemo.Infrastructure.Maps
{
    public class ClassRoomMap : ClassMap<ClassRoom>
    {
        public ClassRoomMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            Table("ClassRoom");
        }
    }
}
