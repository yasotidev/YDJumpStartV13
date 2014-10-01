using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Yd.Server.Core.Model;

namespace Yd.Server.Core.Data
{
    public class YdAdventureContext : DbContext
    {
        public YdAdventureContext():base("YdAdventureEntities")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePicture> EmployeePictures { get; set; }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Expense> Expenses { get; set; }

    }
}
