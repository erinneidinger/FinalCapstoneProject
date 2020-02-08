namespace FinalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nemigrate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "DatePosted", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "DatePosted", c => c.DateTime(nullable: false));
        }
    }
}
