﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Typor.API.Models
{
    public class TyporAPIContext : DbContext, ITyporAPIContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public TyporAPIContext() : base("name=TyporAPIContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<Typor.API.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Typor.API.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Typor.API.Models.ShoppingCart> ShoppingCarts { get; set; }

        public System.Data.Entity.DbSet<Typor.API.Models.Order> Orders { get; set; }

        public void MarkAsModified(Product item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}
