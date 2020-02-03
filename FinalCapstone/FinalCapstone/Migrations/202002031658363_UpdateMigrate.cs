namespace FinalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMigrate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Meetings", "Time", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Meetings", "Time", c => c.DateTime(nullable: false));
        }
    }
}
