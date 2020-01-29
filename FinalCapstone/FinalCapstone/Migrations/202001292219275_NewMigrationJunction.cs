namespace FinalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigrationJunction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TripleJunctionTables", "TeamId", "dbo.Teams");
            DropIndex("dbo.TripleJunctionTables", new[] { "TeamId" });
            DropPrimaryKey("dbo.TripleJunctionTables");
            AlterColumn("dbo.TripleJunctionTables", "TeamId", c => c.Int());
            AddPrimaryKey("dbo.TripleJunctionTables", new[] { "OrganizationId", "TeammemberId" });
            CreateIndex("dbo.TripleJunctionTables", "TeamId");
            AddForeignKey("dbo.TripleJunctionTables", "TeamId", "dbo.Teams", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TripleJunctionTables", "TeamId", "dbo.Teams");
            DropIndex("dbo.TripleJunctionTables", new[] { "TeamId" });
            DropPrimaryKey("dbo.TripleJunctionTables");
            AlterColumn("dbo.TripleJunctionTables", "TeamId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TripleJunctionTables", new[] { "OrganizationId", "TeammemberId", "TeamId" });
            CreateIndex("dbo.TripleJunctionTables", "TeamId");
            AddForeignKey("dbo.TripleJunctionTables", "TeamId", "dbo.Teams", "TeamId", cascadeDelete: true);
        }
    }
}
