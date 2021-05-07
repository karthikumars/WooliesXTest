using Shopping.Models;
using Shopping.Models.Enums;
using Shopping.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Services.ProductsSorting
{
    public class ProductsSortingByPrice : IProductSortingStrategy
    {
        public ProductSortBy ProductSortBy => ProductSortBy.Price;

        public async Task<IEnumerable<Product>> SortAsync(IEnumerable<Product> products, SortDirection sortDirection)
        {
            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    return products.OrderBy(t => t.Price).ToList();

                case SortDirection.Descending:
                    return products.OrderByDescending(t => t.Price).ToList();

                default:
                    return products;
            }
        }
    }
}