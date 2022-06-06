namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DriverAddedProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DriverId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DriverId");
        }
    }
}
