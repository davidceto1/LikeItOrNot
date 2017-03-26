using LikeItOrNot.Models;

namespace LikeItOrNot.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LikeItOrNot.Models.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LikeItOrNot.Models.DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.ImageModels.AddOrUpdate(
              p => p.Number,
              new ImageModel() { Number =  1},
              new ImageModel() { Number = 2 },
              new ImageModel() { Number = 3 },
              new ImageModel() { Number = 4 },
              new ImageModel() { Number = 5 },
              new ImageModel() { Number = 6 },
              new ImageModel() { Number = 7 },
              new ImageModel() { Number = 8 },
              new ImageModel() { Number = 9 },
              new ImageModel() { Number = 1 },
              new ImageModel() { Number = 11 },
              new ImageModel() { Number = 12 }
            );

        }
    }
}
