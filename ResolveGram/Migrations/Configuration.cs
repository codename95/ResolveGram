namespace ResolveGram.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ResolveGram.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ResolveGram.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Category.AddOrUpdate(
              p => p.Name,
              new Models.Entities.Category {CategoryID = 1, Name = "Personal" },
              new Models.Entities.Category { CategoryID = 2, Name = "Work" },
              new Models.Entities.Category { CategoryID = 3, Name = "Software" },
              new Models.Entities.Category { CategoryID = 4, Name = "Others" }
            );


            context.Priority.AddOrUpdate(
             p => p.Name,
             new Models.Entities.Priority {PriorityID = 1, Name = "Low" },
             new Models.Entities.Priority { PriorityID = 2, Name = "Medium" },
             new Models.Entities.Priority { PriorityID = 3, Name = "High" }
           );

        }
    }
}
