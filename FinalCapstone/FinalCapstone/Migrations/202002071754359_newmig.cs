namespace FinalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Requests", "SenderId");
            DropColumn("dbo.Requests", "ReceiverId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "ReceiverId", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "SenderId", c => c.Int(nullable: false));
        }
    }
}
