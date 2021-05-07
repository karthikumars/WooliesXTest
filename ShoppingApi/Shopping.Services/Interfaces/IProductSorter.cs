using Shopping.Models;
using Shopping.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Services.Interfaces
{
    public interface IProductSorter
    {
        Task<IEnumerable<Product>> SortAsync(IEnumerable<Product> products, SortOption sortOption);
    }
}