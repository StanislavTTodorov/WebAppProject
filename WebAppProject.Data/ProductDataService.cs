using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Task<List<ProductModel>> GetProducts()
        {
            string sql = "select * from dbo.Products";

            return this.db.LoadData<ProductModel, dynamic>(sql, new { });
        }

        public Task InsertProduct(ProductModel product)
        {

            string sql = @"INSERT INTO [Products]([Id],[Name],[Price],[DateAdded])
                              VALUES (@Id,@Name,@Price,@DateAdded)";

            return this.db.SaveData(sql, product);

        }
    }
}
