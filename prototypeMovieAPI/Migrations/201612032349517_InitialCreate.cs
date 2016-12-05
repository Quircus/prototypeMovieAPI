namespace prototypeMovieAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        CinemaID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Website = c.String(),
                        PhoneNumber = c.String(),
                        TicketPrice = c.String(),
                        MovieID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.CinemaID)
                .ForeignKey("dbo.Movies", t => t.MovieID)
                .Index(t => t.MovieID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.String(nullable: false, maxLength: 10),
                        Title = c.String(nullable: false),
                        Certification = c.Int(nullable: false),
                        Genre = c.Int(nullable: false),
                        Description = c.String(),
                        RunTime = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MovieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cinemas", "MovieID", "dbo.Movies");
            DropIndex("dbo.Cinemas", new[] { "MovieID" });
            DropTable("dbo.Movies");
            DropTable("dbo.Cinemas");
        }
    }
}
