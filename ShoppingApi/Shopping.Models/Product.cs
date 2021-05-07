namespace Shopping.Models
{
    /// <summary>
    /// Shopping Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public decimal Quantity { get; set; }
    }
}