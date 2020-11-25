namespace Musical.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartProject1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Place = c.String(),
                        GenreId = c.Int(nullable: false),
                        Artist_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.Artist_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Events", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "Artist_Id" });
            DropIndex("dbo.Events", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Events");
        }
    }
}
