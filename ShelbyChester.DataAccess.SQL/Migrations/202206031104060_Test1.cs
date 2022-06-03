namespace ShelbyChester.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContainerRentals",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        numberOfItems = c.Int(nullable: false),
                        weightPerItem = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descriptions = c.String(nullable: false),
                        ContainerType = c.String(),
                        numberOfContainers = c.Int(nullable: false),
                        locationType = c.Int(nullable: false),
                        loadingLocation = c.String(nullable: false),
                        rentInDate = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContainerRentals");
        }
    }
}
