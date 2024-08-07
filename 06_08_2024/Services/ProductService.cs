using _06_08_2024.Contexts;
using _06_08_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace _06_08_2024.Services
{
    public class ProductService
    {
        AppDbContext _context = new AppDbContext();
        public async Task CreateAsync(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Product>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(s => s.Id == id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }
            return product;
        }

        public async Task Update(int id)
        {
            var product = await GetByIdAsync(id);
            _context.Products.Update(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            _context.Products.Remove(product);
        }


    }
}
