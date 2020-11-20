namespace FantasyIsland.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixedeverythingpossibly : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        DestId = c.Int(nullable: false),
                        TransId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id)
                .ForeignKey("dbo.Destination", t => t.DestId, cascadeDelete: false)
                .ForeignKey("dbo.Transportation", t => t.TransId, cascadeDelete: false)
                .Index(t => t.Id)
                .Index(t => t.DestId)
                .Index(t => t.TransId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Booking", "TransId", "dbo.Transportation");
            DropForeignKey("dbo.Booking", "DestId", "dbo.Destination");
            DropForeignKey("dbo.Booking", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.Booking", new[] { "TransId" });
            DropIndex("dbo.Booking", new[] { "DestId" });
            DropIndex("dbo.Booking", new[] { "Id" });
            DropTable("dbo.Booking");
        }
    }
}
