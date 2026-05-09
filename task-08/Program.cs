using System;
using RepositoryPatternApp.Interfaces;
using RepositoryPatternApp.Models;
using RepositoryPatternApp.Repositories;

namespace RepositoryPatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generic Repository Pattern Demo\n");

            IRepository<Product> productRepo = new InMemoryRepository<Product>();

            // --- 1. CREATE (Add) ---
            Console.WriteLine("--- Adding Products ---");
            productRepo.Add(new Product { Id = 1, Name = "Laptop", Price = 1200.00m });
            productRepo.Add(new Product { Id = 2, Name = "Smartphone", Price = 800.00m });
            productRepo.Add(new Product { Id = 3, Name = "Headphones", Price = 150.00m });
            
            PrintAllProducts(productRepo);

            // --- 2. READ (Get) ---
            Console.WriteLine("\n--- Getting Product with ID 2 ---");
            var product2 = productRepo.Get(2);
            if (product2 != null)
            {
                Console.WriteLine($"Found: {product2}");
            }

            // --- 3. UPDATE ---
            Console.WriteLine("\n--- Updating Product with ID 1 ---");
            var productToUpdate = productRepo.Get(1);
            if (productToUpdate != null)
            {
                productToUpdate.Price = 1050.00m; // Sale price
                productToUpdate.Name = "Laptop (On Sale)";
                productRepo.Update(productToUpdate);
            }
            PrintAllProducts(productRepo);

            // --- 4. DELETE ---
            Console.WriteLine("\n--- Deleting Product with ID 3 ---");
            productRepo.Delete(3);
            PrintAllProducts(productRepo);
            
            Console.WriteLine("\nDemo completed.");
        }

        static void PrintAllProducts(IRepository<Product> repo)
        {
            Console.WriteLine("Current Products in Repository:");
            var allProducts = repo.GetAll();
            int count = 0;
            foreach (var p in allProducts)
            {
                Console.WriteLine("  " + p.ToString());
                count++;
            }
            if(count == 0) Console.WriteLine("  (No products found)");
        }
    }
}
