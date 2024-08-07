using _06_08_2024.Contexts;
using _06_08_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace _06_08_2024.Services
{
    public class CategoryService
    {
        AppDbContext _context = new AppDbContext();
        public async Task CreateAsync(Category category)
        {
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

        public async Task Update(int id)
        {
            var category = await GetByIdAsync(id);
            _context.Categories.Update(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);
            _context.Categories.Remove(category);
        }


    }
}
}
