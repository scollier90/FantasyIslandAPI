namespace FantasyIsland.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Destination",
                c => new
                    {
                        DestId = c.Int(nullable: false, identity: true),
                        DestName = c.String(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DestId)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: false)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Transportation",
                c => new
                    {
                        TransId = c.Int(nullable: false, identity: true),
                        TransType = c.String(nullable: false),
                        DestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransId)
                .ForeignKey("dbo.Destination", t => t.DestId, cascadeDelete: true)
                .Index(t => t.DestId);
            
            DropTable("dbo.Guest");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Guest",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        AdminId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.GuestId);
            
            DropForeignKey("dbo.Transportation", "DestId", "dbo.Destination");
            DropForeignKey("dbo.Destination", "GenreId", "dbo.Genre");
            DropIndex("dbo.Transportation", new[] { "DestId" });
            DropIndex("dbo.Destination", new[] { "GenreId" });
            DropTable("dbo.Transportation");
            DropTable("dbo.Genre");
            DropTable("dbo.Destination");
        }
    }
}
