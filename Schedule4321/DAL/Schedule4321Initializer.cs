using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Schedule4321.Models;

namespace Schedule4321.DAL
{
    public class Schedule4321Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Schedule4321Context>
    {
        protected override void Seed(Schedule4321Context context)
        {
            new List<Schedule>
            {
                new Schedule {FirstName="Jeff", LastName="Lederer" },
                new Schedule {FirstName="John", LastName="Smith" },
                new Schedule {FirstName="Bob", LastName="Jones" }
            }.ForEach(s => context.Customers.Add(s));

            context.SaveChanges();
        }
    }
}
