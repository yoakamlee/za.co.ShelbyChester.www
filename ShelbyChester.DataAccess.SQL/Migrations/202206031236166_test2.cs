namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContainerRentals", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContainerRentals", "Image");
        }
    }
}
