namespace FinalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCounter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "Counter", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "Counter");
        }
    }
}
