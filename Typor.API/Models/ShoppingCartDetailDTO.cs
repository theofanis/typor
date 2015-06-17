using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Typor.API.Models
{
    public class ShoppingCartDetailDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }
        [JsonProperty("customer_surname")]
        public string CustomerSurname { get; set; }
        [JsonProperty("products_count")]
        public int ProductsCount { get; set; }
        [JsonProperty("products")]
        public ICollection<Product> Products { get; set; }
    }
}