using Typor.API.Models;

namespace Typor.API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Typor.API.Models.TyporAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Typor.API.Models.TyporAPIContext context)
        {
            context.Products.AddOrUpdate(x => x.Id,
                new Product() { Id = 1, Name = "Θερμοσίφωνο 10 lt" },
                new Product() { Id = 2, Name = "Θερμοσίφωνο 60 lt" },
                new Product() { Id = 3, Name = "Boiler 100 lt" }
                );

            context.Customers.AddOrUpdate(x => x.Id,
                new Customer() { Id = 1, Name = "Νίκος", Surname = "Τόκας" },
                new Customer() { Id = 2, Name = "Αναστασία", Surname = "Μαλαφούρη" },
                new Customer() { Id = 3, Name = "Αγγελική", Surname = "Σπηλιωτακοπούλου" }
                );

            context.ShoppingCarts.AddOrUpdate(x => x.Id,
                new ShoppingCart() { Id = 1, CustomerId = 1 },
                new ShoppingCart() { Id = 2, CustomerId = 2 },
                new ShoppingCart() { Id = 3, CustomerId = 3 }
                );
        }
    }
}
