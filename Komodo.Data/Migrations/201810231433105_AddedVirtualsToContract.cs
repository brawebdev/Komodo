namespace Komodo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVirtualsToContract : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Contract", "DeveloperId");
            CreateIndex("dbo.Contract", "TeamId");
            AddForeignKey("dbo.Contract", "DeveloperId", "dbo.Developer", "DeveloperId", cascadeDelete: true);
            AddForeignKey("dbo.Contract", "TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
            DropColumn("dbo.Developer", "TeamId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Developer", "TeamId", c => c.Int());
            DropForeignKey("dbo.Contract", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Contract", "DeveloperId", "dbo.Developer");
            DropIndex("dbo.Contract", new[] { "TeamId" });
            DropIndex("dbo.Contract", new[] { "DeveloperId" });
        }
    }
}
