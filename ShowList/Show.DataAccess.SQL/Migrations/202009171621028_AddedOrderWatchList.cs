namespace Show.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderWatchList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderWatchListItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OrderId = c.String(),
                        ProductId = c.String(),
                        ProductName = c.String(),
                        Image = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        OrderWatchList_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderWatchLists", t => t.OrderWatchList_Id)
                .Index(t => t.OrderWatchList_Id);
            
            CreateTable(
                "dbo.OrderWatchLists",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        ListStatus = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderWatchListItems", "OrderWatchList_Id", "dbo.OrderWatchLists");
            DropIndex("dbo.OrderWatchListItems", new[] { "OrderWatchList_Id" });
            DropTable("dbo.OrderWatchLists");
            DropTable("dbo.OrderWatchListItems");
        }
    }
}
