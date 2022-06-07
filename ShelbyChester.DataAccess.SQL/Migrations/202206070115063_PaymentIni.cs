namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentIni : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Baskets", newName: "Basketitems");
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.BasketItems", new[] { "BasketId" });
            RenameColumn(table: "dbo.ContainerRents", name: "Basket_Id", newName: "Basketitem_Id");
            RenameIndex(table: "dbo.ContainerRents", name: "IX_Basket_Id", newName: "IX_Basketitem_Id");
            AddColumn("dbo.BasketItems", "Basketitem_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.BasketItems", "BasketId", c => c.String());
            CreateIndex("dbo.BasketItems", "Basketitem_Id");
            AddForeignKey("dbo.BasketItems", "Basketitem_Id", "dbo.Basketitems", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "Basketitem_Id", "dbo.Basketitems");
            DropIndex("dbo.BasketItems", new[] { "Basketitem_Id" });
            AlterColumn("dbo.BasketItems", "BasketId", c => c.String(maxLength: 128));
            DropColumn("dbo.BasketItems", "Basketitem_Id");
            RenameIndex(table: "dbo.ContainerRents", name: "IX_Basketitem_Id", newName: "IX_Basket_Id");
            RenameColumn(table: "dbo.ContainerRents", name: "Basketitem_Id", newName: "Basket_Id");
            CreateIndex("dbo.BasketItems", "BasketId");
            AddForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets", "Id");
            RenameTable(name: "dbo.Basketitems", newName: "Baskets");
        }
    }
}
