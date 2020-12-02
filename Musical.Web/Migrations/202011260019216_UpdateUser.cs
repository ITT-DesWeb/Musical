namespace Musical.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "Artist_Id", newName: "ApplicationUser");
            RenameIndex(table: "dbo.Events", name: "IX_Artist_Id", newName: "IX_ApplicationUser");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_ApplicationUser", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Events", name: "ApplicationUser", newName: "Artist_Id");
        }
    }
}
