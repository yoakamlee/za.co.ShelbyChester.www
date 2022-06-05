namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeeAndDriver : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EmployeeName = c.String(),
                        EmployeeDesignation = c.String(),
                        EmployeeAddress = c.String(),
                        EmployeePassport = c.String(),
                        EmployeePhone = c.Int(nullable: false),
                        EmployeeGender = c.String(),
                        City = c.String(),
                        Project = c.String(),
                        CompanyName = c.String(),
                        PinCode = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
            DropTable("dbo.Drivers");
        }
    }
}
