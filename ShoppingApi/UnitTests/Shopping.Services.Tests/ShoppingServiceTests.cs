using Microsoft.Extensions.Logging;
using Moq;
using Shopping.Repositories.Interfaces;
using Shopping.Services.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace Shopping.Services.Tests
{
    public class ShoppingServiceTests
    {
        private readonly IShoppingService _shoppingService;
        private Mock<IShoppingRepository> _mockShoppingRepository;
        private Mock<IProductSorter> _mockProductSorter;
        private Mock<ITrolleyTotalCalculator> _mockTrolleyTotalCalculator;

        public ShoppingServiceTests()
        {
            var mockLogger = new Mock<ILogger<ShoppingService>>();
            _mockShoppingRepository = new Mock<IShoppingRepository>();
            _mockProductSorter = new Mock<IProductSorter>();
            _mockTrolleyTotalCalculator = new Mock<ITrolleyTotalCalculator>();

            _shoppingService = new ShoppingService(mockLogger.Object, _mockShoppingRepository.Object, _mockProductSorter.Object, _mockTrolleyTotalCalculator.Object);
        }

        [Fact]
        public async Task GetShoppingUserAsync_Simple_Test()
        {
            //1. Arrange
            //2. Act
            var shoppingUser = await _shoppingService.GetShoppingUserAsync();

            //3. Assert
            Assert.NotNull(shoppingUser);
            Assert.Equal("Karthikumar Subramanian", shoppingUser.Name);
            Assert.Equal("f65aa6e5-8cde-4f35-a45b-3ea218d391c8", shoppingUser.Token);
        }

        // more tests to add...
    }
}