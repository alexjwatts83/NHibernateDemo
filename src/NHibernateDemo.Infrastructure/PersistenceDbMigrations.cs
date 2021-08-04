using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Logging;

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
            //try
            //{
            //    const string filter = "EvolveDb.Infrastructure.Persistence.Migrations";
            //    var con = new SqlConnection(connectionString);
            //    var evolve = new Evolve.Evolve(con, msg => logger.LogInformation(msg))
            //    {
            //        EmbeddedResourceAssemblies = new[] { typeof(PersistenceDbMigrations).Assembly },
            //        EmbeddedResourceFilters = new[] { filter },
            //        IsEraseDisabled = true
            //    };

            //    evolve.Migrate();
            //}
            //catch (Exception ex)
            //{
            //    logger.LogCritical("Database migration failed.", ex);
            //    throw;
            //}
        }
    }
}
