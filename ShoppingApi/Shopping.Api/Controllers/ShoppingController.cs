using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping.Models;
using Shopping.Models.Enums;
using Shopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly ILogger<ShoppingController> _logger;
        private readonly IShoppingService _shoppingService;

        public ShoppingController(ILogger<ShoppingController> logger, IShoppingService shoppingService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _shoppingService = shoppingService ?? throw new ArgumentNullException(nameof(shoppingService));
        }

        /// <summary>
        /// Returns shopping user details
        /// </summary>
        /// <returns>Shopping User <see cref="ShoppingUser"/></returns>
        [HttpGet("user")]
        public async Task<ShoppingUser> GetShoppingUserAsync()
        {
            return await _shoppingService.GetShoppingUserAsync();
        }

        /// <summary>
        /// Returns sorted list of products
        /// </summary>
        /// <returns>Products List</returns>
        [HttpGet("sort")]
        public async Task<IEnumerable<Product>> GetSortedProductsAsync([FromQuery] SortOption sortOption)
        {
            return await _shoppingService.GetSortedProductsAsync(sortOption);
        }

        /// <summary>
        /// Calculates the lowest possible total amount for the products in trolley applying specials and promotions
        /// </summary>
        /// <returns>Trolley Total</returns>
        [HttpPost("trolleyTotal")]
        public async Task<decimal> CalculateTrolleyTotal(CalculateTrolleyTotalRequest request)
        {
            return await _shoppingService.CalculateTrolleyTotalAsync(request);
        }
    }
}