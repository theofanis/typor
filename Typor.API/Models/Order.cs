using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typor.API.Models
{
    public class Order
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }
        [JsonProperty("customer")]
        public virtual Customer Customer { get; set; }
        [JsonProperty("products")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
