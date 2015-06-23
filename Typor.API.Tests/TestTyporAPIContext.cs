using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typor.API.Models;

namespace Typor.API.Tests
{
    public class TestTyporAPIContext : ITyporAPIContext
    {
        public DbSet<Product> Products { get; set; }

        public TestTyporAPIContext()
        {
            this.Products = new TestProductDbSet();
        }

        public void Dispose() { }

        public void MarkAsModified(Product item) { }

        public int SaveChanges()
        {
            return 0;
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await Task.Run(() =>
            {
                return 0;
            });

            return result;
        }
    }
}
