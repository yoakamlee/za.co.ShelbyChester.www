namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThingsChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FreightQuotations", "basicprice");
            DropColumn("dbo.FreightQuotations", "totalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FreightQuotations", "totalPrice", c => c.Double(nullable: false));
            AddColumn("dbo.FreightQuotations", "basicprice", c => c.Double(nullable: false));
        }
    }
}
