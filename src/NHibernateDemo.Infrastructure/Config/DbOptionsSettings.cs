namespace NHibernateDemo.Infrastructure.Config
{
    public static class DbOptionsSettings
    {
        public const string Section = "DbOptions";
        public static string MainDbName => $"{Section}:MainDbName";
    }
}
