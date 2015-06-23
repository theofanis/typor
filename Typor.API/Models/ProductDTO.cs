using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typor.API.Models
{
    public class ProductDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("category")]
        public ProductCategory Category { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
