namespace FinalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStateCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "City", c => c.String());
            AddColumn("dbo.Organizations", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "State");
            DropColumn("dbo.Organizations", "City");
        }
    }
}
