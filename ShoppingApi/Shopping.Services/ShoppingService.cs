using Microsoft.Extensions.Logging;
using Shopping.Models;
using Shopping.Models.Enums;
using Shopping.Repositories.Interfaces;
using Shopping.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly ILogger<ShoppingService> _logger;
        private readonly IShoppingRepository _shoppingRepository;
        private readonly IProductSorter _productSorter;
        private readonly ITrolleyTotalCalculator _trolleyTotalCalculator;

        public ShoppingService(ILogger<ShoppingService> logger, IShoppingRepository shoppingRepository, IProductSorter productSorter, ITrolleyTotalCalculator trolleyTotalCalculator)
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            _shoppingRepository = shoppingRepository ?? throw new System.ArgumentNullException(nameof(shoppingRepository));
            _productSorter = productSorter ?? throw new System.ArgumentNullException(nameof(productSorter));
            _trolleyTotalCalculator = trolleyTotalCalculator ?? throw new System.ArgumentNullException(nameof(trolleyTotalCalculator));
        }

        public async Task<ShoppingUser> GetShoppingUserAsync()
        {
            return await Task.FromResult(new ShoppingUser()
            {
                Name = "Karthikumar Subramanian",
                Token = "f65aa6e5-8cde-4f35-a45b-3ea218d391c8"
            });
        }

        public async Task<IEnumerable<Product>> GetSortedProductsAsync(SortOption sortOption)
        {
            //1. Retrieve products
            var products = await _shoppingRepository.GetProductsAsync();

            //2. Sort products
            var sortedProducts = await _productSorter.SortAsync(products, sortOption);

            //3. Return sorted products
            return sortedProducts;
        }

        public async Task<decimal> CalculateTrolleyTotalAsync(CalculateTrolleyTotalRequest request)
        {
            var trolleyTotal = await _trolleyTotalCalculator.Calculate(request);
            return trolleyTotal;
        }
    }
}