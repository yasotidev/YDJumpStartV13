using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Yd.Server.Core.Model;

namespace Yd.Server.Core.Data
{
    public class YdAdventureContext : DbContext
    {
        public YdAdventureContext()
            :base("YdAdventureEntities")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<IssuingAuthorityKey> IssuingAuthorityKeys { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePicture> EmployeePictures { get; set; }     
        public DbSet<Team> Teams { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<HolidayCalendar> HolidayCalendars { get; set; }
        public DbSet<Vaccation> Vaccations { get; set; }
    }
}
