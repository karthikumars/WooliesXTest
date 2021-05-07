using Newtonsoft.Json;

namespace Shopping.Models
{
    [JsonObject("quantity")]
    public class ProductQuantity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}