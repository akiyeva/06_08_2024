using _06_08_2024.Contexts;
using _06_08_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace _06_08_2024.Services
{
    public class StudentService
    {
        AppDbContext _context = new AppDbContext();
        public async Task CreateAsync(Student student)
        {
            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Student>> GetAllAsync()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
            {
                throw new Exception("Student not found.");
            }
            return student;
        }

        public async Task Update(int id)
        {
            var student = await GetByIdAsync(id);
            _context.Students.Update(student);
        }

        public async Task DeleteAsync(int id)
        {
            var student = await GetByIdAsync(id);
            _context.Students.Remove(student);
        }


    }
}
