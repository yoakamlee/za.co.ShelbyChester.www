namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ContainerRentals", "rentInDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContainerRentals", "rentInDate", c => c.DateTime(nullable: false));
        }
    }
}
