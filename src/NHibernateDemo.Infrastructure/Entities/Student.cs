using System;

namespace NHibernateDemo.Infrastructure.Entities
{
    public class Student : BaseEntity
    {
        public virtual int ID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstMidName { get; set; }
        public override string ToString()
        {
            return $"{ID}-{FirstMidName}-{LastName}-{base.ToString()}";
        }
    }
}
