using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Typor.API.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}