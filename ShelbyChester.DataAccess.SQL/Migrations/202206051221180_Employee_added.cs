namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContainerRents", "Employee_Id", c => c.String());
            AddColumn("dbo.Employees", "ContainerRent_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "ContainerRent_Id");
            AddForeignKey("dbo.Employees", "ContainerRent_Id", "dbo.ContainerRents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ContainerRent_Id", "dbo.ContainerRents");
            DropIndex("dbo.Employees", new[] { "ContainerRent_Id" });
            DropColumn("dbo.Employees", "ContainerRent_Id");
            DropColumn("dbo.ContainerRents", "Employee_Id");
        }
    }
}
