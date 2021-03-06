﻿using Newtonsoft.Json;
using System;
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
        [JsonProperty("category")]
        public ProductCategory Category { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("creation_date")]
        public DateTime CreationDate { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public enum ProductCategory
    {
        Thermosifono,
        Boiler,
        Hliakos,
        Syllekths
    }
}