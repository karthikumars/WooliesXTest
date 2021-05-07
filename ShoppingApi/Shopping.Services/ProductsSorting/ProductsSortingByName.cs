using Shopping.Models;
using Shopping.Models.Enums;
using Shopping.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Services.ProductsSorting
{
    public class ProductsSortingByName : IProductSortingStrategy
    {
        public ProductSortBy ProductSortBy => ProductSortBy.Name;

        public async Task<IEnumerable<Product>> SortAsync(IEnumerable<Product> products, SortDirection sortDirection)
        {
            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    return products.OrderBy(t => t.Name).ToList();

                case SortDirection.Descending:
                    return products.OrderByDescending(t => t.Name).ToList();

                default:
                    return products;
            }
        }
    }
}