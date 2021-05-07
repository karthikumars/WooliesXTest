using Microsoft.Extensions.Logging;
using Shopping.Models;
using Shopping.Models.Enums;
using Shopping.Repositories.Interfaces;
using Shopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Services.ProductsSorting
{
    public class ProductsSortingByRecommended : IProductSortingStrategy
    {
        private readonly ILogger<ProductsSortingByRecommended> _logger;
        private readonly IShoppingRepository _shoppingRepository;

        public ProductsSortingByRecommended(ILogger<ProductsSortingByRecommended> logger, IShoppingRepository shoppingRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _shoppingRepository = shoppingRepository ?? throw new ArgumentNullException(nameof(shoppingRepository));
        }

        public ProductSortBy ProductSortBy => ProductSortBy.Recommended;

        public async Task<IEnumerable<Product>> SortAsync(IEnumerable<Product> products, SortDirection sortDirection)
        {
            //1. Retrieve shopper's histories
            var shopperHistories = await _shoppingRepository.GetShopperHistoriesAsync();

            //2. Sort products by weightage
            return (from p in products
                    let weightage = CalculateProductWeightage(p, shopperHistories)
                    orderby weightage descending
                    select p).ToList();
        }

        private int CalculateProductWeightage(Product product, IEnumerable<ShopperHistory> shopperHistories)
        {
            //Weightage Formula = Number of products purchased * Quantity of products purchased

            var shopperProducts = shopperHistories.SelectMany(t => t.Products.Where(p => p.Name == product.Name)).ToList();
            var weightage = shopperProducts.Count * shopperProducts.Sum(testc => testc.Quantity);

            return (int)weightage;
        }
    }
}