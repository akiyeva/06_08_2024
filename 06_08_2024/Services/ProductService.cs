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
            var isExist = await _context.Products.AnyAsync(x => x.Name.ToLower() == product.Name.ToLower());
            if (isExist)
            {
                Console.WriteLine("Bu product artiq movcuddur");
                return;
            }
            var isExistCategory = await _context.Categories.AnyAsync(x => x.Id == product.CategoryId);
            if (!isExistCategory)
            {
                Console.WriteLine("Category tapilmadi");
                return;
            }
            if (product.Price < 0)
            {
                Console.WriteLine("Price 0 dan kicik ola bilmez");
                return;
            }

            product.Id = 0;

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
