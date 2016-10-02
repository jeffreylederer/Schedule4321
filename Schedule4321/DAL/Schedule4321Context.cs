using Schedule4321.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Schedule4321.DAL
{
    public class Schedule4321Context : DbContext
    {

        public Schedule4321Context()
            : base("Schedule4321")
        {
        }

        public DbSet<Schedule> Schedule { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
