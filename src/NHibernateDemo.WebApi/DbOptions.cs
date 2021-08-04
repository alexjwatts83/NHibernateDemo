using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NHibernateDemo.Infrastructure;

namespace NHibernateDemo.WebApi
{
    internal class DbOptions
    {
        public string DbConnectionString { get; set; }
        public string MasterDb { get; set; }
        public string MainDbName { get; set; }
    }
}
