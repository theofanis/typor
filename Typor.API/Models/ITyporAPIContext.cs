using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typor.API.Models
{
    public interface ITyporAPIContext : IDisposable
    {
        DbSet<Product> Products { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void MarkAsModified(Product item);
    }
}
