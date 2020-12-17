namespace Musical.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Picture");
        }
    }
}
