namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BasketItemViewModels", "ContainerRent_Id", "dbo.ContainerRents");
            DropForeignKey("dbo.ContainerRents", "BasketItemViewModel_Id", "dbo.BasketItemViewModels");
            DropForeignKey("dbo.ContainerRents", "BasketItemViewModel_Id1", "dbo.BasketItemViewModels");
            DropIndex("dbo.ContainerRents", new[] { "BasketItemViewModel_Id" });
            DropIndex("dbo.ContainerRents", new[] { "BasketItemViewModel_Id1" });
            DropIndex("dbo.BasketItemViewModels", new[] { "ContainerRent_Id" });
            DropColumn("dbo.ContainerRents", "BasketItemViewModel_Id");
            DropColumn("dbo.ContainerRents", "BasketItemViewModel_Id1");
            DropTable("dbo.BasketItemViewModels");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ContainerRents", "BasketItemViewModel_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.ContainerRents", "BasketItemViewModel_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.BasketItemViewModels", "ContainerRent_Id");
            CreateIndex("dbo.ContainerRents", "BasketItemViewModel_Id1");
            CreateIndex("dbo.ContainerRents", "BasketItemViewModel_Id");
            AddForeignKey("dbo.ContainerRents", "BasketItemViewModel_Id1", "dbo.BasketItemViewModels", "Id");
            AddForeignKey("dbo.ContainerRents", "BasketItemViewModel_Id", "dbo.BasketItemViewModels", "Id");
            AddForeignKey("dbo.BasketItemViewModels", "ContainerRent_Id", "dbo.ContainerRents", "Id");
        }
    }
}
