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
                new Product() { Id = 1, Name = "Θερμοσίφωνο 10 lt", Category = ProductCategory.Thermosifono, Description = "Θερμοσίφωνο GLASS 10 lt", CreationDate = DateTime.Now, Price = 35M },
                new Product() { Id = 2, Name = "Θερμοσίφωνο 60 lt", Category = ProductCategory.Thermosifono, Description = "Θερμοσίφωνο GLASS 60 lt", CreationDate = DateTime.Now, Price = 79.9M },
                new Product() { Id = 3, Name = "Boiler 100 lt", Category = ProductCategory.Boiler, Description = "Boiler GLASS 100 lt", CreationDate = DateTime.Now, Price = 129.9M }
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

            context.Orders.AddOrUpdate(x => x.Id,
                new Order() { Id = 1, CustomerId = 1 },
                new Order() { Id = 2, CustomerId = 2 }
                );
        }
    }
}
