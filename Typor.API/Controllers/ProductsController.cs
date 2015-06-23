using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Typor.API.Models;

namespace Typor.API.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private ITyporAPIContext db = new TyporAPIContext();

        public ProductsController() { }

        public ProductsController(ITyporAPIContext context)
        {
            db = context;
        }

        // Typed lambda expression for Select() method on Products collection.
        private static readonly Expression<Func<Product, ProductDTO>> AsProductDTO =
            x => new ProductDTO
            {
                Name = x.Name,
                Category = x.Category,
                Description = x.Description,
                Price = x.Price
            };

        // GET: api/Products
        [Route("")]
        public IQueryable<ProductDTO> GetProducts()
        {
            return db.Products.Select(AsProductDTO);
        }

        // GET: api/Products/5
        [Route("{id:int}")]
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            ProductDTO product = await db.Products
                .Where(p => p.Id == id)
                .Select(AsProductDTO)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.MarkAsModified(product);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id:int}/details")]
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> GetProductDetail(int id)
        {
            var product = await (from p in db.Products
                                 where p.Id == id
                                 select new ProductDTO
                                 {
                                     Name = p.Name,
                                     Category = p.Category,
                                     Description = p.Description,
                                     Price = p.Price
                                 }).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [Route("{category}")]
        public IQueryable<ProductDTO> GetProductsByCategory(string category)
        {
            return db.Products
                .Where(p => p.Category.ToString() == category)
                .Select(AsProductDTO);
        }

        // POST: api/Products
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            ProductDTO productDTO = new ProductDTO()
            {
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                Price = product.Price
            };

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, productDTO);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}