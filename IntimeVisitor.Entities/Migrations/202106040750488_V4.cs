namespace IntimeVisitor.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VisitPoints", "Capacity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VisitPoints", "Capacity", c => c.Int(nullable: false));
        }
    }
}
