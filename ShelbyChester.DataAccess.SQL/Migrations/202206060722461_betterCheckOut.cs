namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class betterCheckOut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DeliverTo", c => c.String());
            AddColumn("dbo.Orders", "ItemName", c => c.String());
            AddColumn("dbo.Orders", "ItemDescription", c => c.String());
            AddColumn("dbo.Orders", "NumberOfItem", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "WeightOfItem", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "WeightOfItem");
            DropColumn("dbo.Orders", "NumberOfItem");
            DropColumn("dbo.Orders", "ItemDescription");
            DropColumn("dbo.Orders", "ItemName");
            DropColumn("dbo.Orders", "DeliverTo");
        }
    }
}
