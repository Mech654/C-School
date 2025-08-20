namespace DependencyInjection.Exercise_4;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<string> _products;

    public InMemoryProductRepository()
    {
        _products = new List<string>
        {
            "Laptop",
            "Mouse",
            "Keyboard"
        };
    }

    public List<string> GetAllProducts()
    {
        Console.WriteLine("InMemory: Retrieving products from memory...");
        return new List<string>(_products);
    }

    public void AddProduct(string name)
    {
        Console.WriteLine($"InMemory: Adding product '{name}' to memory");
        _products.Add(name);
        Console.WriteLine("InMemory: Product added successfully");
    }
}