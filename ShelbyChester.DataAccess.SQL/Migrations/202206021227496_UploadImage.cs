namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UploadImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContainerCategories", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContainerCategories", "Image");
        }
    }
}
