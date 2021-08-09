using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernateDemo.Infrastructure.Entities;

namespace NHibernateDemo.Infrastructure
{
    public static class FluentNHibernateHelper
    {
        public static ISession CreateSchemaSession(string connectionString)
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql7.ConnectionString(connectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Product>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

        public static ISession OpenSession(string connectionString)
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql7.ConnectionString(connectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Product>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
