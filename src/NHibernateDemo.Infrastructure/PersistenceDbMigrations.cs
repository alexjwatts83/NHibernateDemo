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
            logger.LogInformation("Creating database and tables for lols");
            using (var session = FluentNHibernateHelper.CreateSchemaSession(connectionString))
            {
                // create the db and tables if they don't exists
            }
            logger.LogInformation("Adding a student");
            using (var session = FluentNHibernateHelper.OpenSession(connectionString))
            {
                using (var transaction = session.BeginTransaction())
                {
                    var entity = session.Get<Student>(1);
                    if (entity == null)
                    {
                        entity = new Student
                        {
                            LastName = "Smith",
                            FirstMidName = "John"
                        };
                    }
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
            logger.LogInformation("Student added");
            using (var session = FluentNHibernateHelper.OpenSession(connectionString))
            {
                var items = session.Query<Student>().ToList();
                foreach (var item in items)
                {
                    logger.LogInformation($"{item}");
                }
            }
            logger.LogInformation("Finished doing stuff");
        }
    }
}
