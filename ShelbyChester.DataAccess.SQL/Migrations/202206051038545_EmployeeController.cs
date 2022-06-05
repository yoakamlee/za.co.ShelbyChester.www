namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Image", c => c.String());
            DropColumn("dbo.Employees", "PinCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "PinCode", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Image");
        }
    }
}
