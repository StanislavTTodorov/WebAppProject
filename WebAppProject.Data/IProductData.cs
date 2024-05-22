using WebAppProject.Data.Models;

namespace WebAppProject.Data
{
    public interface IProductData
    {
        Task<List<ProductModel>> GetProducts();
        Task InsertPerson(ProductModel product);
    }
}