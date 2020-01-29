namespace FinalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewJunctionTAble : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organizations", "TeamMember_Id", "dbo.TeamMembers");
            DropForeignKey("dbo.Teams", "TeamMember_Id", "dbo.TeamMembers");
            DropIndex("dbo.Organizations", new[] { "TeamMember_Id" });
            DropIndex("dbo.Teams", new[] { "TeamMember_Id" });
            DropPrimaryKey("dbo.Organizations");
            DropPrimaryKey("dbo.TeamMembers");
            AddColumn("dbo.Organizations", "OrganizationId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TeamMembers", "MemberId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Organizations", "OrganizationId");
            AddPrimaryKey("dbo.TeamMembers", "MemberId");
            DropColumn("dbo.Organizations", "Id");
            DropColumn("dbo.Organizations", "TeamMember_Id");
            DropColumn("dbo.TeamMembers", "Id");
            DropColumn("dbo.Teams", "TeamMember_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "TeamMember_Id", c => c.Int());
            AddColumn("dbo.TeamMembers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Organizations", "TeamMember_Id", c => c.Int());
            AddColumn("dbo.Organizations", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.TeamMembers");
            DropPrimaryKey("dbo.Organizations");
            DropColumn("dbo.TeamMembers", "MemberId");
            DropColumn("dbo.Organizations", "OrganizationId");
            AddPrimaryKey("dbo.TeamMembers", "Id");
            AddPrimaryKey("dbo.Organizations", "Id");
            CreateIndex("dbo.Teams", "TeamMember_Id");
            CreateIndex("dbo.Organizations", "TeamMember_Id");
            AddForeignKey("dbo.Teams", "TeamMember_Id", "dbo.TeamMembers", "Id");
            AddForeignKey("dbo.Organizations", "TeamMember_Id", "dbo.TeamMembers", "Id");
        }
    }
}
