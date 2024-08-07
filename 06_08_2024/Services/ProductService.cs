using _06_08_2024.Contexts;
using _06_08_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace _06_08_2024.Services
{
    public class ProductService
    {
        private AppDbContext _context;
        public ProductService()
        {
            _context = new AppDbContext();
        }
        public async Task CreateAsync(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Product>> GetAllAsync()
        {
            var products = await _context.Products.Include(x => x.Category).ToListAsync();
            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(s => s.Id == id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }
            return product;
        }

        public async Task Update(Product product)
        {
            var dbProduct = await GetByIdAsync(product.Id);
            
            dbProduct.Name = product.Name;
            dbProduct.Category.Name = product.Category.Name;
           // _context.Products.Update(product);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            _context.Products.Remove(product);
        }


    }
}
