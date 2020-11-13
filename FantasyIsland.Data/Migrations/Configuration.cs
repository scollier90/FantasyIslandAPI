namespace FantasyIsland.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FantasyIsland.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FantasyIsland.Data.ApplicationDbContext";
        }

        protected override void Seed(FantasyIsland.Data.ApplicationDbContext context)
        {
            //var userOne = new ApplicationUser() { UserName = "john.hopkins@test.com", Email = "john.hopkins@test.com", PasswordHash = "Testpass1!" }

            //context.Users.AddOrUpdate(x => x.Id,
            //    new ApplicationUser() { UserName = "john.hopkins@test.com", Email = "john.hopkins@test.com", PasswordHash = "Testpass1!" },
            //    new ApplicationUser() { UserName = "bruce.evans@test.com", Email = "bruce.evans@test.com", PasswordHash = "Testpass1!" },
            //    new ApplicationUser() { UserName = "jennifer.gable@test.com", Email = "jennifer.gable@test.com", PasswordHash = "Testpass1!" }
            //    );    

            context.Genres.AddOrUpdate(x => x.GenreId,
                new Genre() { GenreId = 1, GenreType = "Sci-fi" },
                new Genre() { GenreId = 2, GenreType = "Adventure" },
                new Genre() { GenreId = 3, GenreType = "Family-friendly" },
                new Genre() { GenreId = 4, GenreType = "High Fantasy" }
                );

            context.Destinations.AddOrUpdate(x => x.DestId,
                new Destination() { DestId = 1, DestName = "Asgard", GenreId = 1 },
                new Destination() { DestId = 2, DestName = "Rivendell", GenreId = 2 },
                new Destination() { DestId = 3, DestName = "Hogwarts", GenreId = 3 },
                new Destination() { DestId = 4, DestName = "Jurassic Park", GenreId = 2 },
                new Destination() { DestId = 5, DestName = "Atlantis", GenreId = 3 }
                );

            context.Transportations.AddOrUpdate(x => x.TransId,
                new Transportation() { TransId = 1, TransType = "Plane", DestId = 4 },
                new Transportation() { TransId = 2, TransType = "Spaceship", DestId = 1 },
                new Transportation() { TransId = 3, TransType = "Submarine", DestId = 5 },
                new Transportation() { TransId = 4, TransType = "Special Requirement", DestId = 3 }
                );
        }
    }
}
