using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniStoreApi.Controllers;
using MiniStoreApi.Models;
using MiniStoreApi.Services;
using Moq;
using Xunit;

namespace MiniStoreApi.Tests.Controllers
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _mockService;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _mockService = new Mock<IProductService>();
            _controller = new ProductsController(_mockService.Object);
        }

        [Fact]
        public async Task GetProducts_ReturnsOkResult_WithListOfProducts()
        {
            // Arrange
            var mockProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Test Product 1", Price = 100 },
                new Product { Id = 2, Name = "Test Product 2", Price = 200 }
            };
            _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(mockProducts);

            // Act
            var result = await _controller.GetProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public async Task GetProduct_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            _mockService.Setup(s => s.GetByIdAsync(99)).ReturnsAsync((Product?)null);

            // Act
            var result = await _controller.GetProduct(99);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
        
        [Fact]
        public async Task PostProduct_ReturnsCreatedAtAction()
        {
            // Arrange
            var newProduct = new Product { Name = "New Product", Price = 150 };
            var createdProduct = new Product { Id = 3, Name = "New Product", Price = 150 };
            
            _mockService.Setup(s => s.CreateAsync(newProduct)).ReturnsAsync(createdProduct);

            // Act
            var result = await _controller.PostProduct(newProduct);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal("GetProduct", createdAtActionResult.ActionName);
            var returnValue = Assert.IsType<Product>(createdAtActionResult.Value);
            Assert.Equal(3, returnValue.Id);
        }
    }
}
