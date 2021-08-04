using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Logging;
using NHibernateDemo.Infrastructure.Entities;

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
            logger.LogInformation("Adding product");
            using (var session = FluentNHibernateHelper.OpenSession(connectionString))
            {
                var product = new Product { Name = "Lenovo Laptop", Description = "Sample product" };
                session.SaveOrUpdate(product);
            }

            using (var session = FluentNHibernateHelper.OpenSession2(connectionString))
            {
                var products = session.Query<Product>().ToList();
                logger.LogInformation($"products count: {products.Count}");
            }
        }
    }
}
