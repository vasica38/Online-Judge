using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Data
{
    public class JudgeContext: DbContext, IDesignTimeDbContextFactory<JudgeContext>
    {

        public JudgeContext(DbContextOptions<JudgeContext> options)
            : 
            base(options)
        {

        }

        public DbSet<GeneralDashboard> Dashboards { get; set; }
        public DbSet<UserDashboard> UDashboards { get; set; }

        public DbSet<Problem> Problems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Solution> Solutions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GeneralDashboard>(ConfigureGeneralDashboard);
            builder.Entity<UserDashboard>(ConfigureUserDashboard);
            builder.Entity<Problem>(ConfigureProblem);
            builder.Entity<User>(ConfigureUser);
            builder.Entity<Solution>(ConfigureSolution);

        }

        private void ConfigureSolution(EntityTypeBuilder<Solution> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureUser(EntityTypeBuilder<User> obj)
        {
            obj.ToTable("User");

            throw new NotImplementedException();
        }

        private void ConfigureProblem(EntityTypeBuilder<Problem> obj)
        {
            obj.ToTable("Problem");

            throw new NotImplementedException();
        }

        private void ConfigureUserDashboard(EntityTypeBuilder<UserDashboard> obj)
        {
            obj.ToTable("UserDashboard");

            throw new NotImplementedException();
        }

        private void ConfigureGeneralDashboard(EntityTypeBuilder<GeneralDashboard> obj)
        {

            obj.ToTable("GeneralDashboard");
            throw new NotImplementedException();
        }

        public JudgeContext CreateDbContext(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
