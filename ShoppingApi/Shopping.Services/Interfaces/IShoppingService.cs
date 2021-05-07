using Shopping.Models;
using Shopping.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Services.Interfaces
{
    public interface IShoppingService
    {
        Task<ShoppingUser> GetShoppingUserAsync();

        Task<IEnumerable<Product>> GetSortedProductsAsync(SortOption sortOption);

        Task<decimal> CalculateTrolleyTotalAsync(CalculateTrolleyTotalRequest request);
    }
}