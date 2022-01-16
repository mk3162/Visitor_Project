namespace IntimeVisitor.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VisitDetails", "IsApproved", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VisitDetails", "IsApproved", c => c.Boolean());
        }
    }
}
