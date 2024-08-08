using _06_08_2024.Models;
using _06_08_2024.Services;

namespace _06_08_2024
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ProductService productService = new ProductService();
            CategoryService categoryService = new CategoryService();

            Category category = new Category()
            {
                Name = "TestCategory",
            };

            Product product = new Product()
            {
                Name = "TestProduct",
                CategoryId = 1
            };

            await categoryService.CreateAsync(category);
            await productService.CreateAsync(product);

        }
    }
}
