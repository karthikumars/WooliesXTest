using Shopping.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Repositories.Interfaces
{
    public interface IShoppingRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<IEnumerable<ShopperHistory>> GetShopperHistoriesAsync();
    }
}