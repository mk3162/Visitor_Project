namespace IntimeVisitor.Entities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<IntimeVisitor.Entities.Context.IntimeVisitorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

        }
        
        protected override void Seed(IntimeVisitor.Entities.Context.IntimeVisitorContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
       
    }
}
