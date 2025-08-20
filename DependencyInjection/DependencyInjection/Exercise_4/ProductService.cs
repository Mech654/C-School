namespace DependencyInjection.Exercise_4;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void DisplayAllProducts()
    {
        Console.WriteLine("=== Product List ===");
        var products = _productRepository.GetAllProducts();

        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
        }
        else
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]}");
            }
        }
        Console.WriteLine("====================");
    }

    public void AddNewProduct(string productName)
    {
        Console.WriteLine($"Adding new product: {productName}");
        _productRepository.AddProduct(productName);
        Console.WriteLine("Product added to catalog!");
    }

    public int GetProductCount()
    {
        var products = _productRepository.GetAllProducts();
        return products.Count;
    }
}