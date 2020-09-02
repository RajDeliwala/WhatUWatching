namespace Show.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShowModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Genere1 = c.String(),
                        Genere2 = c.String(),
                        Genere3 = c.String(),
                        Genere4 = c.String(),
                        Genere5 = c.String(),
                        Image = c.String(),
                        PremieredSeason = c.String(),
                        EpisodeCount = c.String(),
                        Studio = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShowSeasons",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ShowSeasonAired = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShowSeasons");
            DropTable("dbo.ShowModels");
        }
    }
}
