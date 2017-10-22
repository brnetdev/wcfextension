using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace DB
{
    public class Db : DbContext
    {
        public DbSet<Person> People { get; set; }

        public Db() : base("cs")
        {
            Database.SetInitializer<Db>(new MigrateDatabaseToLatestVersion<Db, DB.Migrations.Configuration>());
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
           
        }
    }
}
