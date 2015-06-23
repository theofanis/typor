using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Typor.API.Controllers;
using Typor.API.Models;

namespace Typor.API.Tests
{
    [TestClass]
    public class TestProductController
    {
        [TestMethod]
        public void PostProduct_ShouldReturnSameProduct()
        {
            var controller = new ProductsController(new TestTyporAPIContext());

            var item = GetDemoProduct();

            IHttpActionResult actionResult = controller.PostProduct(item).Result;
            var contentResult = actionResult as OkNegotiatedContentResult<ProductDTO>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(item.Name, contentResult.Content.Name);
        }

        Product GetDemoProduct()
        {
            return new Product()
            {
                Id = 3,
                Name = "Θερμοσίφωνο Demo",
                Price = 10M
            };
        }
    }
}
