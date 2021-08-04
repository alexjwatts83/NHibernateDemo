using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernateDemo.Infrastructure.Entities;

namespace NHibernateDemo.Infrastructure
{
    public static class FluentNHibernateHelper
    {
        public static ISession OpenSession(string connectionString)
        {
            //string connectionString = "Write your database connection string here";

            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql7.ConnectionString(connectionString).ShowSql())
                .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<Product>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
