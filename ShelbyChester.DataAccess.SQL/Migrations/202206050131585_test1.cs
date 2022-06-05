namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BasketId = c.String(maxLength: 128),
                        ContainerCategoryId = c.String(),
                        Quantity = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.BasketId)
                .Index(t => t.BasketId);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContainerRents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Location = c.String(),
                        DeliverTo = c.String(),
                        ItemName = c.String(),
                        ItemDescription = c.String(),
                        NumberOfItem = c.Int(nullable: false),
                        WeightOfItem = c.Int(nullable: false),
                        ContainerName = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        BasketItemViewModel_Id = c.String(maxLength: 128),
                        BasketItemViewModel_Id1 = c.String(maxLength: 128),
                        ContainerCategory_Id = c.String(maxLength: 128),
                        Basket_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BasketItemViewModels", t => t.BasketItemViewModel_Id)
                .ForeignKey("dbo.BasketItemViewModels", t => t.BasketItemViewModel_Id1)
                .ForeignKey("dbo.ContainerCategories", t => t.ContainerCategory_Id)
                .ForeignKey("dbo.Baskets", t => t.Basket_Id)
                .Index(t => t.BasketItemViewModel_Id)
                .Index(t => t.BasketItemViewModel_Id1)
                .Index(t => t.ContainerCategory_Id)
                .Index(t => t.Basket_Id);
            
            CreateTable(
                "dbo.BasketItemViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        ContainerName = c.String(),
                        ContainerPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        ContainerRent_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContainerRents", t => t.ContainerRent_Id)
                .Index(t => t.ContainerRent_Id);
            
            CreateTable(
                "dbo.ContainerCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ContainerName = c.String(),
                        ContainerCapacity = c.Int(nullable: false),
                        ContainerSize = c.Int(nullable: false),
                        ContainerPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.FreightQuotations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        quantity = c.Int(nullable: false),
                        Weight = c.String(nullable: false),
                        size = c.String(nullable: false),
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
            DropForeignKey("dbo.ContainerRents", "Basket_Id", "dbo.Baskets");
            DropForeignKey("dbo.ContainerRents", "ContainerCategory_Id", "dbo.ContainerCategories");
            DropForeignKey("dbo.ContainerRents", "BasketItemViewModel_Id1", "dbo.BasketItemViewModels");
            DropForeignKey("dbo.ContainerRents", "BasketItemViewModel_Id", "dbo.BasketItemViewModels");
            DropForeignKey("dbo.BasketItemViewModels", "ContainerRent_Id", "dbo.ContainerRents");
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.BasketItemViewModels", new[] { "ContainerRent_Id" });
            DropIndex("dbo.ContainerRents", new[] { "Basket_Id" });
            DropIndex("dbo.ContainerRents", new[] { "ContainerCategory_Id" });
            DropIndex("dbo.ContainerRents", new[] { "BasketItemViewModel_Id1" });
            DropIndex("dbo.ContainerRents", new[] { "BasketItemViewModel_Id" });
            DropIndex("dbo.BasketItems", new[] { "BasketId" });
            DropTable("dbo.WarehouseStorages");
            DropTable("dbo.FreightQuotations");
            DropTable("dbo.ClientPreAdvices");
            DropTable("dbo.ContainerCategories");
            DropTable("dbo.BasketItemViewModels");
            DropTable("dbo.ContainerRents");
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}
