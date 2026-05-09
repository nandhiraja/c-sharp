using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniStoreApi.Data;
using MiniStoreApi.Models;

namespace MiniStoreApi.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreContext _context;

        public ProductService(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null) return null;

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null) return false;

            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
