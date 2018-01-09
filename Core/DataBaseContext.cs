using Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DataBaseContext : DbContext
    {
        protected DataBaseContext()
            : base("name=DataBaseContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }


        public  DbSet<Solution> Solutions { get; set; }
        public  DbSet<User> Users { get; set; }
        public  DbSet<Problem> Problems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           //modelBuilder.Configurations.Add(new CourseConfiguration());
           //relation shieeeet
        }

    }
}
