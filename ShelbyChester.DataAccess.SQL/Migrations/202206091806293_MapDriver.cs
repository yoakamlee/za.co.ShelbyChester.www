namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapDriver : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "UserId", c => c.String());
        }
    }
}
