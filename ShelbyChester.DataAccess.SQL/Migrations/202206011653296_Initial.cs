namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientPreAdvices",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Customer_Name = c.String(nullable: false),
                        Customer_Surname = c.String(nullable: false),
                        Customer_Address = c.String(nullable: false),
                        Customer_Email = c.String(nullable: false),
                        Customer_CellNum = c.String(),
                        NumberOfItems = c.Int(nullable: false),
                        WeightOfItems = c.Int(nullable: false),
                        SizePerItem = c.String(),
                        Client_Description = c.String(maxLength: 500),
                        Country = c.Int(nullable: false),
                        ContainerType = c.String(nullable: false),
                        Province = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContainerCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ContainerName = c.String(),
                        ContainerWeight = c.Int(nullable: false),
                        ContainerSize = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FreightQuotations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        quantity = c.Int(nullable: false),
                        Weight = c.String(nullable: false),
                        size = c.String(nullable: false),
                        basicprice = c.Double(nullable: false),
                        totalPrice = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WarehouseStorages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Location = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WarehouseStorages");
            DropTable("dbo.FreightQuotations");
            DropTable("dbo.ContainerCategories");
            DropTable("dbo.ClientPreAdvices");
        }
    }
}
