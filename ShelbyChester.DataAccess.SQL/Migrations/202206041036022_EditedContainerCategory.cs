namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedContainerCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContainerCategories", "ContainerCapacity", c => c.Int(nullable: false));
            AddColumn("dbo.ContainerCategories", "ContainerPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ContainerCategories", "ContainerWeight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContainerCategories", "ContainerWeight", c => c.Int(nullable: false));
            DropColumn("dbo.ContainerCategories", "ContainerPrice");
            DropColumn("dbo.ContainerCategories", "ContainerCapacity");
        }
    }
}
