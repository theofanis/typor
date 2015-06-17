using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Typor.API.Models
{
    public class ShoppingCartDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }
        [JsonProperty("products_count")]
        public int ProcuctsCount { get; set; }
    }
}