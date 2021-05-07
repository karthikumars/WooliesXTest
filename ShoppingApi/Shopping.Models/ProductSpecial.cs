using Newtonsoft.Json;
using System.Collections.Generic;

namespace Shopping.Models
{
    [JsonObject("special")]
    public class ProductSpecial
    {
        public List<ProductQuantity> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}