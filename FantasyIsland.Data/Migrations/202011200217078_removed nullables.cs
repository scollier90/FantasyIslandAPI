namespace FantasyIsland.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removednullables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transportation", "DestId", "dbo.Destination");
            DropIndex("dbo.Transportation", new[] { "DestId" });
            AlterColumn("dbo.Transportation", "DestId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transportation", "DestId");
            AddForeignKey("dbo.Transportation", "DestId", "dbo.Destination", "DestId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transportation", "DestId", "dbo.Destination");
            DropIndex("dbo.Transportation", new[] { "DestId" });
            AlterColumn("dbo.Transportation", "DestId", c => c.Int());
            CreateIndex("dbo.Transportation", "DestId");
            AddForeignKey("dbo.Transportation", "DestId", "dbo.Destination", "DestId");
        }
    }
}
