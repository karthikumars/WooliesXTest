using Shopping.Models;
using Shopping.Models.Enums;
using Shopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Services.ProductsSorting
{
    public class ProductSorter : IProductSorter
    {
        private readonly IEnumerable<IProductSortingStrategy> _productSortingStrategies;

        public ProductSorter(IEnumerable<IProductSortingStrategy> productSortingStrategies)
        {
            _productSortingStrategies = productSortingStrategies ?? throw new System.ArgumentNullException(nameof(productSortingStrategies));
        }

        public async Task<IEnumerable<Product>> SortAsync(IEnumerable<Product> products, SortOption sortOption)
        {
            IProductSortingStrategy strategy = null;
            switch (sortOption)
            {
                case SortOption.Low:
                    strategy = _productSortingStrategies.Single(t => t.ProductSortBy == ProductSortBy.Price);
                    return await strategy.SortAsync(products, SortDirection.Ascending);

                case SortOption.High:
                    strategy = _productSortingStrategies.Single(t => t.ProductSortBy == ProductSortBy.Price);
                    return await strategy.SortAsync(products, SortDirection.Descending);

                case SortOption.Ascending:
                    strategy = _productSortingStrategies.Single(t => t.ProductSortBy == ProductSortBy.Name);
                    return await strategy.SortAsync(products, SortDirection.Ascending);

                case SortOption.Descending:
                    strategy = _productSortingStrategies.Single(t => t.ProductSortBy == ProductSortBy.Name);
                    return await strategy.SortAsync(products, SortDirection.Descending);

                case SortOption.Recommended:
                    strategy = _productSortingStrategies.Single(t => t.ProductSortBy == ProductSortBy.Recommended);
                    return await strategy.SortAsync(products, SortDirection.None);

                default:
                    throw new Exception($"Unknown sort option; sortoption={sortOption}");
            }
        }
    }
}