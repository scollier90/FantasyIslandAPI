namespace FantasyIsland.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedcascadedelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Booking", "TransId", "dbo.Transportation");
            DropForeignKey("dbo.Transportation", "DestId", "dbo.Destination");
            DropIndex("dbo.Transportation", new[] { "DestId" });
            AlterColumn("dbo.Transportation", "DestId", c => c.Int());
            CreateIndex("dbo.Transportation", "DestId");
            AddForeignKey("dbo.Booking", "TransId", "dbo.Transportation", "TransId");
            AddForeignKey("dbo.Transportation", "DestId", "dbo.Destination", "DestId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transportation", "DestId", "dbo.Destination");
            DropForeignKey("dbo.Booking", "TransId", "dbo.Transportation");
            DropIndex("dbo.Transportation", new[] { "DestId" });
            AlterColumn("dbo.Transportation", "DestId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transportation", "DestId");
            AddForeignKey("dbo.Transportation", "DestId", "dbo.Destination", "DestId", cascadeDelete: true);
            AddForeignKey("dbo.Booking", "TransId", "dbo.Transportation", "TransId", cascadeDelete: true);
        }
    }
}
