using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniStoreApi.Data;
using MiniStoreApi.Models;
using MiniStoreApi.Services;
using Xunit;

namespace MiniStoreApi.Tests.Services
{
    public class ProductServiceTests : IDisposable
    {
        private readonly StoreContext _context;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique DB for each test
                .Options;

            _context = new StoreContext(options);
            _service = new ProductService(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task CreateAsync_AddsProductToDatabase()
        {
            // Arrange
            var product = new Product { Name = "Test Product", Price = 99.99m };

            // Act
            var result = await _service.CreateAsync(product);

            // Assert
            Assert.NotEqual(0, result.Id);
            Assert.Equal(1, await _context.Products.CountAsync());
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllProducts()
        {
            // Arrange
            _context.Products.Add(new Product { Name = "P1", Price = 10 });
            _context.Products.Add(new Product { Name = "P2", Price = 20 });
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }
        
        [Fact]
        public async Task DeleteAsync_RemovesProduct_WhenItExists()
        {
            // Arrange
            var product = new Product { Name = "To Delete", Price = 50 };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            
            // Act
            var result = await _service.DeleteAsync(product.Id);
            
            // Assert
            Assert.True(result);
            Assert.Equal(0, await _context.Products.CountAsync());
        }
    }
}
