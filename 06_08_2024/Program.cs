using _06_08_2024.Models;
using _06_08_2024.Services;

namespace _06_08_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
          StudentService studentService = new StudentService();
          List<Student> students = new List<Student>();

            Student student = new Student()
            {
                FirstName = "Gunel",
                LastName = "Gunelova",
                Grade = 100
            };

            students.Add(student);

            studentService.CreateAsync(student);
        }
    }
}
