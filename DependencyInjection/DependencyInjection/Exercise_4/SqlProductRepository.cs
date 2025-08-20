namespace DependencyInjection.Exercise_4;

public class SqlProductRepository : IProductRepository
{
    private readonly List<string> _simulatedDatabase;

    public SqlProductRepository()
    {
        _simulatedDatabase = new List<string>
        {
            "Phone",
            "Tablet",
            "Headphones"
        };
    }

    public List<string> GetAllProducts()
    {
        Console.WriteLine("SQL: Connecting to database...");
        Thread.Sleep(300);
        Console.WriteLine("SQL: Executing SELECT * FROM Products");
        Console.WriteLine("SQL: Query executed successfully");
        return new List<string>(_simulatedDatabase);
    }

    public void AddProduct(string name)
    {
        Console.WriteLine("SQL: Connecting to database...");
        Thread.Sleep(200);
        Console.WriteLine($"SQL: Executing INSERT INTO Products (Name) VALUES ('{name}')");
        _simulatedDatabase.Add(name);
        Thread.Sleep(100);
        Console.WriteLine("SQL: Product inserted successfully");
        Console.WriteLine("SQL: Connection closed");
    }
}