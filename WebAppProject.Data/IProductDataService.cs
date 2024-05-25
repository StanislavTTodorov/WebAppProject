using WebAppProject.Data.Models;

namespace WebAppProject.Data
{
    public interface IProductDataService
    {
        Task<List<ProductModel>> GetProducts();
        Task InsertProduct(ProductModel product);
        Task UpdateProduct(ProductModel product);
        Task DeleteProduct(ProductModel product);
    }
}