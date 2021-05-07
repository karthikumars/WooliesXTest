using Shopping.Models;
using Shopping.Models.Enums;
using Shopping.Services.ProductsSorting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Services.Interfaces
{
    public interface IProductSortingStrategy
    {
        ProductSortBy ProductSortBy { get; }

        Task<IEnumerable<Product>> SortAsync(IEnumerable<Product> products, SortDirection sortDirection);
    }
}