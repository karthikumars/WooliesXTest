using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopping.Models;
using Shopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Repositories
{
    public class ShoppingRepository : IShoppingRepository
    {
        private readonly ILogger<ShoppingRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly WooliesXApiDetail _wooliesXApiDetail;

        public ShoppingRepository(ILogger<ShoppingRepository> logger, IConfiguration configuration, IOptions<WooliesXApiDetail> wooliesXApiDetailOptions)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _wooliesXApiDetail = wooliesXApiDetailOptions?.Value ?? throw new ArgumentNullException(nameof(wooliesXApiDetailOptions));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            using (var client = new HttpClient())
            {
                //1. Call woolies x api to retrieve products
                var wooliesXProductsUrl = string.Format("{0}/{1}/?token={2}", _wooliesXApiDetail.BaseUrl?.Trim('/'), _wooliesXApiDetail.ProductsMethodName?.Trim('/'), _wooliesXApiDetail.ApiToken);

                var response = await client.GetAsync(wooliesXProductsUrl);
                response.EnsureSuccessStatusCode();

                //2. Read response and de-serialize to list of products
                var result = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(result);

                return products;
            }
        }

        public async Task<IEnumerable<ShopperHistory>> GetShopperHistoriesAsync()
        {
            using (var client = new HttpClient())
            {
                //1. Call woolies x api to retrieve shopper history
                var wooliesXShopperHistoryUrl = string.Format("{0}/{1}?token={2}", _wooliesXApiDetail.BaseUrl.Trim('/'), _wooliesXApiDetail.ShopperHistoryMethodName, _wooliesXApiDetail.ApiToken);

                var response = await client.GetAsync(wooliesXShopperHistoryUrl);
                response.EnsureSuccessStatusCode();

                //2. Read response and de-serialize to list of shopper history
                var result = await response.Content.ReadAsStringAsync();
                var shopperHistory = JsonConvert.DeserializeObject<List<ShopperHistory>>(result);

                return shopperHistory;
            }
        }
    }
}