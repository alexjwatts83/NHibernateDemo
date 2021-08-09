using System.Data.SqlClient;
using System.Linq;
using Dapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Logging;
using NHibernate.Tool.hbm2ddl;
using NHibernateDemo.Infrastructure.Entities;
using NHibernateDemo.Infrastructure.Maps;

namespace NHibernateDemo.Infrastructure
{

    public static class PersistenceDbMigrations
    {
        public static void EnsureDatabase(string connectionString, string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", name);
            using var connection = new SqlConnection(connectionString);
            var records = connection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);
            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE {name}");
            }
        }

        public static void UpdateDatabase(string connectionString, ILogger logger)
        {
            var configuration = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())
                            .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            using (var session = FluentNHibernateHelper.OpenSessionViaConfiguration(configuration))
            {

            }

            //_sessionFactory = configuration.BuildSessionFactory();

            //using (var session = FluentNHibernateHelper.OpenSession(connectionString))
            //{
            //    var product = new Product { Name = "Lenovo Laptop", Description = "Sample product" };
            //    session.SaveOrUpdate(product);
            //}
        }
    }
}
