namespace DependencyInjection.Exercise_4;

public interface IProductRepository
{
    List<string> GetAllProducts();
    void AddProduct(string name);
}