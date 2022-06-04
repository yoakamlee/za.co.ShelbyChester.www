namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BasketItems", name: "Basket_Id1", newName: "BasketId");
            RenameIndex(table: "dbo.BasketItems", name: "IX_Basket_Id1", newName: "IX_BasketId");
            AddColumn("dbo.BasketItems", "ContainerCategoryId", c => c.String());
            DropColumn("dbo.BasketItems", "Basket_Id");
            DropColumn("dbo.BasketItems", "Container_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BasketItems", "Container_Id", c => c.String());
            AddColumn("dbo.BasketItems", "Basket_Id", c => c.String());
            DropColumn("dbo.BasketItems", "ContainerCategoryId");
            RenameIndex(table: "dbo.BasketItems", name: "IX_BasketId", newName: "IX_Basket_Id1");
            RenameColumn(table: "dbo.BasketItems", name: "BasketId", newName: "Basket_Id1");
        }
    }
}
