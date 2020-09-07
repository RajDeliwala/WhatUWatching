namespace Show.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWatchList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WatchListItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        WatchListId = c.String(maxLength: 128),
                        ShowId = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WatchLists", t => t.WatchListId)
                .Index(t => t.WatchListId);
            
            CreateTable(
                "dbo.WatchLists",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WatchListItems", "WatchListId", "dbo.WatchLists");
            DropIndex("dbo.WatchListItems", new[] { "WatchListId" });
            DropTable("dbo.WatchLists");
            DropTable("dbo.WatchListItems");
        }
    }
}
