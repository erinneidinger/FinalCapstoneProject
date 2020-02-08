namespace FinalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "FirstName", c => c.String());
            AddColumn("dbo.Requests", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "LastName");
            DropColumn("dbo.Requests", "FirstName");
        }
    }
}
