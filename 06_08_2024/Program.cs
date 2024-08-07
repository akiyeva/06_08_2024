using _06_08_2024.Models;
using _06_08_2024.Services;

namespace _06_08_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
          
            Category category = new Category()
            {
                Name = "TestCategory",
            };

            Product product = new Product()
            {
                Name = "TestProduct",
                CategoryId =1
            };

            productService.CreateAsync(product);

        }
    }
}
