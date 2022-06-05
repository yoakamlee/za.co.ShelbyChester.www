namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrdersCheckOut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "ContainerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "ContainerName");
        }
    }
}
