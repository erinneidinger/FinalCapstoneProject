namespace FinalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigraton : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meetings", "TeamId", "dbo.Teams");
            DropIndex("dbo.Meetings", new[] { "TeamId" });
            AlterColumn("dbo.Meetings", "TeamId", c => c.Int());
            CreateIndex("dbo.Meetings", "TeamId");
            AddForeignKey("dbo.Meetings", "TeamId", "dbo.Teams", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetings", "TeamId", "dbo.Teams");
            DropIndex("dbo.Meetings", new[] { "TeamId" });
            AlterColumn("dbo.Meetings", "TeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Meetings", "TeamId");
            AddForeignKey("dbo.Meetings", "TeamId", "dbo.Teams", "TeamId", cascadeDelete: true);
        }
    }
}
