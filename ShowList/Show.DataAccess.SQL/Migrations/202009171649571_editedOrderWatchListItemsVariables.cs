namespace Show.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedOrderWatchListItemsVariables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderWatchListItems", "ShowId", c => c.String());
            AddColumn("dbo.OrderWatchListItems", "ShowName", c => c.String());
            AddColumn("dbo.OrderWatchListItems", "ShowDescription", c => c.String());
            AddColumn("dbo.OrderWatchListItems", "ShowSeason", c => c.String());
            AddColumn("dbo.OrderWatchListItems", "ShowStudio", c => c.String());
            AddColumn("dbo.OrderWatchListItems", "ShowEpisodeCount", c => c.String());
            DropColumn("dbo.OrderWatchListItems", "ProductId");
            DropColumn("dbo.OrderWatchListItems", "ProductName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderWatchListItems", "ProductName", c => c.String());
            AddColumn("dbo.OrderWatchListItems", "ProductId", c => c.String());
            DropColumn("dbo.OrderWatchListItems", "ShowEpisodeCount");
            DropColumn("dbo.OrderWatchListItems", "ShowStudio");
            DropColumn("dbo.OrderWatchListItems", "ShowSeason");
            DropColumn("dbo.OrderWatchListItems", "ShowDescription");
            DropColumn("dbo.OrderWatchListItems", "ShowName");
            DropColumn("dbo.OrderWatchListItems", "ShowId");
        }
    }
}
