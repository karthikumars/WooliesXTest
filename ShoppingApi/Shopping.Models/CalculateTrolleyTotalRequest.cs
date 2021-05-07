using System.Collections.Generic;

namespace Shopping.Models
{
    public class CalculateTrolleyTotalRequest
    {
        public List<Product> Products { get; set; }
        public List<ProductSpecial> Specials { get; set; }
        public List<ProductQuantity> Quantities { get; set; }
    }
}