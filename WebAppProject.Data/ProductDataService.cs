using WebAppProject.Data.Models;

namespace WebAppProject.Data
{
    public class ProductDataService : IProductDataService
    {
        private readonly ISqlDbAccessService db;

        public ProductDataService(ISqlDbAccessService db)
        {
            this.db = db;
        }

        public Task DeleteProduct(ProductModel product)
        {
            string sql = @"DELETE FROM [Products]
		                    WHERE Id = @Id";

            return this.db.SaveData(sql, product);
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            string sql = "SELECT * FROM [Products]";

            return await this.db.LoadData<ProductModel, dynamic>(sql, new { });
        }

        public  Task InsertProduct(ProductModel product)
        {

            string sql = @"INSERT INTO  [Products]([Id]
                                       ,[Name],[Price]
                                       ,[DateAdded])
                                VALUES (@Id,@Name,@Price,@DateAdded)";

            return  this.db.SaveData(sql, product);

        }

        public Task UpdateProduct(ProductModel product)
        {
            string sql = @"UPDATE Products
	                          SET  [Name] = @Name
                                  ,[Price] = @Price
                                  ,[DateAdded] = @DateAdded
		                    WHERE Id = @Id";

            return this.db.SaveData(sql, product);
        }
    }
}
