using _06_08_2024.Contexts;
using _06_08_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace _06_08_2024.Services
{
    public class CategoryService
    {
        private AppDbContext _context;
        public CategoryService()
        {
            _context = new AppDbContext();
        }
        public async Task CreateAsync(Category category)
        {
            var isExist = await _context.Categories.AnyAsync(x => x.Name.ToLower() == category.Name.ToLower());
            if (isExist)
            {
                Console.WriteLine("Bu category artiq movcuddur");
                return;
            }
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Category>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (category == null)
            {
                throw new Exception("Product not found.");
            }
            return category;
        }

        public async Task Update(Category category)
        {
            var existCategory = await GetByIdAsync(category.Id);

            var isExist = await _context.Categories.AnyAsync(x => x.Name.ToLower() == category.Name.ToLower());
            if (isExist)
            {
                Console.WriteLine("Bu category artiq movcuddur");
                return;
            }

            existCategory.Name = category.Name;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }


    }
}

