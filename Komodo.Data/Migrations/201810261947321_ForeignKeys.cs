namespace Komodo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contract", "DeveloperId", "dbo.Developer");
            DropForeignKey("dbo.Contract", "TeamId", "dbo.Team");
            DropIndex("dbo.Contract", new[] { "DeveloperId" });
            DropIndex("dbo.Contract", new[] { "TeamId" });
            DropPrimaryKey("dbo.Developer");
            DropPrimaryKey("dbo.Team");
            AddColumn("dbo.Contract", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Developer", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Team", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Developer", "DeveloperId", c => c.Int(nullable: false));
            AlterColumn("dbo.Team", "TeamId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Developer", "DeveloperId");
            AddPrimaryKey("dbo.Team", "TeamId");
            CreateIndex("dbo.Developer", "DeveloperId");
            CreateIndex("dbo.Team", "TeamId");
            AddForeignKey("dbo.Developer", "DeveloperId", "dbo.Contract", "ContractId");
            AddForeignKey("dbo.Team", "TeamId", "dbo.Contract", "ContractId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Team", "TeamId", "dbo.Contract");
            DropForeignKey("dbo.Developer", "DeveloperId", "dbo.Contract");
            DropIndex("dbo.Team", new[] { "TeamId" });
            DropIndex("dbo.Developer", new[] { "DeveloperId" });
            DropPrimaryKey("dbo.Team");
            DropPrimaryKey("dbo.Developer");
            AlterColumn("dbo.Team", "TeamId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Developer", "DeveloperId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Team", "IsActive");
            DropColumn("dbo.Developer", "IsActive");
            DropColumn("dbo.Contract", "IsActive");
            AddPrimaryKey("dbo.Team", "TeamId");
            AddPrimaryKey("dbo.Developer", "DeveloperId");
            CreateIndex("dbo.Contract", "TeamId");
            CreateIndex("dbo.Contract", "DeveloperId");
            AddForeignKey("dbo.Contract", "TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
            AddForeignKey("dbo.Contract", "DeveloperId", "dbo.Developer", "DeveloperId", cascadeDelete: true);
        }
    }
}
