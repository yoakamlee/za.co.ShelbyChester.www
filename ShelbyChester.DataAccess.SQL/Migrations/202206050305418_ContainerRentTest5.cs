namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContainerRentTest5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasketItems", "ContainerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BasketItems", "ContainerName");
        }
    }
}
