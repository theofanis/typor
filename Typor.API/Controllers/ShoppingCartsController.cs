using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Typor.API.Models;

namespace Typor.API.Controllers
{
    public class ShoppingCartsController : ApiController
    {
        private TyporAPIContext db = new TyporAPIContext();

        // GET: api/ShoppingCarts
        public IQueryable<ShoppingCartDTO> GetShoppingCarts()
        {
            var shoppingCarts = from sp in db.ShoppingCarts
                                select new ShoppingCartDTO()
                                {
                                    Id = sp.Id,
                                    CustomerName = sp.Customer.Name + " " + sp.Customer.Surname,
                                    ProcuctsCount = sp.Products.Count
                                };

            return shoppingCarts;
        }

        // GET: api/ShoppingCarts/5
        [ResponseType(typeof(ShoppingCartDetailDTO))]
        public async Task<IHttpActionResult> GetShoppingCart(int id)
        {
            var shoppingCart = await db.ShoppingCarts
                .Include(sp => sp.Customer).Select(sp =>
                new ShoppingCartDetailDTO()
                {
                    Id = sp.Id,
                    CustomerName = sp.Customer.Name,
                    CustomerSurname = sp.Customer.Surname,
                    ProductsCount = sp.Products.Count,
                    Products = sp.Products
                }).SingleOrDefaultAsync(sp => sp.Id == id);

            if (shoppingCart == null)
            {
                return NotFound();
            }

            return Ok(shoppingCart);
        }

        // PUT: api/ShoppingCarts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShoppingCart(int id, ShoppingCart shoppingCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shoppingCart.Id)
            {
                return BadRequest();
            }

            db.Entry(shoppingCart).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingCartExists(id))
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

        // POST: api/ShoppingCarts
        [ResponseType(typeof(ShoppingCartDTO))]
        public async Task<IHttpActionResult> PostShoppingCart(ShoppingCart shoppingCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShoppingCarts.Add(shoppingCart);
            await db.SaveChangesAsync();

            db.Entry(shoppingCart).Reference(x => x.Customer).Load();

            var dto = new ShoppingCartDTO()
            {
                Id = shoppingCart.Id,
                CustomerName = shoppingCart.Customer.Name + " " + shoppingCart.Customer.Surname,
                ProcuctsCount = shoppingCart.Products.Count
            };

            return CreatedAtRoute("DefaultApi", new { id = shoppingCart.Id }, dto);
        }

        // DELETE: api/ShoppingCarts/5
        [ResponseType(typeof(ShoppingCart))]
        public async Task<IHttpActionResult> DeleteShoppingCart(int id)
        {
            ShoppingCart shoppingCart = await db.ShoppingCarts.FindAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            db.ShoppingCarts.Remove(shoppingCart);
            await db.SaveChangesAsync();

            return Ok(shoppingCart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShoppingCartExists(int id)
        {
            return db.ShoppingCarts.Count(e => e.Id == id) > 0;
        }
    }
}