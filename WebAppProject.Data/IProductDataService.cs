using WebAppProject.Data.Models;

namespace WebAppProject.Data
{
    public interface IProductDataService
    {
        Task<List<ProductModel>> GetProducts();
        Task InsertPerson(ProductModel product);
    }
}