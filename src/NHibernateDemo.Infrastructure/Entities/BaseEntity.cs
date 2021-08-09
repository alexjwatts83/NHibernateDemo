using System;
using System.Text;

namespace NHibernateDemo.Infrastructure.Entities
{
    public class BaseEntity
    {
        public virtual DateTime? Created { get; set; }
        public virtual DateTime? Updated { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Created.HasValue)
            {
                sb.Append($"[{Created.Value:yyyy-MM-dd-HH:mm:ss}]-");
            }
            if (Updated.HasValue)
            {
                sb.Append($"[{Updated.Value:yyyy-MM-dd-HH:mm:ss}]");
            }
            return sb.ToString();
        }
    }
}
